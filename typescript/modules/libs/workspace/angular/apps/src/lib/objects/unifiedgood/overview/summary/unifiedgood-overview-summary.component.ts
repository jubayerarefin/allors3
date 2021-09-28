import { Component, Self } from '@angular/core';

import { MetaService, NavigationService, PanelService } from '@allors/angular/services/core';
import { UnifiedGood } from '@allors/domain/generated';
import { Meta } from '@allors/meta/generated';


@Component({
  // tslint:disable-next-line:component-selector
  selector: 'unifiedgood-overview-summary',
  templateUrl: './unifiedgood-overview-summary.component.html',
  providers: [PanelService]
})
export class UnifiedGoodOverviewSummaryComponent {

  m: M;

  good: UnifiedGood;
  suppliers: string;

  constructor(
    @Self() public panel: PanelService,
    
    public navigation: NavigationService) {

    this.m = this.allors.workspace.configuration.metaPopulation as M;

    panel.name = 'summary';

    const pullName = `${panel.name}_${this.m.UnifiedGood.name}`;

    panel.onPull = (pulls) => {
      const { pullBuilder: pull } = this.m; const x = {};

      const id = this.panel.manager.id;

      pulls.push(
        pull.UnifiedGood({
          name: pullName,
          object: id,
          include: {
            ProductType: x,
            Brand: x,
            Model: x,
            SuppliedBy: x,
            ManufacturedBy: x
          }
        })
      );
    };

    panel.onPulled = (loaded) => {
      this.good = loaded.objects[pullName] as UnifiedGood;

      if (this.good.SuppliedBy.length > 0) {
        this.suppliers = this.good.SuppliedBy
          .map(v => v.displayName)
          .reduce((acc: string, cur: string) => acc + ', ' + cur);
      }
    };
  }
}
