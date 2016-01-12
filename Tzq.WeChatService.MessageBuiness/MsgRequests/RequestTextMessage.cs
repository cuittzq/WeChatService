// ***********************************************************************
// <copyright file="RequestTextMessage.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.Business.MsgRequests
// Author            : 谭志强
// Created          : 2015/8/26 11:26:00
// <summary></summary>
// ***********************************************************************

using Tzq.WeChatService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Tzq.WeChatService.MessageBuiness
{
    [Serializable]
    [XmlRoot("xml", Namespace = "")]
    public class RequestTextMessage : RequestMessage
    {
        public RequestTextMessage() { }

        public RequestTextMessage(XElement xml)
            : base(xml)
        {
            this.Content = xml.Element("Content").Value;
        }

        public override MsgType MsgType
        {
            get { return MsgType.Text; }
        }

        [XmlIgnore]
        public string Content { get; set; }

        [XmlElement("Content")]
        public XmlCDataSection CContent
        {
            get
            {
                return doc.CreateCDataSection(Content.ToString());
            }
            set
            {
                Content = value.Value;
            }
        }
    }
}
