import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { IObject } from '@allors/workspace/domain/system';
import { Composite } from '@allors/workspace/meta/system';
import { WorkspaceService } from '@allors/workspace/angular/core';

import { NavigationService } from '../../services/navigation/navigation.service';
import { angularList } from '../../meta/angular.list';
import { angularOverview } from '../../meta/angular.overview';

@Injectable({
  providedIn: 'root',
})
export class NavigationServiceCore extends NavigationService {
  constructor(private router: Router, private workspaceService: WorkspaceService) {
    super();
  }

  hasList(obj: IObject): boolean {
    const list = obj ? angularList(obj.strategy.cls) : null;
    return list != null;
  }

  list(objectType: Composite) {
    const url = angularList(objectType);
    if (url != null) {
      this.router.navigate([url]);
    }
  }

  hasOverview(obj: IObject): boolean {
    const overview = obj ? angularOverview(obj.strategy.cls) : null;
    return overview != null;
  }

  overview(object: IObject) {
    const overview = object ? angularOverview(object.strategy.cls) : null;
    const url = overview?.replace(`:id`, object.strategy.id.toString());
    if (url != null) {
      this.router.navigate([url]);
    }
  }
}
