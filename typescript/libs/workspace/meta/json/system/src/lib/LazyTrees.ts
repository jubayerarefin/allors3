import { MetaPopulation } from '@allors/workspace/meta/system';

export class LazyTrees {
  constructor(metaPopulation: MetaPopulation) {
    for (const composite of metaPopulation.composites) {
      this[composite.singularName] = (obj) => {
        const entries = Object.entries(obj);
        return entries.length > 0
          ? entries.map(([key, value]) => {
              const propertyType = composite.propertyTypeByPropertyName.get(key);
              return value != null
                ? {
                    propertyType,
                    nodes: this[propertyType.objectType.singularName](value),
                  }
                : {
                    propertyType,
                  };
            })
          : undefined;
      };
    }
  }
}
