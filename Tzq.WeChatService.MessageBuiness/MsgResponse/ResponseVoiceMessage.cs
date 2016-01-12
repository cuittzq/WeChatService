// ***********************************************************************
// <copyright file="ResponseVoiceMessage.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.MessageBuiness.MsgResponse
// Author            : 谭志强
// Created          : 2015/9/2 11:25:47
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
    public class ResponseVoiceMessage : ResponseMessage
    {
        public ResponseVoiceMessage() { }
        public ResponseVoiceMessage(RequestMessage request)
            : base(request)
        {
        }
        public override MsgType MsgType
        {
            get { return Model.MsgType.Voice; }
        }

        public VoiceMessage Voice { get; set; }
    }
}
