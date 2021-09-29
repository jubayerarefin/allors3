import { Component, OnInit, Self, HostBinding } from '@angular/core';

import { M } from '@allors/workspace/meta/default';
import { WorkEffort, WorkEffortInventoryAssignment } from '@allors/workspace/domain/default';
import { Action, DeleteService, EditService, NavigationService, ObjectData, PanelService, RefreshService, Table, TableRow, TestScope } from '@allors/workspace/angular/base';
import { WorkspaceService } from '@allors/workspace/angular/core';

interface Row extends TableRow {
  object: WorkEffortInventoryAssignment;
  part: string;
  facility: string;
  quantity: string;
  uom: string;
}

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'workeffortinventoryassignment-overview-panel',
  templateUrl: './workeffortinventoryassignment-overview-panel.component.html',
  providers: [PanelService],
})
export class WorkEffortInventoryAssignmentOverviewPanelComponent extends TestScope implements OnInit {
  workEffort: WorkEffort;

  @HostBinding('class.expanded-panel') get expandedPanelClass() {
    return this.panel.isExpanded;
  }

  m: M;

  objects: WorkEffortInventoryAssignment[] = [];

  edit: Action;
  table: Table<TableRow>;

  get createData(): ObjectData {
    return {
      associationId: this.panel.manager.id,
      associationObjectType: this.panel.manager.objectType,
    };
  }

  constructor(
    @Self() public panel: PanelService,
    public workspaceService: WorkspaceService,

    public refreshService: RefreshService,
    public navigation: NavigationService,

    public deleteService: DeleteService,
    public editService: EditService
  ) {
    super();

    this.m = this.workspaceService.workspace.configuration.metaPopulation as M;
  }

  ngOnInit() {
    this.edit = this.editService.edit();

    this.panel.name = 'workeffortinventoryassignment';
    // this.panel.title = 'Inventory Assignment';
    this.panel.title = 'Parts Used';
    this.panel.icon = 'work';
    this.panel.expandable = true;

    this.table = new Table({
      selection: true,
      columns: [{ name: 'part' }, { name: 'facility' }, { name: 'quantity' }, { name: 'uom' }],
      actions: [this.edit],
      defaultAction: this.edit,
      autoSort: true,
      autoFilter: true,
    });

    const pullName = `${this.panel.name}_${this.m.WorkEffortInventoryAssignment.tag}`;

    this.panel.onPull = (pulls) => {
      const m = this.m;
      const { pullBuilder: pull } = m;
      const x = {};

      const id = this.panel.manager.id;

      pulls.push(
        pull.WorkEffort({
          name: pullName,
          objectId: id,
          select: {
            WorkEffortInventoryAssignmentsWhereAssignment: {
              include: {
                InventoryItem: {
                  Part: x,
                  Facility: x,
                  UnitOfMeasure: x,
                  NonSerialisedInventoryItem_NonSerialisedInventoryItemState: x,
                  SerialisedInventoryItem_SerialisedInventoryItemState: x,
                },
              },
            },
          },
        }),
        pull.WorkEffort({
          objectId: id,
        })
      );
    };

    this.panel.onPulled = (loaded) => {
      this.workEffort = loaded.object<WorkEffort>(m.WorkEffort);
      this.objects = loaded.collection<WorkEffortInventoryAssignment>(pullName);

      if (this.objects) {
        this.table.total = this.objects.length;
        this.table.data = this.objects.map((v) => {
          return {
            object: v,
            part: v.InventoryItem.Part.Name,
            facility: v.InventoryItem.Facility.Name,
            quantity: v.Quantity,
            uom: v.InventoryItem.UnitOfMeasure.Name,
          } as Row;
        });
      }
    };
  }
}
