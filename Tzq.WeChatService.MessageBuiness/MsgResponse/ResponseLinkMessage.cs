// ***********************************************************************
// <copyright file="ResponseLinkMessage.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.Business.MsgResponse
// Author            : 谭志强
// Created          : 2015/8/27 11:34:39
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
    public class ResponseLinkMessage : ResponseMessage
    {
        public ResponseLinkMessage() { }
        public ResponseLinkMessage(RequestMessage request)
            : base(request)
        {
        }

        public override MsgType MsgType
        {
            get { return Model.MsgType.Link; }
        }

        /// <summary>
        /// 消息标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 消息描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 消息链接
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 事件ID
        /// </summary>
        public string MsgId { get; set; }
    }
}
