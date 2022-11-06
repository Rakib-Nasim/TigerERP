using DatabaseContext;
using Infrustracture.ERP.RepositorySetup.ForChallan.ForChallanMaster;
using Microsoft.EntityFrameworkCore;
using ModelClass.ERP.UnitOfWorkRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustracture.ERP.UnitOfWorkSetup.ForChallan.ForChallanMaster
{
    public class ChallanMasterUnitOfWork : UnitOfWork, IChallanMasterUnitOfWork
    {
        public IChallanMasterRepository ChallanMaster { get; private set; }
        public ChallanMasterUnitOfWork(DatabaseContextDb dbContext
            , IChallanMasterRepository _challanMasterRepository) : base((DbContext)dbContext)
        {
            ChallanMaster = _challanMasterRepository;
        }
    }
}
