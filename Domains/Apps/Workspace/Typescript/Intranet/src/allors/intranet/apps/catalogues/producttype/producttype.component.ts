import { AfterViewInit, ChangeDetectorRef, Component, OnDestroy , OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { TdMediaService } from "@covalent/core";
import { Subscription } from "rxjs/Rx";

import { AllorsService, ErrorService, Loaded, Saved, Scope } from "@allors";
import { Fetch, PullRequest, Query, TreeNode } from "@allors";
import { ProductCharacteristic, ProductType } from "@allors";
import { MetaDomain } from "@allors";

@Component({
  templateUrl: "./producttype.component.html",
})
export class ProductTypeComponent implements OnInit, AfterViewInit, OnDestroy {

  public title: string = "Edit Product Type";
  public subTitle: string;

  public m: MetaDomain;

  public productType: ProductType;

  public characteristics: ProductCharacteristic[];

  private subscription: Subscription;
  private scope: Scope;

  constructor(
    private allors: AllorsService,
    private errorService: ErrorService,
    private route: ActivatedRoute,
    public media: TdMediaService, private changeDetectorRef: ChangeDetectorRef) {

    this.scope = new Scope(allors.database, allors.workspace);
    this.m = this.allors.meta;
  }

  public ngOnInit(): void {
    this.subscription = this.route.url
      .switchMap((url: any) => {

        const id: string = this.route.snapshot.paramMap.get("id");
        const m: MetaDomain = this.m;

        const fetch: Fetch[] = [
          new Fetch({
            name: "productType",
            id,
            include: [
              new TreeNode({ roleType: m.ProductType.ProductCharacteristics }),
            ],
          }),
        ];

        const query: Query[] = [
          new Query(
            {
              name: "characteristics",
              objectType: this.m.ProductCharacteristic,
            }),
        ];

        this.scope.session.reset();

        return this.scope
          .load("Pull", new PullRequest({ fetch, query }));
      })
      .subscribe((loaded: Loaded) => {

        this.productType = loaded.objects.productType as ProductType;
        if (!this.productType) {
          this.productType = this.scope.session.create("ProductType") as ProductType;
        }

        this.characteristics = loaded.collections.characteristics as ProductCharacteristic[];
      },
      (error: any) => {
        this.errorService.message(error);
        this.goBack();
      },
    );
  }

  public ngAfterViewInit(): void {
    this.media.broadcast();
    this.changeDetectorRef.detectChanges();
  }

  public ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  public save(): void {

    this.scope
      .save()
      .subscribe((saved: Saved) => {
        this.goBack();
      },
      (error: Error) => {
        this.errorService.dialog(error);
      });
  }

  public goBack(): void {
    window.history.back();
  }
}
