using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FindError
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("请输入内容：");
                int i = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(i);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.ReadLine();
        }
    }
}
