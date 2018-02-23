using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObsLib
{
    public interface IStockObs
    {
        void update(int id, double price);
    }

    public interface IPortifolio
    {
        List<IStock> StockList { get;}
        void buyStock(int amount, IStock stock);
        bool sellStock(int amount, IStock stock);
    }

    public class Portifolio : IStockObs , IPortifolio

    {
        public Portifolio()
        {
            StockList = new List<IStock>();
        }
        public void update(int id, double price) //updates the prices in the observers list
        {
            foreach (var VARIABLE in StockList)
            {
                if (VARIABLE.Id == id)
                {
                    VARIABLE.Price = price;
                }
            }
        }

        public List<IStock> StockList { get; }

        public void buyStock(int amount, IStock stock)
        {
            //see if stock exsists:
            foreach (var VARIABLE in StockList)
            {
                if (VARIABLE.Id == stock.Id)
                {
                    VARIABLE.AvailibleAmount += amount;
                    return;
                }
                StockList.Add(stock);
            }


        }

        public bool sellStock(int amount, IStock stock)
        {
            //find the stock
            foreach (var VARIABLE in StockList)
            {
                if (VARIABLE.Id == stock.Id) //found
                {
                    if (VARIABLE.AvailibleAmount < amount)
                    {
                        Console.WriteLine("not enough stock");
                        return false;
                    }

                    Console.WriteLine("sold stock: " + VARIABLE.Name);
                    VARIABLE.AvailibleAmount -= amount;
                    return true;
                }
            }
            Console.WriteLine("no stocks owned of that type");
            return false;
        }
    }

}
