using System;
using System.Threading;

namespace MoneySyncApp
{

    public class Bank
    {
        private object lockObject = new object();
        private double _money = 1000;
        private int _random;

        public void MoneyOperationWithSync()
        {
            lock (lockObject)
            {

                for (int i = 1; i <= 10; i++)
                {
                    _random = new Random().Next(100);
                    if (_random % 2 == 0)
                    {
                        Thread.Sleep(5 * new Random().Next(100));
                        _money = _money + 150;
                        Console.Write("Операция #" + i + " " + "На счету " + _money + "\n");
                    }
                    else
                    {
                        Thread.Sleep(5 * new Random().Next(100));
                        _money = _money - 150;
                        Console.Write("Операция #" + i + " " + "На счету " + _money + "\n");
                    }
                }
            }
        }
        public void MoneyOperationWithoutSync()
        {     
            for (int i = 1; i <= 10; i++)
            {
                _random = new Random().Next(100);
                if (_random % 2 == 0)
                {
                    Thread.Sleep(5 * new Random().Next(100));
                    _money = _money + 150;
                    Console.Write("Операция #" + i + " " + "На счету " + _money + "\n");
                }
                else
                {
                    Thread.Sleep(5 * new Random().Next(100));
                    _money = _money - 150;
                    Console.Write("Операция #" + i + " " + "На счету " + _money + "\n");
                }
            }

        }
    }
}
