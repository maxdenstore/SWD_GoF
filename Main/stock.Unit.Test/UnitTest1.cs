using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace ObsLib
{
    
    public class StockUnitTest
    {
        private Stock _uut;

        [SetUp]
        public void Init()
        {
            _uut = new Stock("test", 8.0, 10);
        }


        [Test]
        public void StockNameCtorTest()
        {
            Assert.That(_uut._name, Is.EqualTo("test"));
        }
        [Test]
        public void StockIdCtorTest()
        {
            Assert.That(_uut._id, Is.EqualTo(0));
        }

        [Test]
        public void StocAvailibleAmountCtorTest()
        {
            Assert.That(_uut._availibleAmount, Is.EqualTo(10));
        }

        [Test]
        public void StockNameTest()
        {
            Assert.That(_uut._name, Is.EqualTo("test"));
        }
    }
}
