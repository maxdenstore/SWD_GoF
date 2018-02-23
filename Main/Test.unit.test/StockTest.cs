using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
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
       public void Stock_Ctor_Negatice_Price_test()
        {
            Stock _uut2 = new Stock("test2", -102.0, 20);
            
            NUnit.Framework.Assert.That(_uut2.Price, Is.EqualTo(0));
        }
        public void Stock_Ctor_Negatice_AvailibleAmount_test()
        {
            Stock _uut2 = new Stock("test2", -102.0, -20);

            NUnit.Framework.Assert.That(_uut2.AvailibleAmount, Is.EqualTo(0));
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

        [TestCase(10, 5, 5)]
        [TestCase(5, 5, 0)]
        [TestCase(10, 15, 10)]
        public void Stock_Buy_test(int availible, int buyAmount, int afterBuyAmount)
        {
            Stock _uut2 = new Stock("test2", 102.0, availible);
            _uut2.Buy(buyAmount);
            NUnit.Framework.Assert.That(_uut2.AvailibleAmount, Is.EqualTo(afterBuyAmount));
        }

        [TestCase(10, true)]
        [TestCase(-10, false)]
        public void Stock_Sell_test(int SellAmount, bool state)
        {
            Stock _uut2 = new Stock("test2", 102.0, 20);
            
            NUnit.Framework.Assert.That(_uut2.Sell(SellAmount), Is.EqualTo(state));
        }


        [TestCase(10, 5, 5)]
        [TestCase(5, 5, 0)]
        [TestCase(10, 15, 10)]
        public void Stock_Availibilety_test(int availible, int buyAmount, int afterBuyAmount)
        {
            Stock _uut2 = new Stock("test2", 102.0, availible);
            Portifolio port = new Portifolio("jasper");

            port.buyStock(buyAmount, _uut2);
            NUnit.Framework.Assert.That(_uut2.AvailibleAmount, Is.EqualTo(afterBuyAmount));
        }

        [Test]
        public void Stock_Attach_Notifi_test()
        {
            Stock _uut2 = new Stock("test2", 102.0, 50);
            Portifolio port = Substitute.For<Portifolio>("jasper");
           
            //act
            _uut2.attach(port);

            _uut2.Price = 40;
            //assert
            port.Received(1).update("test2",40);
        }
        [Test]
        public void Stock_Detach_Notifi_test()
        {
            Stock _uut2 = new Stock("test2", 102.0, 50);
            Portifolio port = Substitute.For<Portifolio>("jasper");

            //act
            _uut2.attach(port);
            _uut2.Detach(port);

            _uut2.Price = 40;
            //assert
            port.DidNotReceive().update("test2", 40);
        }

    }
}
