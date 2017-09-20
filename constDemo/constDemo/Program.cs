using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace constDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //int one = 9527;		//定义变量，并初始化为9527
            //const int two = 10086;	//定义常量，并初始化为10086
            //Console.WriteLine("变量：{0}", one);	//输出变量的值
            //Console.WriteLine("常量：{0}", two);	//输出常量的值
            //one = two;		//改变变量的值，将常量的值赋给变量
            //Console.WriteLine("更改后的变量：{0}", one);
            Program.zhuangxiang();
            Console.ReadLine();
        }
        public static void change()
        {
            double i = 123456.789;
            int j = (int)i;
            double z = j;
            Console.WriteLine("转换之前的变量：{0}类型，值为：{1}" ,i.GetType().ToString(),i);
            Console.WriteLine("显式转换之后的变量:{0}类型，值为：{1}", j.GetType(),j);
            Console.WriteLine("隐式转换后的变量：{0}类型，值为：{1}", z.GetType(),z);
            
        }
        public static void zhuangxiang()
        {
            int i = 9527;
            object obj = i;
            Console.WriteLine("未装箱前值类型数据：{0}", i);
            Console.WriteLine("装箱后的引用类型数据：{0}", obj);
            i = 10086;
            Console.WriteLine("重新赋值后的值类型数据：{0}", i);
            Console.WriteLine("重新赋值后的装箱对象的数据：{0}", obj);
        }
        public static void chaixiang()
        {
            int i = 9527;
            object obj = i;
            Console.WriteLine("装箱操作：值为：{0},对象为:{1}", i, obj);
            int j = (int)obj;
            Console.WriteLine("拆箱操作：对象为：{0},值为{1}", obj, j);
        }
    }
}
