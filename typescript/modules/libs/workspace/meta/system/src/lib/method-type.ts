import { Composite } from './composite';
import { MetaObject } from './meta-object';
import { OperandType } from './operand-type';

export interface MethodType extends MetaObject, OperandType {
  kind: 'MethodType';
  objectType: Composite;
}
