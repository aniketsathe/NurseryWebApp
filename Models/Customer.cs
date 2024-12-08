using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NurseryWebApp.Models
{
    public class Customer
    {
        public string CustomerName { get; set; }
        public long? MobileNumber { get; set; }
        public string EmailID { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
    }
}