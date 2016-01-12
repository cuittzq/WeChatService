// ***********************************************************************
// <copyright file="RequestVoiceMessage.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.MessageBuiness.MsgRequests
// Author            : 谭志强
// Created          : 2015/9/2 11:28:01
// <summary></summary>
// ***********************************************************************

using Tzq.WeChatService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Tzq.WeChatService.MessageBuiness
{
    public class RequestVoiceMessage : RequestMessage
    {
        public RequestVoiceMessage(XElement xml)
            : base(xml)
        {
            this.MediaId = xml.Element("MediaId") == null ? string.Empty : xml.Element("MediaId").Value;
            this.Format = xml.Element("Format") == null ? string.Empty : xml.Element("Format").Value;
            this.Recognition = xml.Element("Recognition") == null ? string.Empty : xml.Element("Recognition").Value;
        }

        public override MsgType MsgType
        {
            get { return Model.MsgType.Voice; }
        }

        public string MediaId { get; set; }

        public string Format { get; set; }

        public string Recognition { get; set; }
    }
}
