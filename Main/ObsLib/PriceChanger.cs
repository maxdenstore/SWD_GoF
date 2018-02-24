using System;
using System.Threading;

namespace ObsLib
{
    public class PriceChanger
    {
        private static Mutex mut = new Mutex();

        public void priceChanger(Stock changer)
        {
            Thread t = new Thread(new ParameterizedThreadStart(TimeThread));
            t.Start(changer);
        }

        private void TimeThread(object obj)
        {
            Stock prizeup = (Stock)obj;
            Random rnd = new Random();
            while (true)
            {
                int newPrice = (rnd.Next(50, 100));
                prizeup.Price = newPrice;
                mut.WaitOne();
                Console.WriteLine(prizeup.Name + " amount avalible " + prizeup.AvailibleAmount + " new price: " +
                                  prizeup.Price);
                mut.ReleaseMutex();

                Thread.Sleep(rnd.Next(1000, 2000));

            }
        }
    }

}