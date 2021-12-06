import { Component, OnInit, Self, OnDestroy } from '@angular/core';

import { Subscription } from 'rxjs';
import { filter, map, switchMap } from 'rxjs/operators';

import { M } from '@allors/workspace/meta/default';
import { Organisation, Party, Priority, WorkRequirement, SerialisedItem, InternalOrganisation } from '@allors/workspace/domain/default';
import { NavigationService, PanelService, RadioGroupOption, RefreshService, SaveService, SearchFactory } from '@allors/workspace/angular/base';
import { ContextService } from '@allors/workspace/angular/core';
import { IObject } from '@allors/workspace/domain/system';

import { FetcherService } from '../../../../services/fetcher/fetcher-service';
import { InternalOrganisationId } from '../../../../services/state/internal-organisation-id';
import { Filters } from '../../../../filters/filters';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'workrequirement-overview-detail',
  templateUrl: './workrequirement-overview-detail.component.html',
  providers: [PanelService, ContextService],
})
export class WorkRequirementOverviewDetailComponent implements OnInit, OnDestroy {
  readonly m: M;
  public title: string;

  internalOrganisation: InternalOrganisation;
  serialisedItems: SerialisedItem[];
  private subscription: Subscription;
  requirement: WorkRequirement;
  priorities: Priority[];
  priorityOptions: RadioGroupOption[];
  customer: Party;
  customersFilter: SearchFactory;

  constructor(
    @Self() public allors: ContextService,
    @Self() public panel: PanelService,
    public navigationService: NavigationService,
    public refreshService: RefreshService,
    private saveService: SaveService,
    private fetcher: FetcherService,
    private internalOrganisationId: InternalOrganisationId,
  ) {
    this.allors.context.name = this.constructor.name;
    this.m = this.allors.context.configuration.metaPopulation as M;

    panel.name = 'detail';
    panel.title = 'WorkRequirement Details';
    panel.icon = 'business';
    panel.expandable = true;

    // Minimized
    const pullName = `${this.panel.name}_${this.m.WorkRequirement.tag}`;

    panel.onPull = (pulls) => {
      this.requirement = undefined;

      if (this.panel.isCollapsed) {
        const m = this.m;
        const { pullBuilder: pull } = m;
        const x = {};
        const id = this.panel.manager.id;

        pulls.push(
          pull.WorkRequirement({
            name: pullName,
            objectId: id,
          })
        );
      }
    };

    panel.onPulled = (loaded) => {
      if (this.panel.isCollapsed) {
        this.requirement = loaded.object<WorkRequirement>(pullName);
      }
    };
  }

  public ngOnInit(): void {
    const m = this.m;
    const { pullBuilder: pull } = m;
    const x = {};
    const id = this.panel.manager.id;

    // Maximized
    this.subscription = this.panel.manager.on$
      .pipe(
        filter(() => {
          return this.panel.isExpanded;
        }),
        switchMap(() => {
          const pulls = [
            this.fetcher.internalOrganisation,
            pull.WorkRequirement({
              objectId: id,
              include: {
                Originator: x,
                Priority: x,
                FixedAsset: x,
                Pictures: x,
              },
            }),
            pull.Priority({
              predicate: { kind: 'Equals', propertyType: m.Priority.IsActive, value: true },
              sorting: [{ roleType: m.Priority.DisplayOrder }],
            }),
          ];

          this.customersFilter = Filters.customersFilter(m, this.internalOrganisationId.value);

          return this.allors.context.pull(pulls).pipe(map((loaded) => ({ loaded })));
        })
      )
      .subscribe(({ loaded }) => {
        this.allors.context.reset();
        this.internalOrganisation = this.fetcher.getInternalOrganisation(loaded);
        this.priorities = loaded.collection<Priority>(m.Priority);
        this.priorityOptions = this.priorities.map((v) => {
          return {
            label: v.Name,
            value: v,
          };
        });

        this.requirement = loaded.object<WorkRequirement>(m.WorkRequirement);
        this.originatorSelected(this.requirement.Originator);

        if (this.requirement.canWriteDescription) {
          this.title = 'Edit Work Requirement';
        } else {
          this.title = 'View Work Requirement';
        }
      });
  }

  public originatorSelected(party: IObject) {
    if (party) {
      this.updateOriginator(party as Party);
    }
  }

  public ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  public save(): void {
    this.onSave()
    this.allors.context.push().subscribe(() => {
      this.refreshService.refresh();
      this.panel.toggle();
    }, this.saveService.errorHandler);
  }

  private updateOriginator(party: Party) {
    const m = this.m;
    const { pullBuilder: pull } = m;
    const x = {};

    const pulls = [
      pull.SerialisedItem({
        predicate: {
            kind: 'And',
            operands: [
              {
                kind: 'Or',
                operands: [
                  { kind: 'Equals', propertyType: m.SerialisedItem.OwnedBy, object: party },
                  { kind: 'Equals', propertyType: m.SerialisedItem.RentedBy, object: party },
                ],
              },
            ],
          },
      }),
    ];

    this.allors.context.pull(pulls).subscribe((loaded) => {
      this.serialisedItems = loaded.collection<SerialisedItem>(m.SerialisedItem);
    });
  }

  private onSave() {
    this.requirement.Description = `Work Requirement for: ${this.requirement.FixedAsset?.DisplayName}`;
  }
}
