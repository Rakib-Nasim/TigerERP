import { ProductCategoryModel } from "./ProductCategoryModel";
import { ProductColorModel } from "./ProductColorModel";
import { ProductUnitModel } from "./ProductUnitModel";

export class ProductModel {
    id: number;
    productId: number | null;
    name: string | null;
    description: string | null;
    unitId: number | null;
    compId: number;
    categoryId: number | null;
    categoryName: string | null;
    costPrice: number | null;
    salePrice: number | null;
    productType: number | null;
    brandId: number | null;
    brandName: string | null;
    originId: number | null;
    billUnitId: number | null;
    moduleId: number | null;
    colorId: number | null;
    colorName: string | null;
    sizeofProduct: number | null;
    image: string | null;
    vatrate: number | null;
    boxConv: number | null;
    factor: number | null;
    factor2: number | null;
    productBarCode: string | null;
    billType: number | null;
    pParentId: number | null;
    sortOrder: number | null;
    shortCode: string | null;
    productCategories: ProductCategoryModel[] | null;
    productColor: ProductColorModel[] | null;
    productUnitViewModel: ProductUnitModel[] | null;
}