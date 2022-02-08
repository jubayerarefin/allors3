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
  WorkEffortFixedAssetAssignment,
} from '@allors/default/workspace/domain';
import { M } from '@allors/default/workspace/meta';
import {
  ErrorService,
  AllorsFormComponent,
} from '@allors/base/workspace/angular/foundation';
import { ContextService } from '@allors/base/workspace/angular/foundation';

import { InternalOrganisationId } from '../../../services/state/internal-organisation-id';
import { Filters } from '../../../filters/filters';

@Component({
  templateUrl: './workeffortfixedassetassignment-form.component.html',
  providers: [ContextService],
})
export class WorkEffortFixedAssetAssignmentFormComponent
  extends AllorsFormComponent<WorkEffortFixedAssetAssignment>
  implements CreateOrEditPullHandler, EditIncludeHandler, PostCreatePullHandler
{
  readonly m: M;

  workEffortFixedAssetAssignment: WorkEffortFixedAssetAssignment;
  workEffort: WorkEffort;
  assignment: WorkEffort;
  serialisedItem: SerialisedItem;
  assetAssignmentStatuses: Enumeration[];
  title: string;

  private subscription: Subscription;
  serialisedItems: SerialisedItem[];
  externalCustomer: boolean;

  serialisedItemsFilter: SearchFactory;
  workEfforts: WorkEffort[];

  constructor(
    @Self() public allors: ContextService,
    errorService: ErrorService,
    form: NgForm,
    private internalOrganisationId: InternalOrganisationId
  ) {
    super(allors, errorService, form);
  }

  public ngOnInit(): void {
    const m = this.m;
    const { pullBuilder: pull } = m;
    const x = {};

    this.subscription = combineLatest(
      this.refreshService.refresh$,
      this.internalOrganisationId.observable$
    )
      .pipe(
        switchMap(() => {
          const isCreate = this.data.id == null;

          const pulls = [
            pull.WorkEffort({
              sorting: [{ roleType: m.WorkEffort.Name }],
            }),
            pull.SerialisedItem({
              objectId: this.data.associationId,
              sorting: [{ roleType: m.SerialisedItem.Name }],
            }),
            pull.AssetAssignmentStatus({
              predicate: {
                kind: 'Equals',
                propertyType: m.AssetAssignmentStatus.IsActive,
                value: true,
              },
              sorting: [{ roleType: m.AssetAssignmentStatus.Name }],
            }),
          ];

          if (!isCreate) {
            pulls.push(
              pull.WorkEffortFixedAssetAssignment({
                objectId: this.data.id,
                include: {
                  Assignment: x,
                  FixedAsset: x,
                  AssetAssignmentStatus: x,
                },
              })
            );
          }

          if (isCreate && this.data.associationId) {
            pulls.push(
              pull.WorkEffort({
                objectId: this.data.associationId,
                include: { Customer: x },
              })
            );
          }

          this.serialisedItemsFilter = Filters.serialisedItemsFilter(m);

          return this.allors.context
            .pull(pulls)
            .pipe(map((loaded) => ({ loaded, isCreate })));
        })
      )
      .subscribe(({ loaded, isCreate }) => {
        this.allors.context.reset();

        this.workEffort = loaded.object<WorkEffort>(m.WorkEffort);
        this.workEfforts = loaded.collection<WorkEffort>(m.WorkEffort);
        this.serialisedItem = loaded.object<SerialisedItem>(m.SerialisedItem);
        this.assetAssignmentStatuses = loaded.collection<AssetAssignmentStatus>(
          m.AssetAssignmentStatus
        );

        if (this.serialisedItem == null) {
          const b2bCustomer = this.workEffort.Customer as Organisation;
          this.externalCustomer =
            b2bCustomer == null || !b2bCustomer.IsInternalOrganisation;

          if (this.externalCustomer) {
            this.updateSerialisedItems(this.workEffort.Customer);
          }
        }

        if (isCreate) {
          this.title = 'Add Asset Assignment';

          this.workEffortFixedAssetAssignment =
            this.allors.context.create<WorkEffortFixedAssetAssignment>(
              m.WorkEffortFixedAssetAssignment
            );

          if (this.serialisedItem != null) {
            this.workEffortFixedAssetAssignment.FixedAsset =
              this.serialisedItem;
          }

          if (
            this.workEffort != null &&
            this.workEffort.strategy.cls === m.WorkTask
          ) {
            this.assignment = this.workEffort as WorkEffort;
            this.workEffortFixedAssetAssignment.Assignment = this.assignment;
          }
        } else {
          this.workEffortFixedAssetAssignment =
            loaded.object<WorkEffortFixedAssetAssignment>(
              m.WorkEffortFixedAssetAssignment
            );

          if (this.workEffortFixedAssetAssignment.canWriteFromDate) {
            this.title = 'Edit Asset Assignment';
          } else {
            this.title = 'View Asset Assignment';
          }
        }
      });
  }

  private updateSerialisedItems(customer: Party) {
    const m = this.m;
    const { pullBuilder: pull } = m;
    const x = {};

    const pulls = [
      pull.Party({
        object: customer,
        select: {
          SerialisedItemsWhereOwnedBy: x,
        },
      }),
    ];

    this.allors.context.pull(pulls).subscribe((loaded) => {
      this.serialisedItems = loaded.collection<SerialisedItem>(
        m.Party.SerialisedItemsWhereOwnedBy
      );
    });
  }
}
