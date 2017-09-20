using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDBHArith
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("输入一个大于6的偶数：");
            int Num = Convert.ToInt32(Console.ReadLine());
            bool blFlag = IsGDBHArith(Num);
            if (blFlag)     //符合哥德巴赫猜想
            {
                Console.WriteLine("{0}能写出两个素数的和，符合哥德巴赫猜想。", Num);
            }
            else
            {
                Console.WriteLine("猜想错误！！");
            }
            Console.ReadLine();
        }


        static bool IsPrimeNumber(int Num)
        {
            int intFlag;
            bool blFlag=true;   //标识是否是素数
            if(Num==1||Num==2)  //判断输入的数是不是1或2
                blFlag=true;    //是素数
            else 
            {
                int sqr = (int)Math.Ceiling(Math.Sqrt(Convert.ToDouble(Num)));//对输入的数进行开方
                for(int i=sqr;i>=2;i--)
                {
                    intFlag = Convert.ToInt32(Math.IEEERemainder(Num, i));
                    if(intFlag==0)    //循环取余，若余数为0，则跳出循环，不是素数
                    {
                        blFlag=false;
                    }
                }
            }
            return blFlag;      //返回是否为素数，true:是素数，false:不是素数
        }

        static bool IsGDBHArith(int Num)
        { 
            bool blFlag=false;
            if(Num%2==0&&Num>6)     //判断输入的数为大于6的偶数
                for(int i=1;i<=Num/2;i++)
                {
                    bool bl1=IsPrimeNumber(i);  //判断i是否是素数
                    bool bl2=IsPrimeNumber(Num-i);  //判断num-i是不是素数
                    if(bl1&bl2)     //两个数都是素数
                    {
                        Console.WriteLine("{0}={1}+{2}",Num,i,Num-i);   //输出结果
                        blFlag=true; //符合哥德巴赫猜想
                    }
                }
            return blFlag;  //返回是否符合哥德巴赫猜想
        }

    }

}
