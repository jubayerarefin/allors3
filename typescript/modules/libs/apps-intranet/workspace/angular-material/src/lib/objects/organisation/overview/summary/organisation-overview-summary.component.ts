import { Component, Self } from '@angular/core';

import { M } from '@allors/default/workspace/meta';
import { Organisation } from '@allors/default/workspace/domain';
import {
  NavigationService,
  PanelService,
} from '@allors/workspace/angular/base';
import { WorkspaceService } from '@allors/base/workspace/angular/foundation';

@Component({
  selector: 'organisation-overview-summary',
  templateUrl: './organisation-overview-summary.component.html',
  providers: [PanelService],
})
export class OrganisationOverviewSummaryComponent {
  m: M;

  organisation: Organisation;
  contactKindsText: string;

  constructor(
    @Self() public panel: PanelService,
    public workspaceService: WorkspaceService,
    public navigation: NavigationService
  ) {
    this.m = this.workspaceService.workspace.configuration.metaPopulation as M;
    const m = this.m;
    const { pullBuilder: pull } = m;
    const x = {};

    panel.name = 'summary';

    const organisationPullName = `${panel.name}_${this.m.Organisation.tag}`;

    panel.onPull = (pulls) => {
      const id = this.panel.manager.id;

      pulls.push(
        pull.Organisation({
          name: organisationPullName,
          objectId: id,
          include: {
            Locale: x,
            LastModifiedBy: x,
          },
        })
      );
    };

    panel.onPulled = (loaded) => {
      this.organisation = loaded.object<Organisation>(organisationPullName);
    };
  }
}
