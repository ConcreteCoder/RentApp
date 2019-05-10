using EFLibrary.Models;
using RentApp.InventoryReference;
using RentApp.Logger;
using RentApp.Resources;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace RentEquipment2.Controllers
{
    public class ApiInventoryController : Controller
    {
        private IInventoryService InventoryService;

        public ApiInventoryController(IInventoryService _InventoryService)
        {
            InventoryService = _InventoryService;
        }

        [HttpPost]
        public async Task<JsonResult> Post(int inventory_id, int numdays, string token)
        {
            Log.Info("ApiInventory controller post request starts:-");


            JsonResult jsonData = null;
            try
            {

                Model_AddToCart param = new Model_AddToCart()
                {
                    Inventory_id = inventory_id,
                    Numdays = numdays,
                    Token = token
                };

                if (param.Inventory_id != 0)
                {
                    var countOrdered = await InventoryService.AddCartAsync(param);

                    jsonData = Json(new { success = true, msg = Resource1.AddedToCard, countOrdered = countOrdered.ToString() });
                }
                else
                {
                    jsonData = Json(new { success = false, msg = Resource1.NotFound, countOrdered = 0 });
                }
            }
            catch (Exception ex)
            {
                var messsage = ex.Message + "<br />" + ex.InnerException + "<br />" + ex.StackTrace;
                Log.Error("ApiInventory post request error occurred:- <br/>" + messsage);
                jsonData = Json(new { msg = messsage });
            }

            Log.Info("ApiInventory controller post request ends:-");

            return jsonData;
        }


    }
}