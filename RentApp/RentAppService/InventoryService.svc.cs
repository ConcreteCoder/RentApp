using EFLibrary.BusinessLogic;
using EFLibrary.DAL;
using EFLibrary.Datacontext;
using EFLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ToolLib;

namespace RentAppService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "InventoryService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select InventoryService.svc or InventoryService.svc.cs at the Solution Explorer and start debugging.
    public class InventoryService : IInventoryService
    {
        private IInventoryRepository inventoryRepository { get; set; }

        public InventoryService()
        {
            inventoryRepository = new InventoryRepository(new InventoryRepositoryDAL(), new Calculate());
        }

        public async Task<Tuple<List<Model_Inventory>, int>> GetAll(string token)
        {
            return await inventoryRepository.GetAll(token);
        }

        public async Task<List<Model_Cart>> GetCart(string token)
        {
            return await inventoryRepository.GetCart(token);
        }

        public async Task<int> UpdateCart(Model_Order objModel)
        {
            return await inventoryRepository.UpdateCart(objModel);
        }

        public async Task<int> AddCart(Model_AddToCart param)
        {
            return await inventoryRepository.AddCart(param);
        }

        public async Task<Tuple<List<Model_Cart>, Bondora_Order, Bondora_Customer>> GetOrders(string token)
        {
            return await inventoryRepository.GetOrders(token);
        }
    }
}
