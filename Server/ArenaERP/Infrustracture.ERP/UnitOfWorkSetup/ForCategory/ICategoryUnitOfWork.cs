using Infrustracture.ERP.RepositorySetup.ForBranch;
using Infrustracture.ERP.RepositorySetup.ForCategory;
using ModelClass.ERP.UnitOfWorkRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustracture.ERP.UnitOfWorkSetup.ForCategory
{
    public interface ICategoryUnitOfWork:IUnitOfWork
    {
        ICategoryRepository Category { get; }
    }
}
