import { Component, Self } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Title } from '@angular/platform-browser';
import { combineLatest } from 'rxjs';
import { delay, map, switchMap } from 'rxjs/operators';

import { WorkTask } from '@allors/default/workspace/domain';
import {
  RefreshService,
  SharedPullService,
} from '@allors/base/workspace/angular/foundation';
import { WorkspaceService } from '@allors/base/workspace/angular/foundation';
import {
  AllorsOverviewPageComponent,
  NavigationActivatedRoute,
  NavigationService,
  ScopedService,
  PanelService,
} from '@allors/base/workspace/angular/application';
import { AllorsMaterialPanelService } from '@allors/base/workspace/angular-material/application';
import { IPullResult, Pull } from '@allors/system/workspace/domain';
import { M } from '@allors/default/workspace/meta';

@Component({
  templateUrl: './worktask-overview-page.component.html',
  providers: [
    ScopedService,
    {
      provide: PanelService,
      useClass: AllorsMaterialPanelService,
    },
  ],
})
export class WorkTaskOverviewComponent extends AllorsOverviewPageComponent {
  object: WorkTask;

  constructor(
    @Self() scopedService: ScopedService,
    @Self() private panelService: PanelService,
    public navigation: NavigationService,
    private titleService: Title,
    refreshService: RefreshService,
    sharedPullService: SharedPullService,
    private workspaceService: WorkspaceService,
    route: ActivatedRoute
  ) {
    super(scopedService, sharedPullService, refreshService, workspaceService);

    this.scopedService.scoped$ = combineLatest([
      route.url,
      route.queryParams,
    ]).pipe(
      delay(1),
      map(() => new NavigationActivatedRoute(route)),
      switchMap((navRoute) => {
        return this.panelService
          .startEdit(navRoute.panel())
          .pipe(map(() => navRoute));
      }),
      map((navRoute) => {
        return {
          objectType: this.m.Organisation,
          id: navRoute.id(),
        };
      })
    );
  }

  onPreSharedPull(pulls: Pull[], prefix?: string) {
    const m = this.workspaceService.workspace.configuration.metaPopulation as M;
    const { pullBuilder: p } = m;

    pulls.push(
      p.WorkTask({
        name: prefix,
        objectId: this.scoped.id,
      })
    );
  }

  onPostSharedPull(pullResult: IPullResult, prefix?: string) {
    this.object = pullResult.object(prefix);
    const title = this.scoped.objectType.singularName;
    this.titleService.setTitle(title);
  }
}
