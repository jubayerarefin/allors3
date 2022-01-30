import {
  Component,
  Self,
  AfterViewInit,
  OnDestroy,
  Injector,
} from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Title } from '@angular/platform-browser';
import { Subscription, combineLatest } from 'rxjs';
import { switchMap } from 'rxjs/operators';

import { M } from '@allors/default/workspace/meta';
import { WorkRequirement } from '@allors/default/workspace/domain';
import {
  NavigationActivatedRoute,
  NavigationService,
  OldPanelManagerService,
  RefreshService,
} from '@allors/base/workspace/angular/foundation';
import {
  ContextService,
  WorkspaceService,
} from '@allors/base/workspace/angular/foundation';

import { InternalOrganisationId } from '../../../services/state/internal-organisation-id';

@Component({
  templateUrl: './workrequirement-overview.component.html',
  providers: [OldPanelManagerService, ContextService],
})
export class WorkRequirementOverviewComponent
  implements AfterViewInit, OnDestroy
{
  readonly m: M;
  title = 'WorkRequirement';

  requirement: WorkRequirement;

  subscription: Subscription;

  constructor(
    @Self() public allors: ContextService,
    @Self() public panelManager: OldPanelManagerService,
    public workspaceService: WorkspaceService,
    public refreshService: RefreshService,
    public navigationService: NavigationService,
    private route: ActivatedRoute,
    public injector: Injector,
    private internalOrganistationId: InternalOrganisationId,
    titleService: Title
  ) {
    this.allors.context.name = this.constructor.name;
    titleService.setTitle(this.title);

    this.m = this.workspaceService.workspace.configuration.metaPopulation as M;
  }

  public ngOnInit(): void {
    const m = this.m;
    const { pullBuilder: pull } = m;

    this.subscription = combineLatest(
      this.route.url,
      this.route.queryParams,
      this.refreshService.refresh$,
      this.internalOrganistationId.observable$
    )
      .pipe(
        switchMap(([, ,]) => {
          const navRoute = new NavigationActivatedRoute(this.route);
          this.panelManager.objectType = m.WorkTask;
          this.panelManager.id = navRoute.id();
          this.panelManager.expanded = navRoute.panel();

          this.panelManager.on();

          const pulls = [
            pull.WorkRequirement({
              objectId: this.panelManager.id,
            }),
          ];

          this.panelManager.onPull(pulls);

          return this.panelManager.context.pull(pulls);
        })
      )
      .subscribe((loaded) => {
        this.panelManager.context.reset();
        this.panelManager.onPulled(loaded);

        this.requirement = loaded.object<WorkRequirement>(m.WorkRequirement);
      });
  }

  public ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
}
