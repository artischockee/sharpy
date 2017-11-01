using System;

namespace LW06T1
{
    public class Pet
    {
        protected static Random rand = new Random();

        // Class members
        //
        private string name;
        private char sex;
        private double weight;
        private double height;

        // Getters/Setters
        //
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public char Sex
        {
            get { return sex; }
        }
        public double Weight
        {
            get { return weight; }
            set { weight = value > 0 ? value : 0; }
        }
        public double Height
        {
            get { return height; }
            set { height = value > 0 ? value : 0; }
        }

        // Constructor(s)
        //
        public Pet(string name, char sex, double weight, double height)
        {
            this.name = name;
            if (sex != 'm' && sex != 'f') {
                string errorInfo = "Additional info | Name: " + name + " | Tried sex declaration: " + sex;
                throw new InvalidSexException(string.Format("An invalid sex definition has been declared. Only 'm' (male) or 'f' (female) are allowed to use. \n" + errorInfo));
            }
            else
                this.sex = sex;
            this.weight = weight;
            this.height = height;
        }

        // Method(s)
        //
        public virtual void Action()
        {
            // smth here..
        }
    } // class Pet

    public class Cat : Pet
    {
        // Class member(s)
        //
        private const int lives = 9;

        // Constructor
        //
        public Cat(string name, char sex, double weight, double height) : base(name, sex, weight, height) {}

        // Class methods
        //
        public override void Action()
        {
            CatchMice();
        }

        public void CatchMice()
        {
            Console.WriteLine(Name + " is catching mice in the flat..");
            string result = null, miceNumeral = "mice";
            int miceCount = Pet.rand.Next(100);
            if (miceCount == 0)
                result = "There is nothing to say.";
            else if (miceCount == 1)
                miceNumeral = "mouse";
            else if (miceCount < 20)
                result = "Not bad, actually.";
            else if (miceCount < 50)
                result = "Pretty well, you know.";
            else if (miceCount < 80)
                result = "Hah, very good result!";
            else
                result = "Oh my god, this is incredible!";
            Console.WriteLine("{0} {1} has catched {2} {3} in the flat.", result, Name, miceCount, miceNumeral);
        }
    } // public class Cat : Pet

    public class Dog : Pet
    {
        // Constructor
        //
        public Dog(string name, char sex, double weight, double height) : base(name, sex, weight, height) {}

        // Class methods
        //
        public override void Action()
        {
            Guard();
        }

        public void Guard()
        {
            Console.WriteLine(Name + " is guarding the perimeter..");
            string[] famousGuests = { "Steve Jobs", "Mark Zuckerberg", "Elon Musk", "Bill Gates", "Ray Kurzweil", "John Lasseter", "Jony Ive", "Alexander Shelupanov" };

            string guest = famousGuests[rand.Next(famousGuests.Length)];
            if (guest == "Bill Gates")
                DriveAwayTheGuest(guest);
            else
                Console.WriteLine(Name + " has met no threat. The house was visited by {0}.", guest);
        }

        private void DriveAwayTheGuest(string victim)
        {
            Console.WriteLine("**Growl sounds** - looks like {0} was trying to visit our house.", victim);
        }
    } // public class Dog : Pet

    public class Parrot : Pet
    {
        // Constructor
        //
        public Parrot(string name, char sex, double weight, double height) : base(name, sex, weight, height) {}

        // Class methods
        //
        public override void Action()
        {
            Chatter();
        }

        public void Chatter()
        {
            string sex = null;
            switch (Sex) {
                case 'm':
                    sex = "male"; break;
                case 'f':
                    sex = "female"; break;
            }

            Console.WriteLine("Hello, Mr. or Mrs.! My name is {0}, I am a parrot! I am a {1}, also my weight is {2} kg and my height is {3} cm!", Name, sex, Weight, Height);
        }
    } // public class Parrot : Pet
}
