using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;


namespace nový_jazyk
{
    class Methods
    {
        MethodeVars mv;
        public static object ResolveMethods(string Svalue) {
            mv = new MethodeVars();
            MethodLineDef mld = new MethodLineDef(mv);
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

                    return LineDefiner.GetValue(s);

                }
                mld.Define(item);
            }

            throw new Exception("Method doesnt return :(");
        }
        private static void getvv(string line) {

            m

        }
    }
}

   


