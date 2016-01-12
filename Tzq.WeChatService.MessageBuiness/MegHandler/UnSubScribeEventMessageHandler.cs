using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Tzq.WeChatService.MessageBuiness
{
    /// <summary>
    /// 取消关注事件
    /// </summary>
    public class UnSubScribeEventMessageHandler : TextMessageHandler
    {
        /// <summary>
        /// 返回的数据
        /// </summary>
        private static string unsubScribeMsg = "我们会继续努力的！";

        /// <summary>
        /// 构造函数
        /// </summary>
        public UnSubScribeEventMessageHandler(HandleMessage msghander)
            : base(unsubScribeMsg, msghander)
        {
        }
    }
}
