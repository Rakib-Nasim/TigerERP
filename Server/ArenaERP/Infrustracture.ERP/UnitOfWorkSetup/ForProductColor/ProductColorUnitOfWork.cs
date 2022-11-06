using DatabaseContext;
using Infrustracture.ERP.RepositorySetup.ForBrand;
using Infrustracture.ERP.RepositorySetup.ForProductColor;
using Infrustracture.ERP.UnitOfWorkSetup.ForBrand;
using Microsoft.EntityFrameworkCore;
using ModelClass.ERP.UnitOfWorkRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustracture.ERP.UnitOfWorkSetup.ForProductColor
{
    public class ProductColorUnitOfWork: UnitOfWork, IProductColorUnitOfWork
    {
        public IProductColorRepository ProductColor { get; private set; }

        public ProductColorUnitOfWork(DatabaseContextDb dbContext, IProductColorRepository _productColor):base((DbContext)dbContext)
        {
            ProductColor = _productColor;
        }
    }
}
