import {
  SharedPullService,
  RefreshService,
  WorkspaceService,
} from '@allors/base/workspace/angular/foundation';
import { PropertyType, RoleType } from '@allors/system/workspace/meta';
import { Directive } from '@angular/core';
import { AllorsScopedPanelComponent } from '../scoped/scoped-panel.component';
import { ScopedService } from '../scoped/scoped.service';
import { PanelService } from '../panel/panel.service';
import { ObjectPanel } from './object-panel';
import { Path } from '@allors/system/workspace/domain';

@Directive()
export abstract class AllorsViewObjectPanelComponent
  extends AllorsScopedPanelComponent
  implements ObjectPanel
{
  override dataAllorsKind = 'view-object-panel';

  readonly panelMode = 'View';

  readonly panelKind = 'Object';

  abstract anchor: PropertyType | PropertyType[];

  abstract target: PropertyType | Path | (PropertyType | Path)[];

  constructor(
    itemPageService: ScopedService,
    panelService: PanelService,
    onShareService: SharedPullService,
    refreshService: RefreshService
  ) {
    super(itemPageService, panelService, onShareService, refreshService);
  }
}