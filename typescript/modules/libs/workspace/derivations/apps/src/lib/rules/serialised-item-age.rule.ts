import { ICycle, IRule, IPattern, pattern as p } from '@allors/workspace/domain/system';
import { M } from '@allors/workspace/meta/default';
import { SerialisedItem } from '@allors/workspace/domain/default';
import { Dependency } from '@allors/workspace/meta/system';

export class SerialisedItemAgeRule implements IRule {
  patterns: IPattern[];
  dependencies: Dependency[];

  constructor(m: M) {
    this.patterns = [p(m.SerialisedItem, (v) => v.ManufacturingYear)];
  }

  derive(cycle: ICycle, matches: SerialisedItem[]) {
    for (const match of matches) {
      if (match.canReadPurchasePrice && match.ManufacturingYear != null) {
        match.Age = new Date().getFullYear() - match.ManufacturingYear;
      } else {
        match.Age = 0;
      }
    }
  }
}