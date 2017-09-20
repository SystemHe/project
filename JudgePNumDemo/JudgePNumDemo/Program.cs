using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JudgePNumDemo
{
    class Program
    {
        static void Main(string[] args)
        {
                Console.WriteLine("请输入要判断的数:");
                int Num = Convert.ToInt32(Console.ReadLine());
                int j = 0;
                j = (int)Math.Ceiling(Math.Sqrt(Convert.ToDouble(Num)));
                //j = Convert.ToInt32(Num);
                int intFlag = 0;
                for (int i = 2; i <= j; i++)
                {
                    intFlag = Convert.ToInt32(Math.IEEERemainder(Num, i));
                    if (intFlag == 0) break;

                }
                if (intFlag == 0)
                    Console.WriteLine(Num + "不是素数。");
                else
                    Console.WriteLine(Num + "是素数。");
                Console.ReadLine();
           }
    }
}
