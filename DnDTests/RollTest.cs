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
            var roll = 2 * Roll.D(20) + 3;
            Assert.IsTrue(roll.Max == 43);
            Console.WriteLine(roll.DoRoll());
        }
    }
}
