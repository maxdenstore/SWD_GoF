using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using ObsLib;

namespace Test.unit.test
{
    [TestFixture]
    public class StockTest
    {
        private Stock _uut;
        

        [SetUp]
        public void Init()
        {
            _uut = new Stock("test", 100.0,50);
            
        }

        [Test]
        public void Stock_Ctor_ID_test()
        {
            Stock _uut2 = new Stock("test2", 102.0, 20);
            Stock _uut3 = new Stock("test2", 102.0, 20);
            NUnit.Framework.Assert.That(_uut3.Id, Is.EqualTo(_uut2.Id + 1));
        }



        

        [Test]
        public void Stock_Ctor_name_test()
        {
            NUnit.Framework.Assert.That(_uut.Name, Is.EqualTo("test"));
        }
        [Test]
        public void Stock_Ctor_avilabilty_test()
        {
            NUnit.Framework.Assert.That(_uut.AvailibleAmount, Is.EqualTo(50));
        }
        [Test]
        public void Stock_Ctor_price_test()
        {
            NUnit.Framework.Assert.That(_uut.Price, Is.EqualTo(100));
        }

    }
}
