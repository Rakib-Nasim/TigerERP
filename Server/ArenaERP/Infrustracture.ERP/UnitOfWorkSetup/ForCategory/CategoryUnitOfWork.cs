using DatabaseContext;
using Infrustracture.ERP.RepositorySetup.ForBranch;
using Infrustracture.ERP.RepositorySetup.ForCategory;
using Infrustracture.ERP.UnitOfWorkSetup.ForBranch;
using Microsoft.EntityFrameworkCore;
using ModelClass.ERP.UnitOfWorkRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustracture.ERP.UnitOfWorkSetup.ForCategory
{
    public class CategoryUnitOfWork: UnitOfWork, ICategoryUnitOfWork
    {
        public ICategoryRepository Category { get; private set; }
        public CategoryUnitOfWork(ICategoryRepository categoryRepository, DatabaseContextDb dbContext):base((DbContext)dbContext)
        {
            Category = categoryRepository;
        }
    }
}
