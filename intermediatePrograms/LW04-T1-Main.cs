using System;
using System.Collections.Generic;

namespace LabWork04
{
    public class Train
    {
        static Random rand = new Random();
        private string number; // номер поезда
        private string destPoint;
        private string[] departureTime = new string[2];
        private int commonSeats;
        private int compartmentSeats; // купе
        private int reservedSeats; // плацкарт

        // Constructor(s):

        public Train()
        {
            this.number = GenNumber(rand);
            this.destPoint = GenDestPoint(rand);
            this.departureTime = GenDepartureTime(rand);
            this.commonSeats = GenAnyNumber(rand);
            this.compartmentSeats = GenAnyNumber(rand);
            this.reservedSeats = GenAnyNumber(rand);
        }

        // Getters and setters:

        public int CommonSeats
        {
            get {
                return commonSeats;
            }
        }

        public string DestPoint
        {
            get {
                return destPoint;
            }
        }

        public string DepartureHour
        {
            get {
                return departureTime[0];
            }
        }

        public string[] DepartureTime
        {
            get {
                return departureTime;
            }
        }

        // Other methods:

        private static string GenNumber(Random rand)
        {
            string[] numbers = { "100", "101", "102", "103", "104", "105", "123", "234", "555", "123-F", "768", "A-134", "897", "596", "098", "454-B", "055", "998-L", "112-U", "001", "001-P", "028", "332", "333-D", "334-Y", "334-N", "7050", "7199", "665-MN", "10-30Y" };

            return numbers[rand.Next(numbers.Length)];
        }

        private static string GenDestPoint(Random rand)
        {
            string[] destPoints = { "Kaliningrad", "Berlin", "Cologne", "Moscow", "Paris", "Vienna", "Hamburg", "V. Novgorod", "N. Novgorod", "Rostov-Na-Donu", "Luxembourg", "Los Angeles", "St. Petersburg", "Lissabon", "Torjok", "Tomsk", "Novosibirsk", "Vladivostok", "Jakarta", "Dubai", "Kiev", "Odessa", "Donetsk", "Krivosheino", "Irkutsk", "Wroclaw", "Belfast", "Madrid", "Barcelona", "Mecca", "Rome", "Florence", "Yekaterinburg", "Tokyo", "Hiroshima", "New Orlean", "Toronto", "Washington", "Buenos Aires", "Bogota", "Brasilia", "Rio de Janeiro", "Ottawa", "Tallahassee", "Cupertino", "San Francisco", "New York City", "Tallinn" };

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
            int chance = rand.Next(100);
            if (chance >= 50)
                return rand.Next(200);
            else
                return 0;
        }

        public void DisplayInfo()
        {
            Console.WriteLine("{0,-6}   {1,-17}   {2}:{3,-6}   {4,-4}  {5,-4}  {6,-4}", number, destPoint, departureTime[0], departureTime[1], commonSeats, compartmentSeats, reservedSeats);
        }
    }

    public class Task1
    {
        /*
           Необходимо оптимизировать функции поиска, исключив повторение кода
        */

        static void SearchByDestPointAndCmnSeats(ref List<Train> schedule)
        {
            Console.WriteLine("c) Поиск поездов, следующих до указанного пункта назначения и имеющих общие места.");
            Console.Write("Введите пункт назначения латинскими буквами: ");
            string destination = Console.ReadLine();
            destination = destination.ToLower();

            foreach (var train in schedule)
                if (train.DestPoint.ToLower() == destination &&
                train.CommonSeats > 0)
                    train.DisplayInfo();
        }

        static void SearchByDestPointAndDepTime(ref List<Train> schedule)
        {
            Console.WriteLine("b) Поиск поездов, следующих до указанного пункта назначения и отправляющиеся после заданного часа.");
            Console.Write("Введите пункт назначения латинскими буквами: ");
            string destination = Console.ReadLine();
            destination = destination.ToLower();
            Console.Write("Укажите требуемый час отправления: ");
            int _depHour = int.Parse(Console.ReadLine());
            string depHour;
            if (_depHour / 10 == 0)
                depHour = "0" + _depHour.ToString();
            else
                depHour = _depHour.ToString();

            foreach (var train in schedule)
                if (train.DestPoint.ToLower() == destination &&
                String.Compare(train.DepartureHour, depHour) >= 0)
                    train.DisplayInfo();
        }

        static void SearchByDestPoint(ref List<Train> schedule)
        {
            Console.WriteLine("a) Поиск поездов, следующих до указанного пункта назначения.");
            Console.Write("Введите пункт назначения латинскими буквами: ");
            string destination = Console.ReadLine();
            destination = destination.ToLower();
            foreach (var train in schedule)
                if (train.DestPoint.ToLower() == destination)
                    train.DisplayInfo();
        }

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
            const uint trainsAmount = 32;

            List<Train> schedule = new List<Train>();
            CreateTrainSchedule(ref schedule, trainsAmount);

            DepartureTimeComparer dtc = new DepartureTimeComparer();
            schedule.Sort(dtc);

            DisplayTrainSchedule(ref schedule);

            // SearchByDestPoint(ref schedule);
            // SearchByDestPointAndDepTime(ref schedule);
            SearchByDestPointAndCmnSeats(ref schedule);
        }
    }
}
