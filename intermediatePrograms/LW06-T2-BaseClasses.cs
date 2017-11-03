using System;

namespace LW06T2
{
    public class AgeException : Exception
    {
        public AgeException(string message) : base(message) {}
    }

    // B1 class implementation
    public class Person
    {
        protected static Random rand = new Random();
        private string name;
        private int age;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public Person(string name)
        {
            this.name = name;
            this.age = rand.Next(18, 70);
            // Console.WriteLine("> new Person. 'name': {0}, 'age': {1} (randomized)", name, this.age);
        }
        public Person(string name, int age)
        {
            if (age < 0)
                throw new AgeException(string.Format("EXCEPTION: Invalid 'age' parameter. The value should be positive number."));
            else {
                this.name = name;
                this.age = age;
                // Console.WriteLine("> new Person. 'name': {0}, 'age': {1}", name, age);
            }
        }

        public virtual void Show()
        {
            Console.WriteLine("{0} as a Person:", name);
            Console.WriteLine(".. Age: {0}", age);
        }
    } // public class Person

    // B2 class implementation (as an interface)
    public interface ISocietyMember
    {
        void Show();
    } // public interface ISocietyMember
} // namespace LW06T2
