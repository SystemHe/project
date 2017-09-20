using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EightQueenDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            int size;
            Console.WriteLine("请输入棋盘大小：");
            size = Convert.ToInt32(Console.ReadLine());
            QueenArithmetic(size);
        }
        static void QueenArithmetic(int size)
        {
            int[] queen = new int[size];	//每行皇后的位置
            int y, x, i, j, d, t = 0;
            y = 0;		//y用来标记结束点
            queen[0] = -1;     //设置初始位置
            while (true) 	//使用while语句循环检索皇后位置
            {
                for (x = queen[y] + 1; x < size; x++)
                {
                    for (i = 0; i < y; i++)
                    {
                        j = queen[i];	//调整皇后位置
                        d = y - i;
                        if ((j == x) || (j == x - d) || (j == x + d)) 	//检查新皇后是否与前面的冲突
                        {
                            break;
                        }
                    }
                    if (i >= y)	//不冲突
                    {
                        break;
                    }
                }
                if (x == size)		//没有合适的位置
                {
                    if (0 == y)
                    {
                        Console.WriteLine("结束");		//回溯到第一行
                        break;						//结束
                    }
                    queen[y] = -1;					//回溯
                    y--;
                }
                else
                {
                    queen[y] = x;				//确定皇后的位置
                    y++;						//下一个皇后
                    if (y < size)
                    {
                        queen[y] = -1;
                    }
                    else
                    {
                        Console.WriteLine("\n" + ++t + ':');	//所有皇后排完后输出
                        for (i = 0; i < size; i++)
                        {
                            for (j = 0; j < size; j++)
                                Console.Write(queen[i] == j ? 'Q' : '*');		//输出皇后位置
                            Console.WriteLine();
                        }
                        y = size - 1;				//回溯
                    }
                }

            }
            Console.ReadLine();
        }
    }
}
