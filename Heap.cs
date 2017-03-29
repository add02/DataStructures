using System;
using System.Collections.Generic;

namespace BinaryHeap
{
    class Program
    {
        static void Main(string[] args)
        {
            //Intializing inputArray
            List<int> inputArray = new List<int>();

            //Selecting the type of Heap
            string heapType = "MinHeap";

            //Nullifying the 0th element of InputArray
            if (heapType.Equals("MinHeap"))
            {
                inputArray.Insert(0, int.MinValue);
            }
            else if (heapType.Equals("MaxHeap"))
            {
                inputArray.Insert(0, int.MaxValue);
            }

            //Element to inserted
            int inputElement = 6;

            //Populating the input array and making the heap
            int[] input = { 3, 1, 6, 5, 2, 4 };

            for (int i = 0; i < input.Length; i++)
            {
                //Insertion operation
                inputArray = heapInsertion(inputArray, input[i], heapType);
            }

            //Priting the inital array
            for (int i = 1; i < inputArray.Count; i++)
            {
                Console.WriteLine(inputArray[i]);
            }
            Console.ReadLine();

            //Deletion Operation
            inputArray = heapDeletion(inputArray, inputElement, heapType);

            //Sorting Operation
            inputArray = heapSort(inputArray, heapType);

            //Priting the final array
            for (int i = 0; i < inputArray.Count; i++)
            {
                Console.WriteLine(inputArray[i]);
            }
            Console.ReadLine();
        }
       
        /// <summary>
        /// HEAP INSERTION
        /// -----------------------------------------------------------------------------------------------------------------------------------------------------
        /// Idea: The new element is initially appended to the end of the heap (as the last element of the array)
        /// The heap property is repaired by comparing added element with its parent and moving the added element up a level (swapping positions with the parent) 
        /// This process is called "percolation up". The comparison is repeated until the parent is larger than or equal to the percolating element
        /// RUNTIME: the worst-case runtime is O(log n)
        /// </summary>
        /// <param name="inputArray"></param>
        /// <param name="inputElement"></param>
        /// <param name="heapType"></param>
        /// <returns name="inputArray"</returns>
        
        static List<int> heapInsertion(List<int> inputArray, int inputElement, string heapType)
     
        {
            inputArray.Add(inputElement);

            return percolateUp(inputArray, heapType);
        }

        static List<int> percolateUp(List<int> inputArray, string heapType)
        {
            int currentPos = inputArray.Count - 1;

            if (heapType.Equals("MinHeap"))
            {
                while (inputArray[currentPos] <= inputArray[currentPos / 2])
                {
                    int temp = inputArray[currentPos / 2];
                    inputArray[currentPos / 2] = inputArray[currentPos];
                    inputArray[currentPos] = temp;
                    currentPos = currentPos / 2;
                }
            }
            else if (heapType.Equals("MaxHeap"))
            {
                while (inputArray[currentPos] >= inputArray[currentPos / 2])
                {
                    int temp = inputArray[currentPos / 2];
                    inputArray[currentPos / 2] = inputArray[currentPos];
                    inputArray[currentPos] = temp;
                    currentPos = currentPos / 2;
                }
            }

            return inputArray;
        }

        /// <summary>
        /// Heap Deletion
        /// --------------------------------------------------------------------------------------------------------------------------
        /// The minimum/maximum element can be found at the root, which is the first element of the array
        /// We remove the root and replace it with the last element of the heap and then restore the heap property by percolating down
        /// RUNTIME: the worst-case runtime is O{ log n)
        /// </summary>
        /// <param name="inputArray"></param>
        /// <param name="inputElement"></param>
        /// <param name="heapType"></param>
        /// <returns name="inputArray"></returns>
        
        static List<int> heapDeletion(List<int> inputArray, int inputElement, string heapType)
        {
            int temp = inputArray[1];
            inputArray[1] = inputArray[inputArray.Count - 1];
            inputArray[inputArray.Count - 1] = temp;
            inputArray.RemoveAt(inputArray.Count - 1);

            return percolateDown(inputArray, heapType);
        }

        static List<int> percolateDown(List<int> inputArray, string heapType)
        {
            int currentPos = 1;

            if (heapType.Equals("MinHeap"))
            {
                while (((currentPos * 2) < inputArray.Count) && inputArray[currentPos] >= inputArray[currentPos * 2])
                {
                    int temp = inputArray[currentPos * 2];
                    inputArray[currentPos * 2] = inputArray[currentPos];
                    inputArray[currentPos] = temp;
                    currentPos = currentPos * 2;
                }
            }
            else if (heapType.Equals("MaxHeap"))
            {
                while (inputArray[currentPos] <= inputArray[currentPos * 2] && ((currentPos * 2) < inputArray.Count))
                {
                    int temp = inputArray[currentPos * 2];
                    inputArray[currentPos * 2] = inputArray[currentPos];
                    inputArray[currentPos] = temp;
                    currentPos = currentPos * 2;
                }
            }

            return inputArray;
        }

        /// <summary>
        /// Heap Sort
        /// --------------------------------------------------------------------------------------------------------------------------
        /// The algorithm runs in two steps. Given an array of data, first, we build a heap and then turn it into a sorted list by calling deleteMin. 
        /// RUNTIME: Running time of the algorithm is O(n log n).
        /// </summary>
        /// <param name="inputArray"></param>
        /// <param name="heapType"></param>
        /// <returns name="sortedArray"></returns>
       
        static List<int> heapSort(List<int> inputArray, string heapType)
        {
            List<int> sortedArray = new List<int>();
            while(inputArray.Count != 1)
            {
                sortedArray.Add(getMinimum(inputArray, heapType));
            }

            return sortedArray;
        }

        static int getMinimum (List<int> inputArray, string heapType)
        {
            int minimumElement = inputArray[1];
            int temp = inputArray[inputArray.Count - 1];
            inputArray[1] = inputArray[inputArray.Count - 1];
            inputArray[inputArray.Count - 1] = temp;
            inputArray.RemoveAt(inputArray.Count - 1);

            inputArray = percolateDown(inputArray, heapType);

            return minimumElement;
        }
    }
}
