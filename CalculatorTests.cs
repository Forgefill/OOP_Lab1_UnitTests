using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_Lab1;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab1.Tests
{
    [TestClass()]
    public class CalculatorTests
    {
        [TestMethod()]
        public void OperationTest()
        {
            {
                double add = Calculator.Evaluate("1 + 1");
                double sub = Calculator.Evaluate("7 - 7");
                double mul = Calculator.Evaluate("1 * 8");
                double div = Calculator.Evaluate("9 / 3");

                Assert.AreEqual(add, 2, "+");
                Assert.AreEqual(sub, 0, "-");
                Assert.AreEqual(mul, 8, "*");
                Assert.AreEqual(div, 3, "/");
            }

            {
                bool equality = Calculator.Evaluate("22 - 3 * 8 = -2");
                bool less = Calculator.Evaluate("-22 < 3");
                bool great = Calculator.Evaluate("3 > 2");

                Assert.AreEqual(equality, true, "=");
                Assert.AreEqual(less, true, "<");
                Assert.AreEqual(great, true, ">");
            }

            {
                bool inverse = Calculator.Evaluate("!(2=2)");
                Assert.AreEqual(inverse, false, "inverse");
            }

            {
                double inc = Calculator.Evaluate("++ ++ ++ 3");
                double dec = Calculator.Evaluate("-- -1");
                Assert.AreEqual(inc, 6, "inc");
                Assert.AreEqual(dec, -2, "dec");
            }
        }
    }
}