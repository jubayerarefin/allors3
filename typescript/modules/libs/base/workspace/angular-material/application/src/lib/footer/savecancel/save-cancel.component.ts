import { Component } from '@angular/core';
import { Location } from '@angular/common';
import { NgForm } from '@angular/forms';
import { ContextService } from '@allors/base/workspace/angular/foundation';
import { AllorsComponent } from '@allors/base/workspace/angular/foundation';

@Component({
  selector: 'a-mat-footer-save-cancel',
  templateUrl: './save-cancel.component.html',
})
export class AllorsMaterialFooterSaveCancelComponent extends AllorsComponent {
  constructor(
    public form: NgForm,
    public allors: ContextService,
    public location: Location
  ) {
    super();
  }
}
