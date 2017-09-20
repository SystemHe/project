using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringOperations
{
    class Program
    {
        /// <summary>
        /// 字符串操作
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            
            //Compare();//用Compare()方法比较字符串
            //CompareTo();//使用CompareTo()方法比较字符串
            //Equals();//用Equals()方法比较字符串
            //Format();//格式化字符串
            //DateTimes();//格式化日期数据
            //Substrings();//截取字符串
            //Splits();//分割字符串
            //Inserts();//插入字符串
            //PadLeftAndRight();//填充字符串
            //Removes();//删除字符串
            //Copys();//复制字符串
            //CopyTo();//复制字符串
            Replace();//替换字符串

        }

        #region 用Compare()方法比较字符串
        /// <summary>
        /// 用Compare()方法比较字符串
        /// </summary>
        public static void Compare()
        {
            string strA = "东莞领益";
            string strB = "领益科技";
            Console.WriteLine("使用Compare()方法进行比较：");
            Console.WriteLine("strA和strB比较："+string.Compare(strA, strB));
            Console.WriteLine("strA和strA比较："+string.Compare(strA, strA));
            Console.WriteLine("strB和strA比较："+string.Compare(strB, strA));
            Console.ReadLine();
        }
        #endregion

        #region 使用CompareTo()方法比较字符串
        /// <summary>
        /// 使用CompareTo()方法比较字符串
        /// </summary>
        public static void CompareTo()
        {
            string strA = "东莞领益";
            string strB = "领益科技";
            Console.WriteLine("使用CompareTo()方法进行比较：");
            Console.WriteLine("strA和strB比较：" + strA.CompareTo(strB));
            Console.WriteLine("strA和strA比较：" + strA.CompareTo(strA));
            Console.WriteLine("strB和strA比较：" + strB.CompareTo(strA));
            Console.ReadLine();
        }
        #endregion

        #region 用Equals()方法比较字符串
        /// <summary>
        /// 用Equals()方法比较字符串
        /// </summary>
        public static void Equals()
        {
            string strA = "东莞领益";
            string strB = "领益科技";
            Console.WriteLine("使用Equals()方法进行比较：");
            Console.WriteLine(strA.Equals(strB));
            Console.WriteLine(string.Equals(strA, strB));
            Console.ReadLine();
        }
        #endregion

        #region Format()格式化字符串
        /// <summary>
        /// 格式化字符串
        /// </summary>
        public static void Format()
        {
            string strA = "东莞领益";
            string strB = "领益科技";
            Console.WriteLine("使用Format()方法格式化字符串：");
            string strC=string.Format("{0},{1}", strA, strB);
            Console.WriteLine(strC);
            Console.ReadLine();
        }
        #endregion

        #region Format()格式化日期时间数据
        /// <summary>
        /// 格式化日期时间数据
        /// </summary>
        public static void DateTimes()  
        {
            DateTime dt = DateTime.Now;
            Console.WriteLine("格式化时间数据：");
            string str1 = string.Format("{0:D}", dt);
            string str2 = string.Format("{0:T}", dt);
            string str3 = string.Format("{0:F}", dt);
            string str4 = string.Format("{0:G}", dt);
            Console.WriteLine("完整日期格式："+str1);
            Console.WriteLine("完整时间格式："+str2);
            Console.WriteLine("完整日期/时间格式："+str3);
            Console.WriteLine("完整的可排序的日期/时间格式："+str4);
            Console.ReadLine();
        }
        #endregion

        #region Substring()截取字符串
        /// <summary>
        /// 截取字符串
        /// </summary>
        public static void Substrings()
        {
            string strA = "好好学习，天天向上";
            string strB;
            strB = strA.Substring(1, 4);
            Console.WriteLine("截取前的字符串：" + strA);
            Console.WriteLine("截取后的字符串：" + strB);
            Console.ReadLine();
        }
        #endregion

        #region 使用Split()分割字符串
        /// <summary>
       /// 
       /// </summary>
        public static void Splits()
        {
            string strA = "好好学习,天天向上";
            string[] strB = new string[100];
            char[] sp = { ',' };
            strB = strA.Split(sp);
            Console.WriteLine("原字符串：" + strA);
            Console.Write("分隔符：");
            for (int i = 0; i < sp.Length; i++)
            {
                Console.Write(sp[i]+" ");
            }
            Console.WriteLine();
            for (int i = 0; i < strB.Length; i++)
            {
                Console.WriteLine("第{0}项：{1}",i,strB[i]);
            }
            Console.ReadLine();
        }
        #endregion

        #region 使用insert()插入字符串
        /// <summary>
        /// 使用insert()插入字符串
        /// </summary>
        public static void Inserts()
        {
            string str1 = "科技";
            string str2 = str1.Insert(0,"东莞");
            string str3=str2.Insert(2,"领益");
            Console.WriteLine("原始：" + str1);
            Console.WriteLine("第一次插入：" + str2);
            Console.WriteLine("第二次插入："+str3);
            Console.ReadLine();
        }
        #endregion

        #region 使用PadLeft()和PadRight()填充字符串
        /// <summary>
        /// 使用PadLeft()和PadRight()填充字符串
        /// </summary>
        public static void PadLeftAndRight()
        {
            string str1 = "*^_^*";
            string str2 = str1.PadLeft(6, '(');
            string str3 = str2.PadRight(7, ')');
            Console.WriteLine("填充之前的字符串：" + str1);
            Console.WriteLine("填充之后的字符串：" + str3);
            Console.ReadLine();
        }
        #endregion

        #region 使用Remove()删除字符串
        /// <summary>
        /// 使用Remove()删除字符串
        /// </summary>
        public static void Removes()
        {
            string str1 = "好好学习，天天向上！";
            string str2 = str1.Remove(2, 3);
            string str3 = str1.Remove(4);
            Console.WriteLine("原始字符串：" + str1);
            Console.WriteLine("从第三个字符开始删除后面的三个字符：" + str2);
            Console.WriteLine("删除第5个字符开始到最后的全部的字：" + str3);
            Console.ReadLine();
        }
        #endregion

        #region 使用Copy()复制字符串
        /// <summary>
        /// 使用Copy()复制字符串
        /// </summary>
        public static void Copys()
        {
            string strA = "好好学习,天天向上！";
            string strB;
            strB = string.Copy(strA);
            Console.WriteLine("原字符串："+strA);
            Console.WriteLine("复制的字符串：" + strB);
            Console.ReadLine();
        }
        #endregion

        #region 使用CopyTo()复制字符串
        /// <summary>
        /// 使用CopyTo()复制字符串
        /// </summary>
        public static void CopyTo()
        {
            string str1 = "好好学习,天天向上!";
            char[] char1=new char[4];
            str1.CopyTo(2, char1, 0, 4);
            Console.WriteLine(char1);
            Console.ReadLine();
        }
        #endregion

        #region 使用Replace()替换字符串
        /// <summary>
        /// 使用Replace()替换字符串
        /// </summary>
        public static void Replace()
        {
            string str1 = "好好!学习，天天!向上！";
            string str2 = str1.Replace('!', '*');
            string str3=str1.Replace("学习","工作");
            Console.WriteLine("原始字符串：" + str1);
            Console.WriteLine("替换字符后的字符串：" + str2);
            Console.WriteLine("替换字符串后的字符串：" + str3);
            Console.ReadLine();
        }
        #endregion
    }
}
