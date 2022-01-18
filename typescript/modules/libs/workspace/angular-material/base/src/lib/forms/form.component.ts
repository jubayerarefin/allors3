import { HostBinding, Directive, EventEmitter, Output } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Class } from '@allors/workspace/meta/system';
import { M } from '@allors/workspace/meta/default';
import { IObject } from '@allors/workspace/domain/system';
import { Context, ContextService } from '@allors/workspace/angular/core';
import {
  AllorsComponent,
  AllorsForm,
  SaveService,
} from '@allors/workspace/angular/base';

@Directive()
export abstract class AllorsFormComponent<T extends IObject>
  extends AllorsComponent
  implements AllorsForm
{
  dataAllorsKind = 'form';

  @HostBinding('attr.data-allors-id')
  get dataAllorsId() {
    return this.object?.strategy.id;
  }

  context: Context;
  m: M;
  object: T;

  @Output()
  saved: EventEmitter<IObject> = new EventEmitter();

  @Output()
  cancelled: EventEmitter<void> = new EventEmitter();

  constructor(
    allors: ContextService,
    private saveService: SaveService,
    public form: NgForm
  ) {
    super();

    this.context = allors.context;
    this.context.name = this.constructor.name;
    this.m = this.context.configuration.metaPopulation as M;
  }

  get canSave() {
    return this.form.form.valid && this.context.hasChanges();
  }

  get canWrite() {
    // TODO: From meta
    return true;
  }

  create(objectType: Class): void {
    this.object = this.context.create<T>(objectType);
  }

  edit(objectId: number): void {
    this.context.pull({ objectId }).subscribe((loaded) => {
      this.object = loaded.objects.values().next()?.value;
    });
  }

  save(): void {
    this.context.push().subscribe({
      next: () => {
        this.saved.emit(this.object);
      },
      error: (error) => {
        this.saveService.errorHandler(error);
      },
    });
  }

  cancel(): void {
    this.cancelled.emit();
  }
}
