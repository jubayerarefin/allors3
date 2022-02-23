import { Component, HostBinding, OnInit } from '@angular/core';
import { Composite, humanize, RoleType } from '@allors/system/workspace/meta';
import {
  IObject,
  IPullResult,
  Pull,
  Node,
  isPath,
  toNode,
  SharedPullHandler,
  selectLeaf,
  pathLeaf,
  toSelect,
} from '@allors/system/workspace/domain';
import { Period } from '@allors/default/workspace/domain';
import {
  SharedPullService,
  RefreshService,
  WorkspaceService,
  DisplayService,
} from '@allors/base/workspace/angular/foundation';
import {
  PanelService,
  ScopedService,
  AllorsViewExtentPanelComponent,
} from '@allors/base/workspace/angular/application';
import { M } from '@allors/default/workspace/meta';
import { PeriodSelection } from '@allors/base/workspace/angular-material/foundation';

@Component({
  selector: 'a-mat-dyn-view-extent-panel',
  templateUrl: './dynamic-view-extent-panel.component.html',
})
export class AllorsMaterialDynamicViewExtentPanelComponent
  extends AllorsViewExtentPanelComponent
  implements SharedPullHandler, OnInit
{
  @HostBinding('class.expanded-panel')
  get expandedPanelClass() {
    return true;
    // return this.panel.isExpanded;
  }

  get hasPeriod(): boolean {
    return this.objectType.supertypes.has(this.m.Period);
  }

  m: M;

  periodSelection: PeriodSelection = PeriodSelection.Current;

  objects: IObject[];
  filtered: IObject[];

  display: RoleType[];
  includeDisplay: RoleType[];

  description: string;

  constructor(
    scopedService: ScopedService,
    panelService: PanelService,
    sharedPullService: SharedPullService,
    refreshService: RefreshService,
    workspaceService: WorkspaceService,
    private displayService: DisplayService
  ) {
    super(scopedService, panelService, sharedPullService, refreshService);

    this.m = workspaceService.workspace.configuration.metaPopulation as M;
  }

  ngOnInit() {
    this.display = this.displayService.primary(this.objectType);

    if (this.include) {
      const includeObjectType = this.include.objectType as Composite;
      this.includeDisplay = this.displayService.primary(includeObjectType);
    } else {
      this.includeDisplay = [];
    }
  }

  onPreSharedPull(pulls: Pull[], prefix?: string) {
    const id = this.scoped.id;

    const displayInclude: Node[] = this.display
      ?.filter((v) => v.objectType.isComposite)
      .map((v) => {
        return {
          propertyType: v,
        };
      });

    const include = displayInclude ? [...displayInclude] : [];

    if (this.includeDisplay?.length > 0) {
      include.concat({
        propertyType: this.include,
        nodes: this.includeDisplay
          .filter((v) => v.objectType.isComposite)
          .map((v) => {
            return {
              propertyType: v,
            };
          }),
      });
    }

    const results = this.selectAsPaths.map((v) => {
      const select = toSelect(v);
      const leaf = selectLeaf(select);
      leaf.include = include;
      return {
        name: prefix,
        select,
      };
    });

    const pull: Pull = {
      objectId: id,
      results,
    };

    pulls.push(pull);
  }

  onPostSharedPull(pullResult: IPullResult, prefix?: string) {
    this.objects = pullResult.collection<IObject>(prefix) ?? [];
    this.updateFilter();

    const itemName = this.include
      ? this.include.pluralName
      : this.objectType.pluralName;

    if (this.hasPeriod) {
      this.description = `${this.filtered.length} current and ${
        this.objects.length - this.filtered.length
      } inactive ${itemName}`;
    } else {
      this.description = `${this.objects.length} ${itemName}`;
    }
  }

  onPeriodSelectionChange(newPeriodSelection: PeriodSelection) {
    this.periodSelection = newPeriodSelection;

    if (this.objects != null) {
      this.updateFilter();
    }
  }

  toggle() {
    this.panelService.startEdit(this.panelId).subscribe();
  }

  private updateFilter() {
    if (!this.hasPeriod) {
      this.filtered = this.objects;
      return;
    }

    const now = new Date(Date.now());
    switch (this.periodSelection) {
      case PeriodSelection.Current:
        this.filtered = this.objects.filter((v: Period) => {
          if (v.ThroughDate) {
            return v.FromDate < now && v.ThroughDate > now;
          } else {
            return v.FromDate < now;
          }
        });
        break;
      case PeriodSelection.Inactive:
        this.filtered = this.objects.filter((v: Period) => {
          if (v.ThroughDate) {
            return v.FromDate > now || v.ThroughDate < now;
          } else {
            return v.FromDate > now;
          }
        });
        break;
      default:
        this.filtered = this.objects;
        break;
    }
  }
}
