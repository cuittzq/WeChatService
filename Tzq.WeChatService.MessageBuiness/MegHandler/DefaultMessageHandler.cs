// ***********************************************************************
// <copyright file="DefaultMessageHandler.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.Business.MegHandler
// Author            : 谭志强
// Created          : 2015/8/25 11:15:21
// <summary></summary>
// ***********************************************************************

using Common.TxtLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tzq.WeChatService.MessageBuiness
{
    public class DefaultMessageHandler : IMessageHandler
    {

        private static string s_defaultMsg = "欢迎关注全球通旅游平台！！";

        /// <summary>
        /// 消息处理器
        /// </summary>
        private HandleMessage msghander = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="message"></param>
        public DefaultMessageHandler(HandleMessage message)
        {
            this.msghander = message;
        }

        public ResponseMessage HandlerRequestMessage()
        {
            Dictionary<string, object> bugobj = new Dictionary<string, object>();
            try
            {
                if (this.msghander != null)
                {
                    bugobj.Add("消息请求", this.msghander.RequestMessage);
                    return new ResponseTextMessage(this.msghander.RequestMessage)
                    {
                        CreateTime = DateTime.Now.Ticks,
                        Content = s_defaultMsg
                    };
                }
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
            return null;
        }
    }
}
