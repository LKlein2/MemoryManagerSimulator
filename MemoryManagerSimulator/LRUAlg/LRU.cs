using System;
using System.Collections.Generic;
using System.Text;

namespace MemoryManagerSimulator
{
    public class ThreadController
    {
        public int Change = 0;
        public object _lock = new object();

        public void NotifyChange()
        {
            lock (_lock)
            {
                Change++;
            }
        }
    }


    public class LRU
    {
        public ThreadController Tc { get; set; } = new ThreadController();
        public Page Page1 { get; set; }
        public Page Page2 { get; set; }
        public Page Page3 { get; set; }
        public char[] Input { get; set; }

        public LRU(string input)
        {
            Input = SplittedInput(input);
            Page1 = new Page(Tc);
            Page2 = new Page(Tc);
            Page3 = new Page(Tc);
        }

        private char[] SplittedInput(string input)
        {
            char[] splittedInput = new char[input.Length];
            splittedInput = input.ToCharArray();
            return splittedInput;
        }

        public void Simulate()
        {
            InitializeMonitoration();
            foreach (var character in Input)
            {
                ChooseSpot(character).AddValue(character);
            }

            Page1.WriteHistory();
            Page2.WriteHistory();
            Page3.WriteHistory();
        }

        private void InitializeMonitoration()
        {
            Page1.MonitoreAlterValue();
            Page2.MonitoreAlterValue();
            Page3.MonitoreAlterValue();
        }

        public Page ChooseSpot(char character)
        {
            if (Page1.Value == character) return Page1;
            if (Page2.Value == character) return Page2;
            if (Page3.Value == character) return Page3;

            Page page = Page1;

            if (page.WasUsed < Page2.WasUsed)
            {
                page = Page2;
            }
            if (page.WasUsed < Page3.WasUsed)
            {
                page = Page3;
            }
            return page;
        }
    }
}
