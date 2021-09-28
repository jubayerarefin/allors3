import { Select } from './select';
import { Node } from './node';

export interface Result {
  selectRef?: string;

  select?: Select;

  include?: Node[];

  name?: string;

  skip?: number;

  take?: number;
}
