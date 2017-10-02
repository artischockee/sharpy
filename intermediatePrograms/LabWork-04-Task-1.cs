using System;
using System.Collections.Generic;

namespace LabWork04
{
    public class DepartureTimeComparer : IComparer<Train>
    {
        public int Compare(Train x, Train y)
        {
            string[] xDep = x.DepartureTime;
            string[] yDep = y.DepartureTime;

            int hourCmp = String.Compare(xDep[0], yDep[0]);
            int minuteCmp = String.Compare(xDep[1], yDep[1]);

            if (hourCmp != 0)
                return hourCmp;
            else
                return minuteCmp;
        }
    }

    public class Train
    {
        static Random rand = new Random();
        private string number; // номер поезда
        private string destPoint;
        private string[] departureTime = new string[2];
        private int commonSeats;
        private int compartmentSeats; // купе
        private int reservedSeats; // плацкарт

        public Train()
        {
            this.number = GenNumber(rand);
            this.destPoint = GenDestPoint(rand);
            this.departureTime = GenDepartureTime(rand);
            this.commonSeats = GenAnyNumber(rand);
            this.compartmentSeats = GenAnyNumber(rand);
            this.reservedSeats = GenAnyNumber(rand);
        }

        public string[] DepartureTime
        {
            get {
                return departureTime;
            }
        }

        private static string GenNumber(Random rand)
        {
            string[] numbers = { "100", "101", "102", "103", "104", "105", "123", "234", "555", "123-F", "768", "A-134", "897", "596", "098", "454-B", "055", "998-L", "112-U", "001", "001-P", "028", "332", "333-D", "334-Y", "334-N", "7050", "7199", "665-MN", "10-30Y" };

            return numbers[rand.Next(numbers.Length)];
        }

        private static string GenDestPoint(Random rand)
        {
            string[] destPoints = { "Kaliningrad", "Berlin", "Cologne", "Moscow", "Paris", "Vienna", "Hamburg", "V. Novgorod", "N. Novgorod", "Rostov-Na-Donu", "Luxembourg", "Los Angeles", "Saint-Pbg", "Lissabon", "Torjok", "Tomsk", "Novosibirsk", "Vladivostok", "Jakarta", "Dubai", "Kiev", "Odessa", "Donetsk", "Krivosheino", "Irkutsk", "Wroclaw", "Belfast", "Madrid", "Barcelona", "Mecca", "Rome", "Florence", "Yekaterinburg", "Tokyo", "Hiroshima", "New Orlean", "Toronto", "Washington", "Buenos Aires", "Bogota", "Brasilia", "Rio de Janeiro", "Ottawa", "Tallahassee", "Cupertino", "San Francisco", "New York City", "Tallinn" };

            return destPoints[rand.Next(destPoints.Length)];
        }

        private static string[] GenDepartureTime(Random rand)
        {
            int[] time = new int[2];
            time[0] = rand.Next(24);
            time[1] = rand.Next(60);

            string[] strTime = new string[2];
            for (int i = 0; i < strTime.Length; ++i) {
                if (time[i] / 10 == 0)
                    strTime[i] = "0" + time[i].ToString();
                else
                    strTime[i] = time[i].ToString();
            }

            return strTime;
        }

        private static int GenAnyNumber(Random rand)
        {
            return rand.Next(200);
        }

        public void DisplayInfo()
        {
            Console.WriteLine("{0,-6}   {1,-17}   {2}:{3,-6}   {4,-4}  {5,-4}  {6,-4}", number, destPoint, departureTime[0], departureTime[1], commonSeats, compartmentSeats, reservedSeats);
        }
    }

    public class Task1
    {
        static void DisplayTrainSchedule(ref List<Train> schedule)
        {
            Console.WriteLine("-------------------------------- TRAIN SCHEDULE --------------------------------");
            Console.WriteLine("Number | Destination point | Departure | Seats (common, compartment, reserved) ");
            Console.WriteLine("--------------------------------------------------------------------------------");

            foreach (var train in schedule)
                train.DisplayInfo();

            Console.WriteLine("--------------------------------------------------------------------------------");
        }

        static void CreateTrainSchedule(ref List<Train> schedule, uint trainsAmount)
        {
            while (trainsAmount > 0) {
                var train = new Train();
                schedule.Add(train);
                --trainsAmount;
            }
        }

        static void Main(string[] args)
        {
            const uint trainsAmount = 16;

            List<Train> schedule = new List<Train>();
            CreateTrainSchedule(ref schedule, trainsAmount);

            DepartureTimeComparer dtc = new DepartureTimeComparer();
            schedule.Sort(dtc);

            DisplayTrainSchedule(ref schedule);
        }
    }
}
