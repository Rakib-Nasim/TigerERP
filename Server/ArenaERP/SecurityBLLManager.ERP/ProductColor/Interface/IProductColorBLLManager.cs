using ModelClass.ERP.DTO;
using ModelClass.ERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityBLLManager.ERP.ProductColorBLLMana.Interface
{
    public interface IProductColorBLLManager
    {
        Task<bool> AddProductColor(ColorViewModel model);
        Task<bool> UpdateProductColor(ColorViewModel model);
        Task<IEnumerable<ColorViewModel>> GetAllColorByComp(int compId);
        Task<ColorViewModel> GetColorById(int Id);
        Task<bool> DeleteColor(int deletedId);
    }
}
