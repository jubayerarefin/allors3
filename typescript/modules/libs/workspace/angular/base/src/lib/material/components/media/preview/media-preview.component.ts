import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

import { Media } from '@allors/workspace/domain/default';

import { MediaService } from '../../../../services/media/media.service';

import { MediaDialogData } from './dialog.data';
import { isImage } from '../media';

@Component({
  templateUrl: './media-preview.component.html',
})
export class AllorMediaPreviewComponent {
  media: Media;

  constructor(public dialogRef: MatDialogRef<AllorMediaPreviewComponent>, @Inject(MAT_DIALOG_DATA) public data: MediaDialogData, private mediaService: MediaService) {
    this.media = data.media;
  }

  get src(): string | null {
    if (this.media.InDataUri) {
      return this.media.InDataUri;
    } else if (this.media.UniqueId) {
      return this.mediaService.url(this.media);
    }

    return null;
  }

  get isImage(): boolean {
    return isImage(this.media);
  }
}