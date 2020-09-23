using System;
using System.Collections.Generic;
using System.Text;

namespace nový_jazyk
{
    class variables
    {
        static Dictionary<string, string> vars = new Dictionary<string, string>();
      
        public static void SetValue(string Name, string Value)
        {

            if (vars.ContainsKey(Name))
            {
                vars.Remove(Name);
            }
            vars.Add(Name, Value);

        }

        public static string GetValue(string Name) {
            if (vars.ContainsKey(Name))
            {
                return vars[Name];
            }

            throw new Exception("variable not existing :(");
            
        }

    }
}
