using AutoMapper;
using DatabaseContext;
using ModelClass.ERP.DTO;
using ModelClass.ERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionLayer.ERP.ForProductCategory
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

        public async Task<List<ProductCategoryViewModel>> SaveProductCategory(List<ProductCategoryViewModel> productCategories, ProductViewModel model)
        {
            try
            {
                ProductCategories productCategory;

                foreach (ProductCategoryViewModel item in productCategories)
                {
                    productCategory = new ProductCategories();
                    item.ProductId = (int)model.ProductId!;
                    item.CompId = (int)model.CompId!;
                    productCategory.Status = (int)Common.ERP.Enum.AvailableStatus.Active;

                    await _contextDb.ProductCategory.AddRangeAsync(productCategory);
                    productCategory = _mapper.Map(item, productCategory);
                }

                return productCategories;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
