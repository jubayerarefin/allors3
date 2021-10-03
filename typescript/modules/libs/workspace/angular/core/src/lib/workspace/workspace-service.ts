import { Injectable } from '@angular/core';
import { IReactiveDatabaseClient, IWorkspace } from '@allors/workspace/domain/system';
import { Context } from '../context/context';

@Injectable({
  providedIn: 'root',
})
export class WorkspaceService {
  workspace: IWorkspace;

  client: IReactiveDatabaseClient;

  contextBuilder: () => Context;
}
