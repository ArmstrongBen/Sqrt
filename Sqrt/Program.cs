using System;
using System.Runtime.InteropServices;

class Program
{
    static unsafe void Main(string[] args)
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
}

