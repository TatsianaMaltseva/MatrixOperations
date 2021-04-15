namespace Matrix_operations
{
    public class Matrix : ICalculational<int[,], Matrix>
    {
        public int Rows { get; private set; } = 0;
        public int Columns { get; private set; } = 0;
        public int[,] MainMatrix { get; private set; }
        public Matrix(int[,] matrix)
        {
            Columns = matrix.GetLength(1);
            Rows = matrix.GetLength(0);
            MainMatrix = matrix;
        }

        public int[,] Add(Matrix secondMatrix)
        {
            //CompareMatrixSize(secondMatrix);
            int[,] resultMatrix = new int[Rows, Columns];
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j ++)
                {
                    resultMatrix[i, j] = MainMatrix[i, j] + secondMatrix.MainMatrix[i, j];
                }
            }
            return resultMatrix;
        }

        public int[,] Substract(Matrix secondMatrix)
        {
            //CompareMatrixSize(secondMatrix);
            int[,] resultMatrix = new int[Rows, Columns];
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    resultMatrix[i, j] = MainMatrix[i, j] - secondMatrix.MainMatrix[i, j];
                }
            }
            return resultMatrix;
        }

        public int[,] Multiply(Matrix secondMatrix)
        {
            //ValidateMultiplyArgument(secondMatrix);
            int[,] result = new int[Rows, secondMatrix.Columns];
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < secondMatrix.Columns; j++)
                {
                    result[i, j] = 0;
                    for (int k = 0; k < Columns; k++)
                        result[i, j] += MainMatrix[i, k] * secondMatrix.MainMatrix[k, j];
                }
            }
            return result;
        }

        private bool CompareMatrixSize(Matrix secondMatrix)
        {
            if (Rows != secondMatrix.Rows || Columns != secondMatrix.Columns)
            {
                return false;
            }
            return true;
        } // в Add и Substract

        private bool ValidateMultiplyArgument(Matrix secondMatrix)
        {
            if (Columns != secondMatrix.Rows)
            {
                return false;
            }
            return true;
        } // в Multiply

    }

    //public class TestMath : ICalculational<TestMath>
    //{

    //}
}