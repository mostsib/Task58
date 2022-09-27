// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

int Prompt(string message)
{
    Console.WriteLine(message);
    int result = Convert.ToInt32(Console.ReadLine());
    return result;
}

int[,] FillArray(int numline, int numColumns, int minRand = 0, int maxRand = 10)
{
    int[,] matrix = new int[numline, numColumns];
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
       for (int j = 0; j < matrix.GetLength(1); i++) 
       {
        matrix[i,j] = new Random().Next(minRand, maxRand);
       }
    }
    return matrix;
}

void PrintArray(int[,] matrix)
{
     for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i,j]}\t");
        }
        Console.WriteLine();
    }
}

int[,] MatrixMultiplication(int[,] matrix1, int[,] matrix2)
{
    int[,] result = new int[matrix1.GetLength(0), matrix2.GetLength(1)];
    for (int i = 0; i < matrix1.GetLength(0); i++)
    {
        for (int j = 0; j < matrix2.GetLength(1); j++)
        {
            result[i,j] = 0;
            for (int n = 0; n < matrix1.GetLength(1); n++)
            result[i,j] += matrix1[i, n] * matrix2[n,j];
        }
    }
    return result;
}
void Main()
{
    int a = Prompt("Введите число строк матрицы А:");
    int b = Prompt("Введите число столбцов матрицы А:");
    int c = Prompt("Введите число строк матрицы B:");
    int d = Prompt("Введите число столбцов матрицы B:");
    if (!(a > 0 && b > 0 && c > 0 && d > 0))
    {
        Console.WriteLine("Невозможно решить задачу, задайте другие параметры");
        return;
    }
    int[,] array1 = FillArray (a,b);
    int[,] array2 = FillArray (c,d);
    PrintArray(array1);
    Console.WriteLine();
    PrintArray(array2);
    Console.WriteLine();
    if (array1.GetLength(0) != array2.GetLength(1))
    {
        Console.WriteLine("Матрицы несовместимы");
        return;
    }
    int[,] Result = MatrixMultiplication(array1, array2);
    PrintArray(Result);
}