﻿using DatabaseContext;
using Microsoft.EntityFrameworkCore;
using ModelClass.ERP.DTO;
using ModelClass.ERP.UnitOfWorkRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustracture.ERP.RepositorySetup.ForUnit
{
    public class UnitRepository:Repository<Unit, int>,IUnitRepository
    {
        public UnitRepository(DatabaseContextDb context) : base((DbContext)context)
        {

        }
    }
}
