using DatabaseContext;
using Infrustracture.ERP.RepositorySetup.ForBrand;
using Infrustracture.ERP.RepositorySetup.ForProduct;
using Infrustracture.ERP.UnitOfWorkSetup.ForBrand;
using Microsoft.EntityFrameworkCore;
using ModelClass.ERP.UnitOfWorkRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustracture.ERP.UnitOfWorkSetup.ForProduct
{
    public class ProductUnitOfWork: UnitOfWork, IProductUnitOfWork
    {
        public IProductRepository Product { get; private set; }
        public ProductUnitOfWork(DatabaseContextDb contextDb,IProductRepository product):base((DbContext)contextDb)
        {
            Product = product;
        }
    }
}
