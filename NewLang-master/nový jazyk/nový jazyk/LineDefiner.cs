using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace nový_jazyk
{
    class LineDefiner
    {

        variables var;

        public LineDefiner(variables var) {
            this.var = var;
        }


        public void Define(string line) {





            string[] g = line.Split("=");
            string value = g[g.Length - 1].TrimStart(' ');




            string v = GetValue(value);
            Enumerate(line, v);

        }


        private void Enumerate(string line, string value) {
            string[] g = line.Split("=");
            string[] objs = new string[g.Length -1 ];

            for (int i = 0; i < g.Length-1; i++)
            {
                objs[i] = g[i].Replace(" ", "");
            }

            foreach (var item in objs)
            {
                var.SetValue(item,value);
            }

        }

        public string GetValue(string Svalue) {
            string retValue = "";


            if (Regex.Match(Svalue, "IN").Value == Svalue)//pro in
            {
                retValue = InOut.input();
            }
            else if (Regex.Match(Svalue, "[A-Za-z]+[A-Za-z0-9]* [+\\-\\*\\/] [A-Za-z]+[A-Za-z0-9]*").Value == Svalue ||
        Regex.Match(Svalue, "[0-9]* [+\\-\\*\\/] [0-9]*").Value == Svalue) // základní aritmetika
            {
                retValue = Arithmetic.basicOperationsInt(Svalue, var);

            }
            else if (Regex.Match(Svalue, "[A-Za-z]+[A-Za-z0-9]* [&|] [A-Za-z]+[A-Za-z0-9]*").Value == Svalue ||
       Regex.Match(Svalue, "(true|false) [&|] (true|false)").Value == Svalue) // základní aritmetika
            {
                retValue = Arithmetic.basicOperationsBool(Svalue, var);

            }
            else if (Regex.Match(Svalue, "\\*.*").Value == Svalue)//hard code values
            {
                retValue = Svalue;
            }
            else if (Regex.Match(Svalue, "^(true|false)$").Value == Svalue) // bool
            {
                retValue = Svalue;
            }
            else if (Regex.Match(Svalue, "[A-Za-z]+[A-Za-z0-9]+\\(.*\\)").Value == Svalue) // metody
            {
               retValue = Methods.ResolveMethods(Svalue).ToString();
            } 
            else if (var.ValueExists(Svalue))
            {
                retValue = var.GetValue(Svalue);
            }

            return retValue;
        }

    }
}
