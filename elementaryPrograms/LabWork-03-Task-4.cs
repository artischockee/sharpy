using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        static void Operate(FileStream input, FileStream output)
        {
            string[] buffer;
            using (var init = new StreamReader(input)) {
                buffer = GetSeparatedNumbers(init);
            }

            List<int> aux = new List<int>();
            bool signSwitcher = false;

            using (var dest = new StreamWriter(output))
            {
                foreach (var num in buffer) {
                    int parsedNum;
                    Int32.TryParse(num, out parsedNum);

                    if (parsedNum > 0) {
                        if (signSwitcher)
                            aux.Add(parsedNum);
                        else {
                            dest.Write(parsedNum + " ");
                            signSwitcher = !signSwitcher;
                        }
                    } else {
                        if (signSwitcher) {
                            dest.Write(parsedNum + " ");
                            signSwitcher = !signSwitcher;
                        } else
                            aux.Add(parsedNum);
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

            Process.Start("/bin/bash",
            "-c \"echo \'File F:\' && cat f-task-4 && echo\"");
            Process.Start("/bin/bash",
            "-c \"echo \'File G:\' && cat g-task-4 && echo\"");
        }
    }
}
