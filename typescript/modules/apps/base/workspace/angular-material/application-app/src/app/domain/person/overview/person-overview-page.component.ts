import { combineLatest, delay, map, switchMap } from 'rxjs';
import { Component, Self } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';
import { Person } from '@allors/default/workspace/domain';
import {
  RefreshService,
  SharedPullService,
  WorkspaceService,
} from '@allors/base/workspace/angular/foundation';
import {
  NavigationService,
  NavigationActivatedRoute,
  PanelService,
  ObjectService,
  AllorsOverviewPageComponent,
} from '@allors/base/workspace/angular/application';
import { IPullResult, Pull } from '@allors/system/workspace/domain';
import { AllorsMaterialPanelService } from '@allors/base/workspace/angular-material/application';

@Component({
  templateUrl: './person-overview-page.component.html',
  providers: [
    ObjectService,
    {
      provide: PanelService,
      useClass: AllorsMaterialPanelService,
    },
  ],
})
export class PersonOverviewPageComponent extends AllorsOverviewPageComponent {
  object: Person;

  constructor(
    @Self() objectService: ObjectService,
    @Self() private panelService: PanelService,
    public navigation: NavigationService,
    private titleService: Title,
    refreshService: RefreshService,
    sharedPullService: SharedPullService,
    workspaceService: WorkspaceService,
    route: ActivatedRoute
  ) {
    super(objectService, sharedPullService, refreshService, workspaceService);

    this.objectService.objectInfo$ = combineLatest([
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

  onPreSharedPull(pulls: Pull[], scope?: string) {
    const {
      m: { pullBuilder: p },
    } = this;

    pulls.push(
      p.Organisation({
        name: scope,
        objectId: this.objectInfo.id,
      })
    );
  }

  onPostSharedPull(pullResult: IPullResult, scope?: string) {
    this.object = pullResult.object(scope);
  }
}
