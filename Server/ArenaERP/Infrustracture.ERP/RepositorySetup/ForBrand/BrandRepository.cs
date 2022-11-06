using DatabaseContext;
using Microsoft.EntityFrameworkCore;
using ModelClass.ERP.DTO;
using ModelClass.ERP.UnitOfWorkRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustracture.ERP.RepositorySetup.ForBrand
{
    public  class BrandRepository: Repository<Brand, int>, IBrandRepository
    {
        public BrandRepository(DatabaseContextDb context): base((DbContext)context)
        {
        }
    }
}
