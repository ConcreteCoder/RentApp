﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RentApp.InventoryReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="InventoryReference.IInventoryService")]
    public interface IInventoryService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IInventoryService/GetAll", ReplyAction="http://tempuri.org/IInventoryService/GetAllResponse")]
        System.Tuple<EFLibrary.Models.Model_Inventory[], int> GetAll(string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IInventoryService/GetAll", ReplyAction="http://tempuri.org/IInventoryService/GetAllResponse")]
        System.Threading.Tasks.Task<System.Tuple<EFLibrary.Models.Model_Inventory[], int>> GetAllAsync(string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IInventoryService/GetCart", ReplyAction="http://tempuri.org/IInventoryService/GetCartResponse")]
        EFLibrary.Models.Model_Cart[] GetCart(string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IInventoryService/GetCart", ReplyAction="http://tempuri.org/IInventoryService/GetCartResponse")]
        System.Threading.Tasks.Task<EFLibrary.Models.Model_Cart[]> GetCartAsync(string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IInventoryService/UpdateCart", ReplyAction="http://tempuri.org/IInventoryService/UpdateCartResponse")]
        int UpdateCart(EFLibrary.Models.Model_Order objModel);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IInventoryService/UpdateCart", ReplyAction="http://tempuri.org/IInventoryService/UpdateCartResponse")]
        System.Threading.Tasks.Task<int> UpdateCartAsync(EFLibrary.Models.Model_Order objModel);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IInventoryService/AddCart", ReplyAction="http://tempuri.org/IInventoryService/AddCartResponse")]
        int AddCart(EFLibrary.Models.Model_AddToCart param);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IInventoryService/AddCart", ReplyAction="http://tempuri.org/IInventoryService/AddCartResponse")]
        System.Threading.Tasks.Task<int> AddCartAsync(EFLibrary.Models.Model_AddToCart param);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IInventoryService/GetOrders", ReplyAction="http://tempuri.org/IInventoryService/GetOrdersResponse")]
        System.Tuple<EFLibrary.Models.Model_Cart[], EFLibrary.Models.Bondora_Order, EFLibrary.Models.Bondora_Customer> GetOrders(string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IInventoryService/GetOrders", ReplyAction="http://tempuri.org/IInventoryService/GetOrdersResponse")]
        System.Threading.Tasks.Task<System.Tuple<EFLibrary.Models.Model_Cart[], EFLibrary.Models.Bondora_Order, EFLibrary.Models.Bondora_Customer>> GetOrdersAsync(string token);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IInventoryServiceChannel : RentApp.InventoryReference.IInventoryService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class InventoryServiceClient : System.ServiceModel.ClientBase<RentApp.InventoryReference.IInventoryService>, RentApp.InventoryReference.IInventoryService {
        
        public InventoryServiceClient() {
        }
        
        public InventoryServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public InventoryServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public InventoryServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public InventoryServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Tuple<EFLibrary.Models.Model_Inventory[], int> GetAll(string token) {
            return base.Channel.GetAll(token);
        }
        
        public System.Threading.Tasks.Task<System.Tuple<EFLibrary.Models.Model_Inventory[], int>> GetAllAsync(string token) {
            return base.Channel.GetAllAsync(token);
        }
        
        public EFLibrary.Models.Model_Cart[] GetCart(string token) {
            return base.Channel.GetCart(token);
        }
        
        public System.Threading.Tasks.Task<EFLibrary.Models.Model_Cart[]> GetCartAsync(string token) {
            return base.Channel.GetCartAsync(token);
        }
        
        public int UpdateCart(EFLibrary.Models.Model_Order objModel) {
            return base.Channel.UpdateCart(objModel);
        }
        
        public System.Threading.Tasks.Task<int> UpdateCartAsync(EFLibrary.Models.Model_Order objModel) {
            return base.Channel.UpdateCartAsync(objModel);
        }
        
        public int AddCart(EFLibrary.Models.Model_AddToCart param) {
            return base.Channel.AddCart(param);
        }
        
        public System.Threading.Tasks.Task<int> AddCartAsync(EFLibrary.Models.Model_AddToCart param) {
            return base.Channel.AddCartAsync(param);
        }
        
        public System.Tuple<EFLibrary.Models.Model_Cart[], EFLibrary.Models.Bondora_Order, EFLibrary.Models.Bondora_Customer> GetOrders(string token) {
            return base.Channel.GetOrders(token);
        }
        
        public System.Threading.Tasks.Task<System.Tuple<EFLibrary.Models.Model_Cart[], EFLibrary.Models.Bondora_Order, EFLibrary.Models.Bondora_Customer>> GetOrdersAsync(string token) {
            return base.Channel.GetOrdersAsync(token);
        }
    }
}
