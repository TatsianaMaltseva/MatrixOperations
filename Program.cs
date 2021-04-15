using System;
using System.Collections.Generic;

namespace Matrix_operations // тесты
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Dictionary<char, Matrix> dictionary = ConvertToMatrix();
                TaskClass task = new TaskClass(Console.ReadLine());
                task.Count(dictionary);
                Output(task.Task[0], dictionary);
            }
            catch (Exception)
            {
                Console.WriteLine("Can't read matrix");
            }
        }

        static Dictionary<char, Matrix> ConvertToMatrix()
        {
            Dictionary<char, Matrix> dictionary = new Dictionary<char, Matrix>();
            string input = Console.ReadLine();
            while (input != "")
            {
                char key = input[0];
                input = input[3..^1];
                int rows = 0;
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] == ';') rows += 1;
                }
                rows += 1;
                input = input.Replace(";", "");
                string[] splitted = input.Split(" ");
                int columns = splitted.Length / rows;
                int[,] matrix = new int[rows, columns];
                int k = 0;
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        matrix[i, j] = Convert.ToInt32(splitted[k]);
                        k++;
                    }
                }
                dictionary.Add(key, new Matrix(matrix));
                input = Console.ReadLine();

            }
            return dictionary;
        } // первая буква англ алфавит = [; числа пробелы]

        static void Output(char key, Dictionary<char, Matrix> dictionary)
        {
            string output = "[";
            for (int i = 0; i < dictionary[key].Rows; i++)
            {
                for (int j = 0; j < dictionary[key].Columns; j++)
                {
                    output += $"{dictionary[key].MainMatrix[i, j]}";
                    if (j == dictionary[key].Columns - 1
                        && i != dictionary[key].Rows - 1)
                        output += "; ";
                    else output += " ";
                }
            }

            output = output[..^1] + "]";
            Console.WriteLine(output);
        }
    }     
    // сколько памяти занимает массив строк?
}