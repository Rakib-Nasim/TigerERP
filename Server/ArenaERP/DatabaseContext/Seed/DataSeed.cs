using ModelClass.ERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseContext.Seed
{
    public class DataSeed
    {
        public Branch[] Branch
        {
            get
            {
                return new Branch[]
                {
                    new Branch{Id=1, BranchId = -1,Name="Head Office",ContactNo="01749251242",Address="Bangla Motor,Dhaka"}
                };
            }
        } 
    }
}
