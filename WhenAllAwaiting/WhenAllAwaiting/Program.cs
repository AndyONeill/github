using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WhenAllAwaiting
{
    class Program
    {
        static Random random = new Random();
        static async Task Main(string[] args)
        {
            int whileCount = 0;
            while (true)
            {
                var dh = new DooHickey();

                var processList = new List<Task<Item>>();
                for (int i = 1; i < 100; i++)
                {
                    int msDelay = random.Next(200, 3000);
                    Item item = new Item { Value = i, WhileCount = whileCount };
                    processList.Add(Task.Run(() => dh.doStuffItemAsnc(item, msDelay)));
                }

                Console.WriteLine($"Starting whenall {whileCount}");

                await Task.WhenAll(processList);

                Console.WriteLine($"Back from whenall {whileCount}");

                whileCount++;
            }


            //while(true)
            //{
            //    var dh = new DooHickey();

            //    var processList = new List<Task>();
            //    for (int i = 1; i < 100; i++)
            //    {
            //        int msDelay = random.Next(200, 3000);
            //        Item item = new Item { Value=i, WhileCount=whileCount };
            //        processList.Add(Task.Run(() => dh.doStuffVoidAsnc(item, msDelay)));
            //    }

            //    Console.WriteLine($"Starting whenall {whileCount}");

            //    await Task.WhenAll(processList );

            //    Console.WriteLine($"Back from whenall {whileCount}");

            //    whileCount++;
            //}
        }
    }
}
