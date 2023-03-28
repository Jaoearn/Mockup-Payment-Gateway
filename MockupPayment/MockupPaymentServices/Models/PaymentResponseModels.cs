using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockupPaymentServices.Models
{
    public class PaymentResponseModels
    {
        public PaymentResponseModels()
        {
            Response = new ResponseBaseModel();
            Data = new DataPayment();
            Response.Status = new StatusItem();
        }
        public ResponseBaseModel Response { get; set; }
        public DataPayment Data { get; set; }
        public string Error { get; set; }
    }
    public class DataPayment
    {
        public string InvoiceNo { get; set; }
        public string Url { get; set; }
    }
}
