using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MockupPaymentServices.Models
{
    public class CreatePaymentModel
    {
        [JsonPropertyName("reference_order")]
        public string ReferenceOrder { get; set; }
        [JsonPropertyName("invoice_no")]
        public string InvoiceNo { get; set; }
        [JsonPropertyName("payment_status")]
        public string PaymentStatus { get; set; }
        [JsonPropertyName("firstname")]
        public string FirstName { get; set; }
        [JsonPropertyName("lastname")]
        public string LastName { get; set; }
        [JsonPropertyName("total_amount")]
        public double TotalAmount { get; set; }
        [JsonPropertyName("callback_url")]
        public string CallbackURL { get; set; }
    }
}
