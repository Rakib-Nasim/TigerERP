using AutoMapper;
using DatabaseContext;
using ModelClass.ERP.DTO;
using ModelClass.ERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionLayer.ERP.ForProductColor
{
    public class ProductColorServiceManager : IProductColorServiceManager
    {
        private readonly DatabaseContextDb _contextDb;
        private readonly IMapper _mapper;

        public ProductColorServiceManager(DatabaseContextDb contextDb, IMapper mapper)
        {
            _contextDb = contextDb;
            _mapper = mapper;
        }

        public async Task<List<ProductColorViewModel>> SaveProductColor(ProductViewModel model)
        {
            try
            {
                ProductColor productColor;

                foreach (ProductColorViewModel item in model.ProductColor)
                {
                    productColor = new ProductColor();
                    productColor.ProductId = (int)model.ProductId!;
                    productColor.CompId = (int)model.CompId!;
                    productColor.ColorId = (int)item.Id!;
                    productColor.Status = (int)Common.ERP.Enum.AvailableStatus.Active;

                    await _contextDb.ProductColor.AddRangeAsync(productColor);
                }

                return (List<ProductColorViewModel>)model.ProductColor;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

