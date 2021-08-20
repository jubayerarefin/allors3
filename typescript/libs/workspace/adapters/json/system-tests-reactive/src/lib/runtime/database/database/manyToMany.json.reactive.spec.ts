import { initDatabaseManyToMany, databaseManyToManySetRole } from '@allors/workspace/adapters/system-tests';
import { Fixture } from '../../../Fixture';

let fixture: Fixture;

beforeEach(async () => {
  fixture = new Fixture();
  await fixture.init();
  await initDatabaseManyToMany(
    null,
    fixture.reactiveDatabaseClient,
    fixture.databaseConnection.createWorkspace(),
    (login) => fixture.client.login(login),
    () => fixture.databaseConnection.createWorkspace(),
    () => fixture.createDatabaseConnection().createWorkspace()
  );
});

test('databaseManyToManySetRole', async () => {
  await databaseManyToManySetRole();
});
