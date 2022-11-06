using DatabaseContext;
using Infrustracture.ERP.RepositorySetup.ForBrand;
using Microsoft.EntityFrameworkCore;
using ModelClass.ERP.DTO;
using ModelClass.ERP.UnitOfWorkRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustracture.ERP.RepositorySetup.ForCategory
{
    public class CategoryRepository: Repository<Category, int>, ICategoryRepository
    {
        public CategoryRepository(DatabaseContextDb context): base((DbContext) context)
        {

        }
    }
}
