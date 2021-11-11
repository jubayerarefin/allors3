import { Dependency, RoleType } from '@allors/workspace/meta/system';
import { IRule } from '@allors/workspace/domain/system';
import { M } from '@allors/workspace/meta/default';
import { Person } from '@allors/workspace/domain/default';

export class FullNameRule implements IRule<Person> {
  roleType: RoleType;
  dependencies: Dependency[];

  constructor(m: M) {
    this.roleType = m.Person.FullName;
  }

  derive(person: Person) {
    return `${person.FirstName} ${person.LastName}`;
  }
}
