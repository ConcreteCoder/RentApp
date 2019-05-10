using EFLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace RentAppService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IInventoryService" in both code and config file together.
    [ServiceContract]
    public interface IInventoryService
    {

        [OperationContract]
        Task<Tuple<List<Model_Inventory>, int>> GetAll(string token);

        [OperationContract]
        Task<List<Model_Cart>> GetCart(string token);

        [OperationContract]
        Task<int> UpdateCart(Model_Order objModel);


        [OperationContract]
        Task<int> AddCart(Model_AddToCart param);

        [OperationContract]
        Task<Tuple<List<Model_Cart>, Bondora_Order, Bondora_Customer>> GetOrders(string token);

    }
}
