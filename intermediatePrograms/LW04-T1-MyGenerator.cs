using System;

namespace LabWork04
{
    internal static class MyGenerator
    {
        static Random rand = new Random();

        internal static string GenNumber()
        {
            string[] numbers = { "100", "101", "102", "103", "104", "105", "123", "234", "555", "123-F", "768", "A-134", "897", "596", "098", "454-B", "055", "998-L", "112-U", "001", "001-P", "028", "332", "333-D", "334-Y", "334-N", "7050", "7199", "665-MN", "10-30Y" };

            return numbers[rand.Next(numbers.Length)];
        }

        internal static string GenDestPoint()
        {
            // string[] destPoints = { "Kaliningrad", "Berlin", "Cologne", "Moscow", "Paris", "Vienna", "Hamburg", "V. Novgorod", "N. Novgorod", "Rostov-Na-Donu", "Luxembourg", "Los Angeles", "St. Petersburg", "Lissabon", "Torjok", "Tomsk", "Novosibirsk", "Vladivostok", "Jakarta", "Dubai", "Kiev", "Odessa", "Donetsk", "Krivosheino", "Irkutsk", "Wroclaw", "Belfast", "Madrid", "Barcelona", "Mecca", "Rome", "Florence", "Yekaterinburg", "Tokyo", "Hiroshima", "New Orlean", "Toronto", "Washington", "Buenos Aires", "Bogota", "Brasilia", "Rio de Janeiro", "Ottawa", "Tallahassee", "Cupertino", "San Francisco", "New York City", "Tallinn" };

            // Меньше городов для наглядности:
            string[] destPoints = { "Kaliningrad", "Berlin", "Cologne", "Moscow", "Paris", "Vienna", "Hamburg", "V. Novgorod", "N. Novgorod", "Rostov-Na-Donu", "Luxembourg" };

            return destPoints[rand.Next(destPoints.Length)];
        }

        internal static string[] GenDepartureTime()
        {
            int[] time = new int[2];
            time[0] = rand.Next(24);
            time[1] = rand.Next(60);

            string[] strTime = new string[2];
            for (int i = 0; i < strTime.Length; ++i) {
                strTime[i] = Task1.TimeToString(time[i]);
            }

            return strTime;
        }

        internal static int GenAnyNumber()
        {
            int chance = rand.Next(100);
            if (chance >= 50)
                return rand.Next(200);
            else
                return 0;
        }
    }
}
