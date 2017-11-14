using System;
using System.Collections.Generic;
using System.IO;

namespace LW01
{
    public class MainModule
    {
        // Reads a truth table from specified file
        public static void ReadTruthTable(out List<List<byte>> truthTable)
        {
            truthTable = new List<List<byte>>();
            StreamReader inputFile = new StreamReader("lw-01-input");

            while (!inputFile.EndOfStream) {
                string[] buffer = inputFile.ReadLine().Split();
                var collection = new List<byte>();
                foreach (var t in buffer)
                    collection.Add(byte.Parse(t));
                truthTable.Add(collection);
            }
        }

        public static void Display<T>(List<List<T>> matrix)
        {
            foreach (var row in matrix) {
                foreach (var element in row)
                    Console.Write(element + " ");
                Console.WriteLine();
            }
        }

        // Generates the DNF and CNF formulae and sends them to specified files
        public static void GenerateFormulae(List<List<byte>> table)
        {
            StreamWriter fileDNF = new StreamWriter("lw-01-dnf");
            StreamWriter fileCNF = new StreamWriter("lw-01-cnf");

            string strDnf = null;
            string strCnf = null;

            char[] vars = { 'A', 'B', 'C' };

            int lastElement = table[List.Count - 1];

            foreach (var row in table) {
                if (row[row.Count - 1] == 1) {
                    if (!string.IsNullOrEmpty(strDnf))
                        strDnf += " V ";

                    for (int i = 0; i < (row.Count - 1); ++i) {
                        if (i == 0)
                            strDnf += "(";

                        string piece = row[i] == 0 ? "-X" : "X";
                        strDnf += piece;

                        if (i < row.Count - 2)
                            strDnf += " ^ ";
                        else if (i == row.Count - 2)
                            strDnf += ")";
                    }

                    // strDnf += (row[0] == 0 ? "(-A" : "(A");
                    // strDnf += " ^ ";
                    // strDnf += (row[1] == 0 ? "-B" : "B");
                    // strDnf += " ^ ";
                    // strDnf += (row[2] == 0 ? "-C)" : "C)");
                }
                else {
                    if (!string.IsNullOrEmpty(strCnf))
                        strCnf += " ^ ";

                    strCnf += (row[0] == 0 ? "(A" : "(-A");
                    strCnf += " V ";
                    strCnf += (row[1] == 0 ? "B" : "-B");
                    strCnf += " V ";
                    strCnf += (row[2] == 0 ? "C)" : "-C)");
                }
            } // foreach (var row in truthTable)

            fileDNF.WriteLine(string.IsNullOrEmpty(strDnf) ? "0" : strDnf);
            fileCNF.WriteLine(string.IsNullOrEmpty(strCnf) ? "1" : strCnf);

            fileDNF.Close();
            fileCNF.Close();
        }

        /// <summary>
        ///   The main entry point for the application
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            List<List<byte>> truthTable;
            ReadTruthTable(out truthTable);

            // Display(truthTable);

            GenerateFormulae(truthTable);
        }
    } // public class MainModule
} // namespace LW01
