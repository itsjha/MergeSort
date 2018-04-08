using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int SIZE = 15;
            int[] myArray;
            MergeSort mergeSortArray = new MergeSort(SIZE, out myArray);

            Console.WriteLine("The initial unsorted Array is : ");
            DisplayArrayElements(myArray);
            
            mergeSort(myArray, 0, myArray.Length-1);

            Console.WriteLine("\n\n\nThe sorted Array is : ");
            DisplayArrayElements(myArray);
            
            Console.ReadKey();
        }

        private static void DisplayArrayElements(int[] myArray)
        {
            Console.WriteLine("");
            for (int i = 0; i < myArray.Length; i++)
            {
                Console.Write(myArray[i] + "  ");
            }
            Console.WriteLine();
        }


        private static void mergeSort(int[] myArray, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;
                mergeSort(myArray, left, middle);
                mergeSort(myArray, middle + 1, right);

                merge(myArray, left, middle, right);
            }
            
        }

        private static void merge(int[] myArray, int left, int middle, int right)
        {
            int lengthLeft, lengthRight;
            lengthLeft = middle - left + 1;
            lengthRight = right - middle; 

            int[] leftArray = new int[lengthLeft];
            int[] rightArray = new int[lengthRight];

            for(int i=0; i<lengthLeft; i++)
            {
                leftArray[i] = myArray[left + i];
            }

            for(int j=0; j<lengthRight; j++)
            {
                rightArray[j] = myArray[middle + j + 1];
            }

            
            int leftIndex = 0, rightIndex = 0, mergedIndex = left;
            while(leftIndex <lengthLeft && rightIndex < lengthRight)
            {
                if(leftArray[leftIndex] < rightArray[rightIndex])
                {
                    myArray[mergedIndex] = leftArray[leftIndex];
                    leftIndex++;
                }

                else
                {
                    myArray[mergedIndex] = rightArray[rightIndex];
                    rightIndex++;
                }
                mergedIndex++;
            }

            // Copy the remaining elements of leftArray[], if there are any
            while(leftIndex < lengthLeft)
            {
                myArray[mergedIndex] = leftArray[leftIndex];
                leftIndex++;
                mergedIndex++;
            }

            // Copy the remaining elements of rightArray[], if there are any
            while(rightIndex < lengthRight)
            {
                myArray[mergedIndex] = rightArray[rightIndex];
                rightIndex++;
                mergedIndex++;
            }
        }
    }
    class MergeSort
    {
        private static Random generator = new Random();

        public MergeSort(int size, out int[] myArray)
        {
            myArray = new int[size];
            for (int i = 0; i < size; i++)
            {
                myArray[i] = generator.Next(20, 90);
            }

        }
    }
    
}
