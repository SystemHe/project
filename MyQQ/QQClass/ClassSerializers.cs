using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QQClass
{
    /// <summary>
    /// 该类是用SerializerBinary方法和DeSerializerBinary方法在客户端接收或发送消息时，
    /// 将对象序列化为二进制流或将二进制流反序列化为对象
    /// </summary>
    public class ClassSerializers
    {
        public System.IO.MemoryStream SerializerBinary(object request)//将对象序列化为二进制流
        {
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter serializer = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            System.IO.MemoryStream memStream = new System.IO.MemoryStream();//创建一个内存流存储区
            serializer.Serialize(memStream, request);
            return memStream;
        }
        public object DeSerializerBinary(System.IO.MemoryStream memStream)//将二进制流反序列化为对象
        {
            memStream.Position = 0;
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter deserializer = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            object newobj = deserializer.Deserialize(memStream);//将二进制流反序列化为对象
            memStream.Close();          //关闭内存流并释放
            return newobj;
        }
    }
}
