using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MemoryManagerSimulator.OtimoAlg
{
    public class Page
    {
        public ThreadController Tc { get; set; }
        public char Value { get; set; } = '#';
        public List<char> History { get; set; }

        public Page(ThreadController tc)
        {
            Tc = tc;
            History = new List<char>();
        }

        public void AddValue(char value)
        {
            Value = value;
            Tc.NotifyChange();
            Thread.Sleep(50);
        }

        public void MonitoreAlterValue()
        {
            new Thread(() =>
            {
                int oldChange = 0;
                while (true)
                {
                    if (Tc.Change != oldChange)
                    {
                        History.Add(Value);
                        oldChange++;
                    }
                }
            }).Start();
        }

        public void WriteHistory()
        {
            foreach (var value in History)
                Console.Write("  " + value);

            Console.WriteLine();
        }
    }
}
