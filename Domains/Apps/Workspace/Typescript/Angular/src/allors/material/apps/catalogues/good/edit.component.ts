import { AfterViewInit, ChangeDetectorRef, Component, OnDestroy, OnInit } from "@angular/core";
import { Validators } from "@angular/forms";
import { MdNativeDateModule, MdSnackBar, MdSnackBarConfig } from "@angular/material";
import { ActivatedRoute } from "@angular/router";
import { TdMediaService } from "@covalent/core";
import { Observable, Subject, Subscription } from "rxjs/Rx";

import { AllorsService, ErrorService, Filter, Loaded, Saved, Scope } from "../../../../angular";
import { Contains, Equals, Fetch, Like, Page, Path, PullRequest, PushResponse, Query, Sort, TreeNode } from "../../../../domain";
import { Good, InventoryItemVariance, Locale, LocalisedText, NonSerializedInventoryItem, Organisation, OrganisationRole, ProductCategory, ProductCharacteristic, ProductCharacteristicValue, ProductType, Singleton, VarianceReason } from "../../../../domain";
import { MetaDomain } from "../../../../meta/index";

@Component({
  templateUrl: "./edit.component.html",
})
export class GoodEditComponent implements OnInit, AfterViewInit, OnDestroy {

  private subscription: Subscription;
  private scope: Scope;

  m: MetaDomain;

  good: Good;

  title: string;
  singleton: Singleton;
  locales: Locale[];
  selectedLocaleName: string;
  categories: ProductCategory[];
  productTypes: ProductType[];
  productCharacteristicValues: ProductCharacteristicValue[];
  manufacturers: Organisation[];
  varianceReasons: VarianceReason[];
  inventoryItem: NonSerializedInventoryItem;
  actualQuantityOnHand: number;

  manufacturersFilter: Filter;

  constructor(
    private allors: AllorsService,
    private errorService: ErrorService,
    private route: ActivatedRoute,
    public media: TdMediaService, private changeDetectorRef: ChangeDetectorRef) {

    this.scope = new Scope(allors.database, allors.workspace);
    this.m = this.allors.meta;
    this.manufacturersFilter = new Filter(this.scope, this.m.Organisation, [this.m.Organisation.Name]);
  }

  get locale(): Locale {
    return this.locales.find((v: Locale) => v.Name === this.selectedLocaleName);
  }

