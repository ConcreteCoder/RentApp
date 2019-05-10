using RentApp.Resources;
using System;
using System.Resources;
using System.Web.Mvc;

namespace RentApp.Filters
{
    public class OrderFilter : ActionFilterAttribute
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
            ViewBag.Name = Resource1.Name;
            ViewBag.Type = Resource1.Type;
            ViewBag.Duration = Resource1.Duration;
            ViewBag.DateOrderLabel = Resource1.DateOrder;
            ViewBag.ProductsCountLabel = Resource1.ProductsCount;
            ViewBag.CustomerNameLabel = Resource1.Customer;
            ViewBag.LoyaltyPointsLabel = Resource1.LoyaltyPoints;
            ViewBag.StartNewOrder = Resource1.StartNewOrder;
            ViewBag.Download = Resource1.Download;
            ViewBag.Print = Resource1.Print;



            base.OnActionExecuting(filterContext);
        }




    }
}