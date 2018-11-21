import { Component, OnDestroy, OnInit, Self } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';

import { Loaded, SessionService } from '../../allors/angular';
import { Organisation } from '../../allors/domain';
import { PullRequest } from '../../allors/framework';

@Component({
  templateUrl: './fetch.component.html',
  providers: [SessionService]
})
export class FetchComponent implements OnInit, OnDestroy {

  public organisation: Organisation;
  public organisations: Organisation[];

  private subscription: Subscription;

  constructor(
    @Self() private allors: SessionService,
    private title: Title,
    private route: ActivatedRoute,
  ) { }

  public ngOnInit() {
    this.title.setTitle('Fetch');
    this.fetch();
  }

  public fetch() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }

    const { pull, x } = this.allors;

    const id = this.route.snapshot.paramMap.get('id');

    const pulls = [
      pull.Organisation({ object: id, include: { Owner: x } }),
      pull.Organisation({
        object: id, fetch: {
          Owner: {
            OrganisationsWhereOwner: {
              include: {
                Owner: x,
              }
            }
          }
        }
      })
    ];

    this.allors.session.reset();

    this.subscription = this.allors
      .load('Pull', new PullRequest({
        pulls,
      }))
      .subscribe((loaded: Loaded) => {
        this.organisation = loaded.objects.Organisation as Organisation;
        this.organisations = loaded.collections.Organisations as Organisation[];
      },
        (error) => {
          alert(error);
        });
  }

  public ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
}
