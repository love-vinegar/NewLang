using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace nový_jazyk
{
    class LineDefiner
    {
        public static void GessLine(string line) {
            string[] g = line.Split("=");
            string value = g[g.Length - 1].TrimStart(' ');

            for (int i = 0; i < g.Length -1; i++)
            {
                if (g[i].Contains("OUT"))
                {
                    InOut.output(value);
                }
            }



            #region new 
            string v = GetValue(value);
            Enumerate(line, v);
            #endregion

            #region old
        //    if (Regex.Match(line, "OUT = [A-Za-z]+[A-Za-z0-9]*").Value == line) // pro out
        //    {
        //        InOut.output(line.Split(' ')[2]);
        //    }
        //    else if (Regex.Match(line, "[A-Za-z]+[A-Za-z0-9]* = IN").Value == line)//pro in
        //    {
        //        InOut.input(line.Split(' ')[0]);
        //    }
        //    else if (Regex.Match(line, "[A-Za-z]+[A-Za-z0-9=]* = [A-Za-z]+[A-Za-z0-9]* [+\\-\\*\\/] [A-Za-z]+[A-Za-z0-9]*").Value == line ||
        //Regex.Match(line, "[A-Za-z]+[A-Za-z0-9]* = [0-9]* [+\\-\\*\\/] [0-9]*").Value == line)
        //    {
        //        Arithmetic.basicOperations(line);
        //    }
        //    else if (Regex.Match(line, "[A-Za-z]+[A-Za-z0-9=]* = .*").Value == line)//hard code values
        //    {
        //        Enumerate(line, value);
        //    }
            #endregion
        }


        private static void Enumerate(string line, string value) {
            string[] g = line.Split("=");
            string[] objs = new string[g.Length -1 ];

            for (int i = 0; i < g.Length-1; i++)
            {
                objs[i] = g[i].Replace(" ", "");
            }

            foreach (var item in objs)
            {
                variables.SetValue(item,value);
            }

        }

        private static string GetValue(string Svalue) {
            string retValue = "";


            if (Regex.Match(Svalue, "IN").Value == Svalue)//pro in
            {
               retValue = InOut.input();
            }
            else if (Regex.Match(Svalue, "[A-Za-z]+[A-Za-z0-9]* [+\\-\\*\\/] [A-Za-z]+[A-Za-z0-9]*").Value == Svalue ||
        Regex.Match(Svalue, "[0-9]* [+\\-\\*\\/] [0-9]*").Value == Svalue) // základní aritmetika
            {
                retValue = Arithmetic.basicOperations(Svalue);
                
            }
            else if (Regex.Match(Svalue, ".*").Value == Svalue)//hard code values
            {
                retValue = Svalue;
            }

            return retValue;
        }

    }
}
