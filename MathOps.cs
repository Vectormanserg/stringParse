using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Channels;

public class MathOps
{
    public static double result;
    public static double Multiply(int i, List<string> Inserted)
    {
        string tempstr1 = Inserted[i - 1],
        tempstr2 = Inserted[i + 1];
        result = double.Parse(tempstr1) * double.Parse(tempstr2);
        return result;
    }
    public static double Plus(int i, List<string> Inserted)
    {
        string tempstr1 = Inserted[i - 1],
        tempstr2 = Inserted[i + 1];
        result = double.Parse(tempstr1) + double.Parse(tempstr2);
        return result;
    }
    public static double Minus(int i, List<string> Inserted)
    {
        string tempstr1 = Inserted[i - 1],
        tempstr2 = Inserted[i + 1];
        result = double.Parse(tempstr1) - double.Parse(tempstr2);
        return result;
    }
    public static double Divide(int i, List<string> Inserted)
    {
        string tempstr1 = Inserted[i - 1],
        tempstr2 = Inserted[i + 1];
        result = double.Parse(tempstr1) / double.Parse(tempstr2);
        return result;
    }
    public static double Power(int i, List<string> Inserted)
    {
        string tempstr1 = Inserted[i - 1],
        tempstr2 = Inserted[i + 1];
        result = Math.Pow(double.Parse(tempstr1), double.Parse(tempstr2));
        return result;
    }
}

