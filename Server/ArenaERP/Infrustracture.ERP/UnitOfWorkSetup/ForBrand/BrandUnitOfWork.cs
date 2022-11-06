using DatabaseContext;
using Infrustracture.ERP.RepositorySetup.ForBranch;
using Infrustracture.ERP.RepositorySetup.ForBrand;
using Infrustracture.ERP.UnitOfWorkSetup.ForBranch;
using Microsoft.EntityFrameworkCore;
using ModelClass.ERP.UnitOfWorkRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustracture.ERP.UnitOfWorkSetup.ForBrand
{
    public class BrandUnitOfWork : UnitOfWork, IBrandUnitOfWork
    {
        public IBrandRepository Brand { get; private set; }
        public BrandUnitOfWork(DatabaseContextDb dbContext
            , IBrandRepository _brandRepository) : base((DbContext)dbContext)
        {
            Brand = _brandRepository;
        }
    }
}
