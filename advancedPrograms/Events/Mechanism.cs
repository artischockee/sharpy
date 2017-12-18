using System;

namespace Events
{
    internal class Mechanism : Detail, IMovable
    {
        public const int MaxFreedomDegrees = 6;
        public const int MinFreedomDegrees = 1;
        
        private readonly int _freedomDegrees;

        public Mechanism(string name, double size, double weight, int freedomDegrees)
            : base(name, size, weight)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            if (size <= 0 || weight <= 0
                || freedomDegrees < MinFreedomDegrees
                || freedomDegrees > MaxFreedomDegrees)
                throw new ArgumentOutOfRangeException();

            _freedomDegrees = freedomDegrees;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"As Mechanism: Degrees of freedom: {_freedomDegrees}.");
        }

        public void MoveOnAxisX(float distance)
        {
            if (distance == 0)
                return;
            
            Console.WriteLine($"Mechanism \'{Name}\' has been moved on {distance}m along X axis.");
        }

        public void MoveOnAxisY(float distance)
        {
            if (distance == 0)
                return;
            
            Console.WriteLine($"Mechanism \'{Name}\' has been moved on {distance}m along Y axis.");
        }

        public void MoveOnAxisZ(float distance)
        {
            if (distance == 0)
                return;
            
            Console.WriteLine($"Mechanism \'{Name}\' has been moved on {distance}m along Z axis.");
        }
    }
}