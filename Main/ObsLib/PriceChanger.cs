using System;
using System.Threading;

namespace ObsLib
{
    public class PriceChanger
    {
        //private static Mutex mut = new Mutex();

        public void priceChanger(Stock changer)
        {
            Thread t = new Thread(new ParameterizedThreadStart(TimeThread));
            t.Start(changer);
        }

        private void TimeThread(object obj)
        {
            while (true)
            {
                //mut.WaitOne();

                Stock prizeup = (Stock) obj;
                DateTime start = DateTime.Now;
                Random rnd = new Random();
                int newPrice = (start.Second) + (rnd.Next(50, 100));
                prizeup.Price = newPrice;

                Console.WriteLine(prizeup.Name + " amount avalible " + prizeup.AvailibleAmount + " new price: " +
                                  prizeup.Price);


                //mut.ReleaseMutex();

                Thread.Sleep(rnd.Next(1000, 2000));

            }
        }
    }

}