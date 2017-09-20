using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace removeXTNum
{
    class Program
    {
        static int[] removeNum(int[] data)
        {
            List<int> lists = new List<int>();
            for (int i = 0; i < data.Length - 1; i++)//循环访问源数组元素
            {
                if (data[i] != data[i + 1])//判断相邻的值是否相同
                {
                    lists.Add(data[i]);//如果不相同则放入泛型集合中
                }
            }
            lists.Add(data[data.Length - 1]);//将数组的最后一个元素添加到泛型集合中
            return lists.ToArray();//将泛型集合转换为数组
        }
        static void Main(string[] args)
        {
            int[] arr = new int[] { 3, 9, 15, 24, 1, 4, 7, 6, 9, 5, 15, 24, 23, 16 };
            Console.Write("原始数组：");
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
            int temp;
            for (int i = 0; i < arr.Length-1; i++)//冒泡排序
            {
                for (int j = i+1; j < arr.Length ; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
                
            }
            Console.Write("排序后的数组：");
            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            int[] array = removeNum(arr);
            Console.Write("去掉重复值后的数组：");
            foreach (int m in array)
                Console.Write(m + " ");
            Console.WriteLine();
            changeUpAndDown();
            Console.ReadLine();
        }
        public static void changeUpAndDown()//大小写转换
        {
            string[] arr = new string[] { "MarGin", "BeiNbHFdd", "bhbdkDBKLBf" };
            var ChangeWord =
                from word in arr
                select new { Upper = word.ToUpper(), Lower = word.ToLower() };
            foreach (var vword in ChangeWord)
            {
                Console.WriteLine("大写{0},小写{1}", vword.Upper, vword.Lower);
            }
        }
    }
}
