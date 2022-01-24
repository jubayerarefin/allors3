import { Subscription } from 'rxjs';
import { switchMap, filter } from 'rxjs/operators';
import { Component, OnInit, Self, OnDestroy } from '@angular/core';
import { M } from '@allors/default/workspace/meta';
import { Organisation, Country } from '@allors/default/workspace/domain';
import { ContextService } from '@allors/base/workspace/angular/foundation';
import {
  RefreshService,
  SaveService,
  SearchFactory,
  SingletonId,
} from '@allors/base/workspace/angular/foundation';
import {
  AllorsPanelDetailComponent,
  PanelService,
} from '@allors/base/workspace/angular/application';
@Component({
  selector: 'organisation-detail',
  templateUrl: './organisation-detail.component.html',
  providers: [ContextService, PanelService],
})
export class OrganisationDetailComponent
  extends AllorsPanelDetailComponent<Organisation>
  implements OnInit, OnDestroy
{
  override readonly m: M;

  organisation: Organisation;
  countries: Country[];
  peopleFilter: SearchFactory;

  private subscription: Subscription;

  constructor(
    @Self() allors: ContextService,
    @Self() panel: PanelService,
    public saveService: SaveService,
    public refreshService: RefreshService,
    private singletonId: SingletonId
  ) {
    super(allors, panel);

    // Collapsed
    const pullName = `${this.panel.name}_${this.m.Organisation.tag}`;

    panel.onPull = (pulls) => {
      if (this.panel.isCollapsed) {
        const m = this.m;
        const { pullBuilder: pull } = m;
        const id = this.panel.manager.id;

        pulls.push(
          pull.Organisation({
            name: pullName,
            objectId: id,
          })
        );
      }
    };

    panel.onPulled = (loaded) => {
      if (this.panel.isCollapsed) {
        this.organisation = loaded.object<Organisation>(pullName);
      }
    };

    this.peopleFilter = new SearchFactory({
      objectType: this.m.Person,
      roleTypes: [this.m.Person.FirstName, this.m.Person.LastName],
    });
  }

  public ngOnInit(): void {
    const m = this.m;
    const { pullBuilder: pull } = m;
    const x = {};

    // Expanded
    this.subscription = this.panel.manager.on$
      .pipe(
        filter(() => {
          return this.panel.isExpanded;
        }),
        switchMap(() => {
          this.organisation = undefined;

          const id = this.panel.manager.id;

          const pulls = [
            pull.Organisation({
              objectId: id,
              include: {
                Country: x,
                Owner: x,
              },
            }),
            pull.Country({
              sorting: [{ roleType: m.Country.Name }],
            }),
          ];

          return this.allors.context.pull(pulls);
        })
      )
      .subscribe((loaded) => {
        this.organisation = loaded.object<Organisation>(m.Organisation);
        this.countries = loaded.collection<Country>(m.Country);
      });
  }

  public ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  public save(): void {
    this.allors.context.push().subscribe(() => {
      this.refreshService.refresh();
      window.history.back();
    }, this.saveService.errorHandler);
  }
}
