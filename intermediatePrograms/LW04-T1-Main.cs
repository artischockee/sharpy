using System;
using System.Collections.Generic;

namespace LabWork04
{
    public class Task1
    {
        // Converts time value into a human view
        public static string TimeToString(int init)
        {
            if (init / 10 == 0)
                return ("0" + init.ToString());
            else
                return (init.ToString());
        }

        static void SearchByDestPointAndCmnSeats(ref List<Train> schedule)
        {
            Console.Write("Введите пункт назначения латинскими буквами: ");
            string destination = Console.ReadLine().ToLower();

            foreach (var train in schedule)
                if (train.DestPoint.ToLower() == destination &&
                train.CommonSeats > 0)
                    train.DisplayInfo();
        }

        static void SearchByDestPointAndDepTime(ref List<Train> schedule)
        {
            Console.Write("Введите пункт назначения латинскими буквами: ");
            string destination = Console.ReadLine().ToLower();
            Console.Write("Укажите требуемый час отправления: ");
            string depHour = TimeToString(int.Parse(Console.ReadLine()));

            foreach (var train in schedule)
                if (train.DestPoint.ToLower() == destination &&
                String.Compare(train.DepartureHour, depHour) >= 0)
                    train.DisplayInfo();
        }

        static void SearchByDestPoint(ref List<Train> schedule)
        {
            Console.Write("Введите пункт назначения латинскими буквами: ");
            string destination = Console.ReadLine().ToLower();

            foreach (var train in schedule)
                if (train.DestPoint.ToLower() == destination)
                    train.DisplayInfo();
        }

        static void PerformSearchOperations(ref List<Train> schedule)
        {
            Console.WriteLine("a) Поиск поездов, следующих до указанного пункта назначения.");
            SearchByDestPoint(ref schedule);

            Console.WriteLine("b) Поиск поездов, следующих до указанного пункта назначения и отправляющиеся после заданного часа.");
            SearchByDestPointAndDepTime(ref schedule);

            Console.WriteLine("c) Поиск поездов, следующих до указанного пункта назначения и имеющих общие места.");
            SearchByDestPointAndCmnSeats(ref schedule);
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

        static List<Train> CreateTrainSchedule(int trainsAmount)
        {
            List<Train> newSchedule = new List<Train>();
            while (trainsAmount > 0) {
                var train = new Train();
                newSchedule.Add(train);
                --trainsAmount;
            }

            return newSchedule;
        }

        /// <summary>
        ///   The main entry point for the application
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            const int trainsAmount = 24;

            // ***Адекватное ли решение?
            List<Train> schedule = new List<Train>();
            schedule = CreateTrainSchedule(trainsAmount);

            DepartureTimeComparer dtc = new DepartureTimeComparer();
            schedule.Sort(dtc);

            DisplayTrainSchedule(ref schedule);
            PerformSearchOperations(ref schedule);
        }
    }
}
