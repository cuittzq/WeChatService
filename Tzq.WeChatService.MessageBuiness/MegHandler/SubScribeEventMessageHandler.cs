using Common.TxtLog;
using Tzq.WeChatService.Buiness;
using Tzq.WeChatService.Factory;
using Tzq.WeChatService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Tzq.WeChatService.MessageBuiness
{
    /// <summary>
    /// 关注事件
    /// </summary>
    public class SubScribeEventMessageHandler : IMessageHandler
    {
        private string subScribeMsg = "感谢您的关注！";

        /// <summary>
        /// 处理消息器
        /// </summary>
        private HandleMessage message = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="message">处理消息器</param>
        public SubScribeEventMessageHandler(HandleMessage message)
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
            ResponseTextMessage responseTextMessage = null;
            var request = new RequestQREventMessage(this.message.Element);
            try
            {
                if (request != null)
                {
                    // 处理扫描带参数的二维码消息处理器
                    //  bugobj.Add("处理扫描带参数的二维码消息处理器", request);

                }
                responseTextMessage = new ResponseTextMessage(request)
                {
                    Content = subScribeMsg,
                };
            }
            catch (Exception ex)
            {
                TxtLogHelper.WriteLog_Day(new TxtLogInfoObject()
                {
                    LogType = EnumLogType.Error,
                    LogMessage = string.Format("错误信息{0}；堆栈信息{1}", ex.Message, ex.StackTrace),
                });

                responseTextMessage = new ResponseTextMessage(request)
                {
                    Content = subScribeMsg,
                };
            }
            finally
            {
                TxtLogHelper.WriteDebugLog(bugobj);
            }

            return responseTextMessage;
        }
    }
}
