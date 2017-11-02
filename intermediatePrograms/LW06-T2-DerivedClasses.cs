using System;

namespace LW06T2
{
    // D1 class implementation
    public class Worker : Person
    {
        // Class members
        //
        private string placeOfWork;

        // Getters / Setters
        //
        public string PlaceOfWork
        {
            get { return placeOfWork; }
            set { placeOfWork = value; }
        }

        // Constructors
        //
        public Worker(string name, string placeOfWork) : base(name)
        {
            this.placeOfWork = placeOfWork;
            Console.WriteLine("> new Worker (Person). 'placeOfWork': {0}", placeOfWork);
        }
        public Worker(string name, int age, string plOfWork) : base(name, age)
        {
            this.placeOfWork = plOfWork;
            Console.WriteLine("> new Worker (Person). 'placeOfWork': {0}", placeOfWork);
        }

        // Methods
        //
        public override void Show()
        {
            base.Show();
            Console.WriteLine("{0} as a Worker:", base.Name);
            Console.WriteLine(".. Place of Work: {0}", placeOfWork);
        }
    } // public class Worker : Person

    // D2 class implementation
    public class DepartmentMember : Worker /* multi-inheritance should be here */
    {
        // Class members
        //
        private string department;

        // Getters / Setters
        //
        public string Department
        {
            get { return department; }
            set { department = value; }
        }

        // Constructors
        //
        public DepartmentMember(string name, string placeOfWork, string department) : base(name, placeOfWork)
        {
            this.department = department;
            Console.WriteLine("> new DepartmentMember (Worker). 'department': {0}", department);
        }
        public DepartmentMember(string name, int age, string placeOfWork, string department) : base(name, age, placeOfWork)
        {
            this.department = department;
            Console.WriteLine("> new DepartmentMember (Worker). 'department': {0}", department);
        }

        // Methods
        //
        public override void Show()
        {
            base.Show();
            Console.WriteLine("{0} as a DepartmentMember:", base.Name);
            Console.WriteLine(".. Department: {0}", department);
        }
    } // public class DepartmentMember : Worker
} // namespace LW06T2
