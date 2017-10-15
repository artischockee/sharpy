using System;

namespace LW05T2
{
    public class MainModule
    {
        private static void ParseFromLine(out int h, out int m, out int s)
        {
            string[] time = Console.ReadLine().Split();
            h = int.Parse(time[0]);
            m = int.Parse(time[1]);
            s = int.Parse(time[2]);
        }

        private static void TimeCreate(out Time time)
        {
            Console.Write("Set your time [HH MM SS]: ");
            int hour, minute, second;
            ParseFromLine(out hour, out minute, out second);

            time = new Time(hour, minute, second);
        }

        /// <summary>
        ///   The main entry point for the application
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            try {
                Time myTime;
                TimeCreate(out myTime);

                myTime.printf();

                int second;

                Console.Write("Increase time by N seconds: ");
                second = int.Parse(Console.ReadLine());
                myTime += second;
                myTime.printf();

                Console.Write("Decrease time by N seconds: ");
                second = int.Parse(Console.ReadLine());
                myTime -= second;
                myTime.printf();
            }
            catch (TimeFormatException e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}
