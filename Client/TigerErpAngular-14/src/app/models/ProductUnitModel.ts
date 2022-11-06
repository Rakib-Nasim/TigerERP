export class ProductUnitModel {
    id: number;
    productId: number;
    productName: string | null;
    unitId: number;
    unitName: string | null;
    factor: number;
    compId: number;
    isDefaultBillUnit: number | null;
    isDefaultChallanUnit: number | null;
}