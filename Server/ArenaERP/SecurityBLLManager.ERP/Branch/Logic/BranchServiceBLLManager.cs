using AutoMapper;
using Common.ERP.UtilityManagement;
using DatabaseContext;
using Infrustracture.ERP.UnitOfWorkSetup.ForBranch;
using Microsoft.EntityFrameworkCore;
using ModelClass.ERP.DTO;
using ModelClass.ERP.ViewModel;
using SecurityBLLManager.ERP.IBranchService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityBLLManager.ERP.BranchServiceB.Logic
{
    public class BranchServiceBLLManager : IBranchServiceBLLManager
    {
        private readonly ICommonUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BranchServiceBLLManager(ICommonUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> AddBranch(BranchViewModel model)
        {
            try
            {
                Branch data = new Branch();
                int branchId = 0;
                await _unitOfWork.BeginTransactionAsync();
                var existModel = CustomValidation.IsExistForTwoCondition<Branch>("Branch", "Name", model.Name, "CompId", model.CompId);
                if (existModel.Any() && (existModel.Any(c => c.BranchId != model.BranchId) || model.BranchId == null || model.BranchId == 0))
                {
                    throw new DuplicateWaitObjectException($"{model.Name} already exist");
                }
                data = new Branch();
                branchId = CustomValidation.MaxNumber<int>("Branch", "BranchId", "CompId", model.CompId);
                model.BranchId = branchId + 1;
                await _unitOfWork.Branch.AddAsync(data);
                data = _mapper.Map(model, data);
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

        public async Task<IEnumerable<BranchViewModel>> GetAllBranchByComp(int compId)
        {
            IEnumerable<BranchViewModel> result = new BranchViewModel[] { };
            result = CustomValidation.GetAllByCompId<BranchViewModel>("Branch", "CompId", compId);
            result = result.Where(p => p.Status == (int)Common.ERP.Enum.AvailableStatus.Active).ToList();
            return result;
        }
        public async Task<BranchViewModel> GetBranchById(int Id)
        {
            try
            {
                BranchViewModel model = new BranchViewModel();
                model = CustomValidation.GetById<BranchViewModel>("Branch", "Id", model.Id);
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Update(BranchViewModel model)
        {
            try
            {
                Branch data = new Branch();
                data = CustomValidation.GetById<Branch>("Branch", "Id", model.Id);
                await _unitOfWork.BeginTransactionAsync();
                var existModel = CustomValidation.IsExistForTwoCondition<Branch>("Branch", "Name", model.Name, "CompId", model.CompId);
                if (existModel.Any() && (existModel.Any(c => c.BranchId != model.BranchId) || model.BranchId == null || model.BranchId == 0))
                {
                    throw new DuplicateWaitObjectException($"{model.Name} already exist");
                }
                await _unitOfWork.Branch.EditAsync(data);
                data = _mapper.Map(model, data);
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
        public async Task<bool> DeleteBranch(int Id)
        {
            try
            {
                Branch? data = new Branch();
                data = CustomValidation.GetById<Branch>("Branch", "Id", Id);
                data.Name = data.Name.Trim();
                await _unitOfWork.BeginTransactionAsync();
                data.Status = (int)Common.ERP.Enum.AvailableStatus.Delete;
                await _unitOfWork.Branch.EditAsync(data);
                await _unitOfWork.SaveAsync();
                await _unitOfWork.CommitTransactionAsync();
                return true;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();

                throw new Exception(ex.Message);
            }
        }
    }
}
