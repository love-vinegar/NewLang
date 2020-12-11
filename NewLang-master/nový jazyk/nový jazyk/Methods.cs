using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;


namespace nový_jazyk
{
    class Methods
    {
        public static object ResolveMethods(string Svalue, variables MainVars) {
            variables mv = new variables();
            LineDefiner mld = new LineDefiner(mv);
            string file = Svalue.Split('(')[0];
            string parameters = Svalue.Split('(')[1].TrimEnd(')');

            string[] AllLines = File.ReadAllLines($"{file}.txt");

            Regex trimmer = new Regex(@"\s\s+");
            string s = trimmer.Replace(AllLines[0], " ");

            GetParameters(s, parameters, mv, MainVars);


            #region parametry
            
            #endregion

            for (int i = 1; i < AllLines.Length; i++)
            {
                s = trimmer.Replace(AllLines[i], " ");
                s = s.TrimStart(' ');
                if (AllLines[i].StartsWith("return"))
                {
                    s = s.Replace("return ", "");
                    return mld.GetValue(s,ref i);
                }
                mld.Define(AllLines[i], ref i);
            }
            
            

            return "";
        }



        private static void GetParameters(string parameters, string values, variables vars, variables mainVars) {
            string[] par = parameters.Split(' ');
            string[] val = values.Split(' ');

            for (int i = 0; i < par.Length; i++)
            {
                vars.SetValue(par[i], (mainVars.ValueExists(val[i])?mainVars.GetValue(val[i]) : val[i]));
            }
        }
    }
}

   


