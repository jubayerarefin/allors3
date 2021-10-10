import { ICycle, IRule, IPattern, pattern as p } from '@allors/workspace/domain/system';
import { M } from '@allors/workspace/meta/default';
import { Organisation, PostalAddress } from '@allors/workspace/domain/default';
import { Dependency } from '@allors/workspace/meta/system';

export class OrganisationDisplayAddress3Rule implements IRule {
  patterns: IPattern[];
  dependencies: Dependency[];

  m: M;

  constructor(m: M) {
    this.m = m;
    const { treeBuilder: t, dependency: d } = m;

    this.patterns = [
      p(m.Organisation, (v) => v.GeneralCorrespondence),
      p(
        m.Organisation,
        (v) => v.GeneralCorrespondence,
        t.ContactMechanism({
          PartiesWhereGeneralCorrespondence: {},
        }),
        m.Organisation
      ),
    ];

    this.dependencies = [d(m.Organisation, (v) => v.GeneralCorrespondence)];
  }

  derive(cycle: ICycle, matches: Organisation[]) {
    for (const match of matches) {
      if (match.GeneralCorrespondence && match.GeneralCorrespondence.strategy.cls === this.m.PostalAddress) {
        const postalAddress = match.GeneralCorrespondence as PostalAddress;
        match.DisplayAddress3 = `${postalAddress.Country ? postalAddress.Country.Name : ''}`;
      }

      match.DisplayAddress3 = '';
    }
  }
}
