using ModelClass.ERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityBLLManager.ERP.IProductBLL.Interface
{
    public interface IProductBLLManager
    {
        Task<bool> AddProduct(ProductViewModel model);
        Task<IEnumerable<ProductViewModel>> GetAllProductByComp(int compId);
        Task<IEnumerable<ProductViewModel>> GetAllActiveProductByComp(int compId);
        Task<ProductViewModel> GetProductById(int id);
        Task<ProductViewModel> GetProductWithStockById(int id);
        Task<bool> DeleteProduct(int deletedId);
    }
}
