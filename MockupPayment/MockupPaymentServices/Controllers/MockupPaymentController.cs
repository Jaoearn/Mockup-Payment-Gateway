using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MockupPaymentServices.Models;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace MockupPaymentServices.Controllers
{
    public class MockupPaymentController : Controller
    {
        private readonly ILogger<MockupPaymentController> _logger;
        private readonly string path = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/json/";

        public MockupPaymentController(ILogger<MockupPaymentController> logger)
        {
            _logger = logger;
        }

        [Route("MockPayment/{ReferenceOrder}")]
        public IActionResult Index(string ReferenceOrder)
        {
            string json = System.IO.File.ReadAllText(path + $"{ReferenceOrder}.json");
            var PaymentInfo = JsonConvert.DeserializeObject<CreatePaymentModel>(json);

            ViewData.Add("Reference_order", PaymentInfo.ReferenceOrder);
            ViewData.Add("Total_amount", PaymentInfo.TotalAmount);

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        [Route("/api/MockCreatePayment")]
        public async Task<dynamic> GetURL([FromBody] CreatePaymentModel createPaymentModel)
        {
            createPaymentModel.InvoiceNo = GetDynamicNumber();
            var jsondata = JsonConvert.SerializeObject(createPaymentModel);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            await System.IO.File.WriteAllTextAsync(path + $"{createPaymentModel.ReferenceOrder}.json", jsondata);
            PaymentResponseModels responseModel = new PaymentResponseModels();
            responseModel.Data.InvoiceNo = createPaymentModel.InvoiceNo;
            responseModel.Data.Url = String.Format("https://localhost:5001" + "/MockPayment/{0}", createPaymentModel.ReferenceOrder);

            return responseModel;
        }

        private string GetDynamicNumber()
        {
            var DynamicNumber = DateTime.Now.ToString("yyyyMMddHHmmssfff", new CultureInfo("en-US"));
            return DynamicNumber;
        }
    }
}
