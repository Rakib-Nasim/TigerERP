using DatabaseContext;
using Microsoft.EntityFrameworkCore;
using ModelClass.ERP.DTO;
using ModelClass.ERP.UnitOfWorkRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustracture.ERP.RepositorySetup.Accounting.ForLowerGroup
{
    public class LowerGroupRepository : Repository<AccountGroupLower, int>, ILowerGroupRepository
    {
        public LowerGroupRepository(DatabaseContextDb context) : base((DbContext)context)
        {
        }
    }
}
