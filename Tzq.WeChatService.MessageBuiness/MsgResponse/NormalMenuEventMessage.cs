// ***********************************************************************
// <copyright file="NormalMenuEventMessage.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.Business.MsgResponse
// Author            : 谭志强
// Created          : 2015/8/26 10:36:06
// <summary></summary>
// ***********************************************************************

using Tzq.WeChatService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Tzq.WeChatService.MessageBuiness
{
    [XmlRoot("xml")]
    public class NormalMenuEventMessage : ResponseMessage
    {
        public NormalMenuEventMessage() { }
        public NormalMenuEventMessage(RequestMessage request)
            : base(request)
        {
        }

        public override MsgType MsgType
        {
            get { return Model.MsgType.Event; }
        }

        public string EventKey { get; set; }
    }
}
