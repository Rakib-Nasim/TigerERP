﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ERP
{
    public class Response
    {
        public Response() { }
        public Response(string action)
        {
            Action = action;
        }
        public Response(string action, bool status)
        {
            Action = action;
            Status = status;
        }
        public Response(string action, bool status, object result)
        {
            Action = action;
            Status = status;
            Result = result;
        }
        public bool Status { get; set; }
        public string Action { get; set; }
        public object Result { get; set; }
    }
}
