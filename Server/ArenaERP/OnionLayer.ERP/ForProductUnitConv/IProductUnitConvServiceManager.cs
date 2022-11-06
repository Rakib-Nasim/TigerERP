using AutoMapper;
using Common.ERP.UtilityManagement;
using Dapper;
using DatabaseContext;
using Microsoft.Data.SqlClient;
using ModelClass.ERP.DTO;
using ModelClass.ERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionLayer.ERP.ForProductUnitConv
{
    public interface IProductUnitConvServiceManager
    {
        Task<List<ProductUnitViewModel>> AddProductUnit(ProductViewModel model);
    }
    public class ProductUnitConvServiceManager : IProductUnitConvServiceManager
    {
        private readonly DatabaseContextDb _contextDb;
        private readonly IMapper _mapper;

        public ProductUnitConvServiceManager(DatabaseContextDb contextDb, IMapper mapper)
        {
            _contextDb = contextDb;
            _mapper = mapper;
        }

        public async Task<List<ProductUnitViewModel>> AddProductUnit(ProductViewModel model)
        {
            try
            {
                using var con = new SqlConnection(Connection.ConnectionString());
                string deletePrevUniConv = $"DELETE ProductUnitConv WHERE ProductId={model.ProductId} AND CompId={model.CompId}";
                con.Execute(deletePrevUniConv);
                ProductUnit productUnit;
                foreach (ProductUnitViewModel item in model.ProductUnitViewModel!)
                {
                    productUnit = new ProductUnit();
                    item.ProductId = (int)model.ProductId!;
                    item.CompId = (int)model.CompId!;
                    productUnit.Status = (int)Common.ERP.Enum.AvailableStatus.Active;
                    productUnit.CreatedDate = DateTime.Now;
                    productUnit.CreatedBy = "Bappy";
                    productUnit.UpdatedDate = DateTime.Now;
                    productUnit.UpdatedBy = "Bappy";

                    await _contextDb.ProductUnitConv.AddRangeAsync(productUnit);
                    productUnit = _mapper.Map(item, productUnit);
                }

                return (List<ProductUnitViewModel>)model.ProductUnitViewModel;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
