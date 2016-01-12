// ***********************************************************************
// <copyright file="IMessageHandler.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.Business.WeixinAPI
// Author            : 谭志强
// Created          : 2015/8/25 10:56:54
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tzq.WeChatService.MessageBuiness
{
    /// <summary>
    /// 消息处理接口
    /// </summary>
    public interface IMessageHandler
    {
        /// <summary>
        /// 处理消息 接口方法
        /// </summary>
        /// <returns></returns>
        ResponseMessage HandlerRequestMessage();
    }
}
