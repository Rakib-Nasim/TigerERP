using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClass.ERP.ViewModel
{
    public class ChallanViewModel
    {
        public int? NatureId { get; set; }
        public ChallanMasterViewModel ChallanMaster { get; set; }
        public List<ChallanDetailsViewModel> ChallanDetails { get; set; }
    }
}
