using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        bool Sell(int amount);
       
    }
    public class Stock : IStock , Isub
    {
        private List<IStockObs> observersList = new List<IStockObs>();
        private double _price = new double();
        private static Mutex mut = new Mutex();

        public Stock(string name, double price, int availibleAmount)
        {
            Name = name;
            Price = (price > 0.0 ? price : 0);
            AvailibleAmount = (availibleAmount > 0.0 ? availibleAmount : 0);
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price
        {
            get { return _price; }
            set
            {
               
                if (value > 0) {
                    mut.WaitOne();
                    Console.WriteLine("mutex locked");
                    _price = value;
                    mut.ReleaseMutex();
                    Console.WriteLine("mutex unlocked");
                    notify();
                }
                else
                {
                    Console.WriteLine("price cannot be negative");
                }
                

            }
        }

        public int AvailibleAmount { get; set; }

        public int Buy(int amount)
        {
            if (amount < 0) { return 0;}

            if (AvailibleAmount - amount >= 0)
            {
                AvailibleAmount = AvailibleAmount - amount;
                return amount;
            }

            return 0; //buy not possibale
        }

        public bool Sell(int amount)
        {
            if (amount > 0)
            {
                AvailibleAmount += amount;
                return true;
            }
            else
            {
                return false;
            }
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
                obs.update(Name,Price);
            }
        }
    }
}
