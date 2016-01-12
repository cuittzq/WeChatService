// ***********************************************************************
// <copyright file="RequestMessage.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.Business.MsgRequests
// Author            : 谭志强
// Created          : 2015/8/25 10:28:14
// <summary></summary>
// ***********************************************************************

using Common.TxtLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Tzq.WeChatService.MessageBuiness
{
    [Serializable]
    public abstract class RequestMessage : WXMessage
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public RequestMessage() { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="xml">消息主体</param>
        public RequestMessage(XElement xml)
        {
            Dictionary<string, object> bugobj = new Dictionary<string, object>();
            try
            {
                bugobj.Add("消息主体", xml);
                this.FromUserName = xml.Element("FromUserName").Value;
                bugobj.Add("FromUserName", this.FromUserName);
                this.ToUserName = xml.Element("ToUserName").Value;
                bugobj.Add("ToUserName", this.ToUserName);
                this.CreateTime = Int64.Parse(xml.Element("CreateTime").Value);
                bugobj.Add("CreateTime", this.CreateTime);
                this.MsgId = xml.Element("MsgId") != null ? Int64.Parse(xml.Element("MsgId").Value) : 0;
                bugobj.Add("MsgId", this.MsgId);
            }
            catch (Exception ex)
            {
                TxtLogHelper.WriteLog_Day(new TxtLogInfoObject()
                {
                    LogType = EnumLogType.Error,
                    LogMessage = string.Format("错误信息{0}；堆栈信息{1}", ex.Message, ex.StackTrace),
                    LogObject = ex
                });
            }
            finally
            {
                TxtLogHelper.WriteDebugLog(bugobj);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static T Deserializ<T>(Stream stream)
            where T : RequestMessage
        {
            var xs = new XmlSerializer(typeof(T));
            return (T)xs.Deserialize(stream);
        }

        /// <summary>
        /// 消息ID
        /// </summary>
        [XmlElement("MsgId")]
        public long MsgId { get; set; }
    }
}
