using DatabaseContext;
using Infrustracture.ERP.RepositorySetup.ForSettings.ForPages.Interface;
using Microsoft.EntityFrameworkCore;
using ModelClass.ERP.DTO;
using ModelClass.ERP.UnitOfWorkRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustracture.ERP.RepositorySetup.ForSettings.ForPages.Logic
{
    public class PageRepository : Repository<Pages, int>, IPageRepository
    {
        public PageRepository(DatabaseContextDb context) : base((DbContext)context)
        {

        }
    }
}