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
        n = sqrt(n);
        Console.WriteLine(n.ToString());
    }
    unsafe static double sqrt(double x)
    {
        // Get bits as a long
        long bits = *(long*)&x;

        // Extract sign using shorthand if statement
        double sign = (bits >> 63) == 0 ? 1.0 : -1.0;

        // Extract exponent
        int exponent = (int)((bits >> 52) & 0x7FF); // 11 bits for exponent

        // Extract mantissa
        long mantissa = bits & 0x000FFFFFFFFFFFFF; // 52 bits for mantissa

        double normalizedMantissa;

        if (exponent == 0)
        {
            // Subnormal case (denormalized numbers)
            normalizedMantissa = mantissa / Math.Pow(2, 52);
            exponent = -1022; // Exponent for subnormal numbers is -1022
        }
        else
        {
            // Normalized case
            normalizedMantissa = 1 + (mantissa / Math.Pow(2, 52));
            exponent -= 1023; // Adjust exponent to the actual value
        }


        double b = exponent * Math.Log10(2);
        double a = sign * normalizedMantissa; 

        //Mclauren series works best when a is close to one if its greater than 1.5 I take out a factor of 10
        if (Math.Abs(a) > 1.5) 
        {
            a = a / 10;
            b++; 
        }

        //x = a*10^b
        //x^1/2 = a ^ 1/2 * 10^b/2
        return McLauren(a) * Math.Pow(10, b/2);
    }
    static double McLauren(double a)
    {
        // The McLaurin series for sqrt(x) up to 52 terms to be exact.
        //I also generated this with chat gpt im not calculating that and writing it out
        double xMinus1 = a - 1;
        return 1
               + 0.5 * xMinus1
               - (1.0 / 8.0) * Math.Pow(xMinus1, 2)
               + (1.0 / 16.0) * Math.Pow(xMinus1, 3)
               - (5.0 / 128.0) * Math.Pow(xMinus1, 4)
               + (7.0 / 256.0) * Math.Pow(xMinus1, 5)
               - (9.0 / 1024.0) * Math.Pow(xMinus1, 6)
               +(11.0 / 2048.0) * Math.Pow(xMinus1, 7)
               - (51.0 / 8192.0) * Math.Pow(xMinus1, 8)
               + (127.0 / 16384.0) * Math.Pow(xMinus1, 9)
               - (99.0 / 32768.0) * Math.Pow(xMinus1, 10)
               + (169.0 / 65536.0) * Math.Pow(xMinus1, 11)
               - (385.0 / 131072.0) * Math.Pow(xMinus1, 12)
               + (721.0 / 262144.0) * Math.Pow(xMinus1, 13)
               - (693.0 / 524288.0) * Math.Pow(xMinus1, 14)
               + (2145.0 / 1048576.0) * Math.Pow(xMinus1, 15)
               - (2457.0 / 2097152.0) * Math.Pow(xMinus1, 16)
               + (11899.0 / 4194304.0) * Math.Pow(xMinus1, 17)
               - (19435.0 / 8388608.0) * Math.Pow(xMinus1, 18)
               + (22339.0 / 16777216.0) * Math.Pow(xMinus1, 19)
               - (27699.0 / 33554432.0) * Math.Pow(xMinus1, 20)
               + (55629.0 / 67108864.0) * Math.Pow(xMinus1, 21)
               - (180869.0 / 134217728.0) * Math.Pow(xMinus1, 22)
               + (187307.0 / 268435456.0) * Math.Pow(xMinus1, 23)
               - (546285.0 / 536870912.0) * Math.Pow(xMinus1, 24)
               + (1418915.0 / 1073741824.0) * Math.Pow(xMinus1, 25)
               - (1777221.0 / 2147483648.0) * Math.Pow(xMinus1, 26)
               + (1668617.0 / 4294967296.0) * Math.Pow(xMinus1, 27)
               - (3545765.0 / 8589934592.0) * Math.Pow(xMinus1, 28)
               + (7584779.0 / 17179869184.0) * Math.Pow(xMinus1, 29)
               - (5470311.0 / 34359738368.0) * Math.Pow(xMinus1, 30)
               + (30682909.0 / 68719476736.0) * Math.Pow(xMinus1, 31)
               - (24838741.0 / 137438953472.0) * Math.Pow(xMinus1, 32)
               + (125057249.0 / 274877906944.0) * Math.Pow(xMinus1, 33)
               - (5979685.0 / 549755813888.0) * Math.Pow(xMinus1, 34)
               + (31852991.0 / 1099511627776.0) * Math.Pow(xMinus1, 35)
               - (35092657.0 / 2199023255552.0) * Math.Pow(xMinus1, 36)
               + (45667609.0 / 4398046511104.0) * Math.Pow(xMinus1, 37)
               - (132556657.0 / 8796093022208.0) * Math.Pow(xMinus1, 38)
               + (139416139.0 / 17592186044416.0) * Math.Pow(xMinus1, 39)
               - (556059389.0 / 35184372088832.0) * Math.Pow(xMinus1, 40)
               + (1328472497.0 / 70368744177664.0) * Math.Pow(xMinus1, 41)
               - (2557744551.0 / 140737488355328.0) * Math.Pow(xMinus1, 42)
               + (5035015957.0 / 281474976710656.0) * Math.Pow(xMinus1, 43)
               - (7067209011.0 / 562949953421312.0) * Math.Pow(xMinus1, 44)
               + (10148723999.0 / 1125899906842624.0) * Math.Pow(xMinus1, 45)
               - (14177940829.0 / 2251799813685248.0) * Math.Pow(xMinus1, 46)
               + (18790640589.0 / 4503599627370496.0) * Math.Pow(xMinus1, 47)
               - (16412634667.0 / 9007199254740992.0) * Math.Pow(xMinus1, 48)
               + (23359240573.0 / 18014398509481984.0) * Math.Pow(xMinus1, 49)
               - (28651702467.0 / 36028797018963968.0) * Math.Pow(xMinus1, 50)
               + (36247475579.0 / 72057594037927936.0) * Math.Pow(xMinus1, 51)
               - (41737337951.0 / 144115188075855872.0) * Math.Pow(xMinus1, 52);
    }
}


