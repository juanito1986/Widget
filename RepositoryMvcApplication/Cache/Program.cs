using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisCache
{
    public class Program
    {
        static void Main(string[] args)
        {
            Configure();
        }

        private static void Configure()
        {
            //use locally redis installation
            StackExchangeRedisExtensions.Set("test", "test");
            List<string> list = new List<string>() { "A", "B", "C" };
            StackExchangeRedisExtensions.SetList("list", list);


            //Read
            Console.Out.WriteLine("Msg:" + StackExchangeRedisExtensions.Get("test"));

            foreach (string ele in StackExchangeRedisExtensions.GetList<string>("list"))
            {
                Console.Out.WriteLine("Element List:" + ele);
            }
            
            Console.ReadLine();

        }
    }
}
