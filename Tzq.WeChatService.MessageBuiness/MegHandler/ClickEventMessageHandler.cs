// ***********************************************************************
// <copyright file="ClickEventMessageHandler.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.Business.MegHandler
// Author            : 谭志强
// Created          : 2015/8/26 9:42:32
// <summary></summary>
// ***********************************************************************

using Common.TxtLog;
using Tzq.WeChatService.Buiness;
using Tzq.WeChatService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tzq.WeChatService.MessageBuiness
{
    public class ClickEventMessageHandler : IMessageHandler
    {
        /// <summary>
        /// 处理消息器
        /// </summary>
        private HandleMessage message = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="message">处理消息器</param>
        public ClickEventMessageHandler(HandleMessage message)
        {
            this.message = message;
        }
        /// <summary>
        /// 处理请求消息
        /// </summary>
        /// <returns>处理结果</returns>
        public ResponseMessage HandlerRequestMessage()
        {
            Dictionary<string, object> bugobj = new Dictionary<string, object>();
            bugobj.Add("message", this.message);
            var request = new RequestClickEventMessage(this.message.Element);
            /// 返回消息类型
            MsgType msgtype = MsgType.Text;
            // 返回消息
            string result = string.Empty;
            //GetB2CProductInfo getB2CProductInfo = null;
            try
            {
                if (request != null)
                {
                    // 点击菜单事件推送处理
                    bugobj.Add("request", request);
                    switch (request.EventKey)
                    {
                        case "V1001_GOOD":
                            result += "感谢您的支持！";
                            msgtype = MsgType.Text;
                            break;
                        case "V1001_HOT":
                            msgtype = MsgType.News;
                            break;
                        default:
                            break;
                    }
                }

                switch (msgtype)
                {
                    case MsgType.Text:
                        return new ResponseTextMessage(request)
                        {
                            CreateTime = DateTime.Now.Ticks,
                            Content = result,
                        };
                    case MsgType.Image:
                        break;
                    case MsgType.Voice:
                        break;
                    case MsgType.Video:
                        break;
                    case MsgType.Location:
                        break;
                    case MsgType.Link:
                        break;
                    case MsgType.Event:
                        return new NormalMenuEventMessage(request)
                         {
                             CreateTime = DateTime.Now.Ticks,
                         };
                    case MsgType.News:
                    //if (!string.IsNullOrEmpty(request.FromUserName))
                    //{
                    //    getB2CProductInfo = new GetB2CProductInfo(string.Empty, request.ToUserName, request.FromUserName);
                    //    getB2CProductInfo.ExeuteMethod();
                    //    // getB2CProductInfo.QueryB2CProductInfo(request.FromUserName);

                    //    if (getB2CProductInfo.ArticleMessages != null && getB2CProductInfo.ArticleMessages.Count > 0)
                    //    {
                    //        var response = new ResponseNewsMessage(request);
                    //        response.CreateTime = DateTime.Now.Ticks;
                    //        response.ArticleCount = getB2CProductInfo.ArticleMessages.Count;
                    //        response.Articles = getB2CProductInfo.ArticleMessages;
                    //        return response;
                    //    }
                    //    else
                    //    {
                    //        return new ResponseTextMessage(request)
                    //        {
                    //            CreateTime = DateTime.Now.Ticks,
                    //            Content = string.Format("产品太多，店主也不知道该推荐什么，您可以从下面的买家入口进入我的关注，浏览店铺的旅游信息。")
                    //        };
                    //    }
                    //}
                    //else
                    //{
                    //    return new ResponseTextMessage(request)
                    //    {
                    //        CreateTime = DateTime.Now.Ticks,
                    //        Content = "信息格式不正确"
                    //    };
                    //}
                    case MsgType.Music:
                        break;
                    case MsgType.ShortVideo:
                        break;
                    case MsgType.transfer_customer_service:
                        break;
                    default:
                        break;
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
