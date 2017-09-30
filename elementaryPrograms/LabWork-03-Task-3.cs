using System;
using System.Collections.Generic;
using System.IO;

namespace LabWork03
{
    public static class IList
    {
        public static IList<T> Swap<T>(this IList<T> list, int indexA, int indexB)
        {
            T tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
            return list;
        }
    }

    class Task3
    {
        static void Reverse(ref List<string> sentences)
        {
            for (int i = 0, j = 0; i < sentences.Count; ++i)
                if (sentences[i][1] == ' ') {
                    sentences.Swap(i, j);
                    ++j;
                }
        }

        static void Operate(StreamReader inputFile)
        {
            string buffer = inputFile.ReadToEnd();
            string[] bufferWords = buffer.Split();

            List<string> sentences = new List<string>();
            List<string> sepWords = new List<string>();

            // build up sentences from separated words
            foreach (var word in bufferWords) {
                sepWords.Add(word);
                if (word.EndsWith(".") || word.EndsWith("?") || word.EndsWith("!") || word.EndsWith("...")) {
                    string temp = String.Join(" ", sepWords.ToArray());
                    sepWords.Clear();
                    sentences.Add(temp + ' ');
                }
            }

            Reverse(ref sentences);
            sentences.ForEach(Console.Write); Console.WriteLine();
        }

        static void Main(string[] args)
        {
            try {
                using (StreamReader reader = new StreamReader("input-task-3"))
                {
                    Operate(reader);
                }
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}
