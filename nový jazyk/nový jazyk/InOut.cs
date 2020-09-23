using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace nový_jazyk
{
    class InOut
    {
        public static void input(string Name) {
            variables.SetValue(Name, Console.ReadLine()); 
        }

        public static void output(string Name) {
            Console.WriteLine(variables.GetValue(Name));
        }
    }
}
