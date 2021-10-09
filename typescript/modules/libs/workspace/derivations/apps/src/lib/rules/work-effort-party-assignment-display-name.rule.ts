import { ICycle, IRule, IPattern } from '@allors/workspace/domain/system';
import { M } from '@allors/workspace/meta/default';
import { WorkEffortPartyAssignment } from '@allors/workspace/domain/default';
import { Dependency } from '@allors/workspace/meta/system';

export class WorkEffortPartyAssignmentDisplayNameRule implements IRule {
  patterns: IPattern[];
  dependencies: Dependency[];
  
  constructor(m: M) {
    const { treeBuilder: t, dependency: d } = m;

    this.patterns = [
      {
        kind: 'RolePattern',
        roleType: m.WorkEffortPartyAssignment.Party,
      },
    ];

    this.dependencies = [d(m.WorkEffortPartyAssignment, (v) => v.Party)];
  }

  derive(cycle: ICycle, matches: WorkEffortPartyAssignment[]) {
    for (const match of matches) {
      match.DisplayName = match.Party.DisplayName ?? 'N/A';
    }
  }
}
