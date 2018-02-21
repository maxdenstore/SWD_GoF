using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

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



    }
}
