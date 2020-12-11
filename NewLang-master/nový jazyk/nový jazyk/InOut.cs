using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace nový_jazyk
{
    class InOut
    {
        public static string input() {
            return Console.ReadLine(); 
        }
        public static void output(string Value)
        {
            if (Value == "")
            {
                return;
            }
            Console.WriteLine(Value.TrimStart('*'));
        }
    }
}
