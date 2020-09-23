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

        public static void output(string Name) {
            Console.WriteLine(variables.GetValue(Name));
        }
    }
}
