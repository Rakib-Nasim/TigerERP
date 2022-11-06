export class GodownModel {
    id: number;
    godownId: number;
    branchId: number;
    compId: number;
    isParent: number | null;
    parentId: number | null;
    layerId: number | null;
    godownName: string;
    branchName: string | null;
    parentGodownName: string | null;
    godownLocation: string | null;
    status: number | null;
}