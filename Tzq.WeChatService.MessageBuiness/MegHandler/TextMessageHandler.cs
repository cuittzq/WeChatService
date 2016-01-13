using Common.TxtLog;
using Tzq.WeChatService.Buiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using Tzq.WeChatService.Model;
using Newtonsoft.Json;
using Tzq.DataService.Helper;

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
                            if (request.Content.Contains("笑话"))
                            {
                                MQiushibaike qiushibaike = JsonConvert.DeserializeObject<MQiushibaike>(QiushibaikeHelper.GetJokesByRandom());
                                if (qiushibaike != null)
                                {
                                    responseText.Content = string.Format(" {0} ---来源：@糗事百科 {1}", qiushibaike.JokeContent, qiushibaike.JokerName);
                                }
                                else
                                {
                                    responseText.Content = "你在逗我？";
                                }
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