﻿/// <summary>
/// 类说明：MD5Helper
/// 编 码 人：苏飞
/// 联系方式：361983679  
/// 更新网站：http://www.sufeinet.com/thread-655-1-1.html
/// </summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpHttpHelper.Helper
{
    /// <summary>
    /// md5操作相关  Copyright：http://www.httphelper.com/
    /// </summary>
    public static  class MD5Helper
    {
        /// <summary>
        /// 传入明文，返回用MD5加密后的字符串
        /// </summary>
        /// <param name="str">要加密的字符串</param>
        /// <returns>MD5加密后的字符串</returns>
        public static string ToMD5_32(string str)
        {
            string passwordFormat = System.Web.Configuration.FormsAuthPasswordFormat.MD5.ToString();
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, passwordFormat);
        }

        /// <summary>
        /// 传入明文，返回用SHA1密后的字符串
        /// </summary>
        /// <param name="str">要加密的字符串</param>
        /// <returns>SHA1加密后的字符串</returns>
        public static string ToSHA1(string str)
        {
            string passwordFormat = System.Web.Configuration.FormsAuthPasswordFormat.SHA1.ToString();
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, passwordFormat);
        }
    }
}
