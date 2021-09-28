import { IAsyncDatabaseClient, IWorkspace, IReactiveDatabaseClient } from '@allors/workspace/domain/system';
import '@allors/workspace/domain/default';
import { C1 } from '@allors/workspace/domain/default';

import { SingleSessionContext } from '../../../context/single-session-context';
import { MultipleSessionContext } from '../../../context/multiple-session-context';
import { databaseModes } from '../../../context/modes/database-mode';
import { Fixture } from '../../../../fixture';
import '../../../matchers';

let fixture: Fixture;
let singleSessionContext: SingleSessionContext;
let multipleSessionContext: MultipleSessionContext;

it('dummy', () => {
  // otherwise jest will complain that there are no specs
  expect(true).toBeTruthy();
});

export async function initDatabaseOneToMany(
  asyncClient: IAsyncDatabaseClient,
  reactiveClient: IReactiveDatabaseClient,
  workspace: IWorkspace,
  login: (login: string) => Promise<boolean>,
  createWorkspace: () => IWorkspace,
  createExclusiveWorkspace: () => IWorkspace
) {
  fixture = new Fixture(asyncClient, reactiveClient, workspace, login, createWorkspace, createExclusiveWorkspace);
  singleSessionContext = new SingleSessionContext(fixture, 'Single shared');
  multipleSessionContext = new MultipleSessionContext(fixture, 'Multiple shared');
}

const pushes = [
  // eslint-disable-next-line @typescript-eslint/no-empty-function
  async () => {},
  async (session) => await fixture.client.pushAsync(session),
];

function* contextFactories() {
  yield () => singleSessionContext;
  yield () => new SingleSessionContext(fixture, 'Single');
  yield () => multipleSessionContext;
  yield () => new MultipleSessionContext(fixture, 'Multiple');
}

export async function databaseOneToManySetRole() {
  for (const push of pushes) {
    for (const mode1 of databaseModes) {
      for (const mode2 of databaseModes) {
        for (const contextFactory of contextFactories()) {
          const ctx = contextFactory();
          const { session1, session2 } = ctx;
          const { m, client } = fixture;

          const c1x_1 = await ctx.create<C1>(session1, m.C1, mode1);
          const c1y_2 = await ctx.create<C1>(session2, m.C1, mode2);

          expect(c1x_1).toBeDefined();
          expect(c1y_2).toBeDefined();

          await client.pushAsync(session2);
          const result = await client.pullAsync(session1, { object: c1y_2 });

          const c1y_1 = result.objects.values().next().value as C1;

          expect(c1y_1).toBeDefined();

          if (!c1x_1.canWriteC1C1Many2Manies) {
            await client.pullAsync(session1, { object: c1x_1 });
          }

          c1x_1.addC1C1One2Many(c1y_1);

          expect(c1x_1.C1C1One2Manies.length).toBe(1);
          expect(c1x_1.C1C1One2Manies).toContain(c1y_1);
          expect(c1y_1.C1WhereC1C1One2Many).toBe(c1x_1);

          await push(session1);

          expect(c1x_1.C1C1One2Manies.length).toBe(1);
          expect(c1x_1.C1C1One2Manies).toContain(c1y_1);
          expect(c1y_1.C1WhereC1C1One2Many).toBe(c1x_1);
        }
      }
    }
  }
}

export async function databaseOneToManySetRoleToNull() {
  for (const push of pushes) {
    for (const mode1 of databaseModes) {
      for (const mode2 of databaseModes) {
        for (const contextFactory of contextFactories()) {
          const ctx = contextFactory();
          const { session1, session2 } = ctx;
          const { m, client } = fixture;

          const c1x_1 = await ctx.create<C1>(session1, m.C1, mode1);
          const c1y_2 = await ctx.create<C1>(session2, m.C1, mode2);

          expect(c1x_1).toBeDefined();
          expect(c1y_2).toBeDefined();

          await client.pushAsync(session2);
          const result = await client.pullAsync(session1, { object: c1y_2 });

          const c1y_1 = result.objects.values().next().value as C1;

          expect(c1y_1).toBeDefined();

          if (!c1x_1.canWriteC1C1Many2Manies) {
            await client.pullAsync(session1, { object: c1x_1 });
          }

          c1x_1.addC1C1One2Many(null);

          expect(c1x_1.C1C1One2Manies.length).toBe(0);
          expect(c1y_1.C1WhereC1C1One2Many).toBe(null);

          await push(session1);

          if (!c1x_1.canWriteC1C1Many2Manies) {
            await client.pullAsync(session1, { object: c1x_1 });
          }

          c1x_1.addC1C1One2Many(c1y_1);

          expect(c1x_1.C1C1One2Manies.length).toBe(1);
          expect(c1x_1.C1C1One2Manies).toContain(c1y_1);
          expect(c1y_1.C1WhereC1C1One2Many).toBe(c1x_1);

          await push(session1);

          expect(c1x_1.C1C1One2Manies.length).toBe(1);
          expect(c1x_1.C1C1One2Manies).toContain(c1y_1);
          expect(c1y_1.C1WhereC1C1One2Many).toBe(c1x_1);
        }
      }
    }
  }
}

