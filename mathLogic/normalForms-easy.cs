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
            using (StreamReader inputFile = new StreamReader("input-easy"))
            {
                while (!inputFile.EndOfStream) {
                    string[] buffer = inputFile.ReadLine().Split();
                    var collection = new List<byte>();
                    foreach (var t in buffer)
                        collection.Add(byte.Parse(t));
                    truthTable.Add(collection.ToArray());
                }
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

        private static string AssembleFormulaePiece
        (
            byte[] currRow,
            char[] varNames,
            char operationSign
        )
        {
            string formulaePiece = null; // a result string
            int lastIndex = currRow.Length - 2;

            byte comparer; // this variable is used in the assembly of a var definition
            switch (operationSign) {
                case 'V':
                    comparer = 1; break;
                case '^':
                    comparer = 0; break;
                default:
                    throw new ArgumentException();
            }

            for (int i = 0; i < (lastIndex + 1); ++i) {
                if (i == 0)
                    formulaePiece += "(";

                string varDef = currRow[i] == comparer ? String.Concat('-', varNames[i]) : varNames[i].ToString();

                formulaePiece += varDef;

                if (i < lastIndex)
                    formulaePiece = formulaePiece + " " + operationSign + " ";
                else if (i == lastIndex)
                    formulaePiece += ")";
            }

            return formulaePiece;
        } // private static string AssembleFormulaePiece(3 args)

        // Generates the DNF and CNF formulae and sends them to specified files
        public static void GenerateFormulae(List<byte[]> table)
        {
            StreamWriter fileDNF = new StreamWriter("LW-01-DNF");
            StreamWriter fileCNF = new StreamWriter("LW-01-CNF");

            string strDnf = null;
            string strCnf = null;
            char[] vars = { 'A', 'B', 'C' };

            int lastIndex = table[0].Length - 1; // used only in foreach
            foreach (var row in table) {
                if (row[lastIndex] == 1) {
                    if (!string.IsNullOrEmpty(strDnf))
                        strDnf += " V ";
                    strDnf += AssembleFormulaePiece(row, vars, '^');
                }
                else {
                    if (!string.IsNullOrEmpty(strCnf))
                        strCnf += " ^ ";
                    strCnf += AssembleFormulaePiece(row, vars, 'V');
                }
            }

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
            GenerateFormulae(truthTable);
        }
    } // public class MainModule
} // namespace LW01
