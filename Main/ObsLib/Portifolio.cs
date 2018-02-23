using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObsLib
{
    public interface IStockObs
    {
        void update(string name, double price);
    }

    public interface IPortifolio
    {
        List<IStock> StockList { get;}
        void buyStock(int amount, IStock stock);
        bool sellStock(int amount, IStock stock);
        string _name { get; set; }
    }

    public class Portifolio : IStockObs , IPortifolio

    {
        public Portifolio(string name)
        {
            _name = name;
            StockList = new List<IStock>();
        }
        public void update(string name, double price) //updates the prices in the observers list
        {
            foreach (var VARIABLE in StockList)
            {
                if (VARIABLE.Name == name)
                {
                    VARIABLE.Price = price;
                }
            }
        }

        public List<IStock> StockList { get; }

        public void buyStock(int amount, IStock stock)
        {
            int bought = stock.Buy(amount);
            
            //see if stock exsists:
            foreach (var VARIABLE in StockList)
            {
                if (VARIABLE.Name == stock.Name)
                {
                    VARIABLE.AvailibleAmount += bought;
                    return;
                }
                
            }
            StockList.Add(new Stock(stock.Name,stock.Price,bought));

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

        public string _name { get; set; }

    }

}
