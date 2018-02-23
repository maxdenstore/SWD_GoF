using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NUnit.Framework;
using ObsLib;

namespace Test.unit.test
{
    [TestFixture]
    public class PortfolieTest
    {
        private Portifolio _uut;
        private Stock stock;

        [SetUp]
        public void Init()
        {
           _uut = new Portifolio("jasper");
            stock = new Stock("goo", 100.80, 50);
        }
        
        [Test]
        public void portfolio_Buy_test()
        {
            _uut.buyStock(20,stock);
            NUnit.Framework.Assert.That(_uut.StockList[0].Name, Is.EqualTo(stock.Name));
            NUnit.Framework.Assert.That(_uut.StockList[0].Price, Is.EqualTo(stock.Price));

        }
        

        [TestCase(5, 45)]
        [TestCase(-5, 50)]
        public void portfolio_Buy_avalibity_test(int buyAmount, double afterBuyAmount)
        {
            _uut.buyStock(buyAmount, stock);
            NUnit.Framework.Assert.That(stock.AvailibleAmount, Is.EqualTo(afterBuyAmount));
        }

        [TestCase(10, 5, true)]
        [TestCase(5, 50, false)]
        [TestCase(-10, 5, false)]
        public void portfolio_Sell_SellAmount_test(int buyAmount, int SellAmount, bool state)
        {
            _uut.buyStock(buyAmount, stock);
            
            NUnit.Framework.Assert.That(_uut.sellStock(SellAmount, stock), Is.EqualTo(state));
        }


        [Test]
        public void portfolio_Sell_Stock_notInStockList_test()
        {
            Stock tStock = new Stock("testStock", 60, 70);
            _uut.buyStock(5,tStock);

            NUnit.Framework.Assert.That(_uut.sellStock(5, stock), Is.EqualTo(false));
        }

        [TestCase(10, 10)]
        [TestCase(-10, 100.8)]
        public void portfolio_update_test(double newPrice, double expectedPrice)
        {
            _uut.buyStock(5, stock);
    
            stock.attach(_uut);
            stock.Price = newPrice;

            NUnit.Framework.Assert.That(_uut.StockList[0].Price, Is.EqualTo(expectedPrice));
        }

    }
}
