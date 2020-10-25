using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_Lab1;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab1.Tests
{
    [TestClass()]
    public class LinkManagerTests
    {
        [TestMethod()]
        public void FindLincsTest()
        {
            MyExcell table = new MyExcell();
            Cell A1 = new Cell(13, "13", 0, 0);
            Cell temp = new Cell(12, "A1 + 12 + 3 * 9", 4, 3);
            temp.Name = "D3";
            table.Table.Add("D3", temp);
            table.Table.Add("A1", A1);

            LinkManager.FindLincs(temp.Name, temp.Expression, table.Table);

            Assert.AreEqual(A1.GetLinksToCell()[0].Name, "D3");
        }
    }
}