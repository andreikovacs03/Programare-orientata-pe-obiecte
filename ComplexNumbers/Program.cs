using System;

namespace ComplexNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Complex c1 = new Complex(1, 2);
            Complex c2 = new Complex(3, -2);
            Complex c3 = new Complex(-3);

            Console.WriteLine(c1);
            Console.WriteLine(c2);
            Console.WriteLine(c3);

            Console.WriteLine(c1.Abs());
            Console.WriteLine(c1.Phase());
            Console.WriteLine(c1.Pow(5));

            Console.WriteLine(c1 - c2);
        }
    }
}
