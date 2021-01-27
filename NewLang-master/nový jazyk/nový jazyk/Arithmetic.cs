using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;


namespace nový_jazyk
{
    class Arithmetic
    {
        public static string basicOperations(string line, variables vars) {
            string[] lineSplits = line.Split(' ');
            string a, b;
            string sign = lineSplits[1];
            string ans = "";
            

            if (vars.ValueExists(lineSplits[0]))
            {
                a = vars.GetValue(lineSplits[0]).TrimStart('*');
            }
            else
            {
                a = lineSplits[0].TrimStart('*');
            }

            if (vars.ValueExists(lineSplits[2]))
            {
                b = vars.GetValue(lineSplits[2]).TrimStart('*');
            }
            else
            {
                b = lineSplits[2].TrimStart('*');
            }


            switch (sign)
            {
                case "+":
                    ans = Adding(a, b);
                    break;
                case "-":
                    ans = Subtracting(a, b);
                    break;
                case "*":
                    ans = Multiply(a, b);
                    break;
                case "/":
                    ans = Dividing(a, b);
                    break;
                case "&":
                    ans = And(a, b);
                    break;
                case "|":
                    ans = Or(a, b);
                    break;
                case "^":
                    ans = Same(a, b);
                    break;
                case "<":
                    ans = SmallerThan(a, b);
                    break;
                case ">":
                    ans = BiggerThan(a, b);
                    break;
                case "%":
                    ans = mod(a, b);
                    break;
            }
            return ans;
        }
        #region základní operace 
        //
        // pro int
        //
        private static string Adding(string a, string b) {
            return (Convert.ToInt64(a) + Convert.ToInt64(b)).ToString();
        }
        private static string Multiply(string a, string b)
        {
            return (Convert.ToInt16(a) * Convert.ToInt16(b)).ToString();
        }
        private static string Dividing(string a, string b)
        {
            return (Convert.ToInt16(a) / Convert.ToInt16(b)).ToString();
        }
        private static string Subtracting(string a, string b)
        {
            return (Convert.ToInt16(a) - Convert.ToInt16(b)).ToString();
        }
        private static string BiggerThan(string a, string b)
        {
            return (Convert.ToInt16(a) > Convert.ToInt16(b)).ToString();
        }
        private static string SmallerThan(string a, string b)
        {
            return (Convert.ToInt16(a) < Convert.ToInt16(b)).ToString();
        }
        private static string mod(string a, string b)
        {
            return (Convert.ToInt16(a) % Convert.ToInt16(b)).ToString();
        }
        //
        // pro bool
        //
        private static string And(string a, string b) 
        {
            return (Convert.ToBoolean(a) && Convert.ToBoolean(b)).ToString();
        }
        private static string Or(string a, string b)
        {
            return (Convert.ToBoolean(a) || Convert.ToBoolean(b)).ToString();
        }

        //
        // vyroková logika
        //
        private static string Same(string a, string b)
        {
            return (a == b).ToString();
        }
        #endregion

        public static string basicOperaticonsSingle(string line, variables vars) {

            string[] lineSplits = line.Split(' ');
            string a;
            string sign = lineSplits[0];
            string ans = "";


            if (vars.ValueExists(lineSplits[1]))
            {
                a = vars.GetValue(lineSplits[1]).TrimStart('*');
            }
            else
            {
                a = lineSplits[1].TrimStart('*');
            }

            switch (sign)
            {
                case "!":
                    ans = negation(a);
                    break;
            }

            return ans;
        }

        private static string negation(string a) {
            return (!Convert.ToBoolean(a)).ToString();
        }
    }
}
