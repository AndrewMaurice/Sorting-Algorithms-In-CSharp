using System;
using System.Collections.Generic;

namespace SortingPractice
{
    class Sort
    {
        #region Private Methods

        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        private static void MergeArray(int[] arr, int start, int middle, int end)
        {
            // create a new temp array to hold the data of the array after sorting each side.
            List<int> temp = new List<int>();

            // setting some variables.
            int i = start; // to access the begining of the left half.
            int j = middle + 1; // to access the second half.

            // adding the smallest values on top.
            while (i < (middle + 1) && j <= end)
            {
                if (arr[i] < arr[j])
                {
                    temp.Add(arr[i]);
                    i++;
                }
                else
                {
                    temp.Add(arr[j]);
                    j++;
                }
            }

            // adding the rest of the array from the left && right sides.
            while (i < (middle + 1))
            {
                temp.Add(arr[i]);
                i++;
            }
            while (j <= (end))
            {
                temp.Add(arr[j]);
                j++;
            }

            // adding these values to the original array.
            for (i = start; i <= end; i++)
            {
                arr[i] = temp[i - start];
            }
        }

        private static int PartitionArray(int[] arr, int start, int end)
        {
            int i = (start - 1);
            int pivot = arr[end];
            for (int j = start; j < end; j++)
            {
                if (arr[j] <= pivot)
                {
                    ++i;
                    Swap(ref arr[j], ref arr[i]);
                }
            }
            Swap(ref arr[i + 1], ref arr[end]);

            return (i + 1);
        }

        #endregion

        #region Public Methods

        public static void PrintArr(int[] arr)
        {
            for(int i= 0; i <  arr.Length; i++)
            {
                Console.Write("{0},", arr[i]);
            }
            Console.WriteLine();
        }

        public static int[] InsertionSort(int[] arr)
        {
            for(int i = 1; i < arr.Length; i++)
            {
                for(int j = 0; j < i; j++)
                {
                    if(arr[i] < arr[j])
                    {
                        Swap(ref arr[i], ref arr[j]);
                    }
                }
            }

            return arr;
        }

        public static int[] BubbleSort(int[] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                for(int j = 0; j < arr.Length -1; j++)
                {
                    if(arr[j] > arr[j + 1])
                    {
                        Swap(ref arr[j], ref arr[j + 1]);
                    }
                }
            }

            return arr;
        }

        public static int[] SelectionSort(int[] arr)
        {
            int minIndex = 0;
            for(int i = 0; i < arr.Length; i++)
            {
                minIndex = i;
                for(int j = i + 1; j < arr.Length - 1; j++)
                {
                    if(arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                    }
                }

                Swap(ref arr[minIndex], ref arr[i]);
            }

            return arr;
        }

        public static void MergeSort(int[] arr, int start, int end)
        {
            if(start < end)
            {
                // calculate the middle.
                int middle = (start + end) / 2;

                // divide the array.
                MergeSort(arr, start, middle);
                MergeSort(arr, (middle + 1), end);

                // combine and sort the array.
                MergeArray(arr, start, middle, end);
            }
        }

        public static void QuickSort(int[] arr, int start, int end)
        {
            if(start < end)
            {
                int parti = PartitionArray(arr, start, end);

                QuickSort(arr, start, (parti - 1));

                QuickSort(arr, (parti + 1), end);
            }
        }

        #endregion


    }
}
