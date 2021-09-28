import { Component, OnInit, Self, HostBinding } from '@angular/core';
import { Subscription, combineLatest } from 'rxjs';
import { switchMap, filter } from 'rxjs/operators';
import { format } from 'date-fns';

import { MetaService, NavigationService, PanelService, RefreshService, SessionService } from '@allors/angular/services/core';
import { WorkEffort, TimeEntry } from '@allors/domain/generated';
import { Meta } from '@allors/meta/generated';
import { TableRow, Table, DeleteService, EditService, Sorter } from '@allors/angular/material/core';
import { TestScope, Action } from '@allors/angular/core';
import { ObjectData } from '@allors/angular/material/services/core';
import { Equals } from '@allors/data/system';
import { PullRequest } from '@allors/protocol/system';

interface Row extends TableRow {
  object: TimeEntry;
  person: string;
  from: string;
  through: string;
  time: string;
}

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'timeentry-overview-panel',
  templateUrl: './timeentry-overview-panel.component.html',
  providers: [PanelService, SessionService]
})
export class TimeEntryOverviewPanelComponent extends TestScope implements OnInit {
  workEffort: WorkEffort;
@HostBinding('class.expanded-panel') get expandedPanelClass() {
    return this.panel.isExpanded;
  }

  m: M;

  objects: TimeEntry[];
  table: Table<Row>;

  delete: Action;
  edit: Action;

  get createData(): ObjectData {
    return {
      associationId: this.panel.manager.id,
      associationObjectType: this.panel.manager.objectType,
    };
  }

  constructor(
    @Self() public allors: SessionService,
    @Self() public panel: PanelService,
    
    public refreshService: RefreshService,
    public navigationService: NavigationService,
    public deleteService: DeleteService,
    public editService: EditService
  ) {
    super();

    this.m = this.allors.workspace.configuration.metaPopulation as M;

    this.panel.name = 'timeentry';
    this.panel.title = 'Time Entries';
    this.panel.icon = 'timer';
    this.panel.expandable = true;

    this.delete = this.deleteService.delete(this.panel.manager.context);
    this.edit = this.editService.edit();

    this.table = new Table({
      selection: true,
      columns: [
        { name: 'person' },
        { name: 'from', sort: true },
        { name: 'through', sort: true },
        { name: 'time', sort: true },
      ],
      actions: [
        this.edit,
        this.delete,
      ],
      defaultAction: this.edit,
      autoSort: true,
      autoFilter: true,
    });

    this.panel.onPull = (pulls) => {

      const m = this.m; const { pullBuilder: pull } = m; const x = {};
      const id = this.panel.manager.id;

      pulls.push(
        pull.WorkEffort({
          objectId: id,
          select: {
            ServiceEntriesWhereWorkEffort: {
              include: {
                TimeEntry_Worker: x
              }
            }
          }
        }),
        pull.WorkEffort({
          objectId: id,
        }),
      );
    };

    this.panel.onPulled = (loaded) => {
      this.workEffort = loaded.object<WorkEffort>(m.WorkEffort);
      this.objects = loaded.collection<TimeEntry>(m.TimeEntry);

      if (this.objects) {
        this.table.total = this.objects.length;
        this.table.data = this.objects.map((v) => {
          return {
            object: v,
            person: v.Worker && v.Worker.displayName,
            from: format(new Date(v.FromDate), 'dd-MM-yyyy'),
            through: v.ThroughDate !== null ? format(new Date(v.ThroughDate), 'dd-MM-yyyy') : '',
            time: v.AmountOfTime,
          } as Row;
        });
      }
  };
  }

  ngOnInit(): void {

  }
}