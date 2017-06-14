import { Observable, Subject, Subscription } from 'rxjs/Rx';
import { Component, OnInit, AfterViewInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MdSnackBar, MdSnackBarConfig } from '@angular/material';
import { TdMediaService } from '@covalent/core';

import { MetaDomain } from '../../../../allors/meta';
import { PullRequest, Fetch, Path, Query, Equals, Like, TreeNode, Sort, Page } from '../../../../allors/domain';
import { CommunicationEvent, Organisation, Locale } from '../../../../allors/domain';
import { Scope } from '../../../../allors/angular';
import { AllorsService } from '../../../allors.service';

@Component({
  templateUrl: './organisation-overview.component.html',
})
export class OrganisationOverviewComponent implements OnInit, AfterViewInit, OnDestroy {

  private subscription: Subscription;
  private scope: Scope;

  private communicationEvents: CommunicationEvent[];

  private organisation: Organisation;
  id: string;

  constructor(private allors: AllorsService,
    private route: ActivatedRoute,
    public snackBar: MdSnackBar,
    public media: TdMediaService) {
    this.scope = new Scope(allors.database, allors.workspace);
  }

  ngOnInit(): void {

    this.subscription = this.route.url
      .mergeMap((url: any) => {

        this.id = this.route.snapshot.paramMap.get('id');

        const m: MetaDomain = this.allors.meta;

        const fetch: Fetch[] = [
          new Fetch({
            name: 'organisation',
            id: this.id,
            include: [
              new TreeNode({
                roleType: m.Party.CurrentContacts,
                nodes: [
                  new TreeNode({
                    roleType: m.Person.PartyContactMechanisms,
                    nodes: [
                      new TreeNode({ roleType: m.PartyContactMechanism.ContactPurposes }),
                      new TreeNode({ roleType: m.PartyContactMechanism.ContactMechanism }),
                    ],
                  }),
                ],
              }),
              new TreeNode({
                roleType: m.Party.CurrentOrganisationContactRelationships,
                nodes: [
                  new TreeNode({ roleType: m.OrganisationContactRelationship.ContactKinds }),
                  new TreeNode({ roleType: m.OrganisationContactRelationship.Contact }),
                ],
              }),
              new TreeNode({
                roleType: m.Party.InactiveOrganisationContactRelationships,
                nodes: [
                  new TreeNode({ roleType: m.OrganisationContactRelationship.ContactKinds }),
                  new TreeNode({ roleType: m.OrganisationContactRelationship.Contact }),
                ],
              }),
              new TreeNode({
                roleType: m.Party.PartyContactMechanisms,
                nodes: [
                  new TreeNode({ roleType: m.PartyContactMechanism.ContactPurposes }),
                  new TreeNode({ roleType: m.PartyContactMechanism.ContactMechanism }),
                ],
              }),
              new TreeNode({
                roleType: m.Party.CurrentPartyContactMechanisms,
                nodes: [
                  new TreeNode({ roleType: m.PartyContactMechanism.ContactPurposes }),
                  new TreeNode({ roleType: m.PartyContactMechanism.ContactMechanism }),
                ],
              }),
              new TreeNode({
                roleType: m.Party.InactivePartyContactMechanisms,
                nodes: [
                  new TreeNode({ roleType: m.PartyContactMechanism.ContactPurposes }),
                  new TreeNode({ roleType: m.PartyContactMechanism.ContactMechanism }),
                ],
              }),
              new TreeNode({
                roleType: m.Organisation.GeneralCorrespondence,
                nodes: [
                  new TreeNode({
                    roleType: m.PostalAddress.PostalBoundary,
                    nodes: [
                      new TreeNode({ roleType: m.PostalBoundary.Country }),
                    ],
                  }),
                ],
              }),
            ],
          }),
          new Fetch({
            name: 'communicationEvents',
            id: this.id,
            path: new Path({ step: m.Organisation.CommunicationEventsWhereInvolvedParty }),
          }),
        ];

        const query: Query[] = [
          new Query(
            {
              name: 'countries',
              objectType: m.Country,
            }),
          new Query(
            {
              name: 'genders',
              objectType: m.GenderType,
            }),
          new Query(
            {
              name: 'salutations',
              objectType: m.Salutation,
            }),
          new Query(
            {
              name: 'organisationContactKinds',
              objectType: m.OrganisationContactKind,
            }),
          new Query(
            {
              name: 'contactMechanismPurposes',
              objectType: m.ContactMechanismPurpose,
            }),
          new Query(
            {
              name: 'internalOrganisation',
              objectType: m.InternalOrganisation,
            }),
        ];

        this.scope.session.reset();

        return this.scope
          .load('Pull', new PullRequest({ fetch: fetch, query: query }));
      })
      .subscribe(() => {
        this.organisation = this.scope.objects.organisation as Organisation;
        this.communicationEvents = this.scope.collections.communicationEvents as CommunicationEvent[];
      },
      (error: any) => {
        this.snackBar.open(error, 'close', { duration: 5000 });
        this.goBack();
      },
      );
  }

  ngAfterViewInit(): void {
    this.media.broadcast();
  }

  ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  goBack(): void {
    window.history.back();
  }

  checkType(obj: any): string {
    return obj.objectType.name;
  }
}
