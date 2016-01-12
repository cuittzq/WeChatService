// ***********************************************************************
// <copyright file="EventMessageRole.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.Business.WeixinAPI
// Author            : 谭志强
// Created          : 2015/8/25 11:07:34
// <summary></summary>
// ***********************************************************************

using Common.TxtLog;
using Tzq.WeChatService.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tzq.WeChatService.MessageBuiness
{
    /// <summary>
    /// 事件消息处理器
    /// </summary>
    public class EventMessageRole : IMessageRole
    {
        /// <summary>
        /// 事件消息处理
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public IMessageHandler MessageRole(HandleMessage msg)
        {
            Dictionary<string, object> bugobj = new Dictionary<string, object>();
            try
            {
                if (msg == null)
                {
                    throw new ArgumentException("msg is null");
                }
                var eventType = (Event)Enum.Parse(typeof(Event), msg.Element.Element("Event").Value, true);
                IMessageHandler imessageHandler = null;
                switch (eventType)
                {
                    case Event.Subscribe:
                        imessageHandler = new SubScribeEventMessageHandler(msg);
                        break;
                    case Event.Unsubscribe:
                        imessageHandler = new UnSubScribeEventMessageHandler(msg);
                        break;
                    case Event.Scan:
                        imessageHandler = new ScanEventMessageHandler(msg);
                        break;
                    case Event.Location:
                        break;
                    case Event.Click:
                        imessageHandler = new ClickEventMessageHandler(msg);
                        break;
                    case Event.MASSSENDJOBFINISH:
                        break;
                    case Event.View:
                        imessageHandler = new ViewEventMessageHandler(msg);
                        break;
                    case Event.Merchant_Order:
                        break;
                    case Event.TEMPLATESENDJOBFINISH:
                        break;
                    default:
                        imessageHandler = new DefaultMessageHandler(msg);
                        break;
                }


                return imessageHandler;
            }
            catch (Exception ex)
            {
                TxtLogHelper.WriteLog_Day(new TxtLogInfoObject()
                {
                    LogType = EnumLogType.Error,
                    LogMessage = string.Format("错误信息{0}；堆栈信息{1}", ex.Message, ex.StackTrace),
                });
            }
            finally
            {
                TxtLogHelper.WriteDebugLog(bugobj);
            }
            return new DefaultMessageHandler(msg);
        }
    }
}
