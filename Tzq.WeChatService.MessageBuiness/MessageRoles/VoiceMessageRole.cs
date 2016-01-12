// ***********************************************************************
// <copyright file="VoiceMessageRole.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.MessageBuiness.MessageRoles
// Author            : 谭志强
// Created          : 2015/9/2 11:30:35
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
    public class VoiceMessageRole : IMessageRole
    {
        public IMessageHandler MessageRole(HandleMessage message)
        {
            Dictionary<string, object> bugobj = new Dictionary<string, object>();
            try
            {
                if (message == null)
                {
                    throw new ArgumentException("message is null");
                }
                return new VoiceMessageHandler(message);
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

            return new DefaultMessageHandler(message);
        }
    }
}
