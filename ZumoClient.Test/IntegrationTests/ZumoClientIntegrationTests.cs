﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

using Heyns.ZumoClient;
using ZumoClient.Test.TestEntity;

namespace ZumoClient.Test.IntegrationTests
{
    
    public class ZumoClientIntegrationTests
    {
        [TestClass]
        public class TableTests
        {
            private static Item _item;
            private static MobileServicesClient _client;

            [TestInitialize]
            public void Setup()
            {
                if (_item == null)
                    _item = new Item {Text = "Just some random text"};
                if (_client == null)
                    _client = new MobileServicesClient(string.Empty /* Your endpoint */, string.Empty /* Your Api key */);
            }

            [TestMethod]
            public void Insert_Some_Random_Item_Into_Zumo()
            {
                // Arrange 

                // Act
                _item = _client.GetTable<Item>().Insert(_item);
                // Assert

            }

            [TestMethod]
            public void Get_All_Items_From_Zumo()
            {
                // Arrange

                // Act
                var items = _client.GetTable<Item>().Get();

                // Assert
                Assert.IsNotNull(items);
            }

            [TestMethod]
            public void Get_Some_Random_Item_From_Zumo()
            {
                // Arrange

                // Act
                var item = _client.GetTable<Item>().Get(_item.Id);

                // Assert
                Assert.IsNotNull(item);
            }

            [TestMethod]
            public void Update_Some_Random_Item_Into_Zumo()
            {
                // Arrange
                _item.Text = "Just something else";
                // This just doesn't seem right but you need to set the Id to null
                // or ignore it when serializing to Json
                var id = _item.Id;
                _item.Id = null;
                // Act
                var actual = _client.GetTable<Item>().Update(id, _item);

                // Assert
                Assert.AreEqual(_item, actual);
                // Reset the Id back so we can delete
                _item.Id = id;
            }

            [TestMethod]
            public void Delete_Some_Random_Item_Into_Zumo()
            {
                // Arrange

                // Act
                _client.GetTable<Item>().Delete(_item.Id);

                // Assert
            }
        }

        [TestClass]
        public class TableQueryTests
        {
            
        }
    }
}