// ***********************************************************************
// <copyright file="TextMessageRole.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.Business.MessageRoles
// Author            : 谭志强
// Created          : 2015/8/26 11:24:32
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
    /// <summary>
    /// 文本消息处理
    /// </summary>
    public class TextMessageRole : IMessageRole
    {
        /// <summary>
        /// 文本消息处理器
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
                    throw new ArgumentException("message is null");
                }
                return new TextMessageHandler(string.Empty, msg);
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
