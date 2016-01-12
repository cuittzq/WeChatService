// ***********************************************************************
// <copyright file="WebMessageRole.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.Business.WeixinAPI
// Author            : 谭志强
// Created          : 2015/8/25 11:05:59
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
    /// 接收微信回调消息
    /// </summary>
    public class WebMessageRole : IMessageRole
    {

        public IMessageHandler MessageRole(HandleMessage msg)
        {
            try
            {
                return new MsgTypeMessageRole().MessageRole(msg);
            }
            catch
            {
                return new DefaultMessageHandler(msg);
            }
        }
    }
}
