import { ICycle, IRule, IPattern } from '@allors/workspace/domain/system';
import { M } from '@allors/workspace/meta/default';
import { SerialisedItem, UnifiedGood } from '@allors/workspace/domain/default';

export class SerialisedItemYearsToGoRule implements IRule {
  id= '7ad8092ac8d34076bfdf02a06a492d6f';
  patterns: IPattern[];

  constructor(m: M) {
    const { treeBuilder: t } = m;

    this.patterns = [
      {
        kind: 'RolePattern',
        roleType: m.SerialisedItem.ManufacturingYear,
      },
      {
        kind: 'RolePattern',
        roleType: m.SerialisedItem.Age,
      },
      {
        kind: 'RolePattern',
        roleType: m.UnifiedGood.LifeTime,
        tree: t.UnifiedGood({
          SerialisedItems:{}
        })
      },
    ];
  }

  derive(cycle: ICycle, matches: SerialisedItem[]) {
    for (const match of matches) {
      const good = match.PartWhereSerialisedItem as UnifiedGood | null;

      if (match.canReadPurchasePrice && match.ManufacturingYear != null && good?.LifeTime != null) {
        match.YearsToGo = good.LifeTime - match.Age < 0 ? 0 : good.LifeTime - match.Age;
      } else {
        match.YearsToGo = 0;
      }
    }
  }
}
