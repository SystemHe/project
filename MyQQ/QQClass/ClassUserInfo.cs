using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QQClass
{
    /// <summary>
    /// 该类用于记录当前QQ用户的ID编号，IP地址，端口号，用户名，用户状态等
    /// 并对其进行序列化
    /// </summary>
    /// <summary>
    /// ClassUserInfo 的摘要说明。
    /// </summary>
    [Serializable]
    public class ClassUserInfo
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        private string userID;

        public string UserID
        {
            get { return userID; }
            set { userID = value; }
        }
        /// <summary>
        /// 用户正在登录的主机IP
        /// </summary>
        private string userIP;

        public string UserIP
        {
            get { return userIP; }
            set { userIP = value; }
        }
        /// <summary>
        /// 用户正在登录的主机端口号
        /// </summary>
        private string userPort;

        public string UserPort
        {
            get { return userPort; }
            set { userPort = value; }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        /// <summary>
        /// 当前用户状态
        /// </summary>
        private String state;

        public String State
        {
            get { return state; }
            set { state = value; }
        }

    }
}
