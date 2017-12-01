using System;
using System.Collections.Generic;

namespace LW07T2
{
    public class Series
    {
        private static Random rand = new Random();
        private List<Function> functionsList;

        public Series()
        {
            functionsList = new List<Function>();
        }

        public void CreateObjects()
        {
            try {
                functionsList.Add(new Ellipse(10D, 5D));
                functionsList.Add(new Hyperbola(4D, 12D));
                functionsList.Add(new Parabola(7D));
                functionsList.Add(new Ellipse(17.355D, 1.002D));
                functionsList.Add(new Hyperbola(107.08D, 55.12D));
                functionsList.Add(new Parabola(51.5D));
            }
            catch (ArgumentOutOfRangeException e) {
                Console.WriteLine(e.Message);
                Console.WriteLine("Please redefine the values.");
            }
            catch (ArgumentException e) {
                Console.WriteLine(e.Message);
                Console.WriteLine("Please make sure that everything is good.");
            }
            finally {
                int listLength = functionsList.Count;
                string tense = (listLength == 1) ? "has" : "have";
                Console.WriteLine("{0} object(s) {1} been created.", listLength, tense);
            }
        }

        public void Calculate()
        {
            foreach (var obj in functionsList) {
                double x = (double)rand.Next(1, 20);
                obj.Calculate(x);
            }
        }

        public void Display()
        {
            foreach (var obj in functionsList) {
                obj.Display();
                Console.WriteLine();
            }
        }
    } // public class Series

    public class MainModule
    {
        /// <summary>
        ///   The main entry point for the application
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            Series demoSeries = new Series();
            demoSeries.CreateObjects();
            demoSeries.Calculate();
            demoSeries.Display();
        }
    } // public class MainModule
} // namespace LW07T2
