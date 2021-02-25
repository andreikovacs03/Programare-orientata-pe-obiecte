using System;

namespace ComplexNumbers
{
    public class Complex
    {
        double real;
        double imaginary;

        public double Real { get { return real; } }
        public double Imaginary { get { return imaginary; } }

        public Complex(double real, double imaginary = 0)
        {
            this.real = real;
            this.imaginary = imaginary;
        }

        public override string ToString()
        {
            return imaginary == 0 ? $"{real}" : $"{real} {(imaginary > 0 ? "+" : "-")} {Math.Abs(imaginary)}i";
        }

        public Complex Add(Complex number)
        {
            return new Complex(real + number.real, imaginary + number.imaginary);
        }

        public Complex Subtract(Complex number)
        {
            return new Complex(real - number.real, imaginary - number.imaginary);
        }

        public Complex Multiply(Complex number)
        {
            return new Complex(real * number.real - imaginary * number.imaginary,
                               real * number.imaginary - imaginary * number.real);
        }

        public double Abs()
        {
            return Math.Sqrt(real * real + imaginary * imaginary);
        }

        public double Phase()
        {
            return Math.Atan2(imaginary, real);
        }
    }
}
