import { Component, Self } from '@angular/core';
import { NgForm } from '@angular/forms';

import {
  EditIncludeHandler,
  Node,
  CreateOrEditPullHandler,
  Pull,
  IPullResult,
  PostCreatePullHandler,
} from '@allors/system/workspace/domain';
import {
  BasePrice,
  InternalOrganisation,
} from '@allors/default/workspace/domain';
import { M } from '@allors/default/workspace/meta';
import {
  ErrorService,
  AllorsFormComponent,
} from '@allors/base/workspace/angular/foundation';
import { ContextService } from '@allors/base/workspace/angular/foundation';

import { FetcherService } from '../../../services/fetcher/fetcher-service';
import { InternalOrganisationId } from '../../../services/state/internal-organisation-id';

@Component({
  templateUrl: './customerrelationship-form.component.html',
  providers: [ContextService],
})
export class CustomerRelationshipFormComponent implements OnInit, OnDestroy {
  readonly m: M;

  partyRelationship: CustomerRelationship;
  internalOrganisation: InternalOrganisation;
  party: Party;
  title: string;

  private subscription: Subscription;

  constructor(
    @Self() public allors: ContextService,
    @Inject(MAT_DIALOG_DATA) public data: ObjectData,
    public dialogRef: MatDialogRef<CustomerRelationshipFormComponent>,
    public refreshService: RefreshService,
    private errorService: ErrorService,
    private fetcher: FetcherService,
    private internalOrganisationId: InternalOrganisationId
  ) {
    this.allors.context.name = this.constructor.name;
    this.m = this.allors.context.configuration.metaPopulation as M;
  }

  public ngOnInit(): void {
    const m = this.m;
    const { pullBuilder: pull } = m;
    const x = {};

    this.subscription = combineLatest([
      this.refreshService.refresh$,
      this.internalOrganisationId.observable$,
    ])
      .pipe(
        switchMap(() => {
          const isCreate = this.data.id == null;

          const pulls = [this.fetcher.internalOrganisation];

          if (!isCreate) {
            pulls.push(
              pull.CustomerRelationship({
                objectId: this.data.id,
                include: {
                  InternalOrganisation: x,
                },
              })
            );
          }

          if (isCreate && this.data.associationId) {
            pulls.push(
              pull.Party({
                objectId: this.data.associationId,
              })
            );
          }

          return this.allors.context
            .pull(pulls)
            .pipe(map((loaded) => ({ loaded, isCreate })));
        })
      )
      .subscribe(({ loaded, isCreate }) => {
        this.allors.context.reset();

        this.internalOrganisation =
          this.fetcher.getInternalOrganisation(loaded);
        this.party = loaded.object<Party>(m.Party);

        if (isCreate) {
          this.title = 'Add Customer Relationship';

          this.partyRelationship =
            this.allors.context.create<CustomerRelationship>(
              m.CustomerRelationship
            );
          this.partyRelationship.FromDate = new Date();
          this.partyRelationship.Customer = this.party;
          this.partyRelationship.InternalOrganisation =
            this.internalOrganisation;
        } else {
          this.partyRelationship = loaded.object<CustomerRelationship>(
            m.CustomerRelationship
          );

          if (this.partyRelationship.canWriteFromDate) {
            this.title = 'Edit Customer Relationship';
          } else {
            this.title = 'View Customer Relationship';
          }
        }
      });
  }

  public ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  public save(): void {
    this.allors.context.push().subscribe(() => {
      this.dialogRef.close(this.partyRelationship);
      this.refreshService.refresh();
    }, this.errorService.errorHandler);
  }
}
