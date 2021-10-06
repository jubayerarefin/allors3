import { SingleSessionContext, MultipleSessionContext, databaseModes } from '../../../context';
import { C1 } from '@allors/workspace/domain/default';
import { Fixture } from '../../../../fixture';
import '../../../../matchers';

const pushes = [
  // eslint-disable-next-line @typescript-eslint/no-empty-function
  async () => {},
  async (session) => await session.push(),
];

function* contextFactories() {
  yield () => singleSessionContext;
  // yield () => new SingleSessionContext(fixture, 'Single');
  yield () => multipleSessionContext;
  // yield () => new MultipleSessionContext(fixture, 'Multiple');
}

let fixture: Fixture;
let singleSessionContext: SingleSessionContext;
let multipleSessionContext: MultipleSessionContext;

beforeEach(async () => {
  fixture = new Fixture();
  await fixture.init();
  singleSessionContext = new SingleSessionContext(fixture, 'Single shared');
  multipleSessionContext = new MultipleSessionContext(fixture, 'Multiple shared');
});

test('databaseManyToOneSetRole', async () => {
  for (const push of pushes) {
    for (const mode1 of databaseModes) {
      for (const mode2 of databaseModes) {
        for (const contextFactory of contextFactories()) {
          const ctx = contextFactory();
          const { session1, session2 } = ctx;
          const { m } = fixture;

          const c1x_1 = await ctx.create<C1>(session1, m.C1, mode1);
          const c1y_2 = await ctx.create<C1>(session2, m.C1, mode2);

          expect(c1x_1).toBeDefined();
          expect(c1y_2).toBeDefined();

          await session2.push();
          const result = await session1.pull({ object: c1y_2 });

          const c1y_1 = result.objects.values().next().value as C1;

          expect(c1y_1).toBeDefined();

          if (!c1x_1.canWriteC1C1Many2Manies) {
            await session1.pull({ object: c1x_1 });
          }

          c1x_1.C1C1Many2One = c1y_1;

          expect(c1x_1.C1C1Many2One).toBe(c1y_1);
          expect(c1y_1.C1sWhereC1C1Many2One.length).toBe(1);
          expect(c1y_1.C1sWhereC1C1Many2One).toContain(c1x_1);

          await push(session1);

          expect(c1x_1.C1C1Many2One).toBe(c1y_1);
          expect(c1y_1.C1sWhereC1C1Many2One.length).toBe(1);
          expect(c1y_1.C1sWhereC1C1Many2One).toContain(c1x_1);
        }
      }
    }
  }
});

test('databaseManyToOneRemoveRole', async () => {
  for (const push of pushes) {
    for (const mode1 of databaseModes) {
      for (const mode2 of databaseModes) {
        for (const contextFactory of contextFactories()) {
          const ctx = contextFactory();
          const { session1, session2 } = ctx;
          const { m } = fixture;

          const c1x_1 = await ctx.create<C1>(session1, m.C1, mode1);
          const c1y_2 = await ctx.create<C1>(session2, m.C1, mode2);

          expect(c1x_1).toBeDefined();
          expect(c1y_2).toBeDefined();

          await session2.push();
          const result = await session1.pull({ object: c1y_2 });

          const c1y_1 = result.objects.values().next().value as C1;

          expect(c1y_1).toBeDefined();

          if (!c1x_1.canWriteC1C1Many2One) {
            await session1.pull({ object: c1x_1 });
          }

          c1x_1.C1C1Many2One = c1y_1;

          await push(session1);

          if (!c1x_1.canWriteC1C1Many2One) {
            await session1.pull({ object: c1x_1 });
          }

          c1x_1.C1C1Many2One = null;

          expect(c1x_1.C1C1Many2One).toBeNull();
          expect(c1y_1.C1sWhereC1C1Many2One.length).toBe(0);

          await push(session1);

          expect(c1x_1.C1C1Many2One).toBeNull();
          expect(c1y_1.C1sWhereC1C1Many2One.length).toBe(0);
        }
      }
    }
  }
});
