using OnionLayer.ERP.ForChallanDetails;
using OnionLayer.ERP.ForChallanMaster;
using OnionLayer.ERP.ForProduct;
using OnionLayer.ERP.ForProductCategory;
using OnionLayer.ERP.ForProductColor;
using OnionLayer.ERP.ForProductUnitConv;

namespace Services.ERP.Extentions
{
    public static class OnionLayerServiceExtention
    {
        public static IServiceCollection AddScopedServicesForOnionLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IChallanMasterBLLManger, ChallanMasterBLLManger>();
            services.AddScoped<IChallanDetailsBLLManger, ChallanDetailsBLLManger>();
            services.AddScoped<IProductCategoryBLLManager, ProductCategoryBLLManager>();
            services.AddScoped<IProductColorServiceManager, ProductColorServiceManager>();
            services.AddScoped<IProductUnitConvServiceManager, ProductUnitConvServiceManager>();
            services.AddScoped<IForProductBLLManager, ForProductBLLManager>();
            return services;
        }
    }
}
