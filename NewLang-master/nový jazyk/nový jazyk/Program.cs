﻿using System;
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
         if - DONE
         switch 
         for 
        // do while
         pole
        // foreach
         metody 
        // zápis a čtení txt
         random
         mat fce
         beep 
         sleep
             
             
             
             */
        public static variables MainVars;
        static void Main(string[] args)
        {
            string[] AllLines = File.ReadAllLines(Console.ReadLine());

            MainVars = new variables();
            LineDefiner MainLD = new LineDefiner(MainVars);
            for (int i = 0; i < AllLines.Length; i++)
            {
                MainLD.Define(AllLines[i], ref i);

            }
        }
    }
}
