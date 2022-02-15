import { Component } from '@angular/core';
import { Organisation } from '@allors/default/workspace/domain';
import {
  RefreshService,
  SharedPullService,
  WorkspaceService,
} from '@allors/base/workspace/angular/foundation';
import {
  AllorsViewSummaryPanelComponent,
  ScopedService,
  NavigationService,
  PanelService,
} from '@allors/base/workspace/angular/application';
import { IPullResult, Pull } from '@allors/system/workspace/domain';

@Component({
  selector: 'organisation-summary-panel',
  templateUrl: './organisation-summary-panel.component.html',
})
export class OrganisationSummaryPanelComponent extends AllorsViewSummaryPanelComponent {
  organisation: Organisation;
  contactKindsText: string;

  constructor(
    objectService: ScopedService,
    panelService: PanelService,
    sharedPullService: SharedPullService,
    workspaceService: WorkspaceService,
    refreshService: RefreshService,
    public navigation: NavigationService
  ) {
    super(
      objectService,
      panelService,
      sharedPullService,
      refreshService,
      workspaceService
    );
  }

  onPreSharedPull(pulls: Pull[], prefix?: string) {
    const {
      m: { pullBuilder: p },
    } = this;

    pulls.push(
      p.Organisation({
        name: prefix,
        objectId: this.objectInfo.id,
        include: {
          Country: {},
        },
      })
    );
  }

  onPostSharedPull(pullResult: IPullResult, prefix?: string) {
    this.organisation = pullResult.object<Organisation>(prefix);
  }
}
