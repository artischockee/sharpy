using System;
using System.Collections.Generic;

namespace Events
{
    internal delegate void InvalidCastEventHandler();
    
    internal delegate void ProdDisplay();
    internal delegate void ProdMoveAction(float distance);
    internal delegate double ProdSelling();
    
    internal static class Program
    {
        public static void Handler()
        {
            Console.WriteLine("Seems like something went wrong.");
        }

        private static void ThirdTask()
        {
            Console.WriteLine("Type amount of creatable details:");
            
            try
            {
                int amount;
                if (!int.TryParse(Console.ReadLine(), out amount))
                    throw new InvalidCastEvent("This is a stupid example of the exception.");

                var detailsList = new List<Detail>(amount);
            }
            catch (InvalidCastEvent e)
            {
                Console.WriteLine(e.Message);
                e.Activate();
            }
        }
        
        private static void SecondTask()
        {
            var spaceCannon = new Product("Space Cannon", "Truffade", 15.45, 30.00);
            const float distance = 15F; 

            ProdDisplay display = spaceCannon.DisplayInfo;
            ProdMoveAction movingX = spaceCannon.MoveOnAxisX;
            ProdMoveAction movingY = spaceCannon.MoveOnAxisY;
            ProdMoveAction movingZ = spaceCannon.MoveOnAxisZ;
            var movingAllAxes = movingX + movingY + movingZ;
            ProdSelling selling = spaceCannon.Sell;

            display();
            movingAllAxes(distance);
            var receivedMoney = selling();
            Console.WriteLine($"You have received ${receivedMoney} for selling {spaceCannon.Name}.");
            Console.ReadKey();
        }
        
        private static void FirstTask()
        {
            var list = new List<Detail>
            {
                new Detail("Detail01", 14.00, 20.015),
                new Mechanism("Mechanism01", 9.01, 0.0012, 3),
                new Node("Node01", 10, 11.59, 5.5F),
                new Product("Product01", "Toshiba", 29.22, 11.708)
            };

            foreach (var detail in list)
                detail.DisplayInfo();
        }
        
        public static void Main(string[] args)
        {
            FirstTask();
            SecondTask();
            ThirdTask();
        }
    }
}