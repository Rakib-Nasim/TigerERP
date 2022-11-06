using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClass.ERP.ViewModel
{
    public class ExceptionLogModel
    {
        public string? ApplicationName { get; set; }
        public string? ExceptionType { get; set; }
        public string? ExceptionDetails { get; set; }
        public string? Message { get; set; }
        public string? RequestUrl { get; set; }
        public DateTime? CreatedDateTime { get; set; }
    }
}
