using ModelClass.ERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityBLLManager.ERP.IProductSupplierBLL.Interface
{
    public interface IProductSupplierBLLManager
    {
        Task<bool> AddProductSupplies(ProductSupplierViewModel model);
        Task<IEnumerable<ProductSupplierViewModel>> GetAllProductSuppliesComp(int compId);
        Task<ProductSupplierViewModel> GetProductSuppliesId(int Id);
    }
}
