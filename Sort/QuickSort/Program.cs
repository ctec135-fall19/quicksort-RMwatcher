/*
Aurthor: Richard Mora
CTEC 135: Microsoft Software Development with C#
Date: 12/8/2019

Quick Sort

site references:
https://www.geeksforgeeks.org/quick-sort/
https://www.w3resource.com/csharp-exercises/searching-and-sorting-algorithm/searching-and-sorting-algorithm-exercise-9.php (didn't copy and paste code from website, just use
as reference to help me write this program)
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    class Program
    {
        // Here we created a static class Count with a public static int object
        // called count to use to help us keep track on how many times we use
        // the quick sort method to sort our random numbers.
        static class Count
        {
            public static int count;
        }
            
        // The following method we created is a static void method named 
        // QuickSort() which takes on a int array called A, a int called lo
        // and a int called hi as parameters
        static void QuickSort(int[] A, int low, int hi)
        {
            // if the value of lo is less than the value of hi the following
            // code below will run
            if (low < hi)
            {
                // we created a int object called p and attach the value
                // of the method Partition() with the value of A, lo, and hi
                // as parameters required by the method Partition() for it to
                // run
                int p = Partition(A, low, hi);

                // here we test whether or not p from eariler is greater than
                // 1, the following code below will run
                if (p > 1)
                {
                    // This runs the method QuickSort with the value of A, low
                    // and p as parameters. The variable p acts as calling the
                    // method Partition() while running QuickSort() only p 
                    // will have a new value 
                    QuickSort(A, low, p);
                }

                // This else if works similar as the if statement above except
                // it's testing if p (or the value of p when Partition() 
                // method was called and returned it's value) plus 1 is less 
                // than the value of hi, then the following code below will
                // run
                else if (p + 1 < hi)
                {
                    // This runs the QuickSort() method with the value of A, 
                    // p (the method Partition() when called) plus 1 and hi
                    // as parameters. The value of p is the result of running
                    // Partition() with the same parameters as QuickSort()
                    // from the top of this method.
                    QuickSort(A, p + 1, hi);
                }
                
            }
            
        }

        // Here I created a static int Partitin() method that has an int[] 
        // called A, int called low, and int hi as parameters.
        static int Partition(int[] A, int low, int hi)
        {
            // Here I created a int data type called pivot and gave it a value
            // of A[low + (hi - low) / 2]; where you subtract the value of hi
            // with the value of low, divide the result by 2 and add the value
            // of low to get the value of pivot. (ex: A[0 + (9 - 0) / 2] to get
            // 4.5 as the value of pivot to be used later in this method).
            int pivot = A[low + (hi - low) / 2];

            // The following two lines of code is creating two new int data
            // type objects called i and j where i equals value of low minus 1
            // and j equals value of hi plus 1.
            int i = low - 1;
            int j = hi + 1;

        // Here we have a while which as long as the condtion is true, it'll
        // keep running the following codes below, so as long as the conditions
        // inside this while loop is true, the loop will continue.
        while (true)
            {
                // we have a do while loop where it runs the code i = i + 1;
                // as long as A[i] is less than the value of pivot which was 
                // determined above.
                do
                {
                    i = i + 1;
                }
                while (A[i] < pivot);

                // this do while loop is similar to the first loop where the
                // loop will run the code j = j - 1; as long as A[j] is greater
                // than the value of pivot
                do
                {
                    j = j - 1;
                }
                while (A[j] > pivot);

                // we have a if statement that checks if the value of i is
                // greater than or equal to the value of j. If that's true,
                // then it'll return the current value of A[j] once the loop
                // reach the end.
                if (i >= j)
                {
                    return A[j];
                }

                // here we want to swap values between variables so first we
                // create a new int data type called temp and assign it the 
                // A[i]. Next we assign A[i] (not temp) to A[j] on the next 
                // line. Finally we take the variable A[j] and assign it the
                // variable temp to complete the swap.
                int temp = A[i];
                A[i] = A[j];
                A[j] = temp;
            }
        }
        
        static void Main(string[] args)
        {
            // we create a new int array called zeroThruNine and put in 10
            // random numbers into the array in a random order.
            int[] zeroThruNine = new int[] {7, 5, 1, 9, 3, 8, 2, 4, 6, 0};

            Console.WriteLine("Zero thru nine array before quicksort");
            Console.WriteLine("------------------------------------------");
            // we use a foreach loop to iterate through the arrayto have them 
            // print out on a single line with some spaces and a character
            // to make the results more readable.
            foreach (int num in zeroThruNine)
            {
                Console.Write($"{num} | ");
            }
            Console.WriteLine("\n");

            // Here we run the QuickSort() method with the parameters the
            // int array zeroThruNine, 0 and 9 in order to run this method.
            // When we run this method, it'll take the second and third 
            // parameters to help determine how the method sort through our
            // array meaning it'll use 0 and 9 as a pivot or reference point
            // for the method to sort all numbers lower than 9 to the left of
            // the array while moving larger numbers to the right.
            QuickSort(zeroThruNine, 0, 9);

            Console.WriteLine("Zero thru nine array after quicksort");

            Console.WriteLine("------------------------------------------");
            foreach (int num in zeroThruNine)
            {
                Console.Write($"{num} | ");
            }
            // here we keep track of how many 'swaps' we had to perform in
            // order to get the zeroThruNine array in order by using the static
            // class Count to help us keep track of how many times it took.
            Count.count++;
            Console.WriteLine("\n");
            
            // from lines 175 to 210 we perform the same tasks with the
            // differences the second and third parameters will be different
            // for each QuickSort() method call which will sort the array.
            QuickSort(zeroThruNine, 4, 9);

            Console.WriteLine("Zero thru nine array after quicksort");

            Console.WriteLine("------------------------------------------");
            foreach (int num in zeroThruNine)
            {
                Console.Write($"{num} | ");                   
            }
            Count.count++;
            Console.WriteLine("\n");
            
            QuickSort(zeroThruNine, 6, 9);

            Console.WriteLine("Zero thru nine array after quicksort");

            Console.WriteLine("------------------------------------------");
            foreach (int num in zeroThruNine)
            {
                Console.Write($"{num} | ");    
            }
            Count.count++;
            Console.WriteLine("\n");

            QuickSort(zeroThruNine, 6, 8);

            Console.WriteLine("Zero thru nine array after quicksort");

            Console.WriteLine("------------------------------------------");
            foreach (int num in zeroThruNine)
            {
                Console.Write($"{num} | ");    
            }
            Count.count++;
            Console.WriteLine("\n");
            // this Console.WriteLine() tells us how many times we had to run
            // the QuickSort() method and display the total here along with 
            // a small sentance
            Console.WriteLine($"Total number of times it sorted: {Count.count}");
        }
    }
}
