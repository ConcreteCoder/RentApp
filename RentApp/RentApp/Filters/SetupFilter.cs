using RentApp.Controllers;
using RentApp.Logger;
using RentApp.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using ToolLib;

namespace RentApp.Filters
{
    public class SetupFilter : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Setup(filterContext);

            base.OnActionExecuting(filterContext);
        }

        private void Setup(ActionExecutingContext filterContext)
        {
            Log.Info("Setup filter starts");

            var thisController = ((HomeController)filterContext.Controller);
            var tokenService = thisController.ITokenService;

            int customer_id = 1;

            string culture = "en";
            var cultureInfo = new CultureInfo(culture);
            cultureInfo.NumberFormat.CurrencySymbol = "€";
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(culture);

            //clear token
            filterContext.HttpContext.Session.Remove("token");

         

            string token = "";
            if (filterContext.HttpContext != null)
            {
                // token = filterContext.HttpContext.Session["token"].ToString();
                if (filterContext.HttpContext.Session["token"] == null)
                {
                    Token t = new Token();
                    if (tokenService != null)
                    {
                        token = t.CreateToken();
                    }
                    filterContext.HttpContext.Session.Add("token", token);
                }
                filterContext.HttpContext.Session.Add("customer_id", customer_id);
            }

            var ViewBag = filterContext.Controller.ViewBag;

            ViewBag.Token = token;

            ViewBag.Title = Resource1.Title;
            ViewBag.NotFound = Resource1.NotFound;
            ViewBag.Name = Resource1.Name;
            ViewBag.Type = Resource1.Type;
            ViewBag.Duration = Resource1.Duration;
            ViewBag.Days = Resource1.Days;
            ViewBag.AddCart = Resource1.AddCart;
            ViewBag.ErrorApiCall = Resource1.ErrorApiCall;
            ViewBag.Cart = Resource1.ShoppingCart;
            ViewBag.OpenCart = Resource1.OpenCart;
            ViewBag.WrongInput = Resource1.WrongInput;
        }
    }
}