using System;
using System.IO;

namespace nový_jazyk
{
    class Program
    {
        static void Main(string[] args)
        {
          string[] AllLines = File.ReadAllLines("t.txt");
            foreach (var item in AllLines) 
            {
                LineDefiner.GessLine(item);
            }
        }
    }
}
