using ModelClass.ERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionLayer.ERP.ForProductColor
{
    public interface IProductColorServiceManager
    {
        Task<List<ProductColorViewModel>> SaveProductColor(ProductViewModel model);
    }
}
