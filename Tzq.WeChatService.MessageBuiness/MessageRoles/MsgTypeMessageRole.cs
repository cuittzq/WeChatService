// ***********************************************************************
// <copyright file="MsgTypeMessageRole.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.Business.WeixinAPI
// Author            : 谭志强
// Created          : 2015/8/25 11:06:39
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
    /// 按消息角色分发消息
    /// </summary>
    public class MsgTypeMessageRole : IMessageRole
    {
        /// <summary>
        /// 事件消息队列
        /// </summary>
        private static List<BaseMessage> messageQueue = null;

        /// <summary>
        /// 消息分类处理
        /// </summary>
        /// <param name="msg">消息处理器</param>
        /// <returns></returns>
        public IMessageHandler MessageRole(HandleMessage msg)
        {
            Dictionary<string, object> bugobj = new Dictionary<string, object>();
            bugobj.Add("消息分类处理", "消息分类处理");
            try
            {
                bugobj.Add("消息请求", msg.RequestMessage);
                if (msg.RequestMessage == null)
                {
                    return null;
                }

                bugobj.Add("消息去重", "消息去重");
                #region 消息去重
                if (messageQueue == null)
                {
                    messageQueue = new List<BaseMessage>();
                }
                else if (messageQueue.Count >= 50)
                {
                    //保留10秒内未响应的消息
                    messageQueue = messageQueue.Where(q => { return q.CreateTime.AddSeconds(10) > DateTime.Now; }).ToList();
                    bugobj.Add("保留10秒内未响应的消息", messageQueue);
                }
                bugobj.Add("MsgType", msg.RequestMessage.MsgType);
                bugobj.Add("MsgId", msg.RequestMessage.MsgId.ToString());
                bugobj.Add("FromUserName", msg.RequestMessage.FromUserName);
                // 判断当前请求是否已经在队列里面。如果在里面就不做处理,如果当前请求不再队列里面则加入队列并进行接下来的处理
                string msgFlag = msg.RequestMessage.CreateTime.ToString();
                bugobj.Add("当前消息唯一标识", msgFlag);
                if (messageQueue.Find(m => m.MsgFlag == msgFlag && m.FromUser == msg.RequestMessage.FromUserName) == null)
                {
                    messageQueue.Add(new BaseMessage
                    {
                        CreateTime = DateTime.Now,
                        FromUser = msg.RequestMessage.FromUserName,
                        MsgFlag = msgFlag
                    });

                    bugobj.Add("添加当前消息到消息队列中", messageQueue.Last());
                }
                else
                {
                    bugobj.Add("当前消息已经处理过", msgFlag);
                    return null;
                }

                #endregion
                switch (msg.RequestMessage.MsgType)
                {
                    case MsgType.Text:
                        return new TextMessageRole().MessageRole(msg);
                    case MsgType.Event:
                        return new EventMessageRole().MessageRole(msg);
                    case MsgType.Voice:
                        return new VoiceMessageRole().MessageRole(msg);
                    default:
                        return new DefaultMessageHandler(msg);
                }
            }
            catch (Exception ex)
            {
                TxtLogHelper.WriteLog_Day(new TxtLogInfoObject()
                {
                    LogType = EnumLogType.Error,
                    LogMessage = string.Format("错误信息{0}；堆栈信息{1}", ex.Message, ex.StackTrace),
                });
                throw;
            }
            finally
            {
                TxtLogHelper.WriteDebugLog(bugobj);
            }

            return null;
        }
    }
}
