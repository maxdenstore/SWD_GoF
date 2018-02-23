using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObsLib
{

    public interface IPortifolioDisplay
    {
        void print(IPortifolio port);
    }

    public class portifolioDisplay : IPortifolioDisplay
    {
        public void print(IPortifolio port)
        {
            if (port.StockList.Count == 0)
            {
                Console.WriteLine("there is no stocks to print");
                return;
            }

            Console.WriteLine(port._name + " has the following stocks: ");
            foreach (var VARIABLE in port.StockList)
            {
               
                Console.WriteLine(VARIABLE.Name + " amount " + VARIABLE.AvailibleAmount + " at price: " + VARIABLE.Price);
            }
        }
    }
}
