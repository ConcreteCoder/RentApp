using EFLibrary.BusinessLogic;
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

namespace EFLibrary.DAL
{
    public interface IInventoryRepositoryDAL
    {

        Task<Tuple<List<Model_Inventory>, int>> GetAll(string token);


        Task<List<Model_Cart>> GetCart(string token);


        Task<int> UpdateCart(Model_Order objModel);



        Task<int> AddCart(Model_AddToCart param);


        Task<Tuple<List<Model_Cart>, Bondora_Order, Bondora_Customer>> GetOrders(string token);
    }

    public class InventoryRepositoryDAL : IInventoryRepositoryDAL
    {

        public async Task<Tuple<List<Model_Inventory>, int>> GetAll(string token)
        {
            List<Model_Inventory> inventory = null;


            int countOrdered = 0;
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    inventory = await (
                        from a in context.Bondora_Inventory
                        join b in context.Bondora_Inventory_Types on a.Type_id equals b.Type_id
                        select new Model_Inventory()
                        {
                            Inventory_id = a.Inventory_id,
                            Name = a.Name,
                            Type_id = a.Type_id ?? 0,
                            Type_name = b.Type_name
                        }).ToListAsync();

                    countOrdered = await (from a in context.Bondora_Cart
                                          where a.Token == token
                                          select a).CountAsync();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new Tuple<List<Model_Inventory>, int>(inventory, countOrdered);
        }

        public async Task<List<Model_Cart>> GetCart(string token)
        {
            List<Model_Cart> list = null;

            try
            {
                using (var context = new ApplicationDbContext())
                {
                    list = await (from a in context.Bondora_Inventory
                                  join b in context.Bondora_Inventory_Types on a.Type_id equals b.Type_id
                                  join c in context.Bondora_Cart on a.Inventory_id equals c.Inventory_id
                                  where c.Token == token
                                  select new Model_Cart()
                                  {
                                      Inventory_id = a.Inventory_id,
                                      Name = a.Name,
                                      Type_id = a.Type_id ?? 0,
                                      Type_name = b.Type_name,
                                      Days = c.Days ?? 0,
                                      Price = 0
                                  }).ToListAsync();
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
            int retval = -1;

            try
            {
                if (objModel != null)
                {
                    using (var context = new ApplicationDbContext())
                    {
                        var newItem = new Bondora_Order();
                        newItem.Customer_id = objModel.Customer_id;
                        newItem.Date_order = DateTime.Now;
                        newItem.Token = objModel.Token;
                        context.Entry(newItem).State = EntityState.Added;
                        await context.SaveChangesAsync();
                        retval = 1;
                    }
                }
                else
                {

                }
                return retval;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> AddCart(Model_AddToCart param)
        {
            int retval = -1;
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    if (param != null)
                    {
                        if (param.Inventory_id != 0)
                        {
                            var newItem = new Bondora_Cart();
                            newItem.Days = param.Numdays;
                            newItem.Inventory_id = param.Inventory_id;
                            newItem.Token = param.Token;
                            context.Entry(newItem).State = EntityState.Added;
                            await context.SaveChangesAsync();

                            var countOrdered = await (from a in context.Bondora_Cart
                                                      where a.Token == param.Token
                                                      select a).CountAsync();

                            retval = countOrdered;
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                    }
                }

                return retval;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Tuple<List<Model_Cart>, Bondora_Order, Bondora_Customer>> GetOrders(string token)
        {
            List<Model_Cart> list = null;
            Bondora_Order order = null;
            Bondora_Customer customer = null;

            try
            {
                using (var context = new ApplicationDbContext())
                {
                    order = await (from a in context.Bondora_Order
                                   where a.Token == token
                                   select a).FirstOrDefaultAsync();
                    if (order != null)
                    {
                        customer = await (from a in context.Bondora_Customer
                                          where a.Customer_id == order.Customer_id
                                          select a).FirstOrDefaultAsync();

                        list = await (from a in context.Bondora_Inventory
                                      join b in context.Bondora_Inventory_Types on a.Type_id equals b.Type_id
                                      join c in context.Bondora_Cart on a.Inventory_id equals c.Inventory_id
                                      where c.Token == token
                                      select new Model_Cart()
                                      {
                                          Inventory_id = a.Inventory_id,
                                          Name = a.Name,
                                          Type_id = a.Type_id ?? 0,
                                          Type_name = b.Type_name,
                                          Days = c.Days ?? 0,
                                          Price = 0
                                      }).ToListAsync();
                    }
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