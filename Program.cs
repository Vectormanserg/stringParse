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
            Calculate(Parse());
        }
        static string[] Parse()
        {
            string func = "2-x^2+25*7-5^2";
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
            string[] args = new string[Difs.Count];
            for (int i = 0; i< Difs.Count; i++)
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
            string tempstr1, tempstr2;
            List<string> Inserted = new List<string>();
            for (int n = 0; n<args.Length; n++)
            {
                if (args[n] == "x")
                {
                    Inserted.Add(x.ToString());
                }
                else Inserted.Add(args[n]);
            }

            do
            {
                int i;
                if (Inserted.Contains("^"))
                {
                    i = Inserted.IndexOf("^");
                    tempstr1 = Inserted[i - 1];
                    tempstr2 = Inserted[i + 1];
                    temp = Math.Pow(double.Parse(tempstr1), double.Parse(tempstr2));
                    ListMod(i, Inserted, temp);
                }
                else if (Inserted.Contains("*") && Inserted.Contains("/"))
                {
                    if (Inserted.IndexOf("*") < Inserted.IndexOf("/"))
                    {
                        i = Inserted.IndexOf("*");
                        tempstr1 = Inserted[i - 1];
                        tempstr2 = Inserted[i + 1];
                        temp = double.Parse(tempstr1) * double.Parse(tempstr2);
                        ListMod(i, Inserted, temp);
                    }
                    else
                    {
                        i = Inserted.IndexOf("/");
                        tempstr1 = Inserted[i - 1];
                        tempstr2 = Inserted[i + 1];
                        temp = double.Parse(tempstr1) / double.Parse(tempstr2);
                        ListMod(i, Inserted, temp);
                    }
                }
                else if (Inserted.Contains("*"))
                {
                    i = Inserted.IndexOf("*");
                    tempstr1 = Inserted[i - 1];
                    tempstr2 = Inserted[i + 1];
                    temp = double.Parse(tempstr1) * double.Parse(tempstr2);
                    ListMod(i, Inserted, temp);
                }
                else if (Inserted.Contains("/"))
                {
                    i = Inserted.IndexOf("/");
                    tempstr1 = Inserted[i - 1];
                    tempstr2 = Inserted[i + 1];
                    temp = double.Parse(tempstr1) / double.Parse(tempstr2);
                    ListMod(i, Inserted, temp);
                }
                else if (Inserted.Contains("+") && Inserted.Contains("-"))
                {
                    if (Inserted.IndexOf("+") < Inserted.IndexOf("-"))
                    {
                        i = Inserted.IndexOf("+");
                        tempstr1 = Inserted[i - 1];
                        tempstr2 = Inserted[i + 1];
                        temp = double.Parse(tempstr1) + double.Parse(tempstr2);
                        ListMod(i, Inserted, temp);
                    }
                    else
                    {
                        i = Inserted.IndexOf("-");
                        tempstr1 = Inserted[i - 1];
                        tempstr2 = Inserted[i + 1];
                        temp = double.Parse(tempstr1) - double.Parse(tempstr2);
                        ListMod(i, Inserted, temp);
                    }
                }
                else if (Inserted.Contains("+"))
                {
                    i = Inserted.IndexOf("+");
                    tempstr1 = Inserted[i - 1];
                    tempstr2 = Inserted[i + 1];
                    temp = double.Parse(tempstr1) + double.Parse(tempstr2);
                    ListMod(i, Inserted, temp);
                }
                else if (Inserted.Contains("-"))
                {
                    i = Inserted.IndexOf("-");
                    tempstr1 = Inserted[i - 1];
                    tempstr2 = Inserted[i + 1];
                    temp = double.Parse(tempstr1) - double.Parse(tempstr2);
                    ListMod(i, Inserted, temp);
                }
            }
            while (Inserted.Count > 1);
            result = double.Parse(Inserted[0]);
            return result;
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
