// ***********************************************************************
// <copyright file="ResponseNewsMessage.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.Business.MsgResponse
// Author            : 谭志强
// Created          : 2015/8/27 12:09:00
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
    /// <summary>
    /// 图文消息
    /// </summary>
    [XmlRoot("xml")]
    public class ResponseNewsMessage : ResponseMessage
    {
        public ResponseNewsMessage() { }
        public ResponseNewsMessage(RequestMessage request)
            : base(request)
        {
        }
        public override MsgType MsgType
        {
            get { return Model.MsgType.News; }
        }

        public int ArticleCount { get; set; }

        [XmlArrayItem("item")]
        public List<ArticleMessage> Articles { get; set; }
    }
}
