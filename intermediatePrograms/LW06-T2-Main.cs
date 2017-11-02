using System;

namespace LW06T2
{
    public class MainModule
    {
        /// <summary>
        ///   The main entry point for the application
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            try {
                var P1 = new Person("Paul", 25);
                P1.Show();
                Console.WriteLine();

                var W1 = new Worker("Jonathan", "Apple Inc");
                W1.Show();
                Console.WriteLine();

                var DM1 = new DepartmentMember("Paula", 32, "Adobe", "PR");
                DM1.Show();
            }
            catch(AgeException e) {
                Console.WriteLine(e.Message);
            }
        }
    } // public class MainModule
} // namespace LW06T2
