import { Component, Output, EventEmitter, OnInit, OnDestroy } from '@angular/core';

import { SessionService, MetaService } from '@allors/angular/services/core';
import { Person, Enumeration, Locale } from '@allors/domain/generated';
import { Meta } from '@allors/meta/generated';
import { Equals, Sort } from '@allors/data/system';
import { PullRequest } from '@allors/protocol/system';


@Component({
  // tslint:disable-next-line:component-selector
  selector: 'person-inline',
  templateUrl: './person-inline.component.html'
})
export class PersonInlineComponent implements OnInit, OnDestroy {

  @Output()
  public saved: EventEmitter<Person> = new EventEmitter<Person>();

  @Output()
  public cancelled: EventEmitter<any> = new EventEmitter();

  public person: Person;

  public m: M;

  public locales: Locale[];
  public genders: Enumeration[];
  public salutations: Enumeration[];

  constructor(
    private allors: SessionService,
    public ) {

    this.m = this.allors.workspace.configuration.metaPopulation as M;
  }

  public ngOnInit(): void {

    const { pull } = this.metaService;

    const pulls = [
      pull.Locale({
        sorting: [{ roleType: this.m.Locale.Name }]
      }),
      pull.GenderType({
        predicate: { kind: 'Equals', propertyType: this.m.GenderType.IsActive, value: true },
        sorting: [{ roleType: this.m.GenderType.Name }],
      }),
      pull.Salutation({
        predicate: { kind: 'Equals', propertyType: this.m.Salutation.IsActive, value: true },
        sorting: [{ roleType: this.m.Salutation.Name }]
      })
    ];

    this.allors.context
      .load(new PullRequest({ pulls }))
      .subscribe((loaded) => {
        this.locales = loaded.collection<Locale>(m.Locale);
        this.genders = loaded.collection<Enumeration>(m.Enumeration);
        this.salutations = loaded.collection<Enumeration>(m.Enumeration);

        this.person = this.allors.session.create<Person>(m.Person);
      });
  }

  public ngOnDestroy(): void {
    if (!!this.person) {
      this.allors.client.invokeReactive(this.allors.session, this.person.Delete);
    }
  }

  public cancel(): void {
    this.cancelled.emit();
  }

  public save(): void {
      this.saved.emit(this.person);
      this.person = undefined;
  }
}
