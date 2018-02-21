using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObsLib
{
    interface IStockObs
    {
        void update(int id, double price);
    }

    interface IPortifolio
    {
        List<IStock> StockliList { get; set; }
        int buyStock(int amount);
        bool sellStock(int amount);
    }

    class Portifolio
    {
    }
}
