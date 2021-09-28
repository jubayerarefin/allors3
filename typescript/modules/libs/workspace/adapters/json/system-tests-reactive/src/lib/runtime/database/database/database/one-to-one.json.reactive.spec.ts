import { initDatabaseOneToOne, databaseOneToOneSetRole, databaseOneToOneRemoveRole } from '@allors/workspace/adapters/system-tests';
import { Fixture } from '../../../../fixture';

let fixture: Fixture;

beforeEach(async () => {
  fixture = new Fixture();
  await fixture.init();
  await initDatabaseOneToOne(
    null,
    fixture.reactiveDatabaseClient,
    fixture.databaseConnection.createWorkspace(),
    (login) => fixture.client.login(login),
    () => fixture.databaseConnection.createWorkspace(),
    () => fixture.createDatabaseConnection().createWorkspace()
  );
});

test('databaseOneToOneSetRole', async () => {
  await databaseOneToOneSetRole();
});

test('databaseOneToOneRemoveRole', async () => {
  await databaseOneToOneRemoveRole();
});
