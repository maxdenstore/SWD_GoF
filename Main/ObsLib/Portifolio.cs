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
        List<IStock> StockList { get;}
        void buyStock(int amount, IStock stock);
        bool sellStock(int amount, IStock stock);
    }

    class Portifolio : IStockObs , IPortifolio

    {
        public void update(int id, double price) //updates the prices in the observers list
        {
            foreach (var VARIABLE in StockList)
            {
                if (VARIABLE._id == id)
                {
                    VARIABLE._price = price;
                }
            }
        }

        public List<IStock> StockList
        {
            get { return StockList; }
        }

        public void buyStock(int amount, IStock stock)
        {
            //see if stock exsists:
            foreach (var VARIABLE in StockList)
            {
                if (VARIABLE._id == stock._id)
                {
                    VARIABLE._availibleAmount += amount;
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
                if (VARIABLE._id == stock._id) //found
                {
                    if (VARIABLE._availibleAmount < amount)
                    {
                        Console.WriteLine("not enough stock");
                        return false;
                    }

                    Console.WriteLine("sold stock: " + VARIABLE._name);
                    VARIABLE._availibleAmount -= amount;
                    return true;
                }
            }
            Console.WriteLine("no stocks owned of that type");
            return false;
        }
    }

    interface IPortifolioDisplay
    {
        void print(List<IStock> alistToPrint);
    }

    class portifolioDisplay : IPortifolioDisplay
    {
        public void print(List<IStock> alistToPrint)
        {
            foreach (var VARIABLE in alistToPrint)
            {
                Console.WriteLine(VARIABLE._name + " user has: "+ VARIABLE._availibleAmount + "availible stocks");
            }
        }
    }
}
