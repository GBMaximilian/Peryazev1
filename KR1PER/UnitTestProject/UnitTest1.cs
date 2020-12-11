using Microsoft.VisualStudio.TestTools.UnitTesting;
using KR1PER;
using static System.Math;
using System;
namespace UnitTestProject
{
    [TestClass]
    public class MultTest
    {
        [TestMethod]
        public void MRUT()
        {
            // исходные данные

            int a;
            //abcd
            int b;
            int expected;
            int i = 100;
            Mult Z1 = new Mult();
            Random random = new Random();
            while (i > 0)
            {
                // получение значения с помощью тестируемого метода

                
                
                Z1.M1 = random.Next(100, 100000);
                Z1.M2 = random.Next(100, 100000);
                expected = Z1.M2 * Z1.M1;
                int actual = Z1.MRU();

                // сравнение ожидаемого результата с полученным
                Assert.AreEqual(expected, actual);
                /*
                Z1.ConvToMass();

                Z1.MMU();

                Z1.MKB_();
                Z1.MSU();
                */
                i--;
            }
        }
            
    }
}
