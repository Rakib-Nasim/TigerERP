using ModelClass.ERP.DTO;
using ModelClass.ERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityBLLManager.ERP.Categories.Interface
{
    public interface ICategoriesBLLManager
    {
        Task<bool> AddCategory(CategoryViewModel category);
        Task<bool> UpdateCategory(CategoryViewModel category);
        Task<IEnumerable<CategoryViewModel>> GetAllCategoryByComp(int compId);
        Task<CategoryViewModel> GetCategoryById(int Id);
        Task<bool> DeleteCategory(int DeleteId);
        Task<IEnumerable<ProductTypeViewModel>> GetAllProductTypeByComp(int compId);

    }
}
