using AutoMapper;
using AutoMapper.QueryableExtensions;
using Common.ERP.UtilityManagement;
using DatabaseContext;
using Infrustracture.ERP.UnitOfWorkSetup.ForBrand;
using Infrustracture.ERP.UnitOfWorkSetup.ForCategory;
using Microsoft.EntityFrameworkCore;
using ModelClass.ERP.DTO;
using ModelClass.ERP.ViewModel;
using SecurityBLLManager.ERP.Categories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityBLLManager.ERP.ProductCategory.Logic
{
    public class CategoryBLLManager : ICategoriesBLLManager
    {

        private readonly ICategoryUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CategoryBLLManager(ICategoryUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> AddCategory(CategoryViewModel model)
        {
            try
            {
                Category data;
                int catagoryId = 0;
                await _unitOfWork.BeginTransactionAsync();
                var existModel = CustomValidation.IsExistForTwoCondition<Category>("Category", "CategoryName", model.CategoryName, "CompId", model.CompId);
                if (existModel.Any() && (existModel.Any(c => c.CategoryId != model.CategoryId) || model.CategoryId == null || model.CategoryId == 0))
                {
                    throw new DuplicateWaitObjectException($"{model.CategoryName} already exist");
                }
                data = new Category();
                catagoryId = CustomValidation.MaxNumber<int>("Category", "CategoryId", "CompId", model.CompId);
                model.CategoryId = catagoryId + 1;
                data.CreatedBy = "Bappy";
                data.CreatedDate = DateTime.UtcNow;
                await _unitOfWork.Category.AddAsync(data);
                data = _mapper.Map((CategoryViewModel)model, data);
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

        public async Task<bool> UpdateCategory(CategoryViewModel model)
        {
            try
            {
                Category data;
                data = CustomValidation.GetById<Category>("Category", "Id", model.Id);

                await _unitOfWork.BeginTransactionAsync();
                var existModel = CustomValidation.IsExistForTwoCondition<Category>("Category", "CategoryName", model.CategoryName, "CompId", model.CompId);
                if (existModel.Any() && (existModel.Any(c => c.CategoryId != model.CategoryId) || model.CategoryId == null || model.CategoryId == 0))
                {
                    throw new DuplicateWaitObjectException($"{model.CategoryName} already exist");
                }
                data.UpdatedBy = "Bappy";
                data.UpdatedDate = DateTime.UtcNow;
                await _unitOfWork.Category.EditAsync(data);
                data = _mapper.Map((CategoryViewModel)model, data);
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

        public async Task<IEnumerable<CategoryViewModel>> GetAllCategoryByComp(int compId)
        {
            IEnumerable<CategoryViewModel> result = new CategoryViewModel[] { };
            result = CustomValidation.GetAllActiveByCompId<CategoryViewModel>("Category", "CompId", compId, "Status", 1);
            return result;
        }


        public async Task<bool> DeleteCategory(int DeleteId)
        {
            try
            {
                Category category;
                category = CustomValidation.GetById<Category>("Category", "Id", DeleteId); ;
                category.UpdatedBy = "Bappy";
                category.UpdatedDate = DateTime.UtcNow;
                category.Status = (int)Common.ERP.Enum.AvailableStatus.Delete;
                var result = await _unitOfWork.SaveAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<CategoryViewModel> GetCategoryById(int Id)
        {
            try
            {
                CategoryViewModel model = new CategoryViewModel();
                model = CustomValidation.GetById<CategoryViewModel>("Category", "Id", model.Id); ;
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<ProductTypeViewModel>> GetAllProductTypeByComp(int compId)
        {
            IEnumerable<ProductTypeViewModel> result = new ProductTypeViewModel[] { };
            result = CustomValidation.GetAllByCompId<ProductTypeViewModel>("ProductType", "CompId", compId);
            return result;
        }
    }
}
