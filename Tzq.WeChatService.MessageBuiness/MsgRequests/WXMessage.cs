// ***********************************************************************
// <copyright file="WXMessage.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.Business.MsgRequests
// Author            : 谭志强
// Created          : 2015/8/25 10:24:53
// <summary></summary>
// ***********************************************************************

using Newtonsoft.Json;
using Tzq.WeChatService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Tzq.WeChatService.MessageBuiness
{
    /// <summary>
    /// 微信消息基类
    /// </summary>
    [Serializable]
    public abstract class WXMessage
    {
        /// <summary>
        /// 消息体XML
        /// </summary>
        protected XmlDocument doc = new XmlDocument();

        /// <summary>
        /// 开发者微信号
        /// </summary>
        [XmlIgnore]
        public string ToUserName { get; set; }

        /// <summary>
        /// 发送方帐号（一个OpenID）
        /// </summary>
        [XmlIgnore]
        public string FromUserName { get; set; }

        /// <summary>
        /// 消息创建时间 （整型）
        /// </summary>
        [XmlElement("CreateTime")]
        public long CreateTime { get; set; }

        /// <summary>
        /// 消息类型
        /// </summary>
        public abstract MsgType MsgType { get; }

        /// <summary>
        /// MsgType 节点值
        /// </summary>
        [XmlElement("MsgType")]
        public XmlCDataSection CMsgType
        {
            get
            {
                return doc.CreateCDataSection(MsgType.ToString().ToLower());
            }
            set { ;}
        }

        /// <summary>
        /// ToUserName 节点值
        /// </summary>
        [XmlElement("ToUserName")]
        public XmlCDataSection CToUserName
        {
            get
            {
                return doc.CreateCDataSection(ToUserName);
            }
            set
            {
                ToUserName = value.Value;
            }
        }

        /// <summary>
        /// FromUserName 节点值
        /// </summary>
        [XmlElement("FromUserName")]
        public XmlCDataSection CFromUserName
        {
            get
            {
                return doc.CreateCDataSection(FromUserName);
            }
            set
            {
                FromUserName = value.Value;
            }
        }
    }
}
