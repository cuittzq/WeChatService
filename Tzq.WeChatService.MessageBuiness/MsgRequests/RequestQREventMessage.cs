// ***********************************************************************
// <copyright file="RequestQREventMessage.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.Business.MsgRequests
// Author            : 谭志强
// Created          : 2015/8/25 10:32:37
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
    /// <summary>
    /// 扫描带参数的二维码
    /// </summary>
    public class RequestQREventMessage : RequestEventMessage
    {
        public RequestQREventMessage(XElement xml)
            : base(xml)
        {
            this.EventKey = xml.Element("EventKey") != null ? xml.Element("EventKey").Value : string.Empty;
            this.Ticket = xml.Element("Ticket") != null ? xml.Element("Ticket").Value : string.Empty;
        }

        public string EventKey { get; set; }

        public string Ticket { get; set; }
    }
}
