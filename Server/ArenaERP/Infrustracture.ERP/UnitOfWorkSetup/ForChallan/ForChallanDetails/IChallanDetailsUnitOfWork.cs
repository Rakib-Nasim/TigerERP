using Infrustracture.ERP.RepositorySetup.ForChallan.ForChallanDetais;
using ModelClass.ERP.UnitOfWorkRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustracture.ERP.UnitOfWorkSetup.ForChallan.ForChallanDetails
{
    public interface IChallanDetailsUnitOfWork : IUnitOfWork
    {
        IChallanDetailsRepository ChallanDetails { get; }
    }
}
