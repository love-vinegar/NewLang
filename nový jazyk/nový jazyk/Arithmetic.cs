using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;


namespace nový_jazyk
{
    class Arithmetic
    {
        public static string basicOperations(string line) {
            string[] lineSplits = line.Split(' ');
            string a, b;
            string sign = lineSplits[1];
            string ans = "";
            if (Regex.Match(line, "[A-Za-z]+[A-Za-z0-9]* [+\\-\\*\\/] [A-Za-z]+[A-Za-z0-9]*").Value == line)
            {
                a = variables.GetValue(lineSplits[0]);b = variables.GetValue(lineSplits[2]);
            }
            else
            {
                a = lineSplits[2]; b = lineSplits[4];
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
            }
            return ans;
        }
        #region základní operace
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
        #endregion
    }
}
