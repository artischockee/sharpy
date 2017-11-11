using System;
using static System.Math;

namespace LW07T2
{
    abstract class Function
    {
        protected double x;
        protected double y;

        public virtual double Calculate(double x)
        {
            return default(double);
        }

        public virtual void Display()
        {
            Console.WriteLine("if x = {0}, then y = {1:0.####}", x, y);
        }

    } // abstract class Function

    class Ellipse : Function
    {
        private double a;
        private double b;

        public Ellipse(double a, double b)
        {
            if (a < 0 || b < 0)
                throw new ArgumentOutOfRangeException(string.Format("Cannot create an Eclipse object, because input values must not be negative numbers."));
            else if (a <= b)
                throw new ArgumentException(string.Format("Cannot create an Eclipse object, because 'a <= b'."));
            else {
                this.a = a;
                this.b = b;
            }
        }

        public override double Calculate(double x)
        {
            if (Double.IsNaN(x))
                throw new ArgumentException();

            this.x = x;
            // canonical equation for the Ellipse:
            // (x^2 / a^2) + (y^2 / b^2) = 1, if (a > b)
            // after some manipulations:
            // y = sqrt( b^2 - ((b^2 * x^2) / a^2) )
            this.y = Sqrt(Pow(b, 2) - ((Pow(b, 2) * Pow(x, 2)) / Pow(a, 2)));

            return y;
        }

        public override void Display()
        {
            Console.WriteLine("Ellipse: ");
            Console.WriteLine("a = {0}, b = {1}", a, b);
            base.Display();
        }
    } // class Ellipse : Function

    class Hyperbola : Function
    {
        private double a;
        private double b;

        public Hyperbola(double a, double b)
        {
            if (a < 0 || b < 0)
                throw new ArgumentOutOfRangeException(string.Format("Cannot create a Hyperbola object, because input values must not be negative numbers."));
            else {
                this.a = a;
                this.b = b;
            }
        }

        public override double Calculate(double x)
        {
            if (Double.IsNaN(x))
                throw new ArgumentException();

            this.x = x;
            // canonical equation for the Hyperbola:
            // (x^2 / a^2) - (y^2 / b^2) = 1
            // after some manipulations:
            // y = sqrt( ((b^2 * x^2) / a^2) - b^2 )
            this.y = Sqrt(((Pow(b, 2) * Pow(x, 2)) / Pow(a, 2)) - Pow(b, 2));

            return y;
        }

        public override void Display()
        {
            Console.WriteLine("Hyperbola: ");
            Console.WriteLine("a = {0}, b = {1}", a, b);
            base.Display();
        }
    } // class Hyperbola : Function

    class Parabola : Function
    {
        private double p;

        public Parabola(double p)
        {
            if (p <= 0)
                throw new ArgumentOutOfRangeException(string.Format("Cannot create a Parabola object, because input value must not be a negative number."));
            else
                this.p = p;
        }

        public override double Calculate(double x)
        {
            if (Double.IsNaN(x))
                throw new ArgumentException();

            this.x = x;
            // canonical equation for the Parabola:
            // y^2 = 2*p*x, where (p > 0)
            // after some manipulations:
            // y = sqrt(2*p*x)
            this.y = Sqrt(2*p*x);

            return y;
        }

        public override void Display()
        {
            Console.WriteLine("Parabola: ");
            Console.WriteLine("p = {0}", p);
            base.Display();
        }
    } // class Parabola : Function
} // namespace LW07T2
