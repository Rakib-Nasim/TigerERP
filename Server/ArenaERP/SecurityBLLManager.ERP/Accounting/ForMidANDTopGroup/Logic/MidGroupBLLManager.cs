using AutoMapper;
using Common.ERP.UtilityManagement;
using ModelClass.ERP.ViewModel;
using SecurityBLLManager.ERP.Accounting.ForMidGroup.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityBLLManager.ERP.Accounting.ForMidANDTopGroup.Logic
{
    public class MidGroupBLLManager : IMidGroupBLLManager
    {
        private readonly IMapper _mapper;

        public MidGroupBLLManager(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<AccountGroupMidViewModel>> GetAllGroupMid()
        {
            IEnumerable<AccountGroupMidViewModel> result =  new AccountGroupMidViewModel[] { }; ;
            result = CustomValidation.GetAll<AccountGroupMidViewModel>("AccountGroupMid");

            return result;
        }
    }


    public class TopGroupBLLManager : ITopGroupBLLManager
    {
        private readonly IMapper _mapper;

        public TopGroupBLLManager(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<AccountGroupTopViewModel>> GetAllGroupTop()
        {
            IEnumerable<AccountGroupTopViewModel> result = new AccountGroupTopViewModel[] { }; ;
            result = CustomValidation.GetAll<AccountGroupTopViewModel>("AccountGroupTop");

            return result;
        }

        public async Task<IEnumerable<CashFlowViewModel>> GetAllCashflow()
        {
            IEnumerable<CashFlowViewModel> result = new CashFlowViewModel[] { }; ;
            result = CustomValidation.GetAll<CashFlowViewModel>("CashFlow");

            return result;
        }
    }
}
