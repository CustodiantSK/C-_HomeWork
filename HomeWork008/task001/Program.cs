﻿/* Задача 54: Задайте двумерный массив. 
Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2 */

void PrintArray(int[,] someArray)
{
    bool flag = true;
    for (int i = 0; i < someArray.GetLength(0); i++)
    {
        if (flag)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            flag = !flag;
        }
        else
        {
            Console.ResetColor();
            flag = !flag;
        }
        for (int j = 0; j < someArray.GetLength(1); j++)
        {
            Console.Write($"{someArray[i, j],4} ");
        }
        Console.WriteLine();
    }
    Console.ResetColor();
}

int[,] GenerateArray(int m, int n, int min, int max)
{
    int[,] result = new int[m, n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            result[i, j] = new Random().Next(min, max + 1);
        }

    }
    return result;
}

void SortedColumnArray(int[,] tables) // сортировка столбцов
{
    for (int j = 0; j < tables.GetLength(1); j++)
    {
        for (int i = 0; i < tables.GetLength(0); i++)
        {
            for (int t = i + 1; t < tables.GetLength(0); t++)
            {
                if (tables[i, j] < tables[t, j])
                {
                    int temp = tables[i, j];
                    tables[i, j] = tables[t, j];
                    tables[t, j] = temp;
                }
            }
        }
    }
}

void SortedStroceArray(int[,] tables) // сортировка строк
{
    for (int i = 0; i < tables.GetLength(0); i++)
    {
        for (int j = 0; j < tables.GetLength(1); j++)
        {
            for (int t = j + 1; t < tables.GetLength(1); t++)
            {
                if (tables[i, j] < tables[i, t])
                {
                    int temp = tables[i, j];
                    tables[i, j] = tables[i, t];
                    tables[i, t] = temp;
                }
            }
        }
    }
}


Console.Clear();
Console.WriteLine
($"Выберите размер таблицы");
Console.Write("Количество столбцов:");
int column = int.Parse(Console.ReadLine()!);
Console.Write("Количество строк:");
int stroke = int.Parse(Console.ReadLine()!);
Console.Write("Минимальное число: ");
int min = int.Parse(Console.ReadLine()!);
Console.Write("Максимальное число: ");
int max = int.Parse(Console.ReadLine()!);

Console.WriteLine();
int[,] table = GenerateArray(column, stroke, min, max);

Console.WriteLine("Ваша матрица: ");
PrintArray(table);

Console.WriteLine("Отсортируем строки: ");
SortedStroceArray(table);
PrintArray(table);

Console.WriteLine("Отсортируем столбцы: ");
SortedColumnArray(table);
PrintArray(table);
