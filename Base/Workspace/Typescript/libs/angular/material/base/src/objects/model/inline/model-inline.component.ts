import { Component, Output, EventEmitter, OnInit, OnDestroy, Input } from '@angular/core';

import { ContextService, MetaService } from '@allors/angular/core';
import { PartyContactMechanism, ContactMechanismPurpose, EmailAddress, Facility, FacilityType, Organisation, Model } from '@allors/domain/generated';
import { Meta } from '@allors/meta/generated';
import { Equals, Sort } from '@allors/data/system';
import { PullRequest } from '@allors/protocol/system';
import { FetcherService } from '@allors/angular/base';


@Component({
  // tslint:disable-next-line:component-selector
  selector: 'model-inline',
  templateUrl: './model-inline.component.html',
})
export class InlineModelComponent implements OnInit, OnDestroy {
  @Output() public saved: EventEmitter<Model> = new EventEmitter<Model>();

  @Output() public cancelled: EventEmitter<any> = new EventEmitter();

  public model: Model;

  public m: Meta;

  constructor(
    private allors: ContextService,
    private metaService: MetaService,
    ) {

    this.m = this.metaService.m;
  }

  ngOnInit(): void {
    this.model = this.allors.context.create('Model') as Model;
  }

  public ngOnDestroy(): void {
    if (!!this.model) {
      this.allors.context.delete(this.model);
    }
  }

  public cancel(): void {
    this.cancelled.emit();
  }

  public save(): void {
      this.saved.emit(this.model);
      this.model = undefined;
  }
}