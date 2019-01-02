import { Component, Self, OnInit } from '@angular/core';
import { NavigationService, Action, PanelService, RefreshService, ErrorService, MetaService } from '../../../../../../angular';
import { WorkEffortPartyAssignment, OrganisationContactRelationship, Party } from '../../../../../../domain';
import { Meta } from '../../../../../../meta';
import { DeleteService, TableRow, EditService, Table, OverviewService, CreateData } from '../../../../..';
import * as moment from 'moment';

interface Row extends TableRow {
  object: WorkEffortPartyAssignment;
  number: string;
  name: string;
  status: string;
  from: string;
  through: string;
}

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'workeffortpartyassignment-overview-panel',
  templateUrl: './workeffortpartyassignment-overview-panel.component.html',
  providers: [PanelService]
})
export class WorkEffortPartyAssignmentOverviewPanelComponent implements OnInit {

  m: Meta;

  objects: WorkEffortPartyAssignment[] = [];

  delete: Action;
  edit: Action;
  table: Table<TableRow>;

  get createData(): CreateData {
    return {
      associationId: this.panel.manager.id,
      associationObjectType: this.panel.manager.objectType,
    };
  }

  constructor(
    @Self() public panel: PanelService,
    public metaService: MetaService,
    public refreshService: RefreshService,
    public navigation: NavigationService,
    public errorService: ErrorService,
    public deleteService: DeleteService,
    public editService: EditService,
  ) {

    this.m = this.metaService.m;
  }

  ngOnInit() {

    this.delete = this.deleteService.delete(this.panel.manager.context);
    this.edit = this.editService.edit();

    this.panel.name = 'workeffortpartyassignment';
    this.panel.title = 'Work Efforts';
    this.panel.icon = 'work';
    this.panel.expandable = true;

    this.table = new Table({
      selection: true,
      columns: [
        { name: 'number' },
        { name: 'name' },
        { name: 'status' },
        { name: 'from' },
        { name: 'through' },
      ],
      actions: [
        this.edit,
        this.delete,
      ],
      defaultAction: this.edit,
    });

    const personPullName = `${this.panel.name}_${this.m.WorkEffortPartyAssignment.name}_person`;
    const organisationPullName = `${this.panel.name}_${this.m.WorkEffortPartyAssignment.name}_organisation`;

    this.panel.onPull = (pulls) => {
      const { pull, x } = this.metaService;

      const id = this.panel.manager.id;

      pulls.push(
        pull.Person({
          name: personPullName,
          object: id,
          fetch: {
            WorkEffortPartyAssignmentsWhereParty: {
              include: {
                Assignment: {
                  WorkEffortState: x,
                  Priority: x,
                }
              }
            }
          }
        }),
        pull.Organisation({
          name: organisationPullName,
          object: id,
          fetch: {
            CurrentOrganisationContactRelationships: {
              Contact: {
                WorkEffortPartyAssignmentsWhereParty: {
                  include: {
                    Assignment: {
                      WorkEffortState: x,
                      Priority: x,
                    }
                  }
                }
              }
            }
          }
        })
      );
    };

    this.panel.onPulled = (loaded) => {
      const x = loaded.collections[organisationPullName] as WorkEffortPartyAssignment[];
      const collection = loaded.collections[personPullName] || loaded.collections[organisationPullName] as WorkEffortPartyAssignment[];
      this.objects = collection as WorkEffortPartyAssignment[];

      if (this.objects) {
        this.table.total = loaded.values[`${personPullName}_total`] || this.objects.length;
        this.table.data = this.objects.map((v) => {
          return {
            object: v,
            number: v.Assignment.WorkEffortNumber,
            name: v.Assignment.Name,
            status: v.Assignment.WorkEffortState ? v.Assignment.WorkEffortState.Name : '',
            from: moment(v.FromDate).format('L'),
            through: v.ThroughDate !== null ? moment(v.ThroughDate).format('L') : '',
          } as Row;
        });
      }
    };
  }
}
