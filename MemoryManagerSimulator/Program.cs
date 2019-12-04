using MemoryManagerSimulator.OtimoAlg;
using System;

namespace MemoryManagerSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool bContinua = true;
            string StringTest;
            //string StringTest = "70120304230321201701";
            //string StringTest = "654321135246123456";
            //string StringTest = "123456654321123456";

            while (bContinua)
            {
                Console.WriteLine();
                Console.WriteLine("******************************");
                Console.WriteLine("***********  MENU  ***********");
                Console.WriteLine("* 1 - LRU                    *");
                Console.WriteLine("* 2 - OTIMO                  *");
                Console.WriteLine("******************************");
                var input = Console.ReadLine();
                Console.Clear();
                switch (input)
                {
                    case "1":
                        Console.Write("Informe a string:\t");
                        StringTest = Console.ReadLine();
                        LRU lru = new LRU(StringTest);
                        lru.Simulate();
                        break;
                    case "2":
                        Console.Write("Informe a string:\t");
                        StringTest = Console.ReadLine();
                        Otimo otimo = new Otimo(StringTest);
                        otimo.Simulate();
                        break;
                    default:
                        bContinua = false;
                        break;
                }
            }
            Console.ReadKey();
        }
    }
}
