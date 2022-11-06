using AutoMapper;
using AutoMapper.QueryableExtensions;
using Common.ERP.UtilityManagement;
using DatabaseContext;
using Infrustracture.ERP.UnitOfWorkSetup.ForProductColor;
using Infrustracture.ERP.UnitOfWorkSetup.ForUnit;
using Microsoft.EntityFrameworkCore;
using ModelClass.ERP.DTO;
using ModelClass.ERP.ViewModel;
using SecurityBLLManager.ERP.UnitBLLManager.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityBLLManager.ERP.UnitBLLManager.Logic
{
    public class UnitBLLManager : IUnitBLLManager
    {
        private readonly IUnitUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UnitBLLManager(IUnitUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> AddUnit(UnitViewModel model)
        {
            try
            {
                Unit unit;
                int unitId = 0;
                var existModel = CustomValidation.IsExistForTwoCondition<Unit>("Unit", "UnitName", model.UnitName, "CompId", model.CompId);
                if (existModel.Any() && (existModel.Any(c => c.UnitId != model.UnitId) || model.UnitId == null || model.UnitId == 0))
                {
                    throw new DuplicateWaitObjectException($"{model.UnitName} already exist");
                }
                await _unitOfWork.BeginTransactionAsync();
                unit = new Unit();
                unitId = CustomValidation.MaxNumber<int>("Unit", "UnitId", "CompId", model.CompId);
                model.UnitId = unitId + 1;
                await _unitOfWork.Unit.AddAsync(unit);
                unit = _mapper.Map((UnitViewModel)model, unit);
                await _unitOfWork.CommitTransactionAsync();
                var result = await _unitOfWork.SaveAsync();
                return result;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<UnitViewModel>> GetAllUnitByComp(int compId)
        {
            IEnumerable<UnitViewModel> result = new UnitViewModel[] { };
            var models = CustomValidation.GetAllByCompId<UnitViewModel>("Unit", "CompId", compId);
            result = models.Where(p => p.Status == (int)Common.ERP.Enum.AvailableStatus.Active).ToList();
            return result;
        }

        public async Task<UnitViewModel> GetUnitById(int Id)
        {
            try
            {
                UnitViewModel model = new UnitViewModel();
                model = CustomValidation.GetById<UnitViewModel>("Unit", "Id", Id);
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteUnit(int Id)
        {
            try
            {
                Unit unit;
                unit = CustomValidation.GetById<Unit>("Unit", "Id", Id);
                unit.Status = (int)Common.ERP.Enum.AvailableStatus.Delete;
                var result = await _unitOfWork.SaveAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
