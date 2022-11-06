using ModelClass.ERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityBLLManager.ERP.Accounting.AccountChart.Interface
{
    public  interface IAccountChartBLLManager
    {
        Task<bool> AddAccChart(AccChartViewModel model);
        Task<IEnumerable<AccChartViewModel>> GetAllAccChartByComp(int compId,int ? lowerGroupId);
        Task<AccChartViewModel> GetAccChartById(int Id);
        Task<bool> DeleteAccChart(int deleteId);
    }
}
