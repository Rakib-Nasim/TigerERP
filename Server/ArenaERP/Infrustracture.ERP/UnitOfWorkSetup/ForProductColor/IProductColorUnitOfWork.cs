using Infrustracture.ERP.RepositorySetup.ForProductColor;
using ModelClass.ERP.UnitOfWorkRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustracture.ERP.UnitOfWorkSetup.ForProductColor
{
    public interface IProductColorUnitOfWork:IUnitOfWork
    {
        IProductColorRepository ProductColor { get; }
    }
}
