using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace nový_jazyk
{
    class LineDefiner
    {
        public static void GessLine(string line) {
            if (Regex.Match(line, "OUT = [A-Za-z]+[A-Za-z0-9]*").Value == line) // pro out
            {
                InOut.output(line.Split(' ')[2]);
            }
            else if (Regex.Match(line, "[A-Za-z]+[A-Za-z0-9]* = IN").Value == line)//pro in
            {
                InOut.input(line.Split(' ')[0]);
            }
            else if (Regex.Match(line, "[A-Za-z]+[A-Za-z0-9=]* = [A-Za-z]+[A-Za-z0-9]* [+\\-\\*\\/] [A-Za-z]+[A-Za-z0-9]*").Value == line ||
        Regex.Match(line, "[A-Za-z]+[A-Za-z0-9]* = [0-9]* [+\\-\\*\\/] [0-9]*").Value == line)
            {
                Arithmetic.basicOperations(line);
            }
            else if (Regex.Match(line, "[A-Za-z]+[A-Za-z0-9=]* = .*").Value == line)//hard code values
            {
                //string value = "";
                //for (int i = 0; i < line.Split(' ').Length; i++)
                //{
                //    if (i == 0 || i == 1)
                //    {
                //        continue;
                //    }
                //    value += line.Split(' ')[i] + " ";
                //}
                //value.TrimEnd();
                string value = "";
                string[] g = line.Split("=");
                value = g[g.Length - 1];

                Enumerate(line, value);
            }

        }


        private static void Enumerate(string line, string value) {
            string[] g = line.Split("=");
            string[] objs = new string[g.Length -1 ];
            value = value.Replace(" ", "");
            for (int i = 0; i < g.Length-1; i++)
            {
                objs[i] = g[i].Replace(" ", "");
            }

            foreach (var item in objs)
            {
                variables.SetValue(item,value);
            }



        }



    }
}
