import {
  initDiff,
  databaseUnitDiff,
  databaseUnitDiffAfterReset,
  databaseUnitDiffAfterDoubleReset,
  databaseMultipleUnitDiff,
  workspaceUnitDiff,
  workspaceUnitDiffAfterReset,
} from '@allors/workspace/adapters/system-tests';
import { Fixture } from '../fixture';

let fixture: Fixture;

beforeEach(async () => {
  fixture = new Fixture();
  await fixture.init();
  await initDiff(fixture.asyncDatabaseClient, null, fixture.databaseConnection.createWorkspace(), (login) => fixture.client.login(login));
});

test('databaseUnitDiff', async () => {
  await databaseUnitDiff();
});

test('databaseUnitDiffAfterReset', async () => {
  await databaseUnitDiffAfterReset();
});

test('databaseUnitDiffAfterDoubleReset', async () => {
  await databaseUnitDiffAfterDoubleReset();
});

test('databaseMultipleUnitDiff', async () => {
  await databaseMultipleUnitDiff();
});

test('workspaceUnitDiff', async () => {
  await workspaceUnitDiff();
});

test('workspaceUnitDiffAfterReset', async () => {
  await workspaceUnitDiffAfterReset();
});
