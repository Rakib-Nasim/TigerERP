using Infrustracture.ERP.RepositorySetup.Accounting.ForLowerGroup;
using Infrustracture.ERP.RepositorySetup.ForBranch;
using Infrustracture.ERP.RepositorySetup.ForSettings.ForModule.Interface;
using Infrustracture.ERP.RepositorySetup.ForSettings.ForPages.Interface;
using ModelClass.ERP.UnitOfWorkRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustracture.ERP.UnitOfWorkSetup.ForBranch
{
    public interface ICommonUnitOfWork : IUnitOfWork
    {
        IBranchRepository Branch { get; }
        IModuleRepository Module { get; }
        IPageRepository Pages { get; }
        ILowerGroupRepository AccountGroupLower { get; }

    }
}
