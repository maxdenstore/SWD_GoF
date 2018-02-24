using System;
using System.Threading;

namespace ObsLib
{
    public class PriceChanger
    {
        public void priceChanger(Stock changer)
        {
            Thread t = new Thread(new ParameterizedThreadStart(TimeThread));
            t.Start(changer);
        }

        private void TimeThread(object obj)
        {
            while (true)
            {
                Stock prizeup = (Stock) obj;
                DateTime start = DateTime.Now;
                Random rnd = new Random();
                int newPrice = (start.Second)+(rnd.Next(50,100));
                prizeup.Price = newPrice;

                Console.WriteLine(prizeup.Name + " amount avalible " + prizeup.AvailibleAmount + " new price: " + prizeup.Price);

                prizeup.notify();

                Thread.Sleep(2000);
            }

        }
    }
}