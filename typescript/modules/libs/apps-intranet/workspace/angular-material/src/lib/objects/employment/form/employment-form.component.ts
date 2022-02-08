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
  Employment,
  InternalOrganisation,
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
  templateUrl: './employment-form.component.html',
  providers: [ContextService],
})
export class EmploymentFormComponent
  extends AllorsFormComponent<Employment>
  implements CreateOrEditPullHandler, EditIncludeHandler, PostCreatePullHandler
{
  readonly m: M;

  partyRelationship: Employment;
  people: Person[];
  party: Party;
  person: Person;
  organisation: Organisation;
  internalOrganisation: InternalOrganisation;
  internalOrganisations: InternalOrganisation[];
  title: string;
  addEmployee = false;

  private subscription: Subscription;
  canSave: boolean;

  constructor(
    @Self() public allors: ContextService,
    errorService: ErrorService,
    form: NgForm,
    private internalOrganisationId: InternalOrganisationId,
    private fetcher: FetcherService
  ) {
    super(allors, errorService, form);

    this.canSave = true;
  }

  public canCreate(createData: ObjectData) {
    if (createData.associationObjectType === this.m.Organisation) {
      const organisation = this.allors.context.instantiate<Organisation>(
        createData.associationId
      );
      return organisation.IsInternalOrganisation;
    }

    return true;
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

          const pulls = [this.fetcher.internalOrganisation, pull.Person({})];

          if (!isCreate) {
            pulls.push(
              pull.Employment({
                objectId: this.data.id,
                include: {
                  Employee: x,
                  Employer: x,
                  Parties: x,
                },
              })
            );
          }

          if (isCreate && this.data.associationId) {
            pulls.push(
              pull.Party({
                objectId: this.data.associationId,
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

        this.people = loaded.collection<Person>(m.Person);
        this.internalOrganisation =
          this.fetcher.getInternalOrganisation(loaded);

        if (isCreate) {
          this.title = 'Add Employment';

          this.partyRelationship = this.allors.context.create<Employment>(
            m.Employment
          );
          this.partyRelationship.FromDate = new Date();
          this.partyRelationship.Employer = this.internalOrganisation;

          this.party = loaded.object<Party>(m.Party);

          if (this.party.strategy.cls === m.Person) {
            this.person = this.party as Person;
            this.partyRelationship.Employee = this.person;
          }

          if (this.party.strategy.cls === m.Organisation) {
            this.organisation = this.party as Organisation;

            if (!this.organisation.IsInternalOrganisation) {
              this.canSave = false;
              // this.dialogRef.close();
            }
          }
        } else {
          this.partyRelationship = loaded.object<Employment>(m.Employment);
          this.person = this.partyRelationship.Employee;
          this.organisation = this.partyRelationship.Employer as Organisation;

          if (this.partyRelationship.canWriteFromDate) {
            this.title = 'Edit Employment';
          } else {
            this.title = 'View Employment';
          }
        }
      });
  }

  public employeeAdded(employee: Person): void {
    this.partyRelationship.Employee = employee;
    this.people.push(employee);
  }
}
