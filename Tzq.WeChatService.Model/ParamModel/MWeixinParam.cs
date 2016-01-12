// ***********************************************************************
// <copyright file="MWeixinParam.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.Model
// Author            : 谭志强
// Created          : 2015/7/27 9:24:21
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tzq.WeChatService.Model
{
    /// <summary>
    /// 微信参数
    /// </summary>
    public class MWeixinParam
    {
        /// <summary>
        /// 初始化微信参数
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        public MWeixinParam(string appId, string appSecret)
        {
            this.AppID = appId;
            this.AppSecret = appSecret;
        }

        /// <summary>
        /// AppID
        /// </summary>
        public string AppID { get; set; }

        /// <summary>
        /// AppSecret
        /// </summary>
        public string AppSecret { get; set; }
    }
}