export async function databaseOneToManyRemoveRole() {
  for (const push of pushes) {
    for (const mode1 of databaseModes) {
      for (const mode2 of databaseModes) {
        for (const contextFactory of contextFactories()) {
          const ctx = contextFactory();
          const { session1, session2 } = ctx;
          const { m, client } = fixture;

          const c1x_1 = await ctx.create<C1>(session1, m.C1, mode1);
          const c1y_2 = await ctx.create<C1>(session2, m.C1, mode2);

          expect(c1x_1).toBeDefined();
          expect(c1y_2).toBeDefined();

          await client.pushAsync(session2);
          const result = await client.pullAsync(session1, { object: c1y_2 });

          const c1y_1 = result.objects.values().next().value as C1;

          expect(c1y_1).toBeDefined();

          if (!c1x_1.canWriteC1C1Many2Manies) {
            await client.pullAsync(session1, { object: c1x_1 });
          }

          c1x_1.addC1C1One2Many(c1y_1);

          await push(session1);

          if (!c1x_1.canWriteC1C1Many2Manies) {
            await client.pullAsync(session1, { object: c1x_1 });
          }

          c1x_1.removeC1C1One2Many(c1y_1);

          expect(c1x_1.C1C1One2Manies.length).toBe(0);
          expect(c1y_1.C1WhereC1C1One2Many).toBe(null);

          await push(session1);

          expect(c1x_1.C1C1One2Manies.length).toBe(0);
          expect(c1y_1.C1WhereC1C1One2Many).toBe(null);
        }
      }
    }
  }
}

export async function databaseOneToManyRemoveNullRole() {
  for (const push of pushes) {
    for (const mode1 of databaseModes) {
      for (const mode2 of databaseModes) {
        for (const contextFactory of contextFactories()) {
          const ctx = contextFactory();
          const { session1, session2 } = ctx;
          const { m, client } = fixture;

          const c1x_1 = await ctx.create<C1>(session1, m.C1, mode1);
          const c1y_2 = await ctx.create<C1>(session2, m.C1, mode2);

          expect(c1x_1).toBeDefined();
          expect(c1y_2).toBeDefined();

          await client.pushAsync(session2);
          const result = await client.pullAsync(session1, { object: c1y_2 });

          const c1y_1 = result.objects.values().next().value as C1;

          expect(c1y_1).toBeDefined();

          if (!c1x_1.canWriteC1C1Many2Manies) {
            await client.pullAsync(session1, { object: c1x_1 });
          }

          c1x_1.addC1C1One2Many(c1y_1);

          await push(session1);

          if (!c1x_1.canWriteC1C1Many2Manies) {
            await client.pullAsync(session1, { object: c1x_1 });
          }

          c1x_1.removeC1C1One2Many(null);

          expect(c1x_1.C1C1One2Manies.length).toBe(1);
          expect(c1x_1.C1C1One2Manies).toContain(c1y_1);
          expect(c1y_1.C1WhereC1C1One2Many).toBe(c1x_1);

          await push(session1);

          expect(c1x_1.C1C1One2Manies.length).toBe(1);
          expect(c1x_1.C1C1One2Manies).toContain(c1y_1);
          expect(c1y_1.C1WhereC1C1One2Many).toBe(c1x_1);

          if (!c1x_1.canWriteC1C1Many2Manies) {
            await client.pullAsync(session1, { object: c1x_1 });
          }

          c1x_1.removeC1C1One2Many(c1y_1);

          expect(c1x_1.C1C1One2Manies.length).toBe(0);
          expect(c1y_1.C1WhereC1C1One2Many).toBe(null);

          await push(session1);

          expect(c1x_1.C1C1One2Manies.length).toBe(0);
          expect(c1y_1.C1WhereC1C1One2Many).toBe(null);
        }
      }
    }
  }
}
