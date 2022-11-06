using AutoMapper;
using Common.ERP.UtilityManagement;
using Infrustracture.ERP.UnitOfWorkSetup.ForBranch;
using ModelClass.ERP.DTO;
using ModelClass.ERP.ViewModel;
using SecurityBLLManager.ERP.Accounting.ForLowerGroup.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityBLLManager.ERP.Accounting.ForLowerGroup.Logic
{
    public class LowerGroupBLLManager : ILowerGroupBLLManager
    {
        private readonly ICommonUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LowerGroupBLLManager(ICommonUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Add(AccountGroupLowerViewModel model)
        {
            try
            {
                AccountGroupLower data;
                int lowerGroupId = 0;
                await _unitOfWork.BeginTransactionAsync();
                var existModel = CustomValidation.IsExistForTwoCondition<AccountGroupLowerViewModel>("AccountGroupLower", "GroupName", model.GroupName, "CompId", model.CompId);
                if (existModel.Any() && (existModel.Any(c => c.LowerGroupId != model.LowerGroupId) || model.LowerGroupId == null || model.LowerGroupId == 0))
                {
                    throw new DuplicateWaitObjectException($"{model.GroupName} already exist");
                }
                data = new AccountGroupLower();
                lowerGroupId = CustomValidation.MaxNumber<int>("AccountGroupLower", "LowerGroupId", "CompId", model.CompId);
                model.LowerGroupId = lowerGroupId + 1;
                await _unitOfWork.AccountGroupLower.AddAsync(data);
                data = _mapper.Map((AccountGroupLowerViewModel)model, data);
                var result = await _unitOfWork.SaveAsync();
                await _unitOfWork.CommitTransactionAsync();
                return result;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw new Exception(ex.Message);
            }
        }

        public Task<bool> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<AccountGroupLowerViewModel> GetAccountGroupLowerById(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AccountGroupLowerViewModel>> GetAllAccountGroupLowerrByComp(int compId)
        {
            IEnumerable<AccountGroupLowerViewModel> result = new AccountGroupLowerViewModel[] { };
            result =  CustomValidation.GetAll<AccountGroupLowerViewModel>("AccountGroupLower").ToList();
            return  result;
        }

        public Task<bool> Update(AccountGroupLowerViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
