import { MetaPopulation } from '@allors/meta/core';
import { ResponseType, PullResponse } from '@allors/protocol/core';
import { Database } from '@allors/workspace/core';
import { MemoryDatabase } from '@allors/workspace/memory';

import { data, Meta } from '@allors/meta/generated';
import { extend } from '@allors/domain/custom';

import { syncResponse, securityResponse, securityResponse2 } from './fixture';

import 'jest-extended';

describe('Database',
  () => {

    let m: Meta;
    let database: Database;

    beforeEach(() => {
      m = new MetaPopulation(data) as Meta;
      database = new MemoryDatabase(m);
      extend(database);
    });

    it('should have its relations set when synced', () => {
      database.sync(syncResponse(m));

      const martien = database.get('3');

      expect(martien?.id).toBe( '3');
      expect(martien?.version).toBe( '1003');
      expect(martien?.objectType.name).toBe( 'Person');
      expect(martien?.roleByRoleTypeId.get(m.Person.FirstName.relationType.id)).toBe( 'Martien');
      expect(martien?.roleByRoleTypeId.get(m.Person.MiddleName.relationType.id)).toBe( 'van');
      expect(martien?.roleByRoleTypeId.get(m.Person.LastName.relationType.id)).toBe( 'Knippenberg');
      expect(martien?.roleByRoleTypeId.get(m.Person.IsStudent.relationType.id)).toBeUndefined();
      expect(martien?.roleByRoleTypeId.get(m.Person.BirthDate.relationType.id)).toBeUndefined();
    });

    describe('synced with same access control',
      () => {

        beforeEach(() => {
          database.sync(syncResponse(m));
        });

        it('should require load objects only for changed version', () => {
          const pullResponse: PullResponse = {
            hasErrors: false,
            objects: [
              ['101', '1101', '801'],
              ['102', '1102'],
              ['103', '1104'],
            ],
            responseType: ResponseType.Pull,
          };

          const requireLoad = database.diff(pullResponse);

          expect(requireLoad.objects.length).toBe( 1);
          expect(requireLoad.objects[0]).toBe( '103');
        });
      },
    );

    describe('synced with different security',
      () => {
        beforeEach(() => {
          database.sync(syncResponse(m));
        });

        it('should require load objects for all objects', () => {
          const pullResponse: PullResponse = {
            hasErrors: false,
            objects: [
              ['101', '1101', '801', '904'],
              ['102', '1102', '801'],
              ['103', '1103'],
            ],
            responseType: ResponseType.Pull,
          };

          const syncRequest = database.diff(pullResponse);

          expect(syncRequest.objects.length).toBe( 2);
          expect(syncRequest.objects).toIncludeSameMembers( ['101', '102']);
        });
      });


    describe('call security',
      () => {
        beforeEach(() => {
          database.sync(syncResponse(m));
          database.security(securityResponse(m));
        });

        it('with different accesscontrol but already existing permissions', () => {

          const accessControl801 = database.accessControlById.get('801');

          database.security(securityResponse2(m));

          const accessControl802 = database.accessControlById.get('802');

          if (accessControl802?.permissionIds) {
            for (const permission of accessControl802.permissionIds) {
              expect(accessControl801?.permissionIds ?? []).toContain( permission);
            }
          }

        });
      });
  },
);
