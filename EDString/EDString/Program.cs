﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace EDString
{
    class Program
    {
        static string encryptKey = "Oyea";
        static void Main(string[] args)
        {
            Console.WriteLine("请输入要加密的字符串：");
            string strOld = Console.ReadLine();
            string strNew = Encrypt(strOld);
            Console.WriteLine("加密后的字符串："+strNew);
            Console.WriteLine("解密后的字符串：" + Decrypt(strNew));
            Console.ReadLine();
        }

        static string Encrypt(string str)
        { 
            DESCryptoServiceProvider descsp=new DESCryptoServiceProvider();//实例化加密解密类对象
            byte[] key =Encoding.Unicode.GetBytes(encryptKey);      //定义字节数组用来存储秘钥
            byte[] data=Encoding.Unicode.GetBytes(str);         //定义字节数组，用来存储要加密的字符串
            MemoryStream MStream=new MemoryStream();            //实例化内存刘对象
            CryptoStream CStream=new CryptoStream(MStream,descsp.CreateEncryptor(key,key),CryptoStreamMode.Write);//使用内存流实例化加密流对象
            CStream.Write(data,0,data.Length);      //向加密流中写入数据
            CStream.FlushFinalBlock();              //释放加密流
            return Convert.ToBase64String(MStream.ToArray());       //返回加密后的字符串
        }
        static string Decrypt(string str)
        {
            DESCryptoServiceProvider descsp = new DESCryptoServiceProvider();//实例化加密解密类对象
            byte[] key = Encoding.Unicode.GetBytes(encryptKey);//定义字节数组用来存储秘钥
            byte[] data = Convert.FromBase64String(str);//定义字节数组，用来存储要解密的字符串
            MemoryStream MStream = new MemoryStream();//实例化内存流对象
            CryptoStream CStream = new CryptoStream(MStream, descsp.CreateDecryptor(key, key), CryptoStreamMode.Write);//使用内存流实例化解密流对象
            CStream.Write(data, 0, data.Length);//向解密流中写入数据
            CStream.FlushFinalBlock(); //释放解密流
            return Encoding.Unicode.GetString(MStream.ToArray());//返回解密后的字符串
        }
    }
}
