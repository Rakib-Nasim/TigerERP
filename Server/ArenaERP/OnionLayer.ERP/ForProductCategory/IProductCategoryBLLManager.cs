using ModelClass.ERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionLayer.ERP.ForProductCategory
{
    public interface IProductCategoryBLLManager
    {
        Task<List<ProductCategoryViewModel>>SaveProductCategory(List<ProductCategoryViewModel> productCategories, ProductViewModel model);
    }
}
