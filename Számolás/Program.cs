using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Számolás
{
    class Program
    {

        static Random g = new Random();
        static void Main(string[] args)
        {
            var t =  Számolás("a", 10);

            t.Wait();

            Console.ReadLine();
        }

        async static Task<bool> Számolás(string l, int N)
        {
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine($"{l}{i + 1}");
                await Task.Delay(200 + g.Next(800));
            }
            return true;
        }
    }
}
