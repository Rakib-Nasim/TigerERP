using DatabaseContext;
using ModelClass.ERP.DTO;
using Microsoft.EntityFrameworkCore;

using ModelClass.ERP.UnitOfWorkRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustracture.ERP.RepositorySetup.ForProductColor
{
    public class ProductColorRepository:Repository<Color,int>,IProductColorRepository
    {
        public ProductColorRepository(DatabaseContextDb context):base((DbContext) context)
        {

        }
    }
}
