import { Component, Optional } from '@angular/core';
import { NgForm } from '@angular/forms';
import { RoleField } from '@allors/base/workspace/angular/foundation';

@Component({
  selector: 'a-mat-checkbox',
  templateUrl: './checkbox.component.html',
})
export class AllorsMaterialCheckboxComponent extends RoleField {
  constructor(@Optional() parentForm: NgForm) {
    super(parentForm);
  }
}
