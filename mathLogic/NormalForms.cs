using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace mathLogic
{
    internal class TruthTable
    {
        private readonly List<byte[]> _truthTable;
        private int _argumentsAmount;
        private int[] _truthPositions;

        public TruthTable()
        {
            _truthTable = new List<byte[]>();
            _argumentsAmount = 0;
            _truthPositions = null;
        }

        public TruthTable(int argumentsAmount, int[] truthPositions = null)
        {
            if (argumentsAmount <= 0)
                throw new ArgumentOutOfRangeException();
            if (truthPositions != null && truthPositions.Any(x => x <= 0))
                throw new ArgumentOutOfRangeException();

            _truthTable = new List<byte[]>();
            _argumentsAmount = argumentsAmount;
            _truthPositions = truthPositions;
        }

        public void Display()
        {
            foreach (var row in _truthTable) {
                foreach (var element in row)
                    Console.Write(element + " ");
                Console.WriteLine();
            }
        }

        public void FormTruthTable(int argsAmount = 0, int[] truthPos = null)
        {
            if (argsAmount == 0 && _argumentsAmount != 0)
                argsAmount = _argumentsAmount;
            else
                throw new ArgumentNullException($"Number of arguments cannot be {0} or less.");
            if (truthPos == null && _truthPositions != null)
                truthPos = _truthPositions;

            var numOfLines = (int)Math.Pow(2, argsAmount);
            var tPosUpperBound = truthPos?.Length;
            var neededRowLength = argsAmount; // for better semantics

            for (int i = 0, j = 0; i < numOfLines; ++i) {
                var binaryNum = Convert.ToString(i, 2);
                if (binaryNum.Length < neededRowLength)
                    binaryNum = binaryNum.PadLeft(neededRowLength, '0');

                // Splits the result string into separated digits
                var line = binaryNum.Select(digit => (byte) char.GetNumericValue(digit)).ToList();

                if (j < tPosUpperBound && truthPos[j] == i) {
                    line.Add(1);
                    ++j;
                } else
                    line.Add(0);

                _truthTable.Add(line.ToArray());
            }
        }

        // Reads truth table parameters from specified file,
        // Then forms specified truth table with gathered parameters
        public void ReadTableParameters(StreamReader inputFile)
        {
            if (inputFile.EndOfStream)
                throw new EndOfStreamException("Input file is empty.");

            int n; // amount of variables
            int m; // amount of truth lines

            var buffer = inputFile.ReadLine()?.Split();
            if (buffer == null)
                throw new Exception("Input file buffer was empty (check the input file)");

            n = int.Parse(buffer[0]);
            m = int.Parse(buffer[1]);

            var truthPositions = new int[m];

            // Does the action if there is second line in the input file
            if (m > 0)
            {
                buffer = inputFile.ReadLine()?.Split();
                if (buffer == null)
                    throw new Exception("Input file buffer was empty (check the input file)");

                for (var i = 0; i < m; ++i)
                    truthPositions[i] = int.Parse(buffer[i]);

                _truthPositions = truthPositions;
            }

            if (!inputFile.EndOfStream)
                throw new EndOfStreamException("File ending not found. One should contain 2 lines with integers.");

            _argumentsAmount = n;
        }

        private static string AssembleFormulaePiece(
            IReadOnlyList<byte> currRow,
            IReadOnlyList<string> varNames,
            char operationSign
        )
        {
            string formulaePiece = null; // a result string
            var lastIndex = currRow.Count - 2;

            byte comparer; // used in the assembly of a var definition
            switch (operationSign) {
                case 'V':
                    comparer = 1; break;
                case '^':
                    comparer = 0; break;
                default:
                    throw new ArgumentException();
            }

            for (var i = 0; i < lastIndex + 1; ++i) {
                if (i == 0)
                    formulaePiece += "(";

                var varDef = currRow[i] == comparer ? string.Concat('-', varNames[i]) : varNames[i];

                formulaePiece += varDef;

                if (i < lastIndex)
                    formulaePiece = formulaePiece + " " + operationSign + " ";
                else if (i == lastIndex)
                    formulaePiece += ")";
            }

            return formulaePiece;
        }

        // Generates the DNF and CNF formulae and sends them to specified files
        public void GenerateFormulae(StreamWriter fileDnf, StreamWriter fileCnf)
        {
            string strDnf = null;
            string strCnf = null;
            const char basicChar = 'A';
            var argsAmount = _truthTable[0].Length - 1;
            var vars = new string[argsAmount];

            for (var i = 0; i < argsAmount; ++i)
                vars[i] = string.Concat(basicChar, i + 1);

            var lastIndex = argsAmount; // used only in foreach
            foreach (var row in _truthTable) {
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

            fileDnf.WriteLine(string.IsNullOrEmpty(strDnf) ? "0" : strDnf);
            fileCnf.WriteLine(string.IsNullOrEmpty(strCnf) ? "1" : strCnf);
        }
    } // public class TruthTable

    public class MainNormalForms : Program
    {
        private const string ProgramName = "Normal forms";

        protected internal override void ShowName()
        {
            Console.WriteLine(ProgramName);
        }

        protected internal override void Execute()
        {
            var ttable = new TruthTable();
            const string inputFileName = "input";
            const string outFileNameDnf = "outputDNF";
            const string outFileNameCnf = "outputCNF";

            try
            {
                using (var inputFile = new StreamReader(inputFileName))
                    ttable.ReadTableParameters(inputFile);

                ttable.FormTruthTable();

                using (var fileDnf = new StreamWriter(outFileNameDnf, false))
                using (var fileCnf = new StreamWriter(outFileNameCnf, false))
                    ttable.GenerateFormulae(fileDnf, fileCnf);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            if (File.Exists(outFileNameCnf) && File.Exists(outFileNameDnf))
                Console.WriteLine("Output files were successfully created.");
            else
                Console.WriteLine("Output files were not created.");
        }
    } // public class MainModule
} // namespace LW01
