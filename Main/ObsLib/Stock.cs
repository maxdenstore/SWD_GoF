using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObsLib
{


    interface Isub
    {
        void attach();
        void Detach();
        void notify();
    }
    interface IStock
    {
        int _id { get; set; }
        string _name { get; set; }
        double _price { get; set; }
        int _availibleAmount { get; set; }
        int buy(int amount);
        void sell(int amount);
       
    }
    public class Stock : IStock , Isub
    {
        public int _id
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public string _name
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public double _price
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public int _availibleAmount
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public int buy(int amount)
        {
            throw new NotImplementedException();
        }

        public void sell(int amount)
        {
            throw new NotImplementedException();
        }

        public void attach()
        {
            throw new NotImplementedException();
        }

        public void Detach()
        {
            throw new NotImplementedException();
        }

        public void notify()
        {
            throw new NotImplementedException();
        }
    }
}
