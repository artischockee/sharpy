using System;

namespace LW07T3
{
    abstract class Shape
    {
        protected double surfaceSqr;
        public virtual void ShowSurfaceSqr()
        {
            Console.WriteLine("Full surface square: {0}", surfaceSqr);
            Console.WriteLine(new string('.', 80));
        }
    } // abstract class Shape

    class Parallelepiped : Shape
    {
        private double width;
        private double length;
        private double height;

        public double Width
        {
            get { return width; }
        }

        public double Length
        {
            get { return length; }
        }

        public double Height
        {
            get { return height; }
        }

        public Parallelepiped(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
                throw new ArgumentOutOfRangeException();
            else {
                this.width = a;
                this.length = b;
                this.height = c;
            }

            // FullSurfaceSquare = 2 * (a*b + b*c + a*c)
            this.surfaceSqr = 2 * (a * b + b * c + a * c);
        }

        public override void ShowSurfaceSqr()
        {
            Console.WriteLine("Parallelepiped:");
            Console.WriteLine("Width: {0}, Length: {1}, Height: {2}", width, length, height);
            base.ShowSurfaceSqr();
        }
    } // class Parallelepiped : Shape

    class Tetrahedron : Shape
    {
        private double side;

        public double Side
        {
            get { return side; }
        }

        public Tetrahedron(double s)
        {
            if (s <= 0)
                throw new ArgumentOutOfRangeException();
            else
                this.side = s;

            // FullSurfaceSquare = a^2 * sqrt(3)
            this.surfaceSqr = Math.Pow(s, 2) * Math.Sqrt(3);
        }

        public override void ShowSurfaceSqr()
        {
            Console.WriteLine("Tetrahedron (regular):");
            Console.WriteLine("One of the sides: {0}", side);
            base.ShowSurfaceSqr();
        }
    } // class Tetrahedron : Shape

    class Sphere : Shape
    {
        private double radius;

        public double Radius
        {
            get { return radius; }
        }

        public Sphere(double rad)
        {
            if (rad <= 0)
                throw new ArgumentOutOfRangeException();
            else
                this.radius = rad;

            // FullSurfaceSquare = 4 * PI * r^2
            this.surfaceSqr = 4 * Math.PI * Math.Pow(rad, 2);
        }

        public override void ShowSurfaceSqr()
        {
            Console.WriteLine("Sphere:");
            Console.WriteLine("Radius: {0}", radius);
            base.ShowSurfaceSqr();
        }
    } // class Sphere : Shape
} // namespace LW07T3
