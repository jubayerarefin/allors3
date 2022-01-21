import { humanize } from '@allors/system/workspace/meta';
import { Action } from '@allors/base/workspace/angular/foundation';

export class Column {
  name: string;
  assignedLabel: string;
  sort: boolean;
  action: Action;

  constructor(fields?: Partial<Column> | string) {
    if (typeof fields === 'string' || fields instanceof String) {
      this.name = fields as string;
    } else {
      Object.assign(this, fields);
    }
  }

  get label() {
    return this.assignedLabel || humanize(this.name);
  }
}
