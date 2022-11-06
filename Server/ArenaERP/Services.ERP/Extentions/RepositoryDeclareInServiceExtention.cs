using Infrustracture.ERP.RepositorySetup.Accounting.ForLowerGroup;
using Infrustracture.ERP.RepositorySetup.ForBranch;
using Infrustracture.ERP.RepositorySetup.ForBrand;
using Infrustracture.ERP.RepositorySetup.ForCategory;
using Infrustracture.ERP.RepositorySetup.ForChallan.ForChallanDetais;
using Infrustracture.ERP.RepositorySetup.ForChallan.ForChallanMaster;
using Infrustracture.ERP.RepositorySetup.ForGodown;
using Infrustracture.ERP.RepositorySetup.ForProduct;
using Infrustracture.ERP.RepositorySetup.ForProductColor;
using Infrustracture.ERP.RepositorySetup.ForSettings.ForModule.Interface;
using Infrustracture.ERP.RepositorySetup.ForSettings.ForModule.Logic;
using Infrustracture.ERP.RepositorySetup.ForSettings.ForPages.Interface;
using Infrustracture.ERP.RepositorySetup.ForSettings.ForPages.Logic;
using Infrustracture.ERP.RepositorySetup.ForUnit;

namespace Services.ERP.Extentions
{
    public static class RepositoryDeclareInServiceExtention
    {
        public static IServiceCollection AddScopedServicesForRepository(this IServiceCollection services, IConfiguration configuration)
        {
            //Repository
            services.AddScoped<IBranchRepository, BranchRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IChallanDetailsRepository, ChallanDetailsRepository>();
            services.AddScoped<IChallanMasterRepository, ChallanMasterRepository>();
            services.AddScoped<ILowerGroupRepository, LowerGroupRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IModuleRepository, ModuleRepository>();
            services.AddScoped<IPageRepository, PageRepository>();
            services.AddScoped<IProductColorRepository, ProductColorRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IGodownRepository, GodownRepository>();
            services.AddScoped<IUnitRepository, UnitRepository>();
            return services;
        }
    }
}
