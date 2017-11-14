using System;
using System.Collections.Generic;
using System.IO;

namespace LW01
{
    public class MainModule
    {
        // Reads a truth table from specified file
        public static void ReadTruthTable(out List<byte[]> truthTable)
        {
            truthTable = new List<byte[]>();
            StreamReader inputFile = new StreamReader("lw-01-input");

            while (!inputFile.EndOfStream) {
                string[] buffer = inputFile.ReadLine().Split();
                var collection = new List<byte>();
                foreach (var t in buffer)
                    collection.Add(byte.Parse(t));
                truthTable.Add(collection.ToArray());
            }
        }

        public static void Display<T>(List<T[]> matrix)
        {
            foreach (var row in matrix) {
                foreach (var element in row)
                    Console.Write(element + " ");
                Console.WriteLine();
            }
        }

        // private static string AssembleFormulaePiece
        // (
        //     ref byte[] currRow,
        //     ref
        // )

        // Generates the DNF and CNF formulae and sends them to specified files
        public static void GenerateFormulae(List<byte[]> table)
        {
            StreamWriter fileDNF = new StreamWriter("lw-01-dnf");
            StreamWriter fileCNF = new StreamWriter("lw-01-cnf");

            string strDnf = null;
            string strCnf = null;

            char[] vars = { 'A', 'B', 'C' };

            int lastElement = table[0].Length - 1;

            foreach (var row in table) {
                if (row[lastElement] == 1) {
                    // </ a new method will be here />

                    if (!string.IsNullOrEmpty(strDnf))
                        strDnf += " V ";

                    for (int i = 0; i < lastElement; ++i) {
                        if (i == 0)
                            strDnf += "(";

                        string piece = row[i] == 0 ? String.Concat('-', vars[i]) : vars[i].ToString(); // a difference'll be here
                        strDnf += piece;

                        if (i < lastElement - 1)
                            strDnf += " ^ ";
                        else if (i == lastElement - 1)
                            strDnf += ")";
                    }
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
            List<byte[]> truthTable;
            ReadTruthTable(out truthTable);

            // Display(truthTable);

            GenerateFormulae(truthTable);
        }
    } // public class MainModule
} // namespace LW01
