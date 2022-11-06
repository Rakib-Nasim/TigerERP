using ModelClass.ERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionLayer.ERP.ForProduct
{
    public interface IForProductBLLManager
    {
        Task<ProductViewModel> SaveProduct(ProductViewModel model);

    }
}
