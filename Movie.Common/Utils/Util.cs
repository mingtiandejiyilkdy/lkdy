using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Movie.Common.Utils
{
    public class Util
    {
        public static string GetLocalIP()
        {
            string HostName = Dns.GetHostName(); //得到主机名
            IPHostEntry IpEntry = Dns.GetHostEntry(HostName);
            for (int i = 0; i < IpEntry.AddressList.Length; i++)
            {
                //从IP地址列表中筛选出IPv4类型的IP地址
                //AddressFamily.InterNetwork表示此IP为IPv4,
                //AddressFamily.InterNetworkV6表示此地址为IPv6类型
                if (IpEntry.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                {
                    return IpEntry.AddressList[i].ToString();
                }
            }
            return "";
        }



        #region 根据枚举int获取string
        /// <summary>
        /// 根据枚举int获取string
        /// </summary>
        /// <param name="status">int</param>
        /// <param name="enumType">string</param>
        /// <returns></returns>
        public static string getStatus(int status, Type enumType)
        {
            string str = "";
            var dic = EnumHelper.GetEnumDictionary(enumType);
            foreach (var item in dic)
            {
                if (item.Key == status)
                {
                    str = item.Value;
                    break;
                }
            }
            return str;
        }
        #endregion
    }
}
