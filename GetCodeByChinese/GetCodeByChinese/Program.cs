using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetCodeByChinese
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("请输入要查找的汉字：");
                String strChinese = Console.ReadLine();//定义一个字符串，记录输入的汉字
                byte[] array = new byte[2];//定义一个数组，用于存储的汉字
                array = Encoding.Default.GetBytes("" + strChinese + "");//为字节数组赋值
                int front = (short)(array[0] - '\0');//将字节数组的第一位转换为int类型
                int back = (short)(array[1] - '\0');//将字节数据的第二位转换为int类型
                Console.WriteLine(Convert.ToString(front-160)+(back-160).ToString("00"));//计算区位码并输出
            }
        }
    }
}
