using Infrustracture.ERP.RepositorySetup.ForBrand;
using Infrustracture.ERP.RepositorySetup.ForGodown;
using ModelClass.ERP.UnitOfWorkRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustracture.ERP.UnitOfWorkSetup.ForGodown
{
    public interface IGodownUnitOfWork: IUnitOfWork
    {
        IGodownRepository Godown{ get; }
    }
}
