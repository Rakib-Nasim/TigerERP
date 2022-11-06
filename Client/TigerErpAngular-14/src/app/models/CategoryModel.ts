export class CategoryModel {
    id: number;
    categoryId: number;
    categoryName: string | null;
    parentCategoryName: string | null;
    description: string | null;
    parentId: number | null;
    isParent: number | null;
    compId: number;
    productType: number | null;
    productionLevel: number | null;
    isProduction: number | null;
    status: number | null;
}