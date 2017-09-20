using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using N1;//调用自己定义的命名空间N1

namespace HalloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            A oa = new A();  //实例化类A
            oa.Myls();   //调用方法
        }
    }
}
namespace N1   //定义命名空间
{
    class A   //自定义类
    {
        public void Myls()   //自定义方法
        {
            Console.WriteLine("hallo world");
            Console.ReadLine();
        }
    }
}
