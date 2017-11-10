using System;
using System.Linq;

namespace LW07T1
{
    public class MainModule
    {
        /// <summary>
        ///   The main entry point for the application
        /// </summary>
        [STAThread]

        public static void ArrayTesting()
        {
            var array = new Array<int>();
            array.Add(1,2,3,4,5,6,7,8,9,10);

            array.Display();
            Console.WriteLine("Количество эл-тов в массиве array: {0}", array.Length);

            Console.Write("Введи число для добавления его в массив: ");
            int input = int.Parse(Console.ReadLine());
            array.Add(input);

            Console.WriteLine("Результат:");
            array.Display();
            Console.WriteLine(); // ending of this method
        }

        public static void StackTesting()
        {
            var stack = new Stack<string>();
            string[] months = { "january", "february", "march", "april", "may", "june", "july", "august", "september", "october", "november", "december" };

            var selectedMonth =
                from month in months
                where month.Length >= 4 && month.Length <= 6
                select month;

            foreach (var month in selectedMonth)
                stack.Push(month);
            stack.Display();
            Console.WriteLine("Количество эл-тов в стэке stack: {0}", stack.Count);

            Console.Write("Введи строку для добавления её в стэк: ");
            string input = Console.ReadLine();
            stack.Push(input);

            Console.WriteLine("Результат:");
            stack.Display();
            Console.WriteLine(); // ending of this method
        }

        public static void QueueTesting()
        {
            var queue = new Queue<string>();
            string[] people = { "john", "paola", "bruce", "eugene", "terry", "george", "stephanie" };

            foreach (var person in people)
                queue.Enqueue(person);
            queue.Display();
            Console.WriteLine("Количество эл-тов в очереди queue: {0}", queue.Count);

            Console.Write("Введи имя человека для добавления его в очередь: ");
            string newPerson = Console.ReadLine();
            queue.Enqueue(newPerson);

            Console.WriteLine("Результат:");
            queue.Display();
            Console.WriteLine(); // ending of this method
        }

        public static void Main(string[] args)
        {
            try {
                ArrayTesting();
                StackTesting();
                QueueTesting();
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }
    } // public class MainModule
} // namespace LW07T1
