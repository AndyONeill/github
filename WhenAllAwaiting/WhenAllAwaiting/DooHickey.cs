using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WhenAllAwaiting
{
    public class DooHickey
    {
        public async void doStuffVoidAsnc(Item item, int milliseconds)
        {
            Console.WriteLine($"into dostuff whilecount {item.WhileCount} item {item.Value}");
            await Task.Delay(milliseconds);
            Console.WriteLine($"done stuff whilecount {item.WhileCount} item {item.Value}");
        }

        public async Task<Item> doStuffItemAsnc(Item item, int milliseconds)
        {
            Console.WriteLine($"into dostuff whilecount {item.WhileCount} item {item.Value}");
            await Task.Delay(milliseconds);
            Console.WriteLine($"done stuff whilecount {item.WhileCount} item {item.Value}");
            return item;
        }
    }
}
