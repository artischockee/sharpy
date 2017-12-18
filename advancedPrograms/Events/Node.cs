using System;

namespace Events
{
    internal class Node : Detail, IMovable
    {
        private readonly float _warrantyServiceLife;
        
        public Node(string name, double size, double weight, float warrantyServiceLife)
            : base(name, size, weight)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            if (size <= 0 || weight <= 0
                || warrantyServiceLife <= 0)
                throw new ArgumentOutOfRangeException();

            _warrantyServiceLife = warrantyServiceLife;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"As Node: Warranty service life: {_warrantyServiceLife}.");
        }

        public void MoveOnAxisX(float distance)
        {
            if (distance == 0)
                return;
            
            Console.WriteLine($"Node \'{Name}\' has been moved on {distance}m along X axis.");
        }

        public void MoveOnAxisY(float distance)
        {
            if (distance == 0)
                return;
            
            Console.WriteLine($"Node \'{Name}\' has been moved on {distance}m along Y axis.");
        }

        public void MoveOnAxisZ(float distance)
        {
            if (distance == 0)
                return;
            
            Console.WriteLine($"Node \'{Name}\' has been moved on {distance}m along Z axis.");
        }
    }
}