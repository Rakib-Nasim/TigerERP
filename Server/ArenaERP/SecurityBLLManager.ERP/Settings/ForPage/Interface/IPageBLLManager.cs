using ModelClass.ERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityBLLManager.ERP.Settings.ForPage.Interface
{
    public interface IPageBLLManager
    {
        Task<bool> AddPage(PageViewModel model);
        Task<bool> Update(PageViewModel model);
        Task<IEnumerable<PageViewModel>> GetAllPage();
        Task<PageViewModel> GetPageById(int Id);
    }
}
