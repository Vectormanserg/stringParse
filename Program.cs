using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Channels;

namespace stringParse
{
    class StringParse
    {
        static void Main(string[] args)
        {
            string func = "3*x^2+8*5-2*x^2";
            double result;
            if (func.Contains("(") || func.Contains(")"))
            {
                result = Brackets(func);
            }
            else result = Calculate(StringToArr(func));
            Console.WriteLine(result.ToString());
        }
        static double Brackets(string func)
        // Если есть скобки
        {
            int open = 0, close = 0;
            string Temp, Temp2;
            double Temp3;
            do
            {
                open = func.LastIndexOf("(");
                for (int q = open; q < func.Length; q++)
                {
                    if (func[q] == ')')
                    {
                        close = q;
                        break;
                    }
                }
                Temp = func.Substring(open, close - open+1);
                Temp2 = Temp.Trim('(', ')');
                Temp3 = Calculate(StringToArr(Temp2));
                func = func.Replace(Temp, Temp3.ToString());
            }
            while (func.Contains("("));
            return Calculate(StringToArr(func));
        }
        static string[] StringToArr(string func)
        {
            if (func.Contains('('))
            {
                func = Brackets(func).ToString();
            }
            string[] math = new string[func.Length];
            for (int c = 0; c < func.Length; c++)
            {
                math[c] = func[c].ToString();
            }
            string TempStr = "", Oper = "";
            string[] MathFunc = new string[17] { "+", "-", "*", "/", "^", "sin", "cos", "tg", "ctg", "arcsin", "arccos", "arctg", "arcctg", "log", "lg", "ln", "exp" };
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
                        Oper = MathFunc[j];
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
            string[] args = new string[Difs.Count];
            for (int i = 0; i < Difs.Count; i++)
            {
                args[i] = Difs[i];
            }
            return args;
        }
        static double Calculate(string[] args)
        {
            double x = 3;
            double result;
            double temp;
            List<string> Inserted = new List<string>();
            foreach (string q in args)
            {
                if (q == "x")
                {
                    Inserted.Add(x.ToString());
                }
                else Inserted.Add(q);
            }
            do
            {
                int i;
                if (Inserted.Contains("^"))
                {
                    i = Inserted.IndexOf("^");
                    temp = MathOps.Power(i, Inserted);
                    ListMod(i, Inserted, temp);
                }
                else if (Inserted.Contains("*") && Inserted.Contains("/"))
                {
                    if (Inserted.IndexOf("*") < Inserted.IndexOf("/"))
                    {
                        i = Inserted.IndexOf("*");
                        temp = MathOps.Multiply(i, Inserted);
                        ListMod(i, Inserted, temp);
                    }
                    else
                    {
                        i = Inserted.IndexOf("/");
                        temp = MathOps.Divide(i, Inserted);
                        ListMod(i, Inserted, temp);
                    }
                }
                else if (Inserted.Contains("*"))
                {
                    i = Inserted.IndexOf("*");
                    temp = MathOps.Multiply(i, Inserted);
                    ListMod(i, Inserted, temp);
                }
                else if (Inserted.Contains("/"))
                {
                    i = Inserted.IndexOf("/");
                    temp = MathOps.Divide(i, Inserted);
                    ListMod(i, Inserted, temp);
                }
                else if (Inserted.Contains("+") && Inserted.Contains("-"))
                {
                    if (Inserted.IndexOf("+") < Inserted.IndexOf("-"))
                    {
                        i = Inserted.IndexOf("+");
                        temp = MathOps.Plus(i, Inserted);
                        ListMod(i, Inserted, temp);
                    }
                    else
                    {
                        i = Inserted.IndexOf("-");
                        temp = MathOps.Minus(i, Inserted);
                        ListMod(i, Inserted, temp);
                    }
                }
                else if (Inserted.Contains("+"))
                {
                    i = Inserted.IndexOf("+");
                    temp = MathOps.Plus(i, Inserted);
                    ListMod(i, Inserted, temp);
                }
                else if (Inserted.Contains("-"))
                {
                    i = Inserted.IndexOf("-");
                    temp = MathOps.Minus(i, Inserted);
                    ListMod(i, Inserted, temp);
                }
            }
            while (Inserted.Count > 1);
            return result = double.Parse(Inserted[0]);
        }
        static List<string> ListMod(int i, List<string> Inserted, double temp)
        {
            List<string> operate = new List<string>();
            for (int z = 0; z < Inserted.Count; z++)
            {
                if (z < i - 1 || z > i + 1)
                {
                    string s = Inserted[z];
                    operate.Add(Inserted[z]);
                }
                else if (z == i - 1 || z == i + 1)
                {
                }
                else
                {
                    string s = temp.ToString();
                    operate.Add(temp.ToString());
                }
            }
            Inserted.Clear();
            foreach (string q in operate)
            {
                string s = q;
                Inserted.Add(q);
            }
            return operate;
        }
    }      
}
