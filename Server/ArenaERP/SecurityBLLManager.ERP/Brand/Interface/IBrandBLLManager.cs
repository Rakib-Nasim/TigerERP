using ModelClass.ERP.DTO;
using ModelClass.ERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityBLLManager.ERP.BrandBLL.Interface
{
    public interface IBrandBLLManager
    {
        Task<(bool success,int brandId)> AddBrand(BrandViewModel brand);
        Task<(bool success,int brandId)> UpdateBrand(BrandViewModel brand);
        Task<IEnumerable<BrandViewModel>>GetAllBrandByComp(int compId);
        Task<BrandViewModel>GetBrandById(int Id);
        Task<bool>DeleteBrand(int Id);
    }
}
