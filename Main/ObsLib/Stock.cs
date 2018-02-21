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
        int _id { get; }
        string _name { get; set; }
        double _price { get; set; }
        int _availibleAmount { get; set; }
        int buy(int amount);
        void sell(int amount);
       
    }
    public class Stock : IStock , Isub
    {
        private List<IStockObs> observersList = new List<IStockObs>();
        private static int id = 0;
        public Stock(string name, double price, int availibleAmount)
        {
            _id = id++;
            _name = name;
            _price = price;
            _availibleAmount = availibleAmount;
        }
        public int _id
        {
            get { return _id; }
           private set { _id = value; }
        }

        public string _name
        {
            get { return  _name; }
            set { _name = value; }
        }

        public double _price
        {
            get { return _price; }
            set { _price = value; }
        }

        public int _availibleAmount
        {
            get {return  _availibleAmount; }
            set { _availibleAmount = value; }
        }

        public int buy(int amount)
        {
            if (_availibleAmount - amount > 0)
            {
                _availibleAmount = _availibleAmount - amount;
                return amount;
            }

            return 0; //buy not possibale
        }

        public void sell(int amount)
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
                obs.update(_id,_price);
            }
        }
    }
}
