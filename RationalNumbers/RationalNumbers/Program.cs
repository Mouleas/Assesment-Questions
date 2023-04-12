namespace RationalNumbers
{
    struct RationalNumber
    {
        int numerator = 0, denominator = 0;
        public RationalNumber(int numerator, int denominator) 
        { 
            if (denominator == 0)
            {
                throw new DivideByZeroException();
            }
            this.numerator = numerator;
            this.denominator = denominator;
        }

        public static RationalNumber operator +(RationalNumber r1, RationalNumber r2)
        {
            int newNumerator = (r1.numerator * r2.denominator) + (r1.denominator * r2.numerator);
            int newDenominator = (r1.denominator * r2.denominator);

            return new RationalNumber(newNumerator, newDenominator);
        }

        public static RationalNumber operator -(RationalNumber r1, RationalNumber r2)
        {
            int newNumerator = (r1.numerator * r2.denominator) - (r1.denominator * r2.numerator);
            int newDenominator = (r1.denominator * r2.denominator);

            return new RationalNumber(newNumerator, newDenominator);
        }

        public static RationalNumber operator -(RationalNumber r1)
        {
            int newNumerator = -r1.numerator;
            return new RationalNumber(newNumerator, r1.denominator);
        }

        public static RationalNumber operator *(RationalNumber r1, RationalNumber r2)
        {
            int newNumerator = (r1.numerator * r2.numerator);
            int newDenominator = (r1.denominator * r2.denominator);

            return new RationalNumber(newNumerator, newDenominator);
        }

        public static RationalNumber operator /(RationalNumber r1, RationalNumber r2)
        {
            int newNumerator = (r1.numerator * r2.denominator);
            int newDenominator = (r1.denominator * r2.numerator);

            return new RationalNumber(newNumerator, newDenominator);
        }

        public static bool operator ==(RationalNumber r1, RationalNumber r2)
        {
            return (r1.numerator == r2.numerator) && (r1.denominator == r2.denominator);
        }

        public static bool operator !=(RationalNumber r1, RationalNumber r2)
        {
            return (r1.numerator != r2.numerator) || (r1.denominator != r2.denominator);
        }

        public static bool operator >(RationalNumber r1, RationalNumber r2)
        {
            return (((float)r1.numerator)/r1.denominator) > (((float)r2.numerator)/r2.denominator);
        }

        public static bool operator <(RationalNumber r1, RationalNumber r2)
        {
            return (((float)r1.numerator) / r1.denominator) < (((float)r2.numerator) / r2.denominator);
        }

        public static bool operator >=(RationalNumber r1, RationalNumber r2)
        {
            return (((float)r1.numerator) / r1.denominator) >= (((float)r2.numerator) / r2.denominator);
        }

        public static bool operator <=(RationalNumber r1, RationalNumber r2)
        {
            return (((float)r1.numerator) / r1.denominator) <= (((float)r2.numerator) / r2.denominator);
        }

        public RationalNumber GetSimplified(RationalNumber r)
        {
            int Remainder;
            int num1 = r.numerator, num2 = r.denominator;

            while (num2 != 0)
            {
                Remainder = num1 % num2;
                num1 = num2;
                num2 = Remainder;
            }
            r.numerator = r.numerator / num1;
            r.denominator = r.denominator / num1;
            return new RationalNumber(r.numerator, r.denominator);
        }

        public override string ToString()
        {
            RationalNumber r = GetSimplified(this);
            return r.numerator + "/" + r.denominator;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            RationalNumber r1 = new RationalNumber(1, 2);
            RationalNumber r2 = new RationalNumber(10, 8);
            RationalNumber r3 = new RationalNumber(2, -1);

            Console.WriteLine((r1 - -r2));
        }
    }
}