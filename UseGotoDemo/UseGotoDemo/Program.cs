using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UseGotoDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入要查找的值：");
            string input = Console.ReadLine();
            string[] str=new string[3];
            str[0] = "东莞领益";
            str[1] = "深圳领胜";
            str[2] = "领胜集团";
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i].Equals(input))
                {
                    goto Found;
                }
            }
            Console.WriteLine("{0}不存在", input);
            goto Finish;

            Found:
                Console.WriteLine("{0}存在",input);
            Finish:
                Console.WriteLine("查找完毕");

            Console.ReadLine();
        }
    }
}
