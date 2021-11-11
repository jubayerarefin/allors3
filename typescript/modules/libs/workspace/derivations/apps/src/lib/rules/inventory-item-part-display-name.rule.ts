import { ICycle, IRule, IPattern, pattern as p } from '@allors/workspace/domain/system';
import { M } from '@allors/workspace/meta/default';
import { InventoryItem } from '@allors/workspace/domain/default';
import { Dependency } from '@allors/workspace/meta/system';

export class InventoryItemPartDisplayNameRule implements IRule {
  patterns: IPattern[];
  dependencies: Dependency[];

  constructor(m: M) {
    const { treeBuilder: t, dependency: d } = m;

    this.patterns = [
      p(
        m.Part,
        (v) => v.Name,
        t.Part({
          InventoryItemsWherePart: {},
        })
      ),
    ];

    this.dependencies = [d(m.InventoryItem, (v) => v.Part)];
  }

  derive(cycle: ICycle, matches: InventoryItem[]) {
    for (const match of matches) {
      match.PartDisplayName = match.Part?.Name ?? '';
    }
  }
}