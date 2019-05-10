using EFLibrary.BusinessLogic;
using EFLibrary.DAL;
using EFLibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;


namespace RentAppUnitTest
{
    [TestClass]
    public class MoqTest
    {
        Mock<IInventoryRepositoryDAL> IRepoDal = null;
        ICalculate calculate = null;
        IInventoryRepository IRepoBLL = null;
        string token = string.Empty;
        int customerId = 0;
        List<Model_Inventory> lInvData;
        List<Model_Cart> lcart;

        [TestInitialize]
        public void Initialize()
        {
            calculate = new Calculate();

            Model_Order objModel_ord = new Model_Order()
            {
                Customer_id = customerId,
                Token = token
            };



            Tuple<List<Model_Cart>, Bondora_Cart, Bondora_Customer> tupleGetOrders = new Tuple<List<Model_Cart>, Bondora_Cart, Bondora_Customer>(null, null, null);

            IRepoDal = new Mock<IInventoryRepositoryDAL>();





            IRepoDal.Setup(x => x.UpdateCart(objModel_ord)).ReturnsAsync(1);

        }

        [TestMethod]
        public void GetAllInventoryData()
        {

            lInvData = new List<Model_Inventory>() {
                new Model_Inventory(){Inventory_id =1,Name="Caterpillar bulldozer",Type_id=1,Type_name="Heavy"},
                new Model_Inventory(){Inventory_id =2,Name="KAmaz",Type_id=2,Type_name="Regular"},
                new Model_Inventory(){Inventory_id =3,Name="Komatsu",Type_id=1,Type_name="Heavy"},
                new Model_Inventory(){Inventory_id =4,Name="Volvo",Type_id=2,Type_name="Regular"},
                new Model_Inventory(){Inventory_id =5,Name="Bosch",Type_id=3,Type_name="Specialized"},

                };

            Tuple<List<Model_Inventory>, int> tupleGetAll = new Tuple<List<Model_Inventory>, int>(lInvData, 0);

            IRepoDal.Setup(x => x.GetAll(token)).ReturnsAsync(tupleGetAll);

            IRepoBLL = new InventoryRepository(IRepoDal.Object, calculate);
            var lresultdata = IRepoBLL.GetAll(token);
            CollectionAssert.AreEqual(lInvData, lresultdata.Result.Item1);
        }

        [TestMethod]
        public void CheckHeavyLoyaltyPoints()
        {

            lcart = new List<Model_Cart>() {
                new Model_Cart(){Days=1,Name="Caterpillar bulldozer",Type_id=1,Inventory_id=1,Type_name="Heavy" },

            };

            IRepoDal.Setup(x => x.GetCart(token)).ReturnsAsync(lcart);

            IRepoBLL = new InventoryRepository(IRepoDal.Object, calculate);
            var lresultdata = IRepoBLL.GetCart(token);
            Assert.AreEqual(lresultdata.Result[0].Loyaltypoint, 2);
        }

        [TestMethod]
        public void CheckRegularLoyaltyPoints()
        {

            lcart = new List<Model_Cart>() {
                new Model_Cart(){Days=1,Name="Caterpillar bulldozer",Type_id=2,Inventory_id=1,Type_name="Heavy" },

            };

            IRepoDal.Setup(x => x.GetCart(token)).ReturnsAsync(lcart);

            IRepoBLL = new InventoryRepository(IRepoDal.Object, calculate);
            var lresultdata = IRepoBLL.GetCart(token);
            Assert.AreEqual(lresultdata.Result[0].Loyaltypoint, 1);
        }

        [TestMethod]
        public void CheckSpecializedLoyaltyPoints()
        {

            lcart = new List<Model_Cart>() {
                new Model_Cart(){Days=1,Name="Caterpillar bulldozer",Type_id=3,Inventory_id=1,Type_name="Heavy" },
            };

            IRepoDal.Setup(x => x.GetCart(token)).ReturnsAsync(lcart);

            IRepoBLL = new InventoryRepository(IRepoDal.Object, calculate);
            var lresultdata = IRepoBLL.GetCart(token);
            Assert.AreEqual(lresultdata.Result[0].Loyaltypoint, 1);
        }

        [TestMethod]
        public void CheckHeavyPrice()
        {

            lcart = new List<Model_Cart>() {
                new Model_Cart(){Days=10,Name="Caterpillar bulldozer",Type_id=1,Inventory_id=1,Type_name="Heavy" },

            };

            IRepoDal.Setup(x => x.GetCart(token)).ReturnsAsync(lcart);

            IRepoBLL = new InventoryRepository(IRepoDal.Object, calculate);
            var lresultdata = IRepoBLL.GetCart(token);
            Assert.AreEqual(lresultdata.Result[0].Price, 700);
        }

        [TestMethod]
        public void CheckRegularPrice()
        {

            lcart = new List<Model_Cart>() {
                new Model_Cart(){Days=10,Name="Caterpillar bulldozer",Type_id=2,Inventory_id=1,Type_name="Regular" },

            };

            IRepoDal.Setup(x => x.GetCart(token)).ReturnsAsync(lcart);

            IRepoBLL = new InventoryRepository(IRepoDal.Object, calculate);
            var lresultdata = IRepoBLL.GetCart(token);
            Assert.AreEqual(lresultdata.Result[0].Price, 540);
        }

        [TestMethod]
        public void CheckSpecializedPrice()
        {

            lcart = new List<Model_Cart>() {
                new Model_Cart(){Days=10,Name="Caterpillar bulldozer",Type_id=3,Inventory_id=1,Type_name="Specialized" },
            };

            IRepoDal.Setup(x => x.GetCart(token)).ReturnsAsync(lcart);

            IRepoBLL = new InventoryRepository(IRepoDal.Object, calculate);
            var lresultdata = IRepoBLL.GetCart(token);
            Assert.AreEqual(lresultdata.Result[0].Price, 460);
        }

        [TestMethod]
        public void WrongEquipmentTypePrice()
        {
            lcart = new List<Model_Cart>() {
                new Model_Cart(){Days=1,Name="Caterpillar bulldozer",Type_id=5,Inventory_id=1,Type_name="Heavy" },

            };

            IRepoDal.Setup(x => x.GetCart(token)).ReturnsAsync(lcart);

            IRepoBLL = new InventoryRepository(IRepoDal.Object, calculate);
            var lresultdata = IRepoBLL.GetCart(token);
            Assert.AreEqual(lresultdata.Result[0].Price, 0);
        }

        [TestMethod]
        public void WrongEquipmentTypeLoyaltyPoint()
        {
            lcart = new List<Model_Cart>() {
                new Model_Cart(){Days=1,Name="Caterpillar bulldozer",Type_id=5,Inventory_id=1,Type_name="Heavy" },

            };

            IRepoDal.Setup(x => x.GetCart(token)).ReturnsAsync(lcart);

            IRepoBLL = new InventoryRepository(IRepoDal.Object, calculate);
            var lresultdata = IRepoBLL.GetCart(token);
            Assert.AreEqual(lresultdata.Result[0].Loyaltypoint, 0);
        }
    }
}
