using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockupPaymentServices.Models
{
    public class ResponseBaseModel
    {
        public DateTime Date { get; set; } = DateTime.Now;
        public StatusItem Status { get; set; }
    }
    public class StatusItem
    {
        public string Code { get; set; } = "0";
        public string Description { get; set; } = "Success";
    }
}
