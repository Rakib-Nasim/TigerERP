using AutoMapper;
using AutoMapper.QueryableExtensions;
using Common.ERP.UtilityManagement;
using DatabaseContext;
using Microsoft.EntityFrameworkCore;
using ModelClass.ERP.DTO;
using ModelClass.ERP.ViewModel;
using SecurityBLLManager.ERP.Accounting.AccountChart.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityBLLManager.ERP.Accounting.AccountChart.Logic
{
    public class AccountBLLManager : IAccountChartBLLManager
    {
        private readonly DatabaseContextDb _contextDb;
        private readonly IMapper _mapper;

        public AccountBLLManager(DatabaseContextDb contextDb, IMapper mapper)
        {
            _contextDb = contextDb;
            _mapper = mapper;
        }

        public async Task<bool> AddAccChart(AccChartViewModel model)
        {
            try
            {
                AccChart data;
                int accountId = 0;
                var existModel = CustomValidation.IsExistForTwoCondition<AccChart>("AccChart", "AccountName", model.AccountName, "CompId", model.CompId);
                if (existModel.Any() && (existModel.Any(c => c.AccountId != model.AccountId) || model.AccountId == null || model.AccountId == 0))
                {
                    throw new DuplicateWaitObjectException($"{model.AccountName} already exist");
                }
                await _contextDb.Database.BeginTransactionAsync();
                data = new AccChart();
                accountId = CustomValidation.MaxNumber<int>("AccChart", "AccountId", "CompId", model.CompId);
                model.AccountId = accountId + 1;
                data.CreatedBy = "Bappy";
                data.CreatedDate = DateTime.UtcNow;
                data.Status = (int)Common.ERP.Enum.AvailableStatus.Active;
                await _contextDb.AccChart.AddAsync(data);
                data.UpdatedBy = "Bappy";
                data.UpdatedDate = DateTime.UtcNow;
                data = _mapper.Map(model, data);
                var result = await _contextDb.SaveChangesAsync();
                await _contextDb.Database.CommitTransactionAsync();
                return result > 0;
            }
            catch (Exception ex)
            {
                await _contextDb.Database.RollbackTransactionAsync();
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<AccChartViewModel>> GetAllAccChartByComp(int compId, int? lowerGroupId)
        {
            IEnumerable<AccChartViewModel> models = await _contextDb.AccChart.Where(p => p.CompId == compId && p.LowerGroupId == lowerGroupId && p.Status == (int)Common.ERP.Enum.AvailableStatus.Active)
               .ProjectTo<AccChartViewModel>(_mapper.ConfigurationProvider)
               .ToListAsync();
            return models;
        }
        public async Task<bool> DeleteAccChart(int deleteId)
        {
            try
            {
                await _contextDb.Database.BeginTransactionAsync();
                AccChart accChart;
                accChart = CustomValidation.GetById<AccChart>("AccChart", "Id", deleteId); ;
                accChart.UpdatedBy = "Bappy";
                accChart.UpdatedDate = DateTime.UtcNow;
                accChart.Status = (int)Common.ERP.Enum.AvailableStatus.Delete;
                var result = await _contextDb.SaveChangesAsync();
                await _contextDb.Database.CommitTransactionAsync();
                return result > 0;
            }
            catch (Exception ex)
            {
                await _contextDb.Database.RollbackTransactionAsync();
                throw new Exception(ex.Message);
            }
        }

        public async Task<AccChartViewModel> GetAccChartById(int Id)
        {
            try
            {
                AccChartViewModel model = new AccChartViewModel();
                model = CustomValidation.GetById<AccChartViewModel>("AccChart", "Id", Id);
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
