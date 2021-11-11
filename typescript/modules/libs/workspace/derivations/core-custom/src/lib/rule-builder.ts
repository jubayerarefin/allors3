import { IRule } from '@allors/workspace/domain/system';
import { M } from '@allors/workspace/meta/default';

import { OrganisationDisplayNameRule, PersonDisplayNameRule } from './rules';

export function ruleBuilder(m: M): IRule[] {
  return [new OrganisationDisplayNameRule(m), new PersonDisplayNameRule(m)];
}