﻿using DatabaseContext;
using Infrustracture.ERP.RepositorySetup.ForBrand;
using Microsoft.EntityFrameworkCore;
using ModelClass.ERP.DTO;
using ModelClass.ERP.UnitOfWorkRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustracture.ERP.RepositorySetup.ForProduct
{
    public class ProductRepository: Repository<Product, int>, IProductRepository
    {
        public ProductRepository(DatabaseContextDb contextDb):base((DbContext)contextDb)
        {

        }
    }
}
