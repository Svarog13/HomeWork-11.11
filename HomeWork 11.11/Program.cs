class Program
{
    static void Main()
    {
        int[,] arrayA = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
        int[,] arrayB = { { 9, 8, 7 }, { 6, 5, 5 }, { 3, 2, 1 } };

        Matrix matrix1 = new Matrix(arrayA);
        Matrix matrix2 = new Matrix(arrayB);

        System.Console.WriteLine("Matrix 1: ");
        matrix1.PrintMatrix();
  
        System.Console.WriteLine("Matrix 2: ");
        matrix2.PrintMatrix();
      
        Matrix sumMatrix = matrix1 + matrix2;
        System.Console.WriteLine("Sum of matrices: ");
        sumMatrix.PrintMatrix();
  

        int scalar = 2;
        Matrix scaledMatrix = matrix1 * scalar;
        System.Console.WriteLine($"Matrix 1 multiplied by {scalar}");
        scaledMatrix.PrintMatrix();
      

        Matrix productMatrix = matrix1 * matrix2;
        System.Console.WriteLine("Product of matrices: ");
        productMatrix.PrintMatrix();
      
    }
}
class Matrix
{
    private int[,] matrixArray;

    public Matrix(int[,] array)
    {
        matrixArray = array;
    }

    public static Matrix operator +(Matrix m1, Matrix m2)
    {
        int rows = m1.matrixArray.GetLength(0);
        int cols = m1.matrixArray.GetLength(0);

        int[,] result = new int[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = m1.matrixArray[i, j] + m2.matrixArray[i,j];
            }
        }
        return new Matrix(result);
    }
    public static Matrix operator *(Matrix m, int scalar)
    {
        int rows = m.matrixArray.GetLength(0);
        int cols = m.matrixArray.GetLength(0);

        int[,] result = new int[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = m.matrixArray[i, j] * scalar;
            }
        }
        return new Matrix(result);
    }
    public static Matrix operator *(Matrix m1, Matrix m2)
    {
        int rowsM1 = m1.matrixArray.GetLength(0);
        int colsM1 = m1.matrixArray.GetLength(1);
        int colsM2 = m1.matrixArray.GetLength(1);

        int[,] result = new int[rowsM1, colsM2];

        for (int i = 0; i < rowsM1; i++)
        {
            for (int j = 0; j < colsM2; j++)
            {
                for (int k = 0; k < colsM1; k++)
                {
                    result[i, j] += m1.matrixArray[i, k] * m2.matrixArray[k, j];
                }
            }
        }
        return new Matrix(result);
    }

    public int this[int i, int j]
    {
        get { return matrixArray[i, j]; }
        set { matrixArray[i, j] = value; }
    }
    public void PrintMatrix()
    {
        int rows = matrixArray.GetLength(0);
        int cols = matrixArray.GetLength(1);

        for (int i = 0;i < rows; i++)
        {
            for (int j  = 0; j < cols; j++)
            {
                System.Console.Write(matrixArray[i, j] + " ");
            }
            System.Console.WriteLine();
        }
        System.Console.WriteLine();
    }
}