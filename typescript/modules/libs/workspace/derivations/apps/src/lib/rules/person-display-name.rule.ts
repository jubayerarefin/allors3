import { ICycle, IRule, IPattern } from '@allors/workspace/domain/system';
import { M } from '@allors/workspace/meta/default';
import { Person } from '@allors/workspace/domain/default';

export class PersonDisplayNameRule implements IRule {
  id = 'PersonDisplayName';
  patterns: IPattern[];

  constructor(m: M) {
    this.patterns = [
      {
        kind: 'RolePattern',
        roleType: m.Person.FirstName,
      },
      {
        kind: 'RolePattern',
        roleType: m.Person.LastName,
      },
    ];
  }

  derive(cycle: ICycle, matches: Person[]) {
    for (const person of matches) {
      person.DisplayName = `${person.FirstName} ${person.LastName}`;
    }
  }
}
