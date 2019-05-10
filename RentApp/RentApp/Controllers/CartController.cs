using EFLibrary.Models;
using RentApp.Filters;
using RentApp.InventoryReference;
using RentApp.Logger;
using RentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace RentApp.Controllers
{
    public class CartController : Controller
    {
        private IInventoryService InventoryService;

        public CartController(IInventoryService _InventoryService)
        {
            InventoryService = _InventoryService;
        }


        [HttpGet]
        [CartFilter]
        public async Task<ActionResult> Cart()
        {

            Log.Info("Cart controller Get request starts:-");

            string price_cur = "€";
            decimal total = 0;
            Model_Cart[] list;
            string token = Convert.ToString(HttpContext.Session["token"]);

            try
            {
                list = await InventoryService.GetCartAsync(token);
                total = list.Sum(p => p.Price);

                ViewBag.Total = total + " " + price_cur;

                Log.Info("Cart controller Get request ends:-");
                return View(list);
            }
            catch (Exception ex)
            {
                var messsage = ex.Message + "<br />" + ex.InnerException + "<br />";

                Log.Error("Cart controller Get request error occurred:- <br/>" + messsage);
                ViewBag.StatusMessage = messsage;
                return View();
            }
        }
    }
}