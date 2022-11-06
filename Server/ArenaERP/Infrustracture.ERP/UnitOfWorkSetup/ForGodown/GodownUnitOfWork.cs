using DatabaseContext;
using Infrustracture.ERP.RepositorySetup.ForBrand;
using Infrustracture.ERP.RepositorySetup.ForGodown;
using Microsoft.EntityFrameworkCore;
using ModelClass.ERP.UnitOfWorkRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustracture.ERP.UnitOfWorkSetup.ForGodown
{
    public class GodownUnitOfWork:UnitOfWork,IGodownUnitOfWork
    {
        public IGodownRepository Godown{ get; private set; }
        public GodownUnitOfWork(DatabaseContextDb dbContext, IGodownRepository godown):base((DbContext)dbContext)
        {
            Godown = godown;
        }

    }
}
