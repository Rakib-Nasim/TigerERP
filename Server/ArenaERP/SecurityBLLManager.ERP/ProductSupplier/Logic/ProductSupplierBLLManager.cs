using AutoMapper;
using AutoMapper.QueryableExtensions;
using DatabaseContext;
using Microsoft.EntityFrameworkCore;
using ModelClass.ERP.DTO;
using ModelClass.ERP.ViewModel;
using SecurityBLLManager.ERP.IProductSupplierBLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityBLLManager.ERP.ProductSupplierBLLManager.Logic
{
    public class ProductSupplierBLLManager : IProductSupplierBLLManager
    {
        private readonly DatabaseContextDb _contextDb;
        private readonly IMapper _mapper;

        public ProductSupplierBLLManager(DatabaseContextDb contextDb,IMapper mapper)
        {
            _contextDb = contextDb;
            _mapper = mapper;
        }

        public async Task<bool> AddProductSupplies(ProductSupplierViewModel model)
        {
            try
            {
                ProductSupplier ? data;
                data = await _contextDb.ProductSupplier.FirstOrDefaultAsync(p => p.ProductSuplierId == model.ProductSupplierId);
                await _contextDb.Database.BeginTransactionAsync();
                if (data == null)
                {
                    data = new ProductSupplier();
                    data.CreatedBy = "Bappy";
                    data.CreatedDate = DateTime.UtcNow;
                    data.SupplierId = model.AccountId;
                    data.Status = (int)Common.ERP.Enum.AvailableStatus.Active;
                    await _contextDb.ProductSupplier.AddAsync(data);
                }
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

        public async Task<IEnumerable<ProductSupplierViewModel>> GetAllProductSuppliesComp(int compId)
        {
            IEnumerable<ProductSupplierViewModel> models = await _contextDb.ProductSupplier.Where(p => p.CompId == compId && p.Status == (int)Common.ERP.Enum.AvailableStatus.Active)
                .ProjectTo<ProductSupplierViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync();
            return models;
        }

        public async Task<ProductSupplierViewModel> GetProductSuppliesId(int Id)
        {
            try
            {
                ProductSupplierViewModel model = new ProductSupplierViewModel();
                ProductSupplier data = await _contextDb.ProductSupplier.Where(p => p.ProductSuplierId == Id).FirstOrDefaultAsync();
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
