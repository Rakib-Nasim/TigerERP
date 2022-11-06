using Infrustracture.ERP.RepositorySetup.ForChallan.ForChallanMaster;
using ModelClass.ERP.UnitOfWorkRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustracture.ERP.UnitOfWorkSetup.ForChallan.ForChallanMaster
{
    public interface IChallanMasterUnitOfWork : IUnitOfWork
    {
        IChallanMasterRepository ChallanMaster { get; }
    }
}
