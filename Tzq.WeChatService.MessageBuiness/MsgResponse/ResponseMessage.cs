// ***********************************************************************
// <copyright file="ResponseMessage.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.Model.MsgResponse
// Author            : 谭志强
// Created          : 2015/8/25 10:43:32
// <summary></summary>
// ***********************************************************************

using Tzq.WeChatService.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Tzq.WeChatService.MessageBuiness
{
    /// <summary>
    /// 消息响应
    /// </summary>
    [Serializable]
    [XmlRoot("xml")]
    public abstract class ResponseMessage : WXMessage
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public ResponseMessage() { }

        /// <summary>
        /// 带参构造函数
        /// </summary>
        /// <param name="request">请求实体</param>
        public ResponseMessage(RequestMessage request)
        {
            this.FromUserName = request != null ? request.ToUserName : string.Empty;
            this.ToUserName = request != null ? request.FromUserName : string.Empty;
        }

        /// <summary>
        /// 消息类型
        /// </summary>
        public override MsgType MsgType
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public String Serializable()
        {
            var sw = new StringWriter();
            var xmlSerializer = new XmlSerializer(this.GetType());
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            xmlSerializer.Serialize(sw, this, ns);

            return sw.ToString();
        }
    }
}
