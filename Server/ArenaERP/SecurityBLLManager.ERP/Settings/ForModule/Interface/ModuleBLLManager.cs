using AutoMapper;
using Common.ERP.UtilityManagement;
using Dapper;
using Infrustracture.ERP.UnitOfWorkSetup.ForBranch;
using Microsoft.Data.SqlClient;
using ModelClass.ERP.DTO;
using ModelClass.ERP.ViewModel;
using SecurityBLLManager.ERP.Settings.ForModule.Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityBLLManager.ERP.Settings.ForModule.Interface
{
    public class ModuleBLLManager : IModuleBLLManager
    {
        private readonly ICommonUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ModuleBLLManager(ICommonUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> AddModule(ModuleViewModel model)
        {
            try
            {
                Modules data = new Modules();
                data = await _unitOfWork.Module.GetByIdAsync(model.Id);
                //data = CustomValidation.GetById<Modules>("Modules", "Id", model.Id); 
                model.Name = model.Name.Trim();
                await _unitOfWork.BeginTransactionAsync();
                var existModel = CustomValidation.IsExist<Modules>("Modules", "Name", model.Name);
                if (existModel.Any() && (existModel.Any(c => c.Id != model.Id) || model.Id == null || model.Id == 0) && (model.Name.ToLower() == existModel[0].Name.ToLower()))
                {
                    throw new DuplicateWaitObjectException($"{model.Name} already exist");
                }
                if (data == null)
                {
                    data = new Modules();
                    await _unitOfWork.Module.AddAsync(data);
                }
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

        public async Task<IEnumerable<ModuleViewModel>> GetAllModule()
        {
            IEnumerable<ModuleViewModel> result = new ModuleViewModel[] { };
            using (var con =new SqlConnection(Connection.ConnectionString()))
            {
                result = con.Query<ModuleViewModel>("GetAllParentModule", commandType: CommandType.StoredProcedure);

            }
            return result;
        }
        public async Task<ModuleViewModel> GetModuleById(int Id)
        {
            try
            {
                ModuleViewModel model = new ModuleViewModel();
                model = CustomValidation.GetById<ModuleViewModel>("Modules", "Id", Id);
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Update(ModuleViewModel model)
        {
            try
            {
                Modules data ;
                data = CustomValidation.GetById<Modules>("Modules", "Id", model.Id);
                model.Name = model.Name.Trim();
                await _unitOfWork.BeginTransactionAsync();
               var existModel = CustomValidation.IsExist<Modules>("Modules", "Name", model.Name);
                if (existModel.Any() && (existModel.Any(c => c.Id != model.Id) || model.Id == null || model.Id == 0) && (model.Name.ToLower() == existModel[0].Name.ToLower()))
                {
                    throw new DuplicateWaitObjectException($"{model.Name} already exist");
                }
                await _unitOfWork.Module.EditAsync(data);
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

        public async Task<IEnumerable<UserModuleViewModel>> GetSubModuleWithPage(int userId, int companyId, int logedUserId, int moduleId = -1)
        {
            try
            {
                using (var con = new SqlConnection(Connection.ConnectionString()))
                {
                    string moduleList = $"Select * from Modules where Id={moduleId} and IsActive=1 and ParentModuleId=0";
                    IEnumerable<UserModuleViewModel> modules = con.Query<UserModuleViewModel>(moduleList).ToList();
                    Queue<IEnumerable<UserModuleViewModel>> moduleQueue = new Queue<IEnumerable<UserModuleViewModel>>();
                    moduleQueue.Enqueue(modules);
                    if (moduleQueue.Count > 0)
                    {
                        foreach (var module in moduleQueue.Dequeue())
                        {
                            string subModulesList = $"Select * from Modules where ParentModuleId={module.Id} and IsActive=1 order by SerialNo ASC";
                            module.SubModules = con.Query<UserModuleViewModel>(subModulesList).ToList();
                            if (module.SubModules.Count > 0)
                            {
                                foreach (var item in module.SubModules)
                                {
                                    item.Pages = con.Query<PageViewModel>("getAllPagesByModule", param: new { ModuleId = item.Id },commandType:CommandType.StoredProcedure).ToList();

                                }
                                moduleQueue.Enqueue(module.SubModules);
                            }
                     
                           
                        }
                    }

                    return modules;

                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
