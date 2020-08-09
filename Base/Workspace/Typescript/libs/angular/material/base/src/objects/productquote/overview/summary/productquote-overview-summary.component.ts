import { Component, Self, OnInit, OnDestroy, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Subscription, combineLatest } from 'rxjs';
import { switchMap, map } from 'rxjs/operators';
import { isBefore, isAfter } from 'date-fns';

import { TestScope, MetaService, NavigationService, PanelService, MediaService, ContextService, RefreshService, Action, ActionTarget, Invoked } from '@allors/angular/core';
import { Organisation, Person, OrganisationContactRelationship, OrganisationContactKind, SupplierOffering, Part, RatingType, Ordinal, UnitOfMeasure, Currency, Settings, SupplierRelationship, WorkTask, SalesInvoice, FixedAsset, Printable, UnifiedGood, ProductQuote, SalesOrder, RequestForQuote } from '@allors/domain/generated';
import { Meta } from '@allors/meta/generated';
import { ObjectData, SaveService } from '@allors/angular/material/core';
import { FiltersService, FetcherService, InternalOrganisationId, PrintService } from '@allors/angular/base';
import { Sort, ContainedIn, Extent, Equals } from '@allors/data/system';
import { PullRequest } from '@allors/protocol/system';
import { IObject } from '@allors/domain/system';


@Component({
  // tslint:disable-next-line:component-selector
  selector: 'productquote-overview-summary',
  templateUrl: './productquote-overview-summary.component.html',
  providers: [PanelService]
})
export class ProductQuoteOverviewSummaryComponent {

  m: Meta;

  productQuote: ProductQuote;
  salesOrder: SalesOrder;
  request: RequestForQuote;
  print: Action;

  constructor(
    @Self() public panel: PanelService,
    public metaService: MetaService,
    public navigation: NavigationService,
    public printService: PrintService,
    private saveService: SaveService,
    public refreshService: RefreshService,
    public snackBar: MatSnackBar) {

    this.m = this.metaService.m;

    this.print = printService.print();

    panel.name = 'summary';

    const productQuotePullName = `${panel.name}_${this.m.ProductQuote.name}`;
    const salesOrderPullName = `${panel.name}_${this.m.SalesOrder.name}`;
    const requestPullName = `${panel.name}_${this.m.RequestForQuote.name}`;

    panel.onPull = (pulls) => {
      const { pull, x } = this.metaService;

      pulls.push(
        pull.ProductQuote(
          {
            name: productQuotePullName,
            object: this.panel.manager.id,
            include: {
              QuoteItems: {
                Product: x,
                QuoteItemState: x,
              },
              Receiver: x,
              ContactPerson: x,
              QuoteState: x,
              CreatedBy: x,
              LastModifiedBy: x,
              Request: x,
              FullfillContactMechanism: {
                                  PostalAddress_Country: x

              },
              PrintDocument: {
                Media: x,
              }
            }
          }),
        pull.ProductQuote(
          {
            name: salesOrderPullName,
            object: this.panel.manager.id,
            fetch: {
              SalesOrderWhereQuote: x,
            }
          }
        ),
        pull.ProductQuote(
          {
            name: requestPullName,
            object: this.panel.manager.id,
            fetch: {
              Request: x,
            }
          }
        )
      );
    };

    panel.onPulled = (loaded) => {
      this.productQuote = loaded.objects[productQuotePullName] as ProductQuote;
      this.salesOrder = loaded.objects[salesOrderPullName] as SalesOrder;
      this.request = loaded.objects[requestPullName] as RequestForQuote;
    };
  }

  public setReadyForProcessing(): void {

    this.panel.manager.context.invoke(this.productQuote.SetReadyForProcessing)
      .subscribe((invoked: Invoked) => {
        this.refreshService.refresh();
        this.snackBar.open('Successfully set ready for processing.', 'close', { duration: 5000 });
      },
        this.saveService.errorHandler);
  }

  public approve(): void {

    this.panel.manager.context.invoke(this.productQuote.Approve)
      .subscribe(() => {
        this.refreshService.refresh();
        this.snackBar.open('Successfully approved.', 'close', { duration: 5000 });
      },
      this.saveService.errorHandler
    );
  }

  send() {

    this.panel.manager.context.invoke(this.productQuote.Send)
      .subscribe(() => {
        this.refreshService.refresh();
        this.snackBar.open('Successfully sent.', 'close', { duration: 5000 });
      },
      this.saveService.errorHandler);
  }

  accept() {

    this.panel.manager.context.invoke(this.productQuote.Accept)
      .subscribe(() => {
        this.refreshService.refresh();
        this.snackBar.open('Successfully accepted.', 'close', { duration: 5000 });
      },
      this.saveService.errorHandler);
  }
  
  public reopen(): void {

    this.panel.manager.context.invoke(this.productQuote.Reopen)
      .subscribe(() => {
        this.refreshService.refresh();
        this.snackBar.open('Successfully reopened.', 'close', { duration: 5000 });
      },
      this.saveService.errorHandler
    );
  }
  
  public revise(): void {

    this.panel.manager.context.invoke(this.productQuote.Revise)
      .subscribe(() => {
        this.refreshService.refresh();
        this.snackBar.open('Successfully revised.', 'close', { duration: 5000 });
      },
      this.saveService.errorHandler
    );
  }

  public order(): void {

    this.panel.manager.context.invoke(this.productQuote.Order)
      .subscribe(() => {
        this.refreshService.refresh();
        this.snackBar.open('Successfully created a salesorder.', 'close', { duration: 5000 });
      },
      this.saveService.errorHandler);
  }

  public cancel(): void {

    this.panel.manager.context.invoke(this.productQuote.Cancel)
      .subscribe(() => {
        this.refreshService.refresh();
        this.snackBar.open('Successfully cancelled.', 'close', { duration: 5000 });
      },
      this.saveService.errorHandler);
  }

  public reject(): void {

    this.panel.manager.context.invoke(this.productQuote.Reject)
      .subscribe(() => {
        this.refreshService.refresh();
        this.snackBar.open('Successfully rejected.', 'close', { duration: 5000 });
      },
      this.saveService.errorHandler);
  }

  public Order(): void {

    this.panel.manager.context.invoke(this.productQuote.Order)
      .subscribe(() => {
        this.refreshService.refresh();
        this.snackBar.open('SalesOrder successfully created.', 'close', { duration: 5000 });
      },
      this.saveService.errorHandler);
  }
}
