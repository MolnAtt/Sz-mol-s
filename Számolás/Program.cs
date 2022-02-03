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
        static Dictionary<string, int> kijelző = new Dictionary<string, int>();
        static Dictionary<string, bool> villanyrendőr = new Dictionary<string, bool>();
        static void Main(string[] args)
        {
            villanyrendőr["a"] = false;
            villanyrendőr["b"] = false;
            kijelző["a"] = 0;
            kijelző["b"] = 0;

            var a = Számolás("a", 20, 500, ConsoleColor.Red);
            var b = Számolás("b", 20, 200, ConsoleColor.Blue);

            var t = Eredményjelzés(a,b);
            t.Wait();

            Console.ReadLine();
        }

        async static Task Eredményjelzés(Task a, Task b)
        {

            while (kijelző["a"]<20 || kijelző["b"]<20)
            {
                Console.WriteLine($"a:{kijelző["a"]} -- b:{kijelző["b"]} ");
                await Task.Delay(100);

                if (kijelző["a"] % 10 == 0)
                {
                    villanyrendőr["a"] = false;
                    a.Pause();
                }
                if (kijelző["b"] % 10 == 0)
                {
                    villanyrendőr["b"] = false;
                }
                if (!(villanyrendőr["a"] || villanyrendőr["b"]))
                {
                    villanyrendőr["a"] = true;
                    villanyrendőr["b"] = true;
                }
            }
            Console.WriteLine("Befejeződött a meccs!");
        }

        async static Task Számolás(string l, int N, int w, ConsoleColor szin)
        {
            await Task.Delay(1000);
            for (int i = 0; i < N; i++)
            {
                Console.ForegroundColor = szin;
                Console.WriteLine($"{l}{i + 1}");
                kijelző[l] = i+1;
                Console.ForegroundColor = ConsoleColor.White;
                if (i==10)
                {

                }
                await Task.Delay(200 + g.Next(w));
            }
        }
    }
}
