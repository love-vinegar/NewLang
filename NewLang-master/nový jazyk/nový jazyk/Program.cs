using System;
using System.IO;

namespace nový_jazyk
{
    class Program
    {
        /*
        // deklarace
        // inicializace
        // typy
         zápis a čtení - DONE
         if
         switch 
         for 
        // do while
         pole
         foreach
         metody 
         zápis a čtení txt
         random
         mat fce
         beep 
         sleep
             
             
             
             */
        static void Main(string[] args)
        {
          string[] AllLines = File.ReadAllLines("t.txt");
            foreach (var item in AllLines) 
            {
                LineDefiner.Define(item);
            }


            Console.ReadKey();
        }
    }
}
