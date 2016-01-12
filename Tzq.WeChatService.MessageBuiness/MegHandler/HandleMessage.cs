// ***********************************************************************
// <copyright file="HandleMessage.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.Business.WeixinAPI
// Author            : 谭志强
// Created          : 2015/8/25 10:38:21
// <summary></summary>
// ***********************************************************************

using Common.TxtLog;
using Tzq.WeChatService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Tzq.WeChatService.MessageBuiness
{
    /// <summary>
    /// 消息处理封装（不可继承该类）
    /// </summary>
    public sealed class HandleMessage
    {
        /// <summary>
        ///消息处理构造函数
        /// </summary>
        /// <param name="element">消息实体</param>
        public HandleMessage(XElement element)
        {
            Dictionary<string, object> bugobj = new Dictionary<string, object>();
            try
            {
                if (element == null)
                {
                    throw new ArgumentNullException("element is null");
                }
                bugobj.Add("element", element.ToString());
                this.Element = element;
                this.RequestMessage = GetRequestMessageByElement(element);
                bugobj.Add("RequestMessage", this.RequestMessage);
            }
            catch (Exception ex)
            {
                this.Log(ex);
            }
            finally
            {
                TxtLogHelper.WriteDebugLog(bugobj);
            }
        }

        /// <summary>
        /// 消息类型分发器
        /// </summary>
        /// <param name="element">消息实体</param>
        /// <returns></returns>
        private RequestMessage GetRequestMessageByElement(XElement element)
        {
            Dictionary<string, object> bugobj = new Dictionary<string, object>();
            RequestMessage requestMessage = null;
            try
            {
                bugobj.Add("element", element);
                bugobj.Add("MsgType", element.Element("MsgType").Value);
                MsgType msgType = (MsgType)Enum.Parse(typeof(MsgType), element.Element("MsgType").Value, true);
                switch (msgType)
                {
                    case MsgType.Text:
                        requestMessage = new RequestTextMessage(element);
                        break;
                    case MsgType.Video:
                        //  requestMessage = new RequestVoiceMessage(element);
                        break;
                    case MsgType.Voice:
                        requestMessage = new RequestVoiceMessage(element);
                        break;
                    case MsgType.Image:
                        // return new RequestImageMessage(element);
                        break;
                    case MsgType.Link:
                        // return new RequestLinkMessage(element);
                        break;
                    case MsgType.Location:
                        //  return new RequestLocationMessage(element);
                        break;
                    case MsgType.Event:
                        requestMessage = GetEventRequestMessage(element);
                        break;
                    //default:
                    //    throw new ArgumentException("msgType is error");
                }
            }
            catch (Exception ex)
            {
                this.Log(ex);
            }
            finally
            {
                TxtLogHelper.WriteDebugLog(bugobj);
            }

            return requestMessage;
        }

        /// <summary>
        /// 事件消息解析器
        /// </summary>
        /// <param name="element">消息实体</param>
        /// <returns></returns>
        private RequestMessage GetEventRequestMessage(XElement element)
        {
            Dictionary<string, object> bugobj = new Dictionary<string, object>();
            RequestMessage requestMessage = null;
            try
            {
                if (element == null)
                {
                    return null;
                }
                var eventType = (Event)Enum.Parse(typeof(Event), element.Element("Event").Value, true);
                bugobj.Add("eventType", eventType);
                bugobj.Add("element", element);
                switch (eventType)
                {
                    case Event.Unsubscribe:
                        return new RequestEventMessage(element);
                    case Event.Location:
                        //  return new RequestLocationEventMessage(element);
                        break;
                    case Event.Click:
                        requestMessage = new RequestClickEventMessage(element);
                        break;
                    case Event.Scan:
                        requestMessage = new RequestQREventMessage(element);
                        break;
                    case Event.Subscribe:
                        requestMessage = GetSubscribeRequestMessageForQR(element);
                        break;
                    case Event.View:
                        requestMessage = new RequestViewEventMessage(element);
                        break;
                    //default:
                    //    throw new ArgumentException("event type is error");
                }
            }
            catch (Exception ex)
            {
                this.Log(ex);
            }
            finally
            {
                TxtLogHelper.WriteDebugLog(bugobj);
                TxtLogHelper.WriteLog_Hour(new TxtLogInfoObject()
                {
                    LogMessage = "消息实体",
                    LogObject = requestMessage,
                    LogType = EnumLogType.Other
                });
            }

            return requestMessage;
        }

        /// <summary>
        /// 处理未关注的带参数二维码扫描事件
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        private RequestMessage GetSubscribeRequestMessageForQR(XElement element)
        {
            Dictionary<string, object> bugobj = new Dictionary<string, object>();
            try
            {
                bugobj.Add("处理未关注的带参数二维码扫描事件", element);
                bugobj.Add("Ticket", element.Element("Ticket"));
                if (element.Element("Ticket") != null)
                {
                    return new RequestQREventMessage(element);
                }
            }
            catch (Exception ex)
            {
                this.Log(ex);
            }
            finally
            {
                TxtLogHelper.WriteDebugLog(bugobj);
            }
            return new RequestEventMessage(element);
        }

        /// <summary>
        /// 消息响应
        /// </summary>
        public ResponseMessage ResponseMeesage { get; private set; }

        /// <summary>
        /// 消息请求
        /// </summary>
        public RequestMessage RequestMessage { get; private set; }

        /// <summary>
        /// 消息主体
        /// </summary>
        public XElement Element { get; private set; }

        /// <summary>
        /// 记录异常
        /// </summary>
        /// <param name="ex"></param>
        public void Log(Exception ex)
        {
            TxtLogHelper.WriteLog_Day(new TxtLogInfoObject()
            {
                LogType = EnumLogType.Error,
                LogMessage = string.Format("错误信息{0}；堆栈信息{1}", ex.Message, ex.StackTrace),
            });
        }
    }
}
