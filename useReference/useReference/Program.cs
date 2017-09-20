using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace useReference
{
    class Program
    {
        class A         //自定义一个类
        {
            public int Value = 0;       //声明一个公共int类型变量并初始化为0；
        }
        static void Main(string[] args)
        {
            int v1 = 0;     //声明int类型变量v1并赋值为0
            int v2 = v1;    //声明int类型变量v2并将v1赋值给v2
            v2 = 927;       //给v2重新赋值为927
            A r1 = new A(); //使用new来新建引用对象
            A r2 = r1;
            r2.Value = 9527;    //设置r2的Value值
            Console.WriteLine("Values:v1:{0}, v2:{1}", v1, v2);//输出v1，v2
            Console.WriteLine("Values:r1:{0}, r2:{1}", r1.Value, r2.Value);//输出引用类型对象的Value
            Console.ReadLine();
        }
    }
}
