using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Xml;

namespace SelectIDAndName
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable MyHashTable = SelectXML("BroadCastInfo.xml");
            IDictionaryEnumerator IDEnumerator = MyHashTable.GetEnumerator();
            Console.WriteLine("电台地址             电台名称");
            while (IDEnumerator.MoveNext())
            {
                Console.WriteLine(IDEnumerator.Key.ToString() + "        " + IDEnumerator.Value.ToString());
            }
            Console.ReadLine();
        }
        /// <summary>
        /// 查找XML文件中的电台地址和名称
        /// </summary>
        /// <param name="strPath">XMl文件路径</param>
        /// <returns>HashTable对象，用来记录查询到的信息</returns>
        static Hashtable SelectXML(string strPath)
        { 
            Hashtable Htable=new Hashtable();//实例化哈希表对象
            XmlDocument doc=new XmlDocument();//实例化xml文档对象
            doc.Load(strPath);              //加载xml文档
            XmlNodeList xnl=doc.SelectSingleNode("BCastInfo").ChildNodes;//获取newDataSet节点的所有子节点
            string strVersion="";   //定义一个字符串，用来记录电台网址
            string strInfo="";      //定义一个字符串，用来记录电台名称
            foreach(XmlNode xn in xnl)  //遍历所有子节点
            {
                XmlElement xe=(XmlElement)xn;//将子节点转换为XMLElement类型
                if(xe.Name=="DInfo")        //判断字节名是否为DInfo
                {
                    XmlNodeList xnlChild=xe.ChildNodes;     //继续获取xe子节点的所有子节点
                    foreach(XmlNode xnChild in xnlChild)    //遍历
                    {
                        XmlElement xeChild=(XmlElement)xnChild;//转换类型
                        if(xeChild.Name=="Address")
                        {
                            strVersion=xeChild.InnerText;   //记录电台网址
                        }
                        if(xeChild.Name=="Name")
                        {
                            strInfo=xeChild.InnerText;      //记录电台名称
                        }
                    }
                    Htable.Add(strVersion,strInfo);         //向哈希表中添加键值
                }
            }
            return Htable; 
        }
    }
}
