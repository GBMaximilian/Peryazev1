using Microsoft.VisualStudio.TestTools.UnitTesting;
using KR1PER;

namespace UnitTestProject
{
    [TestClass]
    public class DivTest
    {
        [TestMethod]
        public void MRUTЕЕ()
        {
            // исходные данные

            int a = 3589;
            int b = 6295;
            int expected = 22592757;

            // получение значения с помощью тестируемого метода
            Mult Z1 = new Mult();

            Z1.M1 = a;
            Z1.M2 = b;
            int actual = Z1.MRU();

            // сравнение ожидаемого результата с полученным
            Assert.AreEqual(expected, actual);
            /*
            Z1.ConvToMass();

            Z1.MMU();
            
            Z1.MKB_();
            Z1.MSU();
            */
        }

    }
}
