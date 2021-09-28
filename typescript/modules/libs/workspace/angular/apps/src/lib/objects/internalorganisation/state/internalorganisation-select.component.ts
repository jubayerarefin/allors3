import { Component, Self, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';

import { MetaService, SessionService } from '@allors/angular/services/core';
import { Organisation } from '@allors/domain/generated';
import { InternalOrganisationId } from '@allors/angular/base';
import { Sort, Equals } from '@allors/data/system';
import { PullRequest } from '@allors/protocol/system';


@Component({
  // tslint:disable-next-line:component-selector
  selector: 'internalorganisation-select',
  templateUrl: './internalorganisation-select.component.html',
  providers: [SessionService]
})
export class SelectInternalOrganisationComponent implements OnInit, OnDestroy {

  public get internalOrganisation() {
    const internalOrganisation = this.internalOrganisations.find(v => v.id === this.internalOrganisationId.value);
    return internalOrganisation;
  }

  public set internalOrganisation(value: Organisation) {
    this.internalOrganisationId.value = value.id;
  }

  public internalOrganisations: Organisation[];

  private subscription: Subscription;

  constructor(
    @Self() public allors: SessionService,
    
    private internalOrganisationId: InternalOrganisationId,
  ) { }

  ngOnInit(): void {

    const { m, pull } = this.metaService;

    const pulls = [
      pull.Organisation(
        {
          predicate: { kind: 'Equals', propertyType: m.Organisation.IsInternalOrganisation, value: true },
          sorting: [{ roleType: m.Organisation.PartyName }]
        }
      )
    ];

    this.subscription = this.allors.client.pullReactive(this.allors.session, pulls)
      .subscribe((loaded) => {
        this.internalOrganisations = loaded.collection<Organisation>(m.Organisation);
      });
  }

  ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

}
