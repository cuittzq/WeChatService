// ***********************************************************************
// <copyright file="IMessageRole.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.Business.WeixinAPI
// Author            : 谭志强
// Created          : 2015/8/25 10:56:34
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
    /// 消息角色处理接口
    /// </summary>
    public interface IMessageRole
    {
        /// <summary>
        /// 按消息类型处理消息
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        IMessageHandler MessageRole(HandleMessage message);
    }
}
