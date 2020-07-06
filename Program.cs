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
            string Temp = func, temp1;
            int open = Temp.IndexOf('('), close = 0;
            do
            {
                for (int i = open + 1; i < Temp.Length; i++)
                {

                    if (Temp[i] == '(')
                    {
                        open = i;
                        continue;
                    }
                    else if (Temp[i] == ')')
                    {
                        close = i;
                        temp1 = Temp.Substring(i, Temp.Length - i);
                        Sub.Add(Temp.Substring(open+1, close - open-1));
                        Temp = temp1;
                        open = Temp.IndexOf('(');
                        i = 0;
                        continue;
                    }
                }
            }
            while (Temp.Contains('('));
            Console.WriteLine(Sub[0]);
        }
    }
}
