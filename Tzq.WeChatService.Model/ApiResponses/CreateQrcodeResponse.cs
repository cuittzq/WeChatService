using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tzq.WeChatService.Model
{
    public class CreateQrcodeResponse : ApiResponses
    {
        /// <summary>
        /// 获取的二维码ticket
        /// </summary>
        public string Ticket { get; set; }

        /// <summary>
        /// 二维码的有效时间
        /// </summary>
        public int Expire_seconds { get; set; }

        /// <summary>
        /// 二维码图片解析后的地址
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (IsError)
            {
                return base.ToString();
            }

            return String.Format("Ticket:{0}, expires_in:{1},url:{2}", Ticket, Expire_seconds, Url);
        }
    }
}
