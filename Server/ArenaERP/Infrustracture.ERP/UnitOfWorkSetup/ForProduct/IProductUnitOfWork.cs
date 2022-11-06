using Infrustracture.ERP.RepositorySetup.ForBrand;
using Infrustracture.ERP.RepositorySetup.ForProduct;
using ModelClass.ERP.UnitOfWorkRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustracture.ERP.UnitOfWorkSetup.ForProduct
{
    public interface IProductUnitOfWork: IUnitOfWork
    {
        IProductRepository Product { get; }
    }
}
