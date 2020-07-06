using System;
using System.Collections.Generic;
using System.Threading.Channels;

namespace stringParse
{
    class Program
    {
        static void Main(string[] args)
        {
            string func = "x^((4-3)*(x+25))+6*x^3";
            List<string> Sub= new List<string>();
            string[] vars = new string[26] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            string Temp = func;
            int open = Temp.IndexOf('('), close = 0;
            do
            {
                for (int i = open + 1; i < Temp.Length; i++)
                {

                    if (Temp[i] == '(')
                    {
                        open = i;
                        break;
                    }
                    else if (Temp[i] == ')')
                    {
                        close = i;
                        Sub.Add(Temp.Substring(open, close - open));
                        break;
                    }
                }
            }
            while (Temp.Contains('('));
            Console.WriteLine(Sub[0]);
        }
    }
}
