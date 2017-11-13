using System;
using System.Collections.Generic;

namespace LW07T3
{
    public class MainModule
    {
        /// <summary>
        ///   The main entry point for the application
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            var shapes = new List<Shape>();
            shapes.Add(new Parallelepiped(5, 10, 8));
            shapes.Add(new Tetrahedron(84));
            shapes.Add(new Sphere(17));

            foreach (var shape in shapes) {
                shape.ShowSurfaceSqr();
            }
        }
    } // public class MainModule
} // namespace LW07T3
