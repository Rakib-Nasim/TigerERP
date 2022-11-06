using AutoMapper;
using Common.ERP.UtilityManagement;
using Dapper;
using DatabaseContext;
using Infrustracture.ERP.UnitOfWorkSetup.ForCategory;
using Infrustracture.ERP.UnitOfWorkSetup.ForProduct;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ModelClass.ERP.DTO;
using ModelClass.ERP.ViewModel;
using OnionLayer.ERP.ForProduct;
using OnionLayer.ERP.ForProductCategory;
using OnionLayer.ERP.ForProductColor;
using OnionLayer.ERP.ForProductUnitConv;
using SecurityBLLManager.ERP.IProductBLL.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityBLLManager.ERP.ProductBLLManage.Logic
{
    public class ProductBLLManager : IProductBLLManager
    {
        private readonly IProductUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IForProductBLLManager _productBLLManager;
        private readonly IProductCategoryBLLManager _productCategory;
        private readonly IProductColorServiceManager _productColor;
        private readonly IProductUnitConvServiceManager _productUnit;

        public ProductBLLManager(IProductUnitOfWork work,
            IMapper mapper,
            IForProductBLLManager productBLLManager,
            IProductCategoryBLLManager productCategory,
            IProductColorServiceManager productColor,
            IProductUnitConvServiceManager productUnit
            )
        {
            _unitOfWork = work;
            _mapper = mapper;
            _productBLLManager = productBLLManager;
            _productCategory = productCategory;
            _productColor = productColor;
            _productUnit = productUnit;
        }

        public async Task<bool> AddProduct(ProductViewModel model)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();
                model=await _productBLLManager.SaveProduct(model);
                model.ProductCategories = await _productCategory.SaveProductCategory((List<ProductCategoryViewModel>)model.ProductCategories, model);
                model.ProductColor = await _productColor.SaveProductColor(model);
                model.ProductUnitViewModel = await _productUnit.AddProductUnit(model);
                var result = await _unitOfWork.SaveAsync();
                await _unitOfWork.CommitTransactionAsync();
                return result ;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw new Exception(ex.Message);
            }
        }


        public async Task<IEnumerable<ProductViewModel>> GetAllProductByComp(int compId)
        {
            IEnumerable<ProductViewModel> result = new ProductViewModel[] { };
            using (var con = new SqlConnection(Connection.ConnectionString()))
            {
                result = con.Query<ProductViewModel>("GetAllProductByComp", param: new {CompId=compId},commandType:CommandType.StoredProcedure).ToList();
            }
            return result;
        }

        public async Task<IEnumerable<ProductViewModel>> GetAllActiveProductByComp(int compId)
        {
            IEnumerable<ProductViewModel> result = new ProductViewModel[] { };
            using (var con = new SqlConnection(Connection.ConnectionString()))
            {
                result = con.Query<ProductViewModel>("GetAllActiveProductByComp", param: new { CompId = compId }, commandType: CommandType.StoredProcedure).ToList();
            }
            return result;
        }

        public async Task<ProductViewModel> GetProductWithStockById(int id)
        {
            try
            {
                ProductViewModel model = new ProductViewModel();
                var data = await _unitOfWork.Product.GetByIdAsync(id);
                var result = _mapper.Map(data, model);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteProduct(int deletedId)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();
                Product ? product;
                product = await _unitOfWork.Product.GetByIdAsync(deletedId);
                product.UpdatedBy = "Bappy";
                product.UpdatedDate = DateTime.UtcNow;
                product.Status = (int)Common.ERP.Enum.AvailableStatus.Delete;
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

        public async Task<ProductViewModel> GetProductById(int id)
        {
            try
            {
                ProductViewModel model=new ProductViewModel();
                var data = await _unitOfWork.Product.GetByIdAsync(id);
                var result =_mapper.Map(data, model);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        


    }
}
