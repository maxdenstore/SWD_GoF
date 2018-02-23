using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObsLib
{

    public interface IPortifolioDisplay
    {
        void print(List<IStock> alistToPrint);
    }

    public class portifolioDisplay : IPortifolioDisplay
    {
        public void print(List<IStock> alistToPrint)
        {
            if (alistToPrint.Count == 0)
            {
                Console.WriteLine("there is no stocks to print");
            }
            foreach (var VARIABLE in alistToPrint)
            {
                Console.WriteLine(VARIABLE._name + " user has: " + VARIABLE._availibleAmount + "availible stocks");
            }
        }
    }
}
