using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DnDEngine.Character;
using DnDEngine.Item;

namespace DnDTests
{
    [TestClass]
    public class InventoryTest
    {
        [TestMethod]
        public void TestMultipleItems()
        {
            Inventory inv = new Inventory();
            inv.AddItem(ExampleItems.arrow, 5);
            inv.AddItem(ExampleItems.rock, 6);
            inv.AddItem(ExampleItems.arrow, 1);

            Assert.IsTrue(inv.GetItem("Arrow").Quantity == 6);
            Assert.IsTrue(inv.GetItem("Rock").Quantity == 6);
        }
    }
}
