import { Component, Optional, Output, EventEmitter } from '@angular/core';
import { NgForm } from '@angular/forms';

import { RoleField } from '../../../../components/forms/role-field';

@Component({
  selector: 'a-mat-slidetoggle',
  templateUrl: './slide-toggle.component.html',
})
export class AllorsMaterialSlideToggleComponent extends RoleField {
  @Output()
  public changed: EventEmitter<any> = new EventEmitter();

  constructor(@Optional() parentForm: NgForm) {
    super(parentForm);
  }

  public change(): void {
    this.changed.emit();
  }
}
