import { Observable, Subject, Subscription } from 'rxjs/Rx';
import { Component, OnInit, AfterViewInit, OnDestroy, EventEmitter, Output , ChangeDetectorRef } from '@angular/core';
import { Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { MatSnackBar, MatSnackBarConfig } from '@angular/material';
import { TdMediaService } from '@covalent/core';

import { MetaDomain } from '../../../../meta/index';
import { PullRequest, PushResponse, Fetch, Path, Query, Equals, Like, TreeNode, Sort, Page } from '../../../../domain';
import { Person, PersonRole, Locale, Enumeration } from '../../../../domain';
import { AllorsService, ErrorService,  Scope, Loaded, Saved } from '../../../../angular';

@Component({
  selector: 'worktask-inline',
  template:
`
  <a-mat-select  [object]="person" [roleType]="m.Person.PersonRoles" [options]="roles" display="Name"></a-mat-select>
  <a-mat-input [object]="person" [roleType]="m.Person.FirstName" ></a-mat-input>
  <a-mat-input [object]="person" [roleType]="m.Person.MiddleName" ></a-mat-input>
  <a-mat-input [object]="person" [roleType]="m.Person.LastName" ></a-mat-input>
  <a-mat-select [object]="person" [roleType]="m.Person.Gender" [options]="genders" display="Name" ></a-mat-select>
  <a-mat-select [object]="person" [roleType]="m.Person.Salutation" [options]="salutations" display="Name"></a-mat-select>
  <a-mat-select [object]="person" [roleType]="m.Person.Locale" [options]="locales" display="Name"></a-mat-select>

  <button mat-button color="primary" type="button" (click)="save()">Save</button>
  <button mat-button color="secondary" type="button"(click)="cancel()">Cancel</button>
`,
})
export class WorkTaskInlineComponent implements OnInit {

  private scope: Scope;

  @Output()
  saved: EventEmitter<string> = new EventEmitter<string>();

  @Output()
  cancelled: EventEmitter<any> = new EventEmitter();

  person: Person;

  m: MetaDomain;

  locales: Locale[];
  genders: Enumeration[];
  salutations: Enumeration[];
  roles: PersonRole[];

  constructor(private allors: AllorsService, private errorService: ErrorService) {

    this.scope = new Scope(allors.database, allors.workspace);
    this.m = this.allors.meta;
  }

  ngOnInit(): void {
    const query: Query[] = [
      new Query(
        {
          name: 'locales',
          objectType: this.m.Locale,
        }),
      new Query(
        {
          name: 'genders',
          objectType: this.m.GenderType,
        }),
      new Query(
        {
          name: 'salutations',
          objectType: this.m.Salutation,
        }),
      new Query(
        {
          name: 'roles',
          objectType: this.m.PersonRole,
        }),
    ];

    this.scope
      .load('Pull', new PullRequest({ query: query }))
      .subscribe((loaded: Loaded) => {
        this.locales = loaded.collections.locales as Locale[];
        this.genders = loaded.collections.genders as Enumeration[];
        this.salutations = loaded.collections.salutations as Enumeration[];
        this.roles = loaded.collections.roles as PersonRole[];

        this.person = this.scope.session.create('Person') as Person;
      },
      (error: any) => {
        this.cancelled.emit();
      },
    );
  }

  cancel(): void {
    this.cancelled.emit();
  }

  save(): void {
    this.scope
      .save()
      .subscribe((saved: Saved) => {
        this.saved.emit(this.person.id);
      },
      (error: Error) => {
        this.errorService.dialog(error);
      });
  }
}
