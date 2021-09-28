import { deniedPermissions, initSecurity, withAccessControl, withoutAccessControl, withoutPermissions } from '@allors/workspace/adapters/system-tests';
import { Fixture } from '../fixture';

let fixture: Fixture;

beforeEach(async () => {
  fixture = new Fixture();
  await fixture.init();
  await initSecurity(null, fixture.reactiveDatabaseClient, fixture.databaseConnection.createWorkspace(), (login) => fixture.client.login(login));
});

test('withAccessControl', async () => {
  await withAccessControl();
});

test('withoutAccessControl', async () => {
  await withoutAccessControl();
});

test('withoutPermissions', async () => {
  await withoutPermissions();
});

test('deniedPermissions', async () => {
  await deniedPermissions();
});
