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
        // Class members
        //
        protected static Random rand = new Random();
        private string name;
        private int age;

        // Getters / Setters
        //
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

        // Constructors
        //
        public Person(string name)
        {
            this.name = name;
            this.age = rand.Next(18, 70);
            Console.WriteLine("> new Person. 'name': {0}, 'age': {1} (randomized)", name, this.age);
        }
        public Person(string name, int age)
        {
            if (age < 0)
                throw new AgeException(string.Format("EXCEPTION: Invalid 'age' parameter. The value should be positive number."));
            else {
                this.name = name;
                this.age = age;
                Console.WriteLine("> new Person. 'name': {0}, 'age': {1}", name, age);
            }
        }

        // Methods
        //
        public virtual void Show()
        {
            Console.WriteLine("{0} as a Person:", name);
            Console.WriteLine(".. Age: {0}", age);
        }
    } // public class Person

    public class B2
    {
        // Class members
        //
        private int c;
        private int d;
        private string info;

        // Getters / Setters
        //
        public int C
        {
            get { return d; }
            set { c = value; }
        }
        public int D
        {
            get { return d; }
            set { d = value; }
        }
        public string Info
        {
            get { return info; }
            set { info = value; }
        }

        // Constructors
        //
        public B2(int c, int d, string info)
        {
            this.c = c;
            this.d = d;
            this.info = info;
            Console.WriteLine("> B2: A new object has been created.");
            Console.WriteLine("      c = {0}, d = {1}, info = {2}", c, d, info);
        }
        public B2()
        {
            this.c = this.d = 0;
            this.info = "null string";
            Console.WriteLine("> B2: A new object has been created (default constructor).");
            Console.WriteLine("      c = {0}, d = {1}, info = {2}", c, d, info);
        }

        // Methods
        //
        public virtual void Show()
        {
            Console.WriteLine("> B2 object: c = {0}, d = {1}, info = {2}", c, d, info);
        }

    } // public class B2
} // namespace LW06T2
