using AutoMapper;
using Common.ERP.UtilityManagement;
using Dapper;
using Infrustracture.ERP.UnitOfWorkSetup.ForBranch;
using Microsoft.Data.SqlClient;
using ModelClass.ERP.DTO;
using ModelClass.ERP.ViewModel;
using SecurityBLLManager.ERP.Settings.ForPage.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityBLLManager.ERP.Settings.ForPage.Logic
{
    public class PageBLLManager : IPageBLLManager
    {
        private readonly ICommonUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PageBLLManager(ICommonUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> AddPage(PageViewModel model)
        {
            try
            {
                Pages data = new Pages(); 
                await _unitOfWork.BeginTransactionAsync();
              
                    data = new Pages();
                    await _unitOfWork.Pages.AddAsync(data);
                
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

        public async Task<IEnumerable<PageViewModel>> GetAllPage()
        {

            IEnumerable<PageViewModel> result = new PageViewModel[] { };
            using (var con = new SqlConnection(Connection.ConnectionString()))
            {
                result = con.Query<PageViewModel>("getAllPages", commandType: CommandType.StoredProcedure).ToList();
            }
            return result;
        }
        public async Task<PageViewModel> GetPageById(int Id)
        {
            try
            {
                PageViewModel model = new PageViewModel();
                model = CustomValidation.GetById<PageViewModel>("Modules", "Id", Id);
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Update(PageViewModel model)
        {
            try
            {
                Pages data;
                data = CustomValidation.GetById<Pages>("Pages", "Id", model.Id);
                await _unitOfWork.BeginTransactionAsync();
                await _unitOfWork.Pages.EditAsync(data);
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
    }
}

