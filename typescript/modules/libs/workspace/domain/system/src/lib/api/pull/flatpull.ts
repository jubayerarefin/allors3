import { IObject, Node } from '@allors/workspace/domain/system';
import { Extent } from '../../data/Extent';
import { Predicate } from '../../data/Predicate';
import { Result } from '../../data/Result';
import { Select } from '../../data/Select';
import { Sort } from '../../data/Sort';
import { TypeForParameter } from '../../Types';

export interface FlatPull {
  extentRef?: string;

  extent?: Extent;

  predicate?: Predicate;

  sorting?: Sort[];

  object?: IObject;
 
  objectId?: number | string;

  selectRef?: string;

  select?: Select | any;

  include?: Node[] | any;

  name?: string;

  skip?: number;

  take?: number;

  results?: Result[] | any;

  arguments?: { [name: string]: TypeForParameter };
}