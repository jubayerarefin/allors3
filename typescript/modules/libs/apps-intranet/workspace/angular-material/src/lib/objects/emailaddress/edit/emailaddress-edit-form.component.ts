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
  EmailAddress,
  InternalOrganisation,
} from '@allors/default/workspace/domain';
import { M } from '@allors/default/workspace/meta';
import {
  ErrorService,
  AllorsFormComponent,
} from '@allors/base/workspace/angular/foundation';
import { ContextService } from '@allors/base/workspace/angular/foundation';

import { InternalOrganisationId } from '../../../services/state/internal-organisation-id';

@Component({
  templateUrl: './emailaddress-form.component.html',
  providers: [ContextService],
})
export class EmailAddressFormComponent
  extends AllorsFormComponent<EmailAddress>
  implements CreateOrEditPullHandler, EditIncludeHandler, PostCreatePullHandler
{
  readonly m: M;

  contactMechanism: ElectronicAddress;
  contactMechanismTypes: Enumeration[];
  title: string;

  private subscription: Subscription;

  constructor(
    @Self() public allors: ContextService,
    errorService: ErrorService,
    form: NgForm,
    private internalOrganisationId: InternalOrganisationId
  ) {
    super(allors, errorService, form);
  }

  public ngOnInit(): void {
    const m = this.m;
    const { pullBuilder: pull } = m;

    this.subscription = combineLatest(
      this.refreshService.refresh$,
      this.internalOrganisationId.observable$
    )
      .pipe(
        switchMap(() => {
          const pulls = [
            pull.ContactMechanism({
              objectId: this.data.id,
            }),
          ];

          return this.allors.context.pull(pulls);
        })
      )
      .subscribe((loaded) => {
        this.allors.context.reset();
        this.contactMechanism = loaded.object<ElectronicAddress>(
          m.ContactMechanism
        );

        if (this.contactMechanism.canWriteElectronicAddressString) {
          this.title = 'Edit Email Address';
        } else {
          this.title = 'View Email Address';
        }
      });
  }
}
