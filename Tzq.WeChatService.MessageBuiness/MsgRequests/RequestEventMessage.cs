// ***********************************************************************
// <copyright file="RequestEventMessage.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.Business.MsgRequests
// Author            : 谭志强
// Created          : 2015/8/25 10:30:58
// <summary></summary>
// ***********************************************************************

using Tzq.WeChatService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Tzq.WeChatService.MessageBuiness
{
    /// <summary>
    /// 事件消息
    /// </summary>
    public class RequestEventMessage : RequestMessage
    {
        public RequestEventMessage(XElement xml)
            : base(xml)
        {
            this.Event = (Model.Event)Enum.Parse(typeof(Model.Event), xml.Element("Event").Value, true);
        }

        /// <summary>
        /// 事件类型
        /// </summary>
        public Event Event { get; set; }

        /// <summary>
        /// 消息类型
        /// </summary>
        public override MsgType MsgType
        {
            get { return MsgType.Event; }
        }
    }
}
