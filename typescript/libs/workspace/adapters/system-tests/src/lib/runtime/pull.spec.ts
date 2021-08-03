import { IClientAsync, IWorkspace, Pull } from '@allors/workspace/domain/system';
import { Fixture, name_c1B, name_c2B } from '../Fixture';
import '../Matchers';
import '@allors/workspace/domain/core';

let fixture: Fixture;

it('dummy', () => {
  expect(true).toBeTruthy();
});

export async function initPull(client: IClientAsync, workspace: IWorkspace, login: (login: string) => Promise<boolean>) {
  fixture = new Fixture(client, workspace, login);
}

export async function andGreaterThanLessThan() {
  const { client, workspace, m } = fixture;
  const session = workspace.createSession();

  //  Class
  let pull: Pull = {
    extent: {
      kind: 'Filter',
      objectType: m.C1,
      predicate: {
        kind: 'And',
        operands: [
          {
            kind: 'GreaterThan',
            roleType: m.C1.C1AllorsInteger,
            value: 0,
          },
          {
            kind: 'LessThan',
            roleType: m.C1.C1AllorsInteger,
            value: 2,
          },
        ],
      },
    },
  };

  let result = await client.pullAsync(session, [pull]);

  expect(result.collections.size).toBe(1);
  expect(result.objects.size).toBe(0);
  expect(result.values.size).toBe(0);

  const c1s = result.collection('C1s');

  expect(c1s).toEqualObjects([name_c1B]);

  //  Interface
  pull = {
    extent: {
      kind: 'Filter',
      objectType: m.I12,
      predicate: {
        kind: 'And',
        operands: [
          {
            kind: 'GreaterThan',
            roleType: m.I12.I12AllorsInteger,
            value: 0,
          },
          {
            kind: 'LessThan',
            roleType: m.I12.I12AllorsInteger,
            value: 2,
          },
        ],
      },
    },
  };

  result = await client.pullAsync(session, [pull]);

  expect(result.collections.size).toEqual(1);
  expect(result.objects.size).toBe(0);
  expect(result.values.size).toBe(0);

  const i12s = result.collection('I12s');
  expect(i12s).toEqualObjects([name_c1B, name_c2B]);
}
