using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObsLib
{


    public interface Isub
    {
        void attach(IStockObs newObs);
        void Detach(IStockObs newObs);
        void notify();
    }
    public interface IStock
    {
        int Id { get; }
        string Name { get; set; }
        double Price { get; set; }
        int AvailibleAmount { get; set; }
        int Buy(int amount);
        void Sell(int amount);
       
    }
    public class Stock : IStock , Isub
    {
        private List<IStockObs> observersList = new List<IStockObs>();
 

        public Stock(string name, double price, int availibleAmount)
        {
            Name = name;
            Price = price;
            AvailibleAmount = availibleAmount;
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public int AvailibleAmount { get; set; }

        public int Buy(int amount)
        {
            if (AvailibleAmount - amount >= 0)
            {
                AvailibleAmount = AvailibleAmount - amount;
                return amount;
            }

            return 0; //buy not possibale
        }

        public void Sell(int amount)
        {
            throw new NotImplementedException();
        }

        public void attach(IStockObs newObs)
        {
            observersList.Add(newObs);
        }

        public void Detach(IStockObs newObs)
        {
            observersList.Remove(newObs);
        }

        public void notify()
        {
            foreach (var obs in observersList)
            {
                obs.update(Id,Price);
            }
        }
    }
}
