using RentApp.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using RentApp.InventoryReference;
using EFLibrary.Models;
using RentApp.Logger;
using ToolLib;

namespace RentApp.Controllers
{
    public class HomeController : Controller
    {

        private IInventoryService InventoryService;
        public IToken ITokenService;

        public HomeController(IInventoryService _InventoryService, IToken _ITokenService)
        {
            InventoryService = _InventoryService;
            ITokenService = _ITokenService;
        }

        [HttpGet, OutputCache(CacheProfile = "Cache1Minute")]
        [SetupFilter]
        public async Task<ActionResult> Index()
        {
            List<Model_Inventory> result = null;
            int countOrdered = 0;
            try
            {
                Tuple<Model_Inventory[], int> tuple = await InventoryService.GetAllAsync(ViewBag.Token);
                result = tuple.Item1.ToList();
                countOrdered = tuple.Item2;
                ViewBag.CountOrdered = countOrdered;

                return View(result);
            }
            catch (Exception ex)
            {
                var message = ex.Message + "; " + ex.InnerException;
                Log.Error("Exception at Index:- <br/>" + message);
                ViewBag.StatusMessage = ex.Message + "<br />" + ex.InnerException;
                return View();
            }
        }
    }
}