import { AfterViewInit, Component, ElementRef, ViewEncapsulation, Optional, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';

import { RoleField } from '../../../../components/forms/role-field';

import * as EasyMDE from 'easymde';

@Component({
  selector: 'a-mat-markdown',
  template: `
    <h4>{{ label }}</h4>
    <textarea #easymde [attr.data-allors-id]="dataAllorsId" [attr.data-allors-roletype]="dataAllorsRoleType"></textarea>
  `,
  encapsulation: ViewEncapsulation.None,
})
export class AllorsMaterialMarkdownComponent extends RoleField implements AfterViewInit {
  @ViewChild('easymde', { static: true })
  elementRef: ElementRef;

  easyMDE: EasyMDE;

  constructor(@Optional() parentForm: NgForm) {
    super(parentForm);
  }

  ngAfterViewInit() {
    this.easyMDE = new EasyMDE({
      element: this.elementRef.nativeElement,
      errorCallback: (errorMessage) => {
        console.log(errorMessage);
      },
    });

    this.easyMDE.value(this.model ?? '');
    this.easyMDE.codemirror.on('change', () => {
      this.model = this.easyMDE.value();
    });

    this.elementRef.nativeElement.easyMDE = this.easyMDE;
  }
}
