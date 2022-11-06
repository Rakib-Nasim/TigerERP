using DatabaseContext;
using Infrustracture.ERP.RepositorySetup.ForChallan.ForChallanDetais;
using Infrustracture.ERP.RepositorySetup.ForChallan.ForChallanMaster;
using Microsoft.EntityFrameworkCore;
using ModelClass.ERP.UnitOfWorkRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustracture.ERP.UnitOfWorkSetup.ForChallan.ForChallanDetails
{
    public class ChallanDetailsUnitOfWork : UnitOfWork, IChallanDetailsUnitOfWork
    {
        public IChallanDetailsRepository ChallanDetails { get; private set; }
        public ChallanDetailsUnitOfWork(DatabaseContextDb dbContext
            , IChallanDetailsRepository _challanDetailsRepository) : base((DbContext)dbContext)
        {
            ChallanDetails = _challanDetailsRepository;
        }
    }
}
