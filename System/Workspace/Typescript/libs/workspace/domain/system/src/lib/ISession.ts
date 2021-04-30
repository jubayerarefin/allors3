import { Observable } from "rxjs";
import { Composite,  Class} from "@allors/workspace/meta/system";
import { IObject } from './IObject';
import { IWorkspace } from './IWorkspace';
import { Method } from './operands/Method';
import { InvokeOptions } from './database/InvokeOptions';
import { IInvokeResult } from './database/IInvokeResult';
import { IPullResult } from './database/IPullResult';
import { IPushResult } from './database/IPushResult';
import { ISessionLifecycle } from './state/ISessionLifecycle';
import { Pull } from './data/Pull';
import { Procedure } from './data/Procedure';
import { IChangeSet } from './IChangeSet';

export interface ISession {
  workspace: IWorkspace;

  state: ISessionLifecycle;

  create<T>(cls: Class): T;

  getOne<T>(obj: IObject | T | number | string): T;

  getMany<T>(objects: (IObject | T | number | string)[]): T[];

  getAll<T>(objectType?: Composite): T[];

  invoke(method: Method | Method[], options?: InvokeOptions): Observable<IInvokeResult>;

  pull(pullsOrProceudre: Pull[] | Procedure, pulls?: Pull[]): Observable<IPullResult>;

  push(): Observable<IPushResult>;

  checkpoint(): IChangeSet;

  reset(): void;
}
