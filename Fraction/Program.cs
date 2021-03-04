using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fraction
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            var a = new Fraction(2, 3);
            var b = new Fraction(5, 9);

            Console.WriteLine(a.Add(b));
            Console.WriteLine(a.Subtract(b));
            Console.WriteLine(b.Multiply(b));
            Console.WriteLine(a.Divide(b));
            Console.WriteLine(b / a);
        }
    }
}
