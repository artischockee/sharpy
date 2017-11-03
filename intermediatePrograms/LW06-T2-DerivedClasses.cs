using System;

namespace LW06T2
{
    // D1 class implementation
    public class Worker : Person
    {
        private string placeOfWork;

        public string PlaceOfWork
        {
            get { return placeOfWork; }
            set { placeOfWork = value; }
        }

        public Worker(string name, string placeOfWork) : base(name)
        {
            this.placeOfWork = placeOfWork;
            // Console.WriteLine("> new Worker (Person). 'placeOfWork': {0}", placeOfWork);
        }
        public Worker(string name, int age, string placeOfWork)
        : base(name, age)
        {
            this.placeOfWork = placeOfWork;
            // Console.WriteLine("> new Worker (Person). 'placeOfWork': {0}", placeOfWork);
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine("{0} as a Worker:", base.Name);
            Console.WriteLine(".. Place of Work: {0}", placeOfWork);
        }
    } // public class Worker : Person

    // D2 class implementation
    public class DepartmentMember : Worker, ISocietyMember
    {
        private string department;

        public string Department
        {
            get { return department; }
            set { department = value; }
        }

        public DepartmentMember(string name, string placeOfWork, string department) : base(name, placeOfWork)
        {
            this.department = department;
            // Console.WriteLine("> new DeptMember (Worker). 'department': {0}", department);
        }
        public DepartmentMember(string name, int age, string placeOfWork, string department) : base(name, age, placeOfWork)
        {
            this.department = department;
            // Console.WriteLine("> new DeptMember (Worker). 'department': {0}", department);
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine("{0} as a DepartmentMember:", base.Name);
            Console.WriteLine(".. Department: {0}", department);
        }
    } // public class DepartmentMember : Worker

    // D3 class implementation
    public class DepartmentHead : DepartmentMember
    {
        private int yearsOfService;
        private int numOfSubordinates;

        public int YearsOfService
        {
            get { return yearsOfService; }
            set { yearsOfService = value; }
        }
        public int NumOfSubordinates
        {
            get { return numOfSubordinates; }
            set { numOfSubordinates = value; }
        }

        public DepartmentHead(string name, string placeOfWork, string department, int yearsOfService, int numberOfSubordinates) : base(name, placeOfWork, department)
        {
            this.yearsOfService = yearsOfService;
            this.numOfSubordinates = numberOfSubordinates;
            // Console.WriteLine("> new DeptHead (DeptMem). 'yearsOfService': {0}, 'numOfSubordinates': {1}", yearsOfService, numOfSubordinates);
        }
        public DepartmentHead(string name, int age, string placeOfWork, string department, int yearsOfService, int numberOfSubordinates) : base(name, age, placeOfWork, department)
        {
            this.yearsOfService = yearsOfService;
            this.numOfSubordinates = numberOfSubordinates;
            // Console.WriteLine("> new DeptHead (DeptMem). 'yearsOfService': {0}, 'numOfSubordinates': {1}", yearsOfService, numOfSubordinates);
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine("{0} as a DepartmentHead:", base.Name);
            Console.WriteLine(".. Years of Service: {0}", yearsOfService);
            Console.WriteLine(".. Num of Subordinates: {0}", numOfSubordinates);
        }
    } // public class DepartmentHead : DepartmentMember
} // namespace LW06T2
