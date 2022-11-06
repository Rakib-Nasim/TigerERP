using Infrustracture.ERP.RepositorySetup.ForUnit;
using ModelClass.ERP.UnitOfWorkRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustracture.ERP.UnitOfWorkSetup.ForUnit
{
    public interface IUnitUnitOfWork:IUnitOfWork
    {
        IUnitRepository Unit { get; }
    }
}
