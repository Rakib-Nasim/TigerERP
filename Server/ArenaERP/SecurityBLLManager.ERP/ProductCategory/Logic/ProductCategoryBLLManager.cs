using AutoMapper;
using AutoMapper.QueryableExtensions;
using DatabaseContext;
using Microsoft.EntityFrameworkCore;
using ModelClass.ERP.DTO;
using ModelClass.ERP.ViewModel;
using SecurityBLLManager.ERP.IProductCategoryBLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityBLLManager.ERP.ProductCategoryBLLManage.Logic
{
    public class ProductCategoryBLLManager : IProductCategoryBLLManager
    {
        private readonly DatabaseContextDb _contextDb;
        private readonly IMapper _mapper;

        public ProductCategoryBLLManager(DatabaseContextDb contextDb,IMapper mapper)
        {
            _contextDb = contextDb;
            _mapper = mapper;
        }

        public async Task<bool> AddProductCategory(ProductCategoryViewModel model)
        {
            try
            {
                ProductCategories data;
                data = await _contextDb.ProductCategory.FirstOrDefaultAsync(p => p.Id == model.Id);
                await _contextDb.Database.BeginTransactionAsync();
                if (data == null)
                {
                    data = new ProductCategories();
                    data.Status = (int)Common.ERP.Enum.AvailableStatus.Active;
                    await _contextDb.ProductCategory.AddAsync(data);
                }
                data = _mapper.Map((ProductCategoryViewModel)model, data);
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

        public async Task<bool> DeleteProductCategory(int Id)
        {
            try
            {
                ProductCategories ? data = new ProductCategories();
                await _contextDb.Database.BeginTransactionAsync();

                data = await _contextDb.ProductCategory.FirstOrDefaultAsync(p => p.Id == Id);

                data.Status = (int)Common.ERP.Enum.AvailableStatus.Delete;
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

        public async Task<IEnumerable<ProductCategoryViewModel>> GetAllProductCategoryByComp(int compId)
        {
            IEnumerable<ProductCategoryViewModel> models = await _contextDb.ProductCategory.Where(p => p.CompId == compId && p.Status == (int)Common.ERP.Enum.AvailableStatus.Active)
               .ProjectTo<ProductCategoryViewModel>(_mapper.ConfigurationProvider)
               .ToListAsync();
            return models;
        }

        public async Task<ProductCategoryViewModel> GetProductCategoryById(int Id)
        {
            try
            {
                ProductCategoryViewModel model = new ProductCategoryViewModel();
                ProductCategories? data = await _contextDb.ProductCategory.Where(p => p.Id == Id).FirstOrDefaultAsync();
                model = _mapper.Map(data, model);
                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
