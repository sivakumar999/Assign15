﻿using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        int[] arr1 = GenerateRandomArray(20);
        int[] arr2 = GenerateRandomArray(30);
        int[] arr3 = GenerateRandomArray(50);

        Console.WriteLine("20 Size array (Quick Sort):");
        PrintArray(arr1);
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        QuickSort(arr1, 0, arr1.Length - 1);
        stopwatch.Stop();
        Console.WriteLine(" array After Qucik Sort 20 Size");
        PrintArray(arr1);
        Console.WriteLine($"ArraySize {arr1.Length} Time Taken {stopwatch.Elapsed.TotalMilliseconds} milliseconds");

        
        Console.WriteLine("\nSorted array using merge");
        Stopwatch stopwatch1 = new Stopwatch();
        stopwatch1.Start();
        MergeSort(arr1);
        stopwatch1.Stop();
        Console.WriteLine("after merge sort 20size");
        PrintArray(arr1);
        Console.WriteLine($"ArraySize {arr1.Length} Time Taken {stopwatch1.Elapsed.TotalMilliseconds} milliseconds");
        Console.WriteLine("-------------------------------------------------------------------------------");

        Console.WriteLine("\n30 Size array (Quick Sort):");
        PrintArray(arr2);
        Stopwatch stopwatch3 = new Stopwatch();
        stopwatch3.Start();
        QuickSort(arr2, 0, arr2.Length - 1);
        stopwatch3.Stop();
        Console.WriteLine(" array After Qucik Sort 30 Size");
        PrintArray(arr2);
        Console.WriteLine($"ArraySize {arr2.Length} Time Taken {stopwatch3.Elapsed.TotalMilliseconds} milliseconds");


        Console.WriteLine("\nSorted array using merge");
        Stopwatch stopwatch4 = new Stopwatch();
        stopwatch4.Start();
        MergeSort(arr2);
        stopwatch4.Stop();
        Console.WriteLine("after merge sort 30size");
        PrintArray(arr2);
        Console.WriteLine($"ArraySize {arr2.Length} Time Taken {stopwatch4.Elapsed.TotalMilliseconds} milliseconds");
        Console.WriteLine("-------------------------------------------------------------------------------");


        Console.WriteLine("\n50 Size array (Quick Sort):");
        PrintArray(arr3);
        Stopwatch stopwatch5 = new Stopwatch();
        stopwatch5.Start();
        QuickSort(arr3, 0, arr3.Length - 1);
        stopwatch5.Stop();
        Console.WriteLine(" array After Qucik Sort 50 Size");
        PrintArray(arr3);
        Console.WriteLine($"ArraySize {arr3.Length} Time Taken {stopwatch5.Elapsed.TotalMilliseconds} milliseconds");


        Console.WriteLine("\nSorted array using merge");
        Stopwatch stopwatch6 = new Stopwatch();
        stopwatch6.Start();
        MergeSort(arr3);
        stopwatch6.Stop();
        Console.WriteLine("after merge sort 50size");
        PrintArray(arr3);
        Console.WriteLine($"ArraySize {arr3.Length} Time Taken {stopwatch6.Elapsed.TotalMilliseconds} milliseconds");


        /*Console.WriteLine("\nOriginal array (Merge Sort):");
        PrintArray(arr2);

        MergeSort(arr2);

        Console.WriteLine("\nSorted array (Merge Sort):");
        PrintArray(arr2);

        Console.WriteLine("\nOriginal array (Quick Sort):");
        PrintArray(arr3);

        QuickSort(arr3, 0, arr3.Length - 1);

        Console.WriteLine("\nSorted array (Quick Sort):");
        PrintArray(arr3);
        Console.ReadKey();*/
        Console.ReadKey();
    }

    static int[] GenerateRandomArray(int size)
    {
        Random random = new Random();
        int[] array = new int[size];

        for (int i = 0; i < size; i++)
        {
            array[i] = random.Next(1, 100);
        }

        return array;
    }

    static void QuickSort(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int partitionIndex = Partition(arr, low, high);

            QuickSort(arr, low, partitionIndex - 1);
            QuickSort(arr, partitionIndex + 1, high);
        }
    }

    static int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (arr[j] <= pivot)
            {
                i++;
                Swap(arr, i, j);
            }
        }

        Swap(arr, i + 1, high);
        return i + 1;
    }

    static void MergeSort(int[] arr)
    {
        int n = arr.Length;

        if (n <= 1)
            return;

        int mid = n / 2;
        int[] leftArray = new int[mid];
        int[] rightArray = new int[n - mid];

        for (int i = 0; i < mid; i++)
            leftArray[i] = arr[i];

        for (int i = mid; i < n; i++)
            rightArray[i - mid] = arr[i];

        MergeSort(leftArray);
        MergeSort(rightArray);

        Merge(arr, leftArray, rightArray);
    }

    static void Merge(int[] arr, int[] leftArray, int[] rightArray)
    {
        int leftLength = leftArray.Length;
        int rightLength = rightArray.Length;
        int i = 0, j = 0, k = 0;

        while (i < leftLength && j < rightLength)
        {
            if (leftArray[i] < rightArray[j])
            {
                arr[k] = leftArray[i];
                i++;
            }
            else
            {
                arr[k] = rightArray[j];
                j++;
            }
            k++;
        }

        while (i < leftLength)
        {
            arr[k] = leftArray[i];
            i++;
            k++;
        }

        while (j < rightLength)
        {
            arr[k] = rightArray[j];
            j++;
            k++;
        }
    }

    static void Swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }

    static void PrintArray(int[] arr)
    {
        foreach (int num in arr)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }
}
