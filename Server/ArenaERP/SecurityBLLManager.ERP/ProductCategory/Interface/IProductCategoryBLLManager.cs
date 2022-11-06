using ModelClass.ERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityBLLManager.ERP.IProductCategoryBLL.Interface
{
    public interface IProductCategoryBLLManager
    {
        Task<bool> AddProductCategory(ProductCategoryViewModel ProductCategory);
        Task<IEnumerable<ProductCategoryViewModel>> GetAllProductCategoryByComp(int compId);
        Task<ProductCategoryViewModel> GetProductCategoryById(int Id);
        Task<bool> DeleteProductCategory(int Id);
    }
}
