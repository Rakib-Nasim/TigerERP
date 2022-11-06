using DatabaseContext;
using Infrustracture.ERP.RepositorySetup.Accounting.ForLowerGroup;
using Infrustracture.ERP.RepositorySetup.ForBranch;
using Infrustracture.ERP.RepositorySetup.ForSettings.ForModule.Interface;
using Infrustracture.ERP.RepositorySetup.ForSettings.ForPages.Interface;
using Microsoft.EntityFrameworkCore;
using ModelClass.ERP.UnitOfWorkRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustracture.ERP.UnitOfWorkSetup.ForBranch
{
    public class CommonUnitOfWork : UnitOfWork, ICommonUnitOfWork
    {

        public IBranchRepository Branch { get; private set; }
        public ILowerGroupRepository AccountGroupLower { get; private set; }
        public IModuleRepository Module { get; private set; }
        public IPageRepository Pages { get; private set; }
        public CommonUnitOfWork(DatabaseContextDb dbContext,
                                IBranchRepository _branchRepository,
                                ILowerGroupRepository _lowerGroupRepository,
                                IModuleRepository _moduleRepository,
                                IPageRepository _pageRepository
                                ) : base((DbContext)dbContext)
        {
            Branch = _branchRepository;
            AccountGroupLower = _lowerGroupRepository;
            Module = _moduleRepository;
            Pages = _pageRepository;
        }

    }
}
