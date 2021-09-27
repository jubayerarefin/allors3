import { IObject } from '../iobject';
import { IDatabaseDerivationError } from './derivation/idatabase-derivation-error';

export interface IResult {

  hasErrors: boolean;
  
  errorMessage: string;

  versionErrors: IObject[];

  accessErrors: IObject[];

  missingErrors: IObject[];

  derivationErrors: IDatabaseDerivationError[];
}
