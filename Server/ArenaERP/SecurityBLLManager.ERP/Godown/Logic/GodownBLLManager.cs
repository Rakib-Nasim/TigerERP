using AutoMapper;
using AutoMapper.QueryableExtensions;
using Common.ERP.UtilityManagement;
using Dapper;
using DatabaseContext;
using Infrustracture.ERP.UnitOfWorkSetup.ForBrand;
using Infrustracture.ERP.UnitOfWorkSetup.ForGodown;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ModelClass.ERP.DTO;
using ModelClass.ERP.ViewModel;
using SecurityBLLManager.ERP.IGodownBLLManage.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityBLLManager.ERP.GodownBLLManage.Logic
{
    public class GodownBLLManager : IGodownBLLManager
    {
        private readonly IGodownUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GodownBLLManager(IGodownUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> AddGodown(GodownViewModel model)
        {
            try
            {
                Godown data;
                int godwonId = 0;
                await _unitOfWork.BeginTransactionAsync();
                data = new Godown();
                godwonId = CustomValidation.MaxNumber<int>("Godown", "GodownId", "CompId", model.CompId);
                model.GodownId = godwonId + 1;
                data.CreatedBy = "Bappy";
                data.CreatedDate = DateTime.Now;
                await _unitOfWork.Godown.AddAsync(data);

                model.GodownId = data.GodownId;
                data = _mapper.Map((GodownViewModel)model, data);
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

        public async Task<IEnumerable<GodownViewModel>> GetAllGodownByComp(int compId)
        {
            IEnumerable<GodownViewModel> result = new GodownViewModel[] { };
            using (var con = new SqlConnection(Connection.ConnectionString()))
            {
                result = con.Query<GodownViewModel>("GetGodownByCompId", param : new {CompId=compId},commandType:CommandType.StoredProcedure).ToList();
            }
            return result;
        }

        public async Task<GodownViewModel> GetGodownById(int Id)
        {
            try
            {
                GodownViewModel model = new GodownViewModel();
                model = CustomValidation.GetById<GodownViewModel>("Godown", "Id", Id);
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteGodown(int Id)
        {
            try
            {
                Godown data = new Godown();
                await _unitOfWork.BeginTransactionAsync();

                data = CustomValidation.GetById<Godown>("Godown", "Id",Id);

                data.Status = (int)Common.ERP.Enum.AvailableStatus.Delete;
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

       
    }
}
