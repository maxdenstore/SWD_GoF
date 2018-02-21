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
    public class Stock
    {
    }
}
