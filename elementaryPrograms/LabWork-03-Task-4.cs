using System;
using System.Collections.Generic;
using System.IO;

namespace LabWork03
{
    class Task4
    {
        static string[] GetSeparatedNumbers(StreamReader file)
        {
            string buffer = file.ReadToEnd();
            string[] bufNumbers = buffer.Split();
            return bufNumbers;
        }

        static List<int> ParseIntsFromString(ref string[] init)
        {
            var auxiliary = new List<int>();
            foreach (var num in init) {
                int parsedNum;
                Int32.TryParse(num, out parsedNum);
                auxiliary.Add(parsedNum);
            }
            return auxiliary;
        }

        static void Operate(FileStream input, FileStream output)
        {
            var numArray = new List<int>();
            using (var init = new StreamReader(input)) {
                string[] buffer = GetSeparatedNumbers(init);
                numArray = ParseIntsFromString(ref buffer);
            }

            var aux = new List<int>();
            bool signSwitcher = false;

            using (var dest = new StreamWriter(output))
            {
                foreach (var num in numArray) {
                    if (num > 0) {
                        if (signSwitcher)
                            aux.Add(num);
                        else {
                            dest.Write(num + " ");
                            signSwitcher = !signSwitcher;
                        }
                    } else {
                        if (signSwitcher) {
                            dest.Write(num + " ");
                            signSwitcher = !signSwitcher;
                        } else
                            aux.Add(num);
                    }

                    if (aux.Count > 0 &&
                        ((signSwitcher && aux[0] < 0) ||
                         (!signSwitcher && aux[0] > 0)))
                    {
                        dest.Write(aux[0] + " "); aux.RemoveAt(0);
                        signSwitcher = !signSwitcher;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            const string file_f = "f-task-4";
            const string file_g = "g-task-4";

            FileStream initFile = new FileStream(file_f, FileMode.Open, FileAccess.Read);
            FileStream destFile = new FileStream(file_g, FileMode.Create, FileAccess.Write);

            Operate(initFile, destFile);
        }
    }
}
