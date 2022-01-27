import { Injectable } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Observable, throwError } from 'rxjs';
import { IObject } from '@allors/system/workspace/domain';
import { Composite } from '@allors/system/workspace/meta';
import {
  CreateData,
  CreateService,
  OnCreate,
} from '@allors/base/workspace/angular/foundation';

@Injectable()
export class AllorsMaterialCreateService extends CreateService {
  createControlByObjectTypeTag: { [id: string]: any };

  constructor(public dialog: MatDialog) {
    super();
  }

  canCreate(objectType: Composite): boolean {
    return !!this.createControlByObjectTypeTag[objectType.tag];
  }

  create(objectType: Composite, onCreate: OnCreate): Observable<IObject> {
    const data: CreateData = {
      kind: 'CreateData',
      objectType,
      onCreate: onCreate,
    };

    const component = this.createControlByObjectTypeTag[objectType.tag];
    if (component) {
      const dialogRef = this.dialog.open(component, {
        data,
        minWidth: '80vw',
        maxHeight: '90vh',
      });

      return dialogRef.afterClosed();
    }

    return throwError(() => new Error('Missing component'));
  }
}
