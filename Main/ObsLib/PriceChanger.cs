using System;
using System.Threading;

namespace ObsLib
{
    public class PriceChanger
    {
        private static Mutex mut = new Mutex();
        int newPrice;
        static Random rnd = new Random();
        private Stock priceUp;
        public void priceChanger(Stock changer)
        {
            priceUp = (Stock)changer;
            Thread t = new Thread(TimeThread);
            t.Start(changer);
        }

        private void TimeThread(object obj)
        {
            while (true)
            {

                Thread.Sleep(rnd.Next(1000, 2000));
                newPrice = rnd.Next(50,100);
                priceUp.Price = newPrice;
                
                mut.WaitOne(100);
                Console.WriteLine(priceUp.Name + " amount avalible " + priceUp.AvailibleAmount + " new price: " +
                                  priceUp.Price);
           
                mut.ReleaseMutex();


            }
        }
    }

}