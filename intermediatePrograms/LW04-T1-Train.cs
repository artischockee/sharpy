using System;

namespace LabWork04
{
    public class Train
    {
        // Class members:

        private string number; // номер поезда
        private string destPoint;
        private string[] departureTime = new string[2];
        private int commonSeats;
        private int compartmentSeats; // купе
        private int reservedSeats; // плацкарт

        // Constructor(s):

        public Train()
        {
            this.number = MyGenerator.GenNumber();
            this.destPoint = MyGenerator.GenDestPoint();
            this.departureTime = MyGenerator.GenDepartureTime();
            this.commonSeats = MyGenerator.GenAnyNumber();
            this.compartmentSeats = MyGenerator.GenAnyNumber();
            this.reservedSeats = MyGenerator.GenAnyNumber();
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

        // Other method(s):

        public void DisplayInfo()
        {
            Console.WriteLine("{0,-6}   {1,-17}   {2}:{3,-6}   {4,-4}  {5,-4}  {6,-4}", number, destPoint, departureTime[0], departureTime[1], commonSeats, compartmentSeats, reservedSeats);
        }
    }
}
