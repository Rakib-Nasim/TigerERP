import { PageModel } from "./PageModel";

export class ModulesModel{
      id: number;
      name: string;
      moduleRoutePath: string | null;
      isActive: number;
      parentModuleId: number | null;
      isParent: number | null;
      serialNo: number | null;
      image: string;
      pages: PageModel[] | null;
      subModules:ModulesModel[] ;
  
}
