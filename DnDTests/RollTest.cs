using System;
using DnDEngine.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DnDTests
{
    [TestClass]
    public class RollTest
    {
        [TestMethod]
        public void TestCreateRoll()
        {
            var roll = Roll.D(20);
            roll.DoRoll();
            Assert.IsInstanceOfType(roll.value, typeof(int));
            Console.WriteLine(roll.value);
        }

        [TestMethod]
        public void TestModifyRoll()
        {
            var roll = Roll.D(20) + 3;
            roll.DoRoll();
            Assert.IsTrue(roll.value > 4);
            Console.WriteLine(roll.value);
        }
    }
}
