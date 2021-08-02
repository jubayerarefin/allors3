import { assert } from '@allors/workspace/meta/system';
import { ISession, IObject } from '@allors/workspace/domain/system';
import { PullResponse } from '@allors/protocol/system';

export class Loaded {
  public objects: { [name: string]: IObject } = {};
  public collections: { [name: string]: IObject[] } = {};
  public values: { [name: string]: any } = {};

  constructor(public session: ISession, public response: PullResponse) {
    const namedObjects = response.namedObjects;
    const namedCollections = response.namedCollections;
    const namedValues = response.namedValues;

    if (namedObjects) {
      Object.keys(namedObjects).map((key: string) => {
        const object = session.get(namedObjects[key]);
        assert(object);
        this.objects[key] = object;
      });
    }

    if (namedCollections) {
      Object.keys(namedCollections).map((key: string) => {
        const collection = namedCollections[key].map((id: string) => {
          const object = session.get(id);
          assert(object);
          return object;
        });

        this.collections[key] = collection;
      });
    }

    if (namedValues) {
      Object.keys(namedValues).map((key: string) => (this.values[key] = namedValues[key]));
    }
  }
}
