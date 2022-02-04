import { M, tags } from '@allors/default/workspace/meta';
import { Composite } from '@allors/system/workspace/meta';
import {
  FormService,
  WorkspaceService,
} from '@allors/base/workspace/angular/foundation';

import { CountryFormComponent } from '../domain/country/form/country-form.component';
import { EmploymentFormComponent } from '../domain/employment/form/employment-form.component';
import { OrganisationFormComponent } from '../domain/organisation/form/organisation-form.component';

import { Injectable } from '@angular/core';

@Injectable()
export class AppFormService implements FormService {
  m: M;

  constructor(workspaceService: WorkspaceService) {
    this.m = workspaceService.workspace.configuration.metaPopulation as M;
  }

  createForm(composite: Composite) {
    return this.editForm(composite);
  }

  editForm(composite: Composite) {
    switch (composite.tag) {
      case tags.Country:
        return CountryFormComponent;

      case tags.Organisation:
        return OrganisationFormComponent;

      case tags.Person:
        return EmploymentFormComponent;
    }

    return null;
  }
}

export const components: any[] = [
  CountryFormComponent,
  EmploymentFormComponent,
  OrganisationFormComponent,
];
