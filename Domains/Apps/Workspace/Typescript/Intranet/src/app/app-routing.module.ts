import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import * as ap from '../allors/material/apps/components/accountspayable';
import * as ar from '../allors/material/apps/components/accountsreceivable';
import * as catalogues from '../allors/material/apps/components/catalogues';
import * as orders from '../allors/material/apps/components/orders';
import * as relations from '../allors/material/apps/components/relations';
import * as workefforts from '../allors/material/apps/components/workefforts';

import { AuthorizationService } from './auth/authorization.service';
import { LoginComponent } from './auth/login.component';
import { MainComponent } from './main/main.component';
import { DashboardComponent } from './dashboard/dashboard.component';


// tslint:disable:object-literal-sort-keys
export const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { canActivate: [AuthorizationService],  path: 'printinvoice/:id', component: ar.InvoicePrintComponent },
  { canActivate: [AuthorizationService],  path: 'printsalesorder/:id', component: orders.SalesOrderPrintComponent },
  { canActivate: [AuthorizationService],  path: 'printproductquote/:id', component: orders.ProductQuotePrintComponent },
  { canActivate: [AuthorizationService],  path: 'printworktask/:id', component: workefforts.WorkTaskPrintComponent },
  {
    canActivate: [AuthorizationService],
    path: '', component: MainComponent,
    children: [
      {
        path: '', component: DashboardComponent, data: { type: 'module', title: 'Home', icon: 'home' },
      },
      // Relations
      {
        path: 'relations', data: { type: 'module', title: 'Relations', icon: 'dashboard' },
        children: [
          { path: 'people', component: relations.PeopleOverviewComponent, data: { type: 'page', title: 'People', icon: 'people' }},
          { path: 'person/:id', component: relations.PersonOverviewComponent },
          { path: 'organisations', component: relations.OrganisationsOverviewComponent, data: { type: 'page', title: 'Organisations', icon: 'business' } },
          { path: 'organisation/:id', component: relations.OrganisationOverviewComponent },
          { path: 'communicationevents', component: relations.CommunicationEventsOverviewComponent, data: { type: 'page', title: 'Communications', icon: 'share' } },
          { path: 'party/:id/communicationevent/:roleId', component: relations.CommunicationEventOverviewComponent },
        ],
      },
      {
        path: 'person',
        children: [
          { path: '', component: relations.PersonComponent },
          { path: ':id', component: relations.PersonComponent },
          { path: 'organisation/:organisationId', component: relations.PersonComponent },
        ],
      },
      {
        path: 'export',
        children: [
          { path: 'people', component: relations.PeopleExportComponent },
        ],
      },
      {
        path: 'organisation',
        children: [
          { path: '', component: relations.OrganisationComponent },
          { path: ':id', component: relations.OrganisationComponent },
        ],
      },
      {
        path: 'party',
        children: [
          { path: ':id/partycontactmechanism/emailaddress', component: relations.PartyContactMechanismEmailAddressAddComponent },
          { path: ':id/partycontactmechanism/emailaddress/:roleId', component: relations.PartyContactMechanismEmailAddressEditComponent },
          { path: ':id/partycontactmechanism/postaladdress', component: relations.PartyContactMechanismPostalAddressAddComponent },
          { path: ':id/partycontactmechanism/postaladdress/:roleId', component: relations.PartyContactMechanismPostalAddressEditComponent },
          { path: ':id/partycontactmechanism/telecommunicationsnumber', component: relations.PartyContactMechanismTelecommunicationsNumberAddComponent },
          { path: ':id/partycontactmechanism/telecommunicationsnumber/:roleId', component: relations.PartyContactMechanismTelecommunicationsNumberEditComponent },
          { path: ':id/partycontactmechanism/webaddress', component: relations.PartyContactMechanismAddWebAddressComponent },
          { path: ':id/partycontactmechanism/webaddress/:roleId', component: relations.PartyContactMechanismEditWebAddressComponent },

          { path: ':id/communicationevent/emailcommunication/:roleId', component: relations.PartyCommunicationEventEmailCommunicationComponent },
          { path: ':id/communicationevent/emailcommunication', component: relations.PartyCommunicationEventEmailCommunicationComponent },
          { path: ':id/communicationevent/facetofacecommunication/:roleId', component: relations.PartyCommunicationEventFaceToFaceCommunicationComponent },
          { path: ':id/communicationevent/facetofacecommunication', component: relations.PartyCommunicationEventFaceToFaceCommunicationComponent },
          { path: ':id/communicationevent/lettercorrespondence/:roleId', component: relations.PartyCommunicationEventLetterCorrespondenceComponent },
          { path: ':id/communicationevent/lettercorrespondence', component: relations.PartyCommunicationEventLetterCorrespondenceComponent },
          { path: ':id/communicationevent/phonecommunication/:roleId', component: relations.PartyCommunicationEventPhoneCommunicationComponent },
          { path: ':id/communicationevent/phonecommunication', component: relations.PartyCommunicationEventPhoneCommunicationComponent },
        ],
      },
      {
        path: 'communicationevent',
        children: [
          { path: ':id/worktask', component: relations.PartyCommunicationEventWorkTaskComponent },
          { path: ':id/worktask/:roleId', component: relations.PartyCommunicationEventWorkTaskComponent },
        ],
      },

      // Orders
      {
        path: 'orders', data: { type: 'module', title: 'Orders', icon: 'share' },
        children: [
          { path: '', component: orders.OrdersOverviewComponent },
          { path: 'requests', component: orders.RequestsOverviewComponent, data: { type: 'page', title: 'Requests', icon: 'share' } },
          { path: 'request/:id', component: orders.RequestOverviewComponent },
          { path: 'productQuotes', component: orders.ProductQuotesOverviewComponent, data: { type: 'page', title: 'Quotes', icon: 'share' } },
          { path: 'productQuote/:id', component: orders.ProductQuoteOverviewComponent },
          { path: 'salesOrders', component: orders.SalesOrdersOverviewComponent, data: { type: 'page', title: 'Orders', icon: 'share' } },
          { path: 'salesOrder/:id', component: orders.SalesOrderOverviewComponent },
        ],
      },
      {
        path: 'request',
        children: [
          { path: '', component: orders.RequestEditComponent },
          { path: ':id', component: orders.RequestEditComponent },
          { path: ':id/item', component: orders.RequestItemEditComponent },
          { path: ':id/item/:itemId', component: orders.RequestItemEditComponent },
        ],
      },
      {
        path: 'productQuote',
        children: [
          { path: '', component: orders.ProductQuoteEditComponent },
          { path: ':id', component: orders.ProductQuoteEditComponent },
          { path: ':id/item', component: orders.QuoteItemEditComponent },
          { path: ':id/item/:itemId', component: orders.QuoteItemEditComponent },
        ],
      },
      {
        path: 'salesOrder',
        children: [
          { path: '', component: orders.SalesOrderEditComponent },
          { path: ':id', component: orders.SalesOrderEditComponent },
          { path: ':id/item', component: orders.SalesOrderItemEditComponent },
          { path: ':id/item/:itemId', component: orders.SalesOrderItemEditComponent },
          { path: ':id/incoterm', component: orders.IncoTermEditComponent },
          { path: ':id/incoterm/:termId', component: orders.IncoTermEditComponent },
          { path: ':id/invoiceterm', component: orders.InvoiceTermEditComponent },
          { path: ':id/invoiceterm/:termId', component: orders.InvoiceTermEditComponent },
          { path: ':id/orderterm', component: orders.OrderTermEditComponent },
          { path: ':id/orderterm/:termId', component: orders.OrderTermEditComponent },
        ],
      },

      // Catalogues
      {
        path: 'catalogues', data: { type: 'module', title: 'Catalogues', icon: 'share' },
        children: [
          { path: 'catalogues', component: catalogues.CataloguesOverviewComponent, data: { type: 'page', title: 'Catalogues', icon: 'share' } },
          { path: 'categories', component: catalogues.CategoriesOverviewComponent, data: { type: 'page', title: 'Categories', icon: 'share' } },
          { path: 'goods', component: catalogues.GoodsOverviewComponent, data: { type: 'page', title: 'Products', icon: 'share' } },
          { path: 'productCharacteristics', component: catalogues.ProductCharacteristicsOverviewComponent, data: { type: 'page', title: 'Product Characteristics', icon: 'share' } },
          { path: 'productTypes', component: catalogues.ProductTypesOverviewComponent, data: { type: 'page', title: 'Product Types', icon: 'share' } },
        ],
      },
      {
        path: 'catalogue',
        children: [
          { path: '', component: catalogues.CatalogueComponent },
          { path: ':id', component: catalogues.CatalogueComponent },
        ],
      },
      {
        path: 'category',
        children: [
          { path: '', component: catalogues.CategoryComponent },
          { path: ':id', component: catalogues.CategoryComponent },
        ],
      },
      {
        path: 'nonSerialisedGood',
        children: [
          { path: ':id', component: catalogues.NonSerialisedGoodComponent },
          { path: '', component: catalogues.NonSerialisedGoodComponent },
        ],
      },
      {
        path: 'serialisedGood',
        children: [
          { path: ':id', component: catalogues.SerialisedGoodComponent },
          { path: '', component: catalogues.SerialisedGoodComponent },
        ],
      },
      {
        path: 'productCharacteristic',
        children: [
          { path: '', component: catalogues.ProductCharacteristicComponent },
          { path: ':id', component: catalogues.ProductCharacteristicComponent },
        ],
      },
      {
        path: 'productType',
        children: [
          { path: '', component: catalogues.ProductTypeComponent },
          { path: ':id', component: catalogues.ProductTypeComponent },
        ],
      },

      // Accounts Payable
      {
        path: 'accountspayable', data: { type: 'module', title: 'Accounts Payable', icon: 'dashboard' },
        children: [
          { path: 'invoices', component: ap.InvoicesOverviewComponent, data: { type: 'page', title: 'Invoices', icon: 'attach_money' } },
          { path: 'invoice/:id', component: ap.InvoiceOverviewComponent },
        ],
      },
      {
        path: 'purchaseinvoice',
        children: [
          { path: '', component: ap.InvoiceComponent },
          { path: ':id', component: ap.InvoiceComponent },
          { path: ':id/item', component: ap.InvoiceItemEditComponent },
          { path: ':id/item/:itemId', component: ap.InvoiceItemEditComponent },
        ],
      },

      // Accounts Receivable
      {
        path: 'accountsreceivable', data: { type: 'module', title: 'Accounts Receivable', icon: 'dashboard' },
        children: [
          { path: 'invoices', component: ar.InvoicesOverviewComponent, data: { type: 'page', title: 'Invoices', icon: 'attach_money' } },
          { path: 'invoice/:id', component: ar.InvoiceOverviewComponent },
        ],
      },
      {
        path: 'salesinvoice',
        children: [
          { path: '', component: ar.InvoiceComponent },
          { path: ':id', component: ar.InvoiceComponent },
          { path: ':id/item', component: ar.InvoiceItemEditComponent },
          { path: ':id/repeat', component: ar.RepeatingInvoiceEditComponent },
          { path: ':id/repeat/:repeatingInvoiceId', component: ar.RepeatingInvoiceEditComponent },
          { path: ':id/item/:itemId', component: ar.InvoiceItemEditComponent },
          { path: ':id/incoterm', component: ar.IncoTermEditComponent },
          { path: ':id/incoterm/:termId', component: ar.IncoTermEditComponent },
          { path: ':id/invoiceterm', component: ar.InvoiceTermEditComponent },
          { path: ':id/invoiceterm/:termId', component: ar.InvoiceTermEditComponent },
          { path: ':id/orderterm', component: ar.OrderTermEditComponent },
          { path: ':id/orderterm/:termId', component: ar.OrderTermEditComponent },
        ],
      },

      // WorkEfforts
      {
        path: 'workefforts', data: { type: 'module', title: 'Work Efforts', icon: 'work' },
        children: [
          { path: '', component: workefforts.WorkEffortsOverviewComponent },
          { path: 'worktasks', component: workefforts.WorkTasksOverviewComponent, data: { type: 'page', title: 'Tasks', icon: 'timer' } },
          { path: 'worktask/:id', component: workefforts.WorkTaskOverviewComponent },
        ],
      },
      {
        path: 'worktask',
        children: [
          { path: '', component: workefforts.WorkTaskEditComponent },
          { path: ':id', component: workefforts.WorkTaskEditComponent },
        ],
      },

    ],
  },
];
// tslint:enable:object-literal-sort-keys
@NgModule({
  exports: [RouterModule],
  imports: [RouterModule.forRoot(routes)],
})
export class AppRoutingModule { }
