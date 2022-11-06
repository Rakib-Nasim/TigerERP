using DatabaseContext;
using Infrustracture.ERP.RepositorySetup.ForProductColor;
using Infrustracture.ERP.RepositorySetup.ForUnit;
using Microsoft.EntityFrameworkCore;
using ModelClass.ERP.UnitOfWorkRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustracture.ERP.UnitOfWorkSetup.ForUnit
{
    public class UnitUnitOfWork: UnitOfWork,IUnitUnitOfWork
    {
        public IUnitRepository Unit { get; private set; }

        public UnitUnitOfWork(DatabaseContextDb dbContext, IUnitRepository _unit) : base((DbContext)dbContext)
        {
            Unit = _unit;
        }
    }
}
