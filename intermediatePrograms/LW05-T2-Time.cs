using System;

namespace LW05T2
{
    public class TimeFormatException : Exception
    {
        public TimeFormatException(string message) : base(message) {}
    }

    public class Time
    {
        // Class members:

        private int hour;
        private int minute;
        private int second;

        // Constructors:

        public Time()
        {
            hour = minute = second = 0;
        }

        public Time(int hour, int minute, int second)
        {
            if (hour < 0 || hour >= 24
            || minute < 0 || minute >= 60
            || second < 0 || second >= 60)
                throw new TimeFormatException(string.Format("Unappropriate time format: {0}:{1}:{2}.", ToString(hour), ToString(minute), ToString(second)));
            else {
                this.hour = hour;
                this.minute = minute;
                this.second = second;
            }
        }

        // Overloaded operators (+ and -)

        public static Time operator +(Time old, int second)
        {
            if (second < 0)
                return old -= Math.Abs(second);

            var time = new Time(old.hour, old.minute, old.second);

            time.second += second;
            if (time.second >= 60) {
                int minute = time.second / 60;
                time.second %= 60;
                time.minute += minute;
                if (time.minute >= 60) {
                    int hour = time.minute / 60;
                    time.minute %= 60;
                    time.hour += hour;
                    if (time.hour >= 24)
                        time.hour %= 24;
                }
            }

            return time;
        }

        public static Time operator -(Time old, int second)
        {
            if (second < 0)
                return old += Math.Abs(second);

            var time = new Time(old.hour, old.minute, old.second);

            time.second -= second;
            if (time.second < 0) {
                int minute = 0;
                while (time.second < 0) {
                    time.second += 60;
                    ++minute;
                }
                time.minute -= minute;
                if (time.minute < 0) {
                    int hour = 0;
                    while (time.minute < 0) {
                        time.minute += 60;
                        ++hour;
                    }
                    time.hour -= hour;
                    if (time.hour < 0)
                        time.hour += 24;
                }
            }

            return time;
        }

        // Class methods:

        private static string ToString(int init)
        {
            if (init / 10 == 0)
                return ("0" + init.ToString());
            else
                return (init.ToString());
        }

        public void printf()
        {
            Console.WriteLine("Time: {0}:{1}:{2}.", ToString(hour), ToString(minute), ToString(second));
        }
    }
}
