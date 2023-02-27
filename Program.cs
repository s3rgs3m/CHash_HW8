﻿// https://github.com/s3rgs3m/CHash_HW8.git
// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка

// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

// Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

int[,] getArr(int m, int n){ // заполнение массива
    Random rnd = new Random();
    int[,] arr = new int[m,n];
    for (int i=0; i<m; i++)
        for (int j=0; j<n; j++)
            arr[i,j] = rnd.Next(0,10);
    return arr;
}

void viewArr(int[,] arr, int M, int N){ // вывод массива
    for (int i=0; i < M; i++){
        Console.Write("\n\t");
        for (int j=0; j < N ; j++)
            Console.Write($"\t{arr[i,j]}");
    }
}
Console.Clear();
Console.WriteLine("Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.");

int [,] arr = getArr(3,4); // задаем массив
int M = arr.GetUpperBound(0)+1; // получаем размерность - строки
int N = arr.GetUpperBound(1)+1; // получаем размерность - стролбики

Console.Write("\tИсходный массив:");
viewArr(arr,M,N);

int tmp; // сортировка
for (int i=0; i < M; i++)
    for (int j=0; j<N-1;j++)
        for (int t=j+1; t<N;t++)
            if (arr[i,j] < arr[i,t]){
                tmp = arr[i,j];
                arr[i,j] = arr[i,t];
                arr[i,t] = tmp;
            }

Console.Write("\n\tСортированный массив:");
viewArr(arr,M,N);

Console.WriteLine("\n\nЗадача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.");
arr = getArr(3,3); 
M = arr.GetUpperBound(0)+1;
N = arr.GetUpperBound(1)+1;

Console.Write("\tИсходный массив:");
viewArr(arr,M,N);

int sum; // сумма в текущей строке
int minSum = 0; // текущая наименьшая сумма
int minSumIndex = 0; // строка с наименьшей суммой

for (int i=0; i<M; i++){
    sum = 0;
    for (int j=0; j<N; j++)
        sum+=arr[i,j];
    if (sum < minSum || i==0){
        minSum = sum;
        minSumIndex = i+1;
    }
}
Console.WriteLine($"\n\tСтрока с наименьшей суммой: {minSumIndex}");

Console.WriteLine("Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.");
int [,] arr1 = getArr(2,3); // матрица 1
int M1 = arr1.GetUpperBound(0)+1; 
int N1 = arr1.GetUpperBound(1)+1; 
int [,] arr2 = getArr(3,4); // матрица 2 Произведение двух матриц АВ имеет смысл только в том случае, когда число столбцов матрицы А совпадает с числом строк матрицы В .
int M2 = arr2.GetUpperBound(0)+1; 
int N2 = arr2.GetUpperBound(1)+1; 

Console.Write("\tМатрица A:");
viewArr(arr1,M1,N1);
Console.Write("\n\tМатрица B:");
viewArr(arr2,M2,N2);

int [,] arr3 = new int[M1,N2]; //матрица результата

for (int i=0; i<M1; i++)
    for (int j=0; j<N2; j++){
        arr3[i,j] = 0;
        for (int z=0; z<N1 ; z++)
            arr3[i,j] = arr3[i,j] + arr1[i,z]*arr2[z,j];
    }

Console.WriteLine("\nРезультат умножения:");
viewArr(arr3,M1,N2);