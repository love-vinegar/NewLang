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


        public void Define(string line, ref int LineCount) {


            string[] g = line.Split("=");
            string value = g[g.Length - 1].TrimStart(' ');


            string v = GetValue(value, ref LineCount);
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
        int SkipLine = -1;
        int loopNumber = 0;
        int loopVar = 0;


        string LoopName = "";
        public string GetValue(string Svalue,ref int Line) {
            string retValue = "";
            if (Line == SkipLine)
            {
                
                return "";
            }

            if (Svalue == "")
            {
                return "";
            }

            if (loopNumber > 0)
            {
                loopNumber--;
                Line--;
                var.SetValue(LoopName, (loopVar).ToString());
                if (loopNumber == 0)
                {
                    SkipLine = Line + 1;
                }

                loopVar++;
            }

            if (Regex.Match(Svalue, "IN").Value == Svalue)//pro in
            {
                retValue = InOut.input();
            }
            else if (Regex.Match(Svalue, "^IF\\(.+\\)").Value == Svalue)//pro if
            {
                string work = Svalue.Split('(')[1].TrimEnd(')');
                string toIf = GetValue(work,ref Line);
                if (!Convert.ToBoolean(toIf))
                {
                    SkipLine = Line + 1;
                }
                else
                {
                    SkipLine = Line + 2;
                }
            }
            else if (Regex.Match(Svalue, "^LOOP\\(.+\\)").Value == Svalue)//pro loop
            {
                string work = Svalue.Split('(')[1].TrimEnd(')');
                string[] split = work.Split(' ');
                if (split.Length == 2)
                {
                    var.SetValue(split[0], "0");
                    loopNumber = Convert.ToInt32(GetValue(split[1], ref Line));
                    LoopName = split[0];
                    loopVar = 0;
                }
                else
                {
                    loopNumber = Convert.ToInt32(GetValue(split[0], ref Line));
                }
            }
            else if (Regex.Match(Svalue, "(\\*?[A-Za-z]+[A-Za-z0-9]*|[0-9]*) [+\\-\\*\\/&|^<>] (\\*?[A-Za-z]+[A-Za-z0-9]*|[0-9]*)").Value == Svalue) // základní aritmetika dvě 
            {
                retValue = Arithmetic.basicOperations(Svalue, var);
            }
            else if (Regex.Match(Svalue, "[!] (\\*?[A-Za-z]+[A-Za-z0-9]*|[0-9]*)").Value == Svalue) // základní aritmetika jedna
            {
                retValue = Arithmetic.basicOperaticonsSingle(Svalue, var);
            }
            else if (Regex.Match(Svalue, "^\\*.*").Value == Svalue)//string
            {
                retValue = Svalue;
            }
            else if (Regex.Match(Svalue, "^(True|False)$").Value == Svalue) //bool
            {
                retValue = Svalue;
            }
            else if (Regex.Match(Svalue, "^[0-9]*$").Value == Svalue) //cisla
            {
                retValue = Svalue;
            }
            else if (Regex.Match(Svalue, "[A-Za-z]+[A-Za-z0-9]+\\(.*\\)").Value == Svalue) // metody
            {
               retValue = Methods.ResolveMethods(Svalue, var).ToString();
            } 
            else if (var.ValueExists(Svalue))
            {
                retValue = var.GetValue(Svalue);
            }

            return retValue;
        }

    }
}
