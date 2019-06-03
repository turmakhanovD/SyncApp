using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MoneySyncApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            var threads = new  Thread[10];
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("------------Синхронизация--------------");

            for (int i = 0; i < threads.Length; i++)
            {
                var thread = new Thread(bank.MoneyOperationWithSync);
                thread.Name = $"Поток номер {thread.ManagedThreadId}";
                threads[i] = thread;
            }

            foreach (var thread in threads)
            {
                thread.Start();
            }

            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("------------Без синхронизации-------------");
            for (int i = 0; i < threads.Length; i++)
            {
                var thread = new Thread(bank.MoneyOperationWithoutSync);
                thread.Name = $"Поток номер {thread.ManagedThreadId}";
                threads[i] = thread;
            }

            foreach (var thread in threads)
            {
                thread.Start();
                
            }

            Console.ReadLine();
        }
    }
}
