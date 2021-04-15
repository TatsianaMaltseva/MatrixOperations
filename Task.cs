using System;
using System.Collections.Generic;

namespace Matrix_operations
{
    class TaskClass 
    {
        public string Task;

        public TaskClass(string task)
            {
                Task = task;
            }

        public void Count(Dictionary<char, Matrix> dictionary)
        {
            string key = "0";
            Multiply(ref key, dictionary);
            Add(ref key, dictionary);
            Substract(ref key, dictionary);
            if (!TaskValidate()) Console.WriteLine("Task contains inappropriate characters.");
        }
        // так чтобы оно не выводило результат после эксепшена 

        // попробовать под один метод подвести

        private void Multiply(ref string key, Dictionary<char, Matrix> dictionary)
        {
            for (int i = 0; i < Task.Length; i++)
            {
                if (Task[i] == '*')
                {
                    string todo = Task[(i - 1)..(i + 2)];
                    dictionary.Add(key[0], new Matrix(dictionary[todo[0]].Multiply(dictionary[todo[2]])));
                    Task = Task.Replace(todo, key);
                    key = $"{key[0] + 1 - '0'}";
                    i = 0;
                }
            }
        }

        private void Add(ref string key, Dictionary<char, Matrix> dictionary)
        {
            for (int i = 0; i < Task.Length; i++)
            {
                if (Task[i] == '+')
                {
                    string todo = Task[(i - 1)..(i + 2)];
                    dictionary.Add(key[0], new Matrix(dictionary[todo[0]].Add(dictionary[todo[2]])));
                    Task = Task.Replace(todo, key);
                    key = $"{key[0] + 1 - '0'}";
                    i = 0;
                }
            }
        }

        private void Substract(ref string key, Dictionary<char, Matrix> dictionary)
        {
            for (int i = 0; i < Task.Length; i++)
            {
                if (Task[i] == '-')
                {
                    string todo = Task[(i - 1)..(i + 2)];
                    dictionary.Add(key[0], new Matrix(dictionary[todo[0]].Substract(dictionary[todo[2]])));
                    Task = Task.Replace(todo, key);
                    key = $"{key[0] + 1 - '0'}";
                    i = 0;
                }
            }
        }

        private bool TaskValidate()
        {
            if (Task.Length != 1)
            {
                return false;
            }
            return true;
        } 
    }
}