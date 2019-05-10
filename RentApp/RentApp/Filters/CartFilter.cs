using RentApp.Resources;
using System;
using System.Resources;
using System.Web.Mvc;

namespace RentApp.Filters
{
    public class CartFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string token = Convert.ToString(filterContext.HttpContext.Session["token"]);
            int? customer_id = Convert.ToInt32(filterContext.HttpContext.Session["customer_id"]);


            var ViewBag = filterContext.Controller.ViewBag;
            ViewBag.Token = token;
            ViewBag.Customer_id = customer_id;
            ViewBag.strToken = token;

            ViewBag.Title = Resource1.Title;
            ViewBag.CartTitle = Resource1.ShoppingCart;
            ViewBag.NotFound = Resource1.NotFound;
            ViewBag.SubmitOrder = Resource1.SubmitOrder;
            ViewBag.TotalLabel = Resource1.Total;

            ViewBag.Name = Resource1.Name;
            ViewBag.Type = Resource1.Type;
            ViewBag.Days = Resource1.Days;
            ViewBag.Duration = Resource1.Duration;
            ViewBag.Price = Resource1.Price;
            ViewBag.Delete = Resource1.Delete;
            ViewBag.LoyaltyPoints = Resource1.LoyaltyPoints;

            base.OnActionExecuting(filterContext);
        }




    }
}