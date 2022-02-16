import {
  AfterViewInit,
  Directive,
  HostBinding,
  OnDestroy,
} from '@angular/core';
import { Panel, PanelKind, PanelMode } from '../panel/panel';
import { ScopedService } from './scoped.service';
import { Subscription, tap } from 'rxjs';
import { PanelService } from '../panel/panel.service';
import {
  IPullResult,
  Pull,
  SharedPullHandler,
} from '@allors/system/workspace/domain';
import {
  AllorsComponent,
  SharedPullService,
  RefreshService,
  WorkspaceService,
} from '@allors/base/workspace/angular/foundation';
import { M } from '@allors/default/workspace/meta';
import { Scoped } from './scoped';

@Directive()
export abstract class AllorsScopedPanelComponent
  extends AllorsComponent
  implements Panel, SharedPullHandler, AfterViewInit, OnDestroy
{
  @HostBinding('attr.data-allors-id')
  get dataAllorsId() {
    return this.scoped?.id;
  }

  @HostBinding('attr.data-allors-objecttype')
  get dataAllorsObjectType() {
    return this.scoped?.objectType?.tag;
  }

  abstract panelId: string;

  abstract panelMode: PanelMode;

  abstract panelKind: PanelKind;

  panelEnabled: boolean;

  scoped: Scoped;

  private panelSubscription: Subscription;

  constructor(
    public scopedService: ScopedService,
    public panelService: PanelService,
    public sharedPullService: SharedPullService,
    public refreshService: RefreshService
  ) {
    super();

    panelService.register(this);
    this.sharedPullService.register(this);
  }

  ngAfterViewInit(): void {
    this.panelSubscription = this.scopedService.scoped$
      .pipe(
        tap((info) => {
          this.scoped = info;
          this.refreshService.refresh();
        })
      )
      .subscribe();
  }

  ngOnDestroy(): void {
    this.panelService.unregister(this);
    this.sharedPullService.unregister(this);

    if (this.panelSubscription) {
      this.panelSubscription?.unsubscribe();
    }
  }

  abstract onPreSharedPull(pulls: Pull[], prefix?: string): void;

  abstract onPostSharedPull(pullResult: IPullResult, prefix?: string): void;
}
