using EFLibrary.Models;
using RentApp.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace RentApp.Custom
{
    public class Invoice
    {

        public static StringBuilder GenerateInvoice(Model_Cart[] lcart, Bondora_Order order, StringBuilder strb)
        {
            string file = "";
            string price_cur = "EUR";
            int count = 0, loyaltyPoints = 0;
            decimal total = 0;

            strb.Append(Resource1.OrderNo + " " + order.Order_id + Environment.NewLine);
            file = Resource1.Order + order.Order_id + ".txt";

            strb.Append("Days    Name      Price" + Environment.NewLine);

            foreach (var item in lcart)
            {
                item.Price_cur = price_cur;
                total += item.Price;
                loyaltyPoints += item.Loyaltypoint;
                count += 1;
                strb.Append(item.Days + "    " + item.Name + "      " + item.Price + " " + item.Price_cur + Environment.NewLine);
            }
            strb.Append(Environment.NewLine + Resource1.ProductsCount + ": " + count + Environment.NewLine);
            strb.Append(Resource1.Total + ": " + total + " " + price_cur + Environment.NewLine);
            strb.Append(Resource1.LoyaltyPoints + " " + loyaltyPoints + Environment.NewLine);

            return strb;
        }

    }
}