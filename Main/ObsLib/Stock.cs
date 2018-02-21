using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObsLib
{
    interface IStock
    {
        void attach();
        void Detach();
        void notify();
    }
    public class Stock
    {
    }
}
