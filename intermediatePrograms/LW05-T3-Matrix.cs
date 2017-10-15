using System;

namespace LW05T3
{
    public class Matrix
    {
        // Class members:

        static Random rand = new Random();

        private int rows;
        private int cols;
        private int[,] innerMatrix;

        // Constructors:

        public Matrix(int rows, int cols)
        {
            if (rows <= 0 || cols <= 0)
                throw new IndexOutOfRangeException(string.Format("Invalid arguments of a new Matrix."));
            else {
                this.rows = rows;
                this.cols = cols;
                this.innerMatrix = new int[rows, cols];
            }
        }

        public Matrix(Matrix copy)
        {
            this.rows = copy.rows;
            this.cols = copy.cols;
            this.innerMatrix = copy.innerMatrix;
        }

        // Class methods:

        public void Fill()
        {
            for (int i = 0; i < rows; ++i)
                for (int j = 0; j < cols; ++j)
                    innerMatrix[i,j] = rand.Next(1, 100);
        }

        public void Fill(int variable)
        {
            for (int i = 0; i < rows; ++i)
                for (int j = 0; j < cols; ++j)
                    innerMatrix[i,j] = variable;
        }

        public void Display()
        {
            for (int i = 0; i < rows; ++i) {
                for (int j = 0; j < cols; ++j)
                    Console.Write("{0,4}", innerMatrix[i,j]);
                Console.WriteLine();
            }
        }

        public int GetMinimum()
        {
            int minimum = innerMatrix[0,0];
            for (int i = 0; i < rows; ++i)
                for (int j = 0; j < cols; ++j)
                    if (innerMatrix[i,j] < minimum)
                        minimum = innerMatrix[i,j];
            return minimum;
        }

        // Overloaded operator(s):

        public static Matrix operator -(Matrix a, Matrix b)
        {
            Matrix result = new Matrix(a.rows, a.cols);
            for (int i = 0; i < result.rows; ++i)
                for (int j = 0; j < result.cols; ++j)
                    result.innerMatrix[i,j] = a.innerMatrix[i,j] - b.innerMatrix[i,j];
            return result;
        }
    }
}
