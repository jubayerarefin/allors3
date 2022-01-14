import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Context } from '@allors/workspace/angular/core';
import {
  Action,
  RefreshService,
  SaveService,
} from '@allors/workspace/angular/base';
import { AllorsMaterialDialogService } from '../../dialog/dialog.service';
import { DeleteAction } from './delete-action';

@Injectable({
  providedIn: 'root',
})
export class DeleteService {
  constructor(
    private refreshService: RefreshService,
    private dialogService: AllorsMaterialDialogService,
    private saveService: SaveService,
    private snackBar: MatSnackBar
  ) {}

  delete(context: Context): Action {
    return new DeleteAction(
      this.refreshService,
      this.dialogService,
      this.saveService,
      this.snackBar,
      context
    );
  }
}
