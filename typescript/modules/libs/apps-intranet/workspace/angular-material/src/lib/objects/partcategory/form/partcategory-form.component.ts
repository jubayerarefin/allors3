import { Component, Self } from '@angular/core';
import { NgForm } from '@angular/forms';

import {
  EditIncludeHandler,
  Node,
  CreateOrEditPullHandler,
  Pull,
  IPullResult,
  PostCreatePullHandler,
} from '@allors/system/workspace/domain';
import {
  BasePrice,
  InternalOrganisation,
  PartCategory,
} from '@allors/default/workspace/domain';
import { M } from '@allors/default/workspace/meta';
import {
  ErrorService,
  AllorsFormComponent,
} from '@allors/base/workspace/angular/foundation';
import { ContextService } from '@allors/base/workspace/angular/foundation';

import { InternalOrganisationId } from '../../../services/state/internal-organisation-id';
import { FetcherService } from '../../../services/fetcher/fetcher-service';

@Component({
  templateUrl: './partcategory-form.component.html',
  providers: [ContextService],
})
export class PartCategoryFormComponent
  extends AllorsFormComponent<PartCategory>
  implements CreateOrEditPullHandler, EditIncludeHandler, PostCreatePullHandler
{
  public m: M;
  public title: string;

  public category: PartCategory;
  public locales: Locale[];
  public categories: PartCategory[];

  private subscription: Subscription;

  constructor(
    @Self() public allors: ContextService,
    errorService: ErrorService,
    form: NgForm,
    private fetcher: FetcherService,
    private internalOrganisationId: InternalOrganisationId
  ) {
    super(allors, errorService, form);
  }

  public ngOnInit(): void {
    const m = this.m;
    const { pullBuilder: pull } = m;
    const x = {};

    this.subscription = combineLatest(
      this.refreshService.refresh$,
      this.internalOrganisationId.observable$
    )
      .pipe(
        switchMap(() => {
          const isCreate = this.data.id == null;

          const pulls = [
            this.fetcher.locales,
            pull.PartCategory({
              sorting: [{ roleType: m.PartCategory.Name }],
            }),
          ];

          if (!isCreate) {
            pulls.push(
              pull.PartCategory({
                objectId: this.data.id,
                include: {
                  CategoryImage: x,
                  Children: x,
                  LocalisedNames: {
                    Locale: x,
                  },
                  LocalisedDescriptions: {
                    Locale: x,
                  },
                },
              })
            );
          }

          return this.allors.context
            .pull(pulls)
            .pipe(map((loaded) => ({ loaded, isCreate })));
        })
      )
      .subscribe(({ loaded, isCreate }) => {
        this.allors.context.reset();

        this.category = loaded.object<PartCategory>(m.PartCategory);
        this.categories = loaded.collection<PartCategory>(m.PartCategory);
        this.locales = this.fetcher.getAdditionalLocales(loaded);

        if (isCreate) {
          this.title = 'Add Part Category';
          this.category = this.allors.context.create<PartCategory>(
            m.PartCategory
          );
        } else {
          if (this.category.canWriteName) {
            this.title = 'Edit Part Category';
          } else {
            this.title = 'View Part Category';
          }
        }
      });
  }
}
