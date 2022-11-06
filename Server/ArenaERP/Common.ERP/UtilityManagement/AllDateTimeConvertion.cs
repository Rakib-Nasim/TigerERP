using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ERP.UtilityManagement
{
    public abstract class AllDateTimeConvertion
    {

        //date time to mm/dd/yyyy Algorithom
        public Task<string> DateToYyyymmddAlogorithm(DateTime dateTime)
        {
            string first = dateTime.Year.ToString();
            string second = dateTime.Month.ToString();
            string third = dateTime.Day.ToString();
            string result = first+second+third;
            return Task.FromResult(result);
        }



        //date To YyyyMMdd
        public Task<string>DateToYyyymmdd(DateTime dateTime)
        {
            string result =  dateTime.ToString("yyyyMMdd");
            return Task.FromResult(result);
        }


        // MM/dd/yyyy To yyyyMMdd
        public  Task<string> MmDdYyyyToYyyymmdd(string date)
        {
            string [] dateString = date.Split("/");
            string month = "";
            string day = "";
            string year = "";
            if (dateString[0].Length < 2)
            {
                month="0"+dateString[0];
            }
            else
            {
                month=dateString[0];    
            }
            if (dateString[1].Length < 2)
            {
                day = "0" + dateString[1];
            }
            else
            {
                day = dateString[1];
            }

            year=dateString[2];

            return Task.FromResult(year+month+day);

        }

        // dd/MM/yyyy To yyyyMMdd
        public Task<string> DdMMYyyyToYyyymmdd(string date)
        {
            string[] dateString = date.Split("/");
            string month = "";
            string day = "";
            string year = "";
            if (dateString[0].Length < 2)
            {
                day = "0" + dateString[0];
            }
            else
            {
                day = dateString[0];
            }
            if (dateString[1].Length < 2)
            {
                month = "0" + dateString[1];
            }
            else
            {
                month = dateString[1];
            }

            year = dateString[2];

            return Task.FromResult(year + month + day);

        }


        //Age Calculate yyyymmdd

        public Task<decimal> AgeCalculateYyyymmdd(string value1,string value2)
        {
            decimal number1 = decimal.Parse(value1);
            decimal number2 = decimal.Parse(value2);
            decimal result = number1-number2;
            return Task.FromResult(result);
        }

        public Task< int> CalculateAgeFromDate( DateTime theDateTime)
        {
            var age = DateTime.Today.Year - theDateTime.Year;
            if (theDateTime.AddYears(age) > DateTime.Today)
                age--;
            return Task.FromResult(age);
        }

    }
}
