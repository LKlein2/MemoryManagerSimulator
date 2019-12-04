using System;
using System.Collections.Generic;
using System.Text;

namespace MemoryManagerSimulator.OtimoAlg
{
    public class Otimo
    {
        public ThreadController Tc { get; set; } = new ThreadController();
        public Page Page1 { get; set; }
        public Page Page2 { get; set; }
        public Page Page3 { get; set; }
        public char[] Input { get; set; }

        public Otimo(string input)
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
            for (int i = 0; i < Input.Length; i ++)
            {
                ChooseSpot(i, Input[i]).AddValue(Input[i]);
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

        public Page ChooseSpot(int pos , char character)
        {
            if (Page1.Value == character) return Page1;
            if (Page2.Value == character) return Page2;
            if (Page3.Value == character) return Page3;

            int c1 = 0;
            int c2 = 0;
            int c3 = 0;

           for (int i = pos; i < Input.Length; i++)
            {
                if (Page1.Value == Input[i] && c1 == 0)
                    c1 = i + 1;

                if (Page2.Value == Input[i] && c2 == 0)
                    c2 = i + 1;

                if (Page3.Value == Input[i] && c3 == 0)
                    c3 = i + 1;
            }
            if (c1 == 0) return Page1;
            if (c2 == 0) return Page2;
            if (c3 == 0) return Page3;

            if (c1 > c2 && c1 > c3) return Page1;
            if (c2 > c1 && c2 > c3) return Page2;
            if (c3 > c2 && c3 > c1) return Page3;

            return Page1;
        }

    }
}
