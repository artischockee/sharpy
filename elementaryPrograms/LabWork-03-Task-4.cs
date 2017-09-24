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

        static void WriteNumber(FileStream destination, int number)
        {
            using (var file = new StreamWriter(destination))
            {
                file.WriteLine(number);
            }            
        }

        static int ReadNumber(FileStream source)
        {
            int sourceNumber;
            using (var file = new StreamReader(source))
            {
                string buffer = file.ReadLine();
                Int32.TryParse(buffer, out sourceNumber);
            }
            return sourceNumber;
        }

        static void Operate(FileStream input, FileStream aux, FileStream output)
        {
            string[] buffer;
            using (var init = new StreamReader(input))
            {
                buffer = GetSeparatedNumbers(init);
            }

            bool switcher = false;
            using (var dest = new StreamWriter(output))
            {
                foreach (var num in buffer) {
                    int temp;
                    Int32.TryParse(num, out temp);

                    if (temp > 0) {
                        if (switcher) {
                            WriteNumber(aux, temp);
                        } else {
                            dest.Write(temp + ' ');
                            switcher = !switcher;
                        }
                    } else {
                        if (switcher) {
                            dest.Write(temp + ' ');
                            switcher = !switcher;
                        } else {
                            WriteNumber(aux, temp);
                        }
                    }

                    if (switcher && aux.Length > 0) {
                        int fromAux = ReadNumber(aux);
                        dest.Write(fromAux + ' ');
                        switcher = !switcher;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            const string file_f = "f-task-4";
            const string file_h = "h-task-4";
            const string file_g = "g-task-4";

            FileStream initFile = new FileStream(file_f, FileMode.Open, FileAccess.Read);
            FileStream auxFile = new FileStream(file_h, FileMode.Create, FileAccess.ReadWrite);
            FileStream destFile = new FileStream(file_g, FileMode.Create, FileAccess.Write);

            Operate(initFile, auxFile, destFile);
        }
    }
}
