import { ISession } from '../runtime/ISession';
import { Method } from '../runtime/Method';

import { IInvokeResult } from './pull/IInvokeResult';
import { InvokeOptions } from './pull/InvokeOptions';
import { IPullResult } from './pull/IPullResult';
import { Procedure } from './pull/Procedure';
import { Pull } from './pull/Pull';
import { IPushResult } from './push/IPushResult';

import type { Observable } from 'rxjs';

export interface IReactiveDatabaseClient {
  invokeReactive(session: ISession, method: Method | Method[], options?: InvokeOptions): Observable<IInvokeResult>;

  callReactive(session: ISession, procedure: Procedure, ...pulls: Pull[]): Observable<IPullResult>;

  pullReactive(session: ISession, pulls: Pull[]): Observable<IPullResult>;

  pushReactive(session: ISession): Observable<IPushResult>;
}
