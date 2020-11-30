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
        public static variables MainVars;
        static void Main(string[] args)
        {
          string[] AllLines = File.ReadAllLines("t.txt");

             MainVars = new variables();
            LineDefiner MainLD = new LineDefiner(MainVars);
            foreach (var item in AllLines) 
            {
                MainLD.Define(item);
            }


            Console.ReadKey();
        }
    }
}
