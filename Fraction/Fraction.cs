using System;

namespace Fraction
{
    public class Fraction
    {
        int num { get; }
        int den { get; }

        public Fraction(int num, int den)
        {
            if (den == 0)
                throw new ArgumentException("Denominator cannot be zero.", nameof(den));

            this.num = num;
            this.den = den;
        }

        public Fraction Add(Fraction number) => new Fraction(num * number.den + number.num * den, den * number.den);

        public Fraction Subtract(Fraction number) => Add(new Fraction(-number.num, number.den));

        public Fraction Multiply(Fraction number) => new Fraction(num * number.num, den * number.den);

        public Fraction Divide(Fraction number)
        {
            if (number.num == 0)
                throw new DivideByZeroException();
            return new Fraction(num * number.den, den * number.num);
        }

        public static Fraction operator +(Fraction a, Fraction b) => a.Add(b);

        public static Fraction operator -(Fraction a, Fraction b) => a.Subtract(b);

        public static Fraction operator *(Fraction a, Fraction b) => a.Multiply(b);

        public static Fraction operator /(Fraction a, Fraction b) => a.Divide(b);

        public override string ToString() => $"{num} / {den}";
    }
}
