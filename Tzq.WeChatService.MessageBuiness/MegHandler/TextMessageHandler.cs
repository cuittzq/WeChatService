using Common.TxtLog;
using Tzq.WeChatService.Buiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Tzq.WeChatService.MessageBuiness
{
    public class TextMessageHandler : IMessageHandler
    {
        /// <summary>
        /// 消息处理器
        /// </summary>
        private HandleMessage msghander = null;

        /// <summary>
        /// 
        /// </summary>
        private string Message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="msghander"></param>
        public TextMessageHandler(string msg, HandleMessage msghander)
        {
            this.Message = msg;
            this.msghander = msghander;
        }

        public ResponseMessage HandlerRequestMessage()
        {
            var request = this.msghander.RequestMessage as RequestTextMessage;
            var responseText = new ResponseTextMessage(request);
            Dictionary<string, object> bugobj = new Dictionary<string, object>();
            try
            {
                bugobj.Add("文字处理！", "文字处理");
                if (request != null)
                {
                    if (!String.IsNullOrEmpty(request.Content))
                    {
                        if (!string.IsNullOrEmpty(request.FromUserName))
                        {
                            // 关键字搜索
                            bugobj.Add("关键字搜索", request.Content);

                            // bugobj.Add("搜索结果", getB2CProductInfo.ArticleMessages);
                            //if (getB2CProductInfo.ArticleMessages != null && getB2CProductInfo.ArticleMessages.Count > 0)
                            //{
                            //    var response = new ResponseNewsMessage(request);
                            //    response.CreateTime = DateTime.Now.Ticks;
                            //    response.ArticleCount = getB2CProductInfo.ArticleMessages.Count;
                            //    response.Articles = getB2CProductInfo.ArticleMessages;
                            //    return response;
                            //}
                            //else
                            //{
                            //    responseText.Content = string.Format("暂时未搜索到【{0}】相应的旅游产品，你从下面的买家入口进入我的关注，浏览店铺的旅游信息。", request.Content);
                            //}
                        }
                        else
                        {
                            responseText.Content = "你在逗我？";
                        }

                    }
                    else
                    {
                        responseText.Content = "你在逗我？";
                    }
                }
                else
                {
                    responseText.Content = "你在逗我？";
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

            if (!string.IsNullOrEmpty(this.Message))
            {
                responseText.Content = this.Message;
            }
            return responseText;
        }
    }
}