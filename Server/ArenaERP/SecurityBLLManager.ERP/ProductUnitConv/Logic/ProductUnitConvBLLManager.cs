using AutoMapper;
using AutoMapper.QueryableExtensions;
using DatabaseContext;
using Microsoft.EntityFrameworkCore;
using ModelClass.ERP.DTO;
using ModelClass.ERP.ViewModel;
using SecurityBLLManager.ERP.IProductUnitConvBLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityBLLManager.ERP.ProductUnitConvBLLManager.Logic
{
    public class ProductUnitConvBLLManager : IProductUnitConvBLLManager
    {
        private readonly DatabaseContextDb _contextDb;
        private readonly IMapper _mapper;

        public ProductUnitConvBLLManager(DatabaseContextDb contextDb,IMapper mapper)
        {
            _contextDb = contextDb;
            _mapper = mapper;
        }

        public async Task<bool> AddProductUnit(ProductUnitViewModel model)
        {
            try { 
            ProductUnit ? data;
            data = await _contextDb.ProductUnitConv.FirstOrDefaultAsync(p => p.Id == model.Id);
            await _contextDb.Database.BeginTransactionAsync();
            if (data == null)
            {
                data = new ProductUnit();
                data.Status = (int)Common.ERP.Enum.AvailableStatus.Active;
                data.CreatedBy = "Bappy";
                    data.CreatedDate = DateTime.Now;
                await _contextDb.ProductUnitConv.AddAsync(data);
            }
                data.UpdatedBy = "Bappy";
                data.UpdatedDate = DateTime.Now;
            data = _mapper.Map((ProductUnitViewModel)model, data);
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

        public async Task<bool> DeleteProductUnit(int Id)
        {
            try
            {
                ProductUnit ? data = new ProductUnit();
                await _contextDb.Database.BeginTransactionAsync();

                data = await _contextDb.ProductUnitConv.FirstOrDefaultAsync(p => p.Id == Id);

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

        public async Task<IEnumerable<ProductUnitViewModel>> GetAllProductUnitByComp(int compId)
        {
            IEnumerable<ProductUnitViewModel> models = await _contextDb.ProductUnitConv.Where(p => p.CompId == compId && p.Status == (int)Common.ERP.Enum.AvailableStatus.Active)
                 .ProjectTo<ProductUnitViewModel>(_mapper.ConfigurationProvider)
                 .ToListAsync();
            return models;
        }

        public async Task<ProductUnitViewModel> GetProductUnitById(int Id)
        {
            try
            {
                ProductUnitViewModel  model = new ProductUnitViewModel();
                Godown ? data = await _contextDb.Godown.Where(p => p.Id == Id).FirstAsync();
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
