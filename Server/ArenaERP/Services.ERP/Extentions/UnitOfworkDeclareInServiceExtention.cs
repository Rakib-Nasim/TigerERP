using Infrustracture.ERP.UnitOfWorkSetup.ForBranch;
using Infrustracture.ERP.UnitOfWorkSetup.ForBrand;
using Infrustracture.ERP.UnitOfWorkSetup.ForCategory;
using Infrustracture.ERP.UnitOfWorkSetup.ForChallan.ForChallanDetails;
using Infrustracture.ERP.UnitOfWorkSetup.ForChallan.ForChallanMaster;
using Infrustracture.ERP.UnitOfWorkSetup.ForGodown;
using Infrustracture.ERP.UnitOfWorkSetup.ForProduct;
using Infrustracture.ERP.UnitOfWorkSetup.ForProductColor;
using Infrustracture.ERP.UnitOfWorkSetup.ForUnit;

namespace Services.ERP.Extentions
{
    public static class UnitOfworkDeclareInServiceExtention
    {
        public static IServiceCollection AddScopedServicesForUnitOfWork(this IServiceCollection services, IConfiguration configuration)
        {
            //Unit Of Work
            services.AddScoped<ICommonUnitOfWork, CommonUnitOfWork>();
            services.AddScoped<IBrandUnitOfWork, BrandUnitOfWork>();
            services.AddScoped<IChallanDetailsUnitOfWork, ChallanDetailsUnitOfWork>();
            services.AddScoped<IChallanMasterUnitOfWork, ChallanMasterUnitOfWork>();
            services.AddScoped<ICategoryUnitOfWork, CategoryUnitOfWork>();
            services.AddScoped<IProductColorUnitOfWork, ProductColorUnitOfWork>();
            services.AddScoped<IProductUnitOfWork, ProductUnitOfWork>();
            services.AddScoped<IGodownUnitOfWork, GodownUnitOfWork>();
            services.AddScoped<IUnitUnitOfWork, UnitUnitOfWork>();
            return services;
        }
    }
}
