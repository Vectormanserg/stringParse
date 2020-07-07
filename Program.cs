using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Channels;

namespace stringParse
{
    class Program
    {
        static void Main(string[] args)
        {
            Parse();
        }
        static void Parse()
        {
            string func = "2-x*x";
            char[] math = func.ToCharArray();
            string TempStr = "", Oper = "";
            char[] MathFunc = new char[5] { '+', '-', '*', '/', '^' };
            List<string> Difs = new List<string>();
            for (int i = 0; i < math.Length; i++)
            {
                int n = 0;
                for (int j = 0; j < MathFunc.Length; j++)
                {
                    if (math[i] != MathFunc[j])
                    {
                        n += 0;
                    }
                    else
                    {
                        n += 1;
                        Oper = MathFunc[j].ToString();
                        break;
                    }
                }
                if (n == 0)
                // Записываем число, пока не наткнемся на матем. оператор
                {
                    TempStr += math[i];
                }
                else
                // Наткнулись на матем. оператор, записанное ранее число заносим в список
                {
                    Difs.Add(TempStr);
                    Difs.Add(Oper);
                    // Обнуляем временное хранилище числа
                    TempStr = "";
                }
                // Занесение последнего числа из формулы в список
                if (i == math.Length - 1 && TempStr != "")
                {
                    Difs.Add(TempStr);
                }
            }
            foreach (string x in Difs)
            {
                Console.WriteLine(x);
            }
        }
        static double Calculate()
        {
            double result;
            result = 1.25;
            return result;
        }
    }
}
