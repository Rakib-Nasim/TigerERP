using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ERP
{
    public class Enum
    {
        public enum AvailableStatus
        {
            Active = 1,
            Inactive = 2,
            Delete = 3,
        }

        public enum Gender
        {
            Male = 1,
            FeMale = 2,
            Other = 3,
        }

        public enum ProductCondition
        {
            Used = 1,
            New = 2
        }

        public enum ChallanType
        {
            Delivery = 1,
            Receive = 2,
            DeliveryReturn = 3,
            ReceiveReturn = 4,
            Transfer = 5,
            Manufacture = 6,
            Consumption = 7,
            WReceive = 8,

        }
    }
}
