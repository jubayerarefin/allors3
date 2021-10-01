import { Class } from './class';
import { Interface } from './interface';
import { MetaObject } from './meta-object';
import { MethodType } from './method-type';
import { Unit } from './unit';
import { RelationType } from './relation-type';
import { Composite } from './composite';

// eslint-disable-next-line @typescript-eslint/no-empty-interface
export interface MetaPopulationExtension {}

export interface MetaPopulation {
  readonly kind: 'MetaPopulation';
  _: MetaPopulationExtension;
  metaObjectByTag: Map<string, MetaObject>;
  units: Set<Unit>;
  interfaces: Set<Interface>;
  classes: Set<Class>;
  composites: Set<Composite>;
  relationTypes: Set<RelationType>;
   methodTypes: Set<MethodType>;
}
