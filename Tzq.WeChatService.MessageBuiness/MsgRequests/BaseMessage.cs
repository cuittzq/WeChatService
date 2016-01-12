using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tzq.WeChatService.MessageBuiness
{
    /// <summary>
    /// 消息队列 用于消息去重
    /// </summary>
    public class BaseMessage
    {
        /// <summary>
        /// 发送者标识
        /// </summary>
        public string FromUser { get; set; }

        /// <summary>
        /// 消息表示。普通消息时，为msgid，事件消息时，为事件的创建时间
        /// </summary>
        public string MsgFlag { get; set; }

        /// <summary>
        /// 添加到队列的时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
