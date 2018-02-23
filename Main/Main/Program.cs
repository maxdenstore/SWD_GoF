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
            ObsLib.IPortifolio a = new Portifolio("Hans");
            IPortifolioDisplay b = new portifolioDisplay();
<<<<<<< HEAD
            Stock stockGoo = new Stock("google", 100.00, 80);
            a.buyStock(10, stockGoo);
            b.print(a.StockList);
=======

            Stock stockGoo = new Stock("google", 100.00, 80);
            Stock stockapl = new Stock("Apple", 200.00,90);

            a.buyStock(10, stockGoo);
            a.buyStock(20,stockapl);

            

            b.print(a);
            stockGoo.Price = 250;

            a.buyStock(20,stockGoo);

            b.print(a);
>>>>>>> 03b3ca83331e0fa447fd25066e2b44dc276fe712


            Console.ReadLine();
        }
    }
}
