using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YSFHResult
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] intPers = Jose(100, 3, 49);
            Console.WriteLine("出列顺序：");
            for (int i = 0; i < intPers.Length; i++)
            {
                Console.Write(intPers[i] + " ");
            }
            Console.ReadLine();
        }
        /// <summary>
        /// 约瑟夫环算法问题
        /// </summary>
        /// <param name="total">总人数</param>
        /// <param name="start">开始报数的人</param>
        /// <param name="alter">要出列的人</param>
        /// <returns>返回一个int类型的数组</returns>
        static int[] Jose(int total ,int start,int alter)
        { 
            int j,k=0;
            int[] intCount=new int[total+1];//存储按出列顺序排序的数据，已作为结果返回
            int[] intPers=new int[total+1];//存储初始数据
            for(int i=0;i<total;i++)//对intPars数组赋初值，第一人编号为0，第二人为1，以此类推
            {
                intPers[i]=i;
            }
            for(int i=total;i>=2;i--)//按出列顺序依次存于intCount数组中
            {
                start=(start+alter-1)%i;
                if(start==0)
                {
                    start=i;
                }
                intCount[k]=intPers[start];
                k++;
                for(j=start+1;j<=i;j++)
                {
                    intPers[j-1]=intPers[j];
                }
                intCount[k]=intPers[1];
            }
            return intCount;
        }
    }
}
