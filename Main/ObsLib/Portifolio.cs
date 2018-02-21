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

    class Portifolio : IStockObs , IPortifolio

    {
        public void update(int id, double price)
        {
            throw new NotImplementedException();
        }

        public List<IStock> StockliList
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public int buyStock(int amount)
        {
            throw new NotImplementedException();
        }

        public bool sellStock(int amount)
        {
            throw new NotImplementedException();
        }
    }
}
