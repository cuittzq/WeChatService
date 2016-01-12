using Common.TxtLog;
using Tzq.WeChatService.Buiness;
using Tzq.WeChatService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tzq.WeChatService.MessageBuiness
{
    /// <summary>
    /// 语音消息处理
    /// </summary>
    public class VoiceMessageHandler : IMessageHandler
    {

        /// <summary>
        /// 消息处理器
        /// </summary>
        private HandleMessage msghander = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="message"></param>
        public VoiceMessageHandler(HandleMessage message)
        {
            this.msghander = message;
        }

        /// <summary>
        /// 语音识别处理
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public ResponseMessage HandlerRequestMessage()
        {
            Dictionary<string, object> bugobj = new Dictionary<string, object>();
            var request = this.msghander.RequestMessage as RequestVoiceMessage;
            var responseText = new ResponseTextMessage(request);
            try
            {
                bugobj.Add("语音识别处理！", "语音识别处理");
                if (request != null)
                {
                    bugobj.Add("语音识别结果", request);
                    if (!String.IsNullOrEmpty(request.Recognition))
                    {
                        if (!string.IsNullOrEmpty(request.FromUserName))
                        {

                        }
                        else
                        {
                            responseText.Content = "信息格式不正确。";
                        }

                    }
                    else
                    {
                        responseText.Content = "您说的啥？我没听懂";
                    }
                }
                else
                {
                    responseText.Content = "我暂时还无法理解你所说的意思。";
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

            return responseText;
        }
    }
}
