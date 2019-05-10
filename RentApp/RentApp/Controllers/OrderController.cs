using EFLibrary.Models;
using RentApp.Custom;
using RentApp.InventoryReference;
using RentApp.Logger;
using RentApp.Resources;
using System;
using System.IO;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace RentApp.Controllers
{
    public class OrderController : Controller
    {
        private IInventoryService InventoryService;

        public OrderController(IInventoryService _InventoryService)
        {
            InventoryService = _InventoryService;
        }

        public async Task<ActionResult> Download()
        {
            string file = "";
            string token = Convert.ToString(HttpContext.Session["token"]);
            ContentType mimeType = new ContentType("text/plain");
            mimeType.CharSet = "utf-8";

            StringBuilder strb = new StringBuilder();            

            try
            {

                Model_Order param = new Model_Order() { Customer_id = 1, Token = token };
                await InventoryService.UpdateCartAsync(param);

                Tuple<Model_Cart[], Bondora_Order, Bondora_Customer> tuple = await InventoryService.GetOrdersAsync(token);

                file = Resource1.Order + tuple.Item2.Order_id + ".txt";

                strb = Invoice.GenerateInvoice(tuple.Item1, tuple.Item2, strb);

                ContentDisposition cd = new ContentDisposition
                {
                    FileName = file,
                    Inline = false
                };
                Response.ContentType = "UTF-8";
                Response.Headers.Add("Content-Disposition", cd.ToString());
                Response.Headers.Add("X-Content-Type-Options", "nosniff");


                byte[] byteArray = Encoding.ASCII.GetBytes(strb.ToString());
                MemoryStream stream = null;
                var memory = new MemoryStream();
                using (stream = new MemoryStream(byteArray))
                {
                    await stream.CopyToAsync(memory);
                }
                memory.Position = 0;
                return File(memory, mimeType.ToString());

            }
            catch (Exception ex)
            {
                var message = ex.Message + "; " + ex.InnerException;

                Log.Info(message);
                ViewBag.StatusMessage = message;
                return View();
            }
        }
    }
}