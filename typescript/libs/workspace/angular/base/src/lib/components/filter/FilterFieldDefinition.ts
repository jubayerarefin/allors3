import { humanize, ObjectType } from '@allors/workspace/meta/system';
import { ParameterizablePredicate, parameterizablePredicateObjectType } from '@allors/workspace/domain/system';

import { FilterOptions } from './FilterOptions';
import { UnitTags } from '../../../../../../meta/system/src/lib/UnitTags';

export class FilterFieldDefinition {
  predicate: ParameterizablePredicate;
  options?: FilterOptions;

  get isLike() {
    return this.predicate.kind === 'Like';
  }

  get isExists() {
    return this.predicate.kind === 'Exists';
  }

  get isBetween() {
    return this.predicate.kind === 'Between';
  }

  get isBoolean(): boolean {
    return this.objectType?.tag === UnitTags.Boolean;
  }

  get isDateTime(): boolean{
    return this.objectType?.tag === UnitTags.DateTime;
  }

  get isBinary(): boolean{
    return this.objectType?.tag === UnitTags.Binary;
  }

  get objectType(): ObjectType {
    return parameterizablePredicateObjectType(this.predicate);
  }

  get name(): string | undefined {
    return this.predicate.parameter ? humanize(this.predicate.parameter) : undefined;
  }

  get criteria(): string {
    if (this.isLike) {
      return 'Starts with';
    }

    return 'Select';
  }

  constructor(fields?: Partial<FilterFieldDefinition>) {
    Object.assign(this, fields);
  }
}
