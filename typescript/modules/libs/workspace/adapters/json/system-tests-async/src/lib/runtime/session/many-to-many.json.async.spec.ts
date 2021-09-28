import { initSessionManyToMany, sessionManyToManySetRole } from '@allors/workspace/adapters/system-tests';
import { Fixture } from '../../fixture';

let fixture: Fixture;

beforeEach(async () => {
  fixture = new Fixture();
  await fixture.init();
  await initSessionManyToMany(
    fixture.asyncDatabaseClient,
    null,
    fixture.databaseConnection.createWorkspace(),
    (login) => fixture.client.login(login),
    () => fixture.databaseConnection.createWorkspace(),
    () => fixture.createDatabaseConnection().createWorkspace()
  );
});

test('sessionManyToManySetRole', async () => {
  await sessionManyToManySetRole();
});

// test('databaseManyToManySetRoleToNull', async () => {
//   await databaseManyToManySetRoleToNull();
// });

// test('databaseManyToManyRemoveRole', async () => {
//   await databaseManyToManyRemoveRole();
// });

// test('databaseManyToManyRemoveNullRole', async () => {
//   await databaseManyToManyRemoveNullRole();
// });
