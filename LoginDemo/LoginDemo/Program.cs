using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoginDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入账号：");
            string name = Console.ReadLine();
            Console.WriteLine("请输入密码：");
            string pwd = Console.ReadLine();
            bool beLogin = (name == "qq" & pwd == "123");
            string islogin=beLogin?"登录成功":"登录失败";
            Console.WriteLine(islogin);
            Console.ReadLine();
        }
    }
}
