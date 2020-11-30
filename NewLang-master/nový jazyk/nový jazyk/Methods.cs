using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;


namespace nový_jazyk
{
    class Methods
    {
        public static object ResolveMethods(string Svalue) {
            variables mv = new variables();
            LineDefiner mld = new LineDefiner(mv);
            string file = Svalue.Split('(')[0];
            string parameters = Svalue.Split('(')[1].TrimEnd(')');
            GetParameters(parameters, mv);
            string[] AllLines = File.ReadAllLines($"{file}.txt");


            foreach (var item in AllLines)
            {
                Regex trimmer = new Regex(@"\s\s+");

                string s = trimmer.Replace(item, " ");
                s = s.TrimStart(' ');
                if (item.StartsWith("return"))
                {
                    s = s.Replace("return ", "");
                    return mld.GetValue(s);

                }
                mld.Define(item);
            }

            return "";
        }



        private static void GetParameters(string parameters, variables vars) {
            string[] par = parameters.Split(',');
            foreach (var item in par)
            {
                vars.SetValue(item.Trim(' '), Program.MainVars.GetValue(item.Trim(' ')));
            }
        }
    }
}

   


