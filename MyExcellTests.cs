using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_Lab1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;

namespace OOP_Lab1.Tests
{
    [TestClass()]
    public class MyExcellTests
    {
        [TestMethod()]
        public void CorrectAddTest()
        {
            MyExcell table = new MyExcell();
            table.AddCell("12 > 3", "A1", 0, 0);

            Assert.IsTrue(table.Table.Any());
        }

        [TestMethod()]
        public void WrongAddTest()
        {
            MyExcell table = new MyExcell();
                   
            // Виключення що я перехоплюю, правильні. Вони обробляються іншою частиною програми. 
            // Перевіряю чи додаються неправильні комірки.
            {   //N1
                try
                {
                    table.AddCell("wrong format of expression", "A1", 0, 0);
                }
                catch (ArgumentException)
                {
                    Assert.IsFalse(table.Table.Any(), "N1");
                }
            }

            { // N2
                try
                {
                    table.AddCell("12 / 0", "A1", 0, 0);
                }
                catch(DivideByZeroException)
                {
                    Assert.IsFalse(table.Table.Any(), "N2");
                }
            }
        }



        [TestMethod()]
        public void ClearTest()
        {
            Cell temp = new Cell(false, "22 < 3", 0, 0);
            MyExcell table = new MyExcell();
            table.Table.Add("A1", temp);
            table.Clear();

            Assert.AreEqual(table.Table.Count, 0);
        }

        [TestMethod()]
        public void HasReferenceErrorTest()
        {
            // N1
            {                                               // Пряме посилання на себе. 
                MyExcell table = new MyExcell();
                Cell A1 = new Cell("12", "A1", 0, 0);
                table.Table.Add("A1", A1);
                A1.AddLinkToCell(A1);                   

                Assert.IsTrue(table.HasReferenceError(A1, "A1"), "N1");
            }

            //N2
            {                                              //  Циклічне посилання на себе.        
                MyExcell table = new MyExcell();
                Cell A1 = new Cell("A3", "A3", 0, 0);
                Cell A2 = new Cell("A1", "A1", 0, 1);
                Cell A3 = new Cell("A2", "A2", 0, 2);
                A1.AddLinkToCell(A2);
                A2.AddLinkToCell(A3);
                A3.AddLinkToCell(A1);
                table.Table.Add("A1", A1);
                table.Table.Add("A2", A2);
                table.Table.Add("A3", A3);

                Assert.IsTrue(table.HasReferenceError(A1, "A1"), "N2");
            }

        }
    }
}