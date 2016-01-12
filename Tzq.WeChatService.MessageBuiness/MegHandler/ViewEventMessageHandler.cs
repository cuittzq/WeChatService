using Common.TxtLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tzq.WeChatService.MessageBuiness
{
    /// <summary>
    /// 点击菜单跳转链接时的事件推送处理
    /// </summary>
    public class ViewEventMessageHandler : IMessageHandler
    {
        /// <summary>
        /// 处理消息器
        /// </summary>
        private HandleMessage messageHandler = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="message">处理消息器</param>
        public ViewEventMessageHandler(HandleMessage message)
        {
            this.messageHandler = message;
        }
        /// <summary>
        /// 处理请求消息
        /// </summary>
        /// <returns>处理结果</returns>
        public ResponseMessage HandlerRequestMessage()
        {
            Dictionary<string, object> bugobj = new Dictionary<string, object>();
            NormalMenuEventMessage viewEventMessage = null;
            bugobj.Add("message", this.messageHandler);
            var request = new RequestViewEventMessage(this.messageHandler.Element);
            try
            {
                if (request != null)
                {
                    // 点击菜单跳转链接时的事件推送处理
                    bugobj.Add("request", request);
                }
                viewEventMessage = new NormalMenuEventMessage(request)
                {
                    CreateTime = DateTime.Now.Ticks,
                    ToUserName = request.ToUserName,
                    FromUserName = request.FromUserName,
                    EventKey = request.EventKey,
                };
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

            return viewEventMessage;
        }
    }
}
