using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QQClass
{
    /// <summary>
    /// 该类主要用于将服务器端所有注册的用户信息存储到Base类的Innerlist列表中
    /// 这样当用户注册或登录时，便可以将列表中的信息群发给当前在线的所有用户
    /// 以改变QQ窗体中的显示状态
    /// </summary>
    [Serializable]
    public class ClassUsers : System.Collections.CollectionBase
    {
        public void Add(ClassUserInfo userInfo)
        {
            base.InnerList.Add(userInfo);       //在列表中添加用户信息
        }
        public void Remove(ClassUserInfo userInfo)
        {
            base.InnerList.Remove(userInfo);    //在列表中移除指定的用户信息
        }
        public ClassUserInfo this[int index]    //根据索引号在列表中查找指定的用户信息
        {
            get { return ((ClassUserInfo)List[index]); }
            set { List[index] = value; }
        }
    }
}
