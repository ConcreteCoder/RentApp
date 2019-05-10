using EFLibrary.DAL;
using EFLibrary.Datacontext;
using EFLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ToolLib;

namespace EFLibrary.BusinessLogic
{
    public interface IInventoryRepository
    {

        Task<Tuple<List<Model_Inventory>, int>> GetAll(string token);


        Task<List<Model_Cart>> GetCart(string token);


        Task<int> UpdateCart(Model_Order objModel);



        Task<int> AddCart(Model_AddToCart param);


        Task<Tuple<List<Model_Cart>, Bondora_Order, Bondora_Customer>> GetOrders(string token);
    }

    public class InventoryRepository : IInventoryRepository
    {
        private readonly IInventoryRepositoryDAL maincontext;
        private readonly ICalculate calculate;

        public InventoryRepository(IInventoryRepositoryDAL _context, ICalculate _calculate)
        {
            maincontext = _context;
            calculate = _calculate;
        }

        public async Task<Tuple<List<Model_Inventory>, int>> GetAll(string token)
        {
            return await maincontext.GetAll(token);
        }

        public async Task<List<Model_Cart>> GetCart(string token)
        {
            List<Model_Cart> list = null;
            string price_cur = "€";

            try
            {
                list = await maincontext.GetCart(token);

                foreach (var item in list)
                {
                    item.Price_cur = price_cur;
                    item.Price = calculate.CalcPrices(item.Type_id, item.Days);
                    item.Loyaltypoint = calculate.CalcPoints(item.Type_id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }

        public async Task<int> UpdateCart(Model_Order objModel)
        {


            try
            {
                return await maincontext.UpdateCart(objModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> AddCart(Model_AddToCart param)
        {
            return await maincontext.AddCart(param);
        }

        public async Task<Tuple<List<Model_Cart>, Bondora_Order, Bondora_Customer>> GetOrders(string token)
        {
            List<Model_Cart> list = null;
            Bondora_Order order = null;
            Bondora_Customer customer = null;
            string price_cur = "€";

            try
            {
                Tuple<List<Model_Cart>, Bondora_Order, Bondora_Customer> tuple = await maincontext.GetOrders(token);

                list = tuple.Item1;
                order = tuple.Item2;
                customer = tuple.Item3;

                foreach (var item in list)
                {
                    item.Price = calculate.CalcPrices(item.Type_id, item.Days);
                    item.Price_cur = price_cur;
                    item.Loyaltypoint = calculate.CalcPoints(item.Type_id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new Tuple<List<Model_Cart>, Bondora_Order, Bondora_Customer>(list, order, customer);
        }
    }
}