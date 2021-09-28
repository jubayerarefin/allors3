import { Component, Self, AfterViewInit, OnDestroy, Injector } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Title } from '@angular/platform-browser';
import { Subscription, combineLatest } from 'rxjs';
import { switchMap } from 'rxjs/operators';

import { M } from '@allors/workspace/meta/default';
import { RequestForQuote, Quote } from '@allors/workspace/domain/default';
import { NavigationActivatedRoute, NavigationService, PanelManagerService, RefreshService, TestScope } from '@allors/workspace/angular/base';
import { SessionService } from '@allors/workspace/angular/core';

import { InternalOrganisationId } from '../../../services/state/internal-organisation-id';

@Component({
  templateUrl: './requestforquote-overview.component.html',
  providers: [PanelManagerService, SessionService],
})
export class RequestForQuoteOverviewComponent extends TestScope implements AfterViewInit, OnDestroy {
  title = 'Request For Quote';

  public requestForQuote: RequestForQuote;
  public quote: Quote;

  subscription: Subscription;

  constructor(
    @Self() public panelManager: PanelManagerService,

    public refreshService: RefreshService,
    public navigation: NavigationService,
    private route: ActivatedRoute,
    public injector: Injector,
    private internalOrganisationId: InternalOrganisationId,
    titleService: Title
  ) {
    super();

    titleService.setTitle(this.title);
  }

  public ngAfterViewInit(): void {
    this.subscription = combineLatest(this.route.url, this.route.queryParams, this.refreshService.refresh$, this.internalOrganisationId.observable$)
      .pipe(
        switchMap(() => {
          const m = this.allors.workspace.configuration.metaPopulation as M;
          const { pullBuilder: pull } = m;
          const x = {};

          const navRoute = new NavigationActivatedRoute(this.route);
          this.panelManager.id = navRoute.id();
          this.panelManager.objectType = m.RequestForQuote;
          this.panelManager.expanded = navRoute.panel();

          this.panelManager.on();

          const pulls = [
            pull.RequestForQuote({
              objectId: this.panelManager.id,
              include: {
                FullfillContactMechanism: {
                  PostalAddress_Country: x,
                },
                RequestItems: {
                  Product: x,
                },
                Originator: x,
                ContactPerson: x,
                RequestState: x,
                Currency: x,
                CreatedBy: x,
                LastModifiedBy: x,
              },
            }),
            pull.RequestForQuote({
              objectId: this.panelManager.id,
              select: {
                QuoteWhereRequest: x,
              },
            }),
          ];

          this.panelManager.onPull(pulls);

          return this.panelManager.client.pullReactive(this.panelManager.session, pulls);
        })
      )
      .subscribe((loaded) => {
        this.panelManager.session.reset();

        this.panelManager.onPulled(loaded);

        this.requestForQuote = loaded.object<RequestForQuote>(m.RequestForQuote);
        this.quote = loaded.object<Quote>(m.Quote);
      });
  }

  public ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
}
