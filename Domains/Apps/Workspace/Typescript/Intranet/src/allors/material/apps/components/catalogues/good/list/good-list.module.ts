import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MatButtonModule, MatCardModule, MatDividerModule, MatFormFieldModule, MatIconModule, MatListModule, MatMenuModule, MatRadioModule, MatToolbarModule, MatTooltipModule, MatOptionModule, MatSelectModule, MatInputModule, MatGridListModule, MatCheckboxModule, MatChipsModule, MatTableModule, MatSortModule, MatDialogModule, MatPaginatorModule } from '@angular/material';
import { RouterModule } from '@angular/router';

import { AllorsMaterialHeaderModule } from '../../../../../base/components/header';
import { AllorsMaterialFileModule } from '../../../../../base/components/file';
import { AllorsMaterialFilterModule } from '../../../../../base/components/filter';
import { AllorsMaterialInputModule } from '../../../../../base/components/input';
import { AllorsMaterialSelectModule } from '../../../../../base/components/select';
import { AllorsMaterialSideNavToggleModule } from '../../../../../base/components/sidenavtoggle';
import { AllorsMaterialSlideToggleModule } from '../../../../../base/components/slidetoggle';
import { AllorsMaterialStaticModule } from '../../../../../base/components/static';
import { AllorsMaterialTextAreaModule } from '../../../../../base/components/textarea';

import { InternalOrganisationSelectModule } from '../../../common/internalorganisation/internalorganisation-select.module';

import { GoodListComponent } from './good-list.component';
export { GoodListComponent } from './good-list.component';

@NgModule({
  declarations: [
    GoodListComponent,
  ],
  exports: [
    GoodListComponent,
  ],
  imports: [
    AllorsMaterialFileModule,
    AllorsMaterialFilterModule,
    AllorsMaterialHeaderModule,
    AllorsMaterialInputModule,
    AllorsMaterialSelectModule,
    AllorsMaterialSideNavToggleModule,
    AllorsMaterialSlideToggleModule,
    AllorsMaterialStaticModule,
    AllorsMaterialTextAreaModule,
    CommonModule,
    FormsModule,
    InternalOrganisationSelectModule,
    MatButtonModule,
    MatCardModule,
    MatCheckboxModule,
    MatChipsModule,
    MatDialogModule,
    MatDividerModule,
    MatFormFieldModule,
    MatGridListModule,
    MatIconModule,
    MatInputModule,
    MatListModule,
    MatMenuModule,
    MatPaginatorModule,
    MatRadioModule,
    MatSelectModule,
    MatToolbarModule,
    MatTooltipModule,
    MatOptionModule,
    MatTableModule,
    MatSortModule,
    ReactiveFormsModule,
    RouterModule
  ],
  entryComponents: [
  ]
})
export class GoodsOverviewModule { }
