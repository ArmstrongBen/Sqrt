using System;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        double n = 0;
        while (n == 0)
        {
            Console.WriteLine("Please enter a number to be square rooted (other than 0):");
            var temp = Console.ReadLine();
            double.TryParse(temp, out n);
            Console.Clear();
        }
        Console.WriteLine(n.ToString());
    }
    unsafe double sqrt(double x)
    {
        //Rewrite x as a * 10 ^ b
        //x is in IEEE 754 format 1 sign bit 11 Exponent bits and 52 mantisa 
        //Im taking the code to extract the parts from memory from chat gpt 
        //because Idk how unsafe works
        //Get bits as a long
        long bits = *(long*)&x;

        //Extract sign using shorthand if statement
        double sign = (bits >> 63) == 0 ? 1.0 : -1.0;

        //Extract exponent
        int exponent = (int)((bits >> 52) & 0xff);

        //Extract mantisa
        long mantissa = bits & 0x000ffffffffffff;

        double normalisedMantissa;

        if (exponent == 0)
        {
            normalisedMantissa = mantissa / Math.Pow(2, 52);
            exponent = -1022;
        }
        else 
        {
            normalisedMantissa = mantissa / Math.Pow(2, 52);
            exponent -= 1023;
        }

        double b = exponent * Math.Log10(2);
        double a = sign * normalisedMantissa; 

        return 0;
    }
}


