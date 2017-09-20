using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CockSort
{
    class Program
    {
        public static void Change(ref int low,ref int up)
        {
            int temp = low;
            low = up;
            up = temp;
        }
        public static  void CockSorts(int[] arr)
        {
            int up, low, index;
            low = 0;
            up = arr.Length - 1;
            index = low;
            while (up > low)
            {
                for (int i = low; i < up; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        Change(ref arr[i],ref arr[i + 1]);
                        index = i;
                    }
                }
                up = index;
                for (int i = up; i > low; i--)
                {
                    if (arr[i] < arr[i - 1])
                    {
                        Change(ref arr[i], ref arr[i - 1]);
                        index = i;
                    }
                }
                low = index;
            }
        }
        public static void Sorts(int[] arr)
        {
            int[] intarr = arr;
            CockSorts(intarr);
        }
        static void Main(string[] args)
        {
            int[] arr = new int[] { 3,9,27,6,18,12,21,15};
            Sorts(arr);
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            
            Console.ReadLine();
        }
    }
}
