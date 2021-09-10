import { Subject } from 'rxjs';

import { Action } from '../../../../components/actions/Action';
import { ActionTarget } from '../../../../components/actions/ActionTarget';
import { NavigationService } from '../../../../services/navigation/navigation.service';

function objectTypeName(target: ActionTarget) {
  return Array.isArray(target) ? target.length > 0 && target[0].strategy.cls.singularName : target.strategy.cls.singularName;
}

export class OverviewAction implements Action {
  name = 'overview';

  constructor(private navigationService: NavigationService) {}

  result = new Subject<boolean>();

  displayName = (target: ActionTarget) => 'Overview';

  description = (target: ActionTarget) => `Go to ${objectTypeName(target)} overview`;

  disabled = () => false;

  execute = (target: ActionTarget) => {
    if (Array.isArray(target)) {
      if (target.length > 0) {
        this.navigationService.overview(target[0]);
      }
    } else {
      this.navigationService.overview(target);
    }

    this.result.next(true);
  };
}
