// ***********************************************************************
// <copyright file="RequestViewEventMessage.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.Business.MsgResponse
// Author            : 谭志强
// Created          : 2015/8/26 10:18:45
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Tzq.WeChatService.MessageBuiness
{
    public class RequestViewEventMessage : RequestEventMessage
    {
        public RequestViewEventMessage(XElement xml)
            : base(xml)
        {
            EventKey = xml.Element("EventKey") == null ? string.Empty : xml.Element("EventKey").Value;
        }

        public string EventKey { get; set; }
    }
}
