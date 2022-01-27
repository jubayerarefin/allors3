import { Composite } from '@allors/system/workspace/meta';
import { CreateRequestArgument } from './create-request-argument';

export interface CreateRequest {
  readonly kind: 'CreateRequest';
  objectType: Composite;
  arguments?: CreateRequestArgument[];
}
