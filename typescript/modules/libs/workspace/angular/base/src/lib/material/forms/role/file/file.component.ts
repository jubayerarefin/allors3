import { Component, EventEmitter, Input, Optional, Output } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';

import { ISession } from '@allors/workspace/domain/system';
import { Media } from '@allors/workspace/domain/default';
import { WorkspaceService } from '@allors/workspace/angular/core';
import { M } from '@allors/workspace/meta/default';

import { RoleField } from '../../../../forms/role-field';
import { MediaService } from '../../../../media/media.service';

@Component({
  selector: 'a-mat-file',
  templateUrl: './file.component.html',
})
export class AllorsMaterialFileComponent extends RoleField {
  @Output()
  changed: EventEmitter<RoleField> = new EventEmitter<RoleField>();

  @Input()
  accept = '*/*';

  constructor(@Optional() parentForm: NgForm, private dialog: MatDialog, private mediaService: MediaService, private workspaceService: WorkspaceService) {
    super(parentForm);
  }

  get media(): Media {
    return this.model;
  }

  set media(value: Media) {
    this.model = value;
  }

  get fieldValue(): string {
    return this.media ? '1 file' : '';
  }

  get src(): string | null {
    if (this.media.InDataUri) {
      return this.media.InDataUri;
    } else if (this.media.UniqueId) {
      return this.mediaService.url(this.media);
    }

    return null;
  }

  public delete(): void {
    this.model = undefined;
  }

  public onFileInput(event: Event) {
    const input = event.target as HTMLInputElement;
    const files = input.files;
    if (files?.length && files.length > 0) {
      const file = files.item(0);

      if (file != null) {
        const session: ISession = this.object.strategy.session;
        const m = this.workspaceService.workspace.configuration.metaPopulation as M;
        const media = session.create<Media>(m.Media);
        media.InType = file.type;

        const reader: FileReader = new FileReader();
        const load: () => void = () => {
          media.InFileName = file.name;
          media.InDataUri = reader.result as string;
          this.media = media;
          this.changed.emit(this);
        };

        reader.addEventListener('load', load, false);
        reader.readAsDataURL(file);
      }
    }
  }
}
