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
    }
}

   


