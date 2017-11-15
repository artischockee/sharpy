using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.IO;

namespace LW01
{
    public class MainModule
    {
        // Formats a specified string that represents a binary number,
        // Adding zeroes in front of it
        private static string FormatToBinary(string initial, int neededLength)
        {
            int zeroesAmount = neededLength - initial.Length;
            string zeroes = new string('0', zeroesAmount);

            return string.Concat(zeroes, initial);
        }

        // Forms the specified truth table
        private static void FormTruthTable(
            ref List<byte[]> table, int argsAmount, int[] truthPos
        )
        {
            int numOfLines = (int)Math.Pow(2, argsAmount);
            int tPosUpperBound = truthPos.Length;

            for (int i = 0, j = 0; i < numOfLines; ++i) {
                string result = Convert.ToString(i, 2);
                if (result.Length < argsAmount)
                    result = FormatToBinary(result, argsAmount);

                var line = new List<byte>();
                foreach (char number in result) {
                    byte properValue = (byte)char.GetNumericValue(number);
                    line.Add(properValue);
                }

                if (j < tPosUpperBound && truthPos[j] == i) {
                    line.Add(1);
                    ++j;
                } else
                    line.Add(0);

                table.Add(line.ToArray());
            }
        }

        // Reads truth table parameters from specified file,
        // Then forms specified truth table with gathered parameters
        public static void ReadTableParameters(out List<byte[]> truthTable)
        {
            truthTable = new List<byte[]>();

            int N, M; // N is amount of variables, M is amount of truth lines
            int[] truthPositions; // Contain positions indexes of truth lines

            // Parses values from the file and put them into the previous int's
            using (var inputFile = new StreamReader("LW-01-Input-Enhanced"))
            {
                string[] buffer;

                buffer = inputFile.ReadLine().Split();
                N = int.Parse(buffer[0]);
                M = int.Parse(buffer[1]);

                truthPositions = new int[M];

                // Does the action if there is second line in the input file
                if (M > 0) {
                    buffer = inputFile.ReadLine().Split();
                    for (int i = 0; i < M; ++i)
                        truthPositions[i] = int.Parse(buffer[i]);
                }

                if (!inputFile.EndOfStream)
                    throw new EndOfStreamException(string.Format("File ending not found. One should contain 2 lines with integers."));
            }

            FormTruthTable(ref truthTable, N, truthPositions);
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
            string[] varNames,
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
            StreamWriter fileDNF = new StreamWriter("LW-01-DNF-Enh");
            StreamWriter fileCNF = new StreamWriter("LW-01-CNF-Enh");

            string strDnf = null;
            string strCnf = null;
            char basicChar = 'A';
            int argsAmount = table[0].Length - 1;
            string[] vars = new string[argsAmount];

            for (int i = 0; i < argsAmount; ++i)
                vars[i] = string.Concat(basicChar, (i + 1));

            int lastIndex = argsAmount; // used only in foreach
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
        } // public static void GenerateFormulae(1 arg)

        /// <summary>
        ///   The main entry point for the application
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            List<byte[]> truthTable;
            try {
                ReadTableParameters(out truthTable);
                GenerateFormulae(truthTable);
                // Display(truthTable);
            }
            catch (EndOfStreamException e) {
                Console.WriteLine(e.Message);
            }
            catch (Exception e) {
                Console.WriteLine("An undefined exception has been caught:");
                Console.WriteLine(e.Message);
            }
        }
    } // public class MainModule
} // namespace LW01
