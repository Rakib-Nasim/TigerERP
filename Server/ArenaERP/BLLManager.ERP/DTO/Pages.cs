using ModelClass.ERP.UnitOfWorkRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClass.ERP.DTO
{
    public class Pages:IEntity<int>
    {
        public int Id { get; set; }
        public int ModuleId { get; set; }
        public string Name { get; set; }
        public string PageRoutePath { get; set; }
        public int? SerialNo { get; set; }
    }
}