  ngOnInit(): void {
    this.subscription = this.route.url
      .switchMap((url: any) => {

        const id: string = this.route.snapshot.paramMap.get("id");
        const m: MetaDomain = this.m;

        const fetch: Fetch[] = [
          new Fetch({
            name: "good",
            id,
            include: [
              new TreeNode({ roleType: m.Good.PrimaryPhoto }),
              new TreeNode({ roleType: m.Product.LocalisedNames }),
              new TreeNode({ roleType: m.Product.LocalisedDescriptions }),
              new TreeNode({ roleType: m.Product.LocalisedComments }),
              new TreeNode({ roleType: m.Product.ProductCategories }),
              new TreeNode({ roleType: m.Good.ManufacturedBy }),
              new TreeNode({
                roleType: m.Good.ProductType,
                nodes: [
                  new TreeNode({
                    roleType: m.ProductType.ProductCharacteristics,
                    nodes: [new TreeNode({ roleType: m.ProductCharacteristic.LocalisedNames })],
                  }),
                ],
              }),
              new TreeNode({
                roleType: m.Product.ProductCharacteristicValues,
                nodes: [
                  new TreeNode({ roleType: m.ProductCharacteristicValue.ProductCharacteristic }),
                ],
              }),
            ],
          }),
        ];

        const query: Query[] = [
          new Query(
            {
              name: "singletons",
              objectType: this.m.Singleton,
              include: [
                new TreeNode({
                  roleType: m.Singleton.Locales,
                  nodes: [
                    new TreeNode({ roleType: m.Locale.Language }),
                    new TreeNode({ roleType: m.Locale.Country }),
                  ],
                }),
              ],
            }),
          new Query(
            {
              name: "organisationRoles",
              objectType: this.m.OrganisationRole,
            }),
          new Query(
            {
              name: "categories",
              objectType: this.m.ProductCategory,
            }),
          new Query(
            {
              name: "productTypes",
              objectType: this.m.ProductType,
            }),
          new Query(
            {
              name: "varianceReasons",
              objectType: this.m.VarianceReason,
            }),
        ];

        this.scope.session.reset();

        return this.scope
          .load("Pull", new PullRequest({ fetch, query }))
          .switchMap((loaded: Loaded) => {

            this.good = loaded.objects.good as Good;
            if (!this.good) {
              this.good = this.scope.session.create("Good") as Good;
            }

            this.title = this.good.Name;
            this.actualQuantityOnHand = this.good.QuantityOnHand;
            this.categories = loaded.collections.categories as ProductCategory[];
            this.productTypes = loaded.collections.productTypes as ProductType[];
            this.varianceReasons = loaded.collections.varianceReasons as VarianceReason[];
            this.singleton = loaded.collections.singletons[0] as Singleton;
            this.locales = this.singleton.Locales;
            this.selectedLocaleName = this.singleton.DefaultLocale.Name;

            this.setProductCharacteristicValues();

            const organisationRoles: OrganisationRole[] = loaded.collections.organisationRoles as OrganisationRole[];
            const manufacturerRole: OrganisationRole = organisationRoles.find((v: OrganisationRole) => v.Name === "Manufacturer");

            const manufacturersQuery: Query[] = [
              new Query(
                {
                  name: "manufacturers",
                  objectType: m.Organisation,
                  predicate: new Contains({ roleType: m.Organisation.OrganisationRoles, object: manufacturerRole }),
                }),
              new Query(
                {
                  include: [new TreeNode({ roleType: m.NonSerializedInventoryItem.InventoryItemVariances })],
                  name: "inventoryItems",
                  objectType: m.NonSerializedInventoryItem,
                  predicate: new Equals({ roleType: m.NonSerializedInventoryItem.Good, value: this.good }),
                }),
            ];

            return this.scope.load("Pull", new PullRequest({ query: manufacturersQuery }));
          });
      })
      .subscribe((loaded: Loaded) => {
        this.manufacturers = loaded.collections.manufacturers as Organisation[];
        this.inventoryItem = loaded.collections.inventoryItems[0] as NonSerializedInventoryItem;
      },
      (error: any) => {
        this.errorService.message(error);
        this.goBack();
      },
    );
  }

  ngAfterViewInit(): void {
    this.media.broadcast();
    this.changeDetectorRef.detectChanges();
  }

  ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  save(): void {
    if (this.actualQuantityOnHand !== this.good.QuantityOnHand) {
      const reason = this.varianceReasons.find((v: VarianceReason) => v.Name === "Unknown");

      const inventoryItemVariance = this.scope.session.create("InventoryItemVariance") as InventoryItemVariance;
      inventoryItemVariance.Quantity = this.actualQuantityOnHand - this.good.QuantityOnHand;
      inventoryItemVariance.Reason = reason;

      this.inventoryItem.AddInventoryItemVariance(inventoryItemVariance);
    }

    this.scope
      .save()
      .subscribe((saved: Saved) => {
        this.goBack();
      },
      (error: Error) => {
        this.errorService.dialog(error);
      });
  }

  goBack(): void {
    window.history.back();
  }

  localisedName(productCharacteristic: ProductCharacteristic): string {
    const localisedText: LocalisedText = productCharacteristic.LocalisedNames.find((v: LocalisedText) => v.Locale === this.locale);
    if (localisedText) {
      return localisedText.Text;
    }

    return productCharacteristic.Name;
  }

  setProductCharacteristicValues(): void {
    this.productCharacteristicValues = this.good.ProductCharacteristicValues.filter((v: ProductCharacteristicValue) => v.Locale === this.locale);
  }
}
