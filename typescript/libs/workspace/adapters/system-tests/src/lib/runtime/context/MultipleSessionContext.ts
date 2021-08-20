import { Fixture } from '../../Fixture';
import { Context } from './Context';

export class MultipleSessionContext extends Context {
  constructor(fixture: Fixture, name: string) {
    super(fixture, name);
    this.session1 = this.fixture.workspace.createSession();
    this.session2 = this.fixture.workspace.createSession();
  }
}
