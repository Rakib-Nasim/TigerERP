using DatabaseContext;
using Infrustracture.ERP.RepositorySetup.ForSettings.ForModule.Interface;
using Microsoft.EntityFrameworkCore;
using ModelClass.ERP.DTO;
using ModelClass.ERP.UnitOfWorkRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustracture.ERP.RepositorySetup.ForSettings.ForModule.Logic
{
    public class ModuleRepository : Repository<Modules, int>, IModuleRepository
    {
        public ModuleRepository(DatabaseContextDb context) : base((DbContext)context)
        {

        }
    }
}
