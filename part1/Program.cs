using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5780_01_7922_4084
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random(DateTime.Now.Millisecond); //Grates numbers
            //Create arrays
            int[] A = new int[20]; 
            int[] B = new int[20]; 
            int[] C = new int[20]; 
            fill(rnd, A);
            fill(rnd, B);
            for (int i = 0; i < 20; i++)
                C[i] = Math.Abs(A[i] - B[i]);  //The difference between the numbers

            print(A);
            print(B);
            print(C);
            Console.ReadKey();
        }

        private static void print(int[] arry)// prints out the arrys
        {
            for (int i = 1; i < 20; i++)
                Console.Write("{0 ,-3} ", arry[i]);
            Console.WriteLine();
        }

        private static void fill(Random rnd, int[] arry)//fills arrays a,b in random numbers
        {
            for (int i = 0; i < 20; i++)
                arry[i] = rnd.Next(18, 122);
        }
    }
}
