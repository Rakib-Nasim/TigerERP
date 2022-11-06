using ModelClass.ERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityBLLManager.ERP.IProductUnitConvBLL.Interface
{
    public interface IProductUnitConvBLLManager
    {
        Task<bool> AddProductUnit(ProductUnitViewModel model);
        Task<IEnumerable<ProductUnitViewModel>> GetAllProductUnitByComp(int compId);
        Task<ProductUnitViewModel> GetProductUnitById(int Id);
        Task<bool> DeleteProductUnit(int Id);
    }
}
