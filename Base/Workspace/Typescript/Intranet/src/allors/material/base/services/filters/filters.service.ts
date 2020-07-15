import { Observable } from 'rxjs';
import { SearchFactory } from '../../../../angular';

export abstract class FiltersService {
    customersFilter: SearchFactory;
    employeeFilter: SearchFactory;
    goodsFilter: SearchFactory;
    serialisedgoodsFilter: SearchFactory;
    internalOrganisationsFilter: SearchFactory;
    nonUnifiedPartsFilter: SearchFactory;
    unifiedGoodsFilter: SearchFactory;
    organisationsFilter: SearchFactory;
    partiesFilter: SearchFactory;
    partsFilter: SearchFactory;
    peopleFilter: SearchFactory;
    serialisedItemsFilter: SearchFactory;
    subContractorsFilter: SearchFactory;
    suppliersFilter: SearchFactory;
    allSuppliersFilter: SearchFactory;
    workEffortsFilter: SearchFactory;
}
