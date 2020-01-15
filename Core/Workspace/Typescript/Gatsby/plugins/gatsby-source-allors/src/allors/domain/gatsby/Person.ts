import { domain } from '../domain';
import { Meta } from '../../meta';
import { Person } from '../generated';

import createSlug from './createSlug';

declare module '../generated/Person.g' {
  interface Person {
    slug;
  }
}

domain.extend((workspace) => {

  const m = workspace.metaPopulation as Meta;
  const organisation = workspace.constructorByObjectType.get(m.Person).prototype as any;

  Object.defineProperty(organisation, 'slug', {
    enumerable: true,
    get(this: Person): string {
      return createSlug(this.FullName);
    },
  });
});
