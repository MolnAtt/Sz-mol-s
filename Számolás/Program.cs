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
            var t1 = Számolás("a", 20, 2);
            var t2 = Számolás("b", 20, 1);

            t1.Wait();
            t2.Wait();

            Console.ReadLine();
        }

        async static Task<bool> Számolás(string l, int N, int k)
        {
            for (int i = 0; i < N; i+=k)
            {
                Console.WriteLine($"{l}{i + 1}");
                await Task.Delay(200 + g.Next(800));
            }
            return true;
        }
    }
}
