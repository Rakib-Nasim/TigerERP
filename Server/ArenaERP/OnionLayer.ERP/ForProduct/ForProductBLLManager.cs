using AutoMapper;
using Common.ERP.UtilityManagement;
using DatabaseContext;
using ModelClass.ERP.DTO;
using ModelClass.ERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionLayer.ERP.ForProduct
{
    public class ForProductBLLManager : IForProductBLLManager
    {
        private readonly DatabaseContextDb _contextDb;
        private readonly IMapper _mapper;

        public ForProductBLLManager(DatabaseContextDb contextDb,IMapper mapper)
        {
            _contextDb = contextDb;
            _mapper = mapper;
        }

        public async Task<ProductViewModel> SaveProduct(ProductViewModel model)
        {
            try
            {
                Product data=new Product();
                int productId = 0;
                var existModel = CustomValidation.IsExistForTwoCondition<Product>("Product", "Name", model.Name, "CompId", model.CompId);
                if (existModel.Any() && (existModel.Any(c => c.ProductId != model.ProductId) || model.ProductId == null || model.ProductId == 0))
                {
                    throw new DuplicateWaitObjectException($"{model.Name} already exist");
                }
                    data = new Product();
                    productId = CustomValidation.MaxNumber<int>("Product", "ProductId", "CompId", model.CompId);
                    model.ProductId = productId + 1;
                    data.CreatedBy = "Bappy";
                    data.CreatedDate = DateTime.UtcNow;
                    data.Status = (int)Common.ERP.Enum.AvailableStatus.Active;
                    await _contextDb.Product.AddAsync(data);
                
                data.UpdatedBy = "Bappy";
                data.UpdatedDate = DateTime.UtcNow;
                data = _mapper.Map(model, data);
                return model;


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
