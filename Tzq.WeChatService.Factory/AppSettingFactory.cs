// ***********************************************************************
// <copyright file="AppSettingFactory.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.Factory
// Author            : 谭志强
// Created          : 2015/7/27 9:55:56
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tzq.WeChatService.Factory
{
    /// <summary>
    /// 程序参数设置工厂
    /// </summary>
    public class AppSettingFactory
    {

        /// <summary>
        /// AppID
        /// </summary>
        /// <returns></returns>
        public static string GetAppID()
        {
            return getAppSettings("AppID");
        }

        /// <summary>
        /// AppID
        /// </summary>
        /// <returns></returns>
        public static string GetAppSecret()
        {
            return getAppSettings("AppSecret");
        }

        /// <summary>
        /// 获取回调地址
        /// </summary>
        /// <returns></returns>
        public static string GetBackDomain()
        {
            return getAppSettings("BackDomain");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetWeixinID()
        {
            return getAppSettings("WeixinID");
        }
        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="keyname"></param>
        /// <returns></returns>
        private static string getAppSettings(string keyname)
        {
            if (ConfigurationManager.AppSettings.AllKeys.Contains(keyname))
            {
                return ConfigurationManager.AppSettings[keyname];
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
