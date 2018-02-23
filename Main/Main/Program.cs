using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObsLib;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            ObsLib.IPortifolio a = new Portifolio();
            IPortifolioDisplay b = new portifolioDisplay();
            b.print(a.StockList);
        }
    }
}
