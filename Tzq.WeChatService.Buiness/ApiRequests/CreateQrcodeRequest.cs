using Newtonsoft.Json;
using Tzq.WeChatService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tzq.WeChatService.Buiness
{
    /// <summary>
    /// 二维码生成
    /// </summary>
    public class CreateQrcodeRequest : ApiRequestBase<CreateQrcodeResponse>
    {

        /// <summary>
        /// 口令
        /// </summary>
        private string token = string.Empty;

        /// <summary>
        /// 过期时间 
        /// </summary>
        private int expire_seconds = 604800;

        /// <summary>
        /// 事件名称
        /// </summary>
        private Action_Name action_name = Action_Name.QR_SCENE;

        /// <summary>
        /// 事件ID
        /// </summary>
        private int scene_id = 0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupInfo"></param>
        /// <param name="token"></param>
        public CreateQrcodeRequest(string token, int scene_id, Action_Name action_name)
            : base()
        {
            this.token = token;
            this.action_name = action_name;
            this.scene_id = scene_id;
        }


        internal override string Method
        {
            get { return "POST"; }
        }

        internal override string GetUrl()
        {
            return String.Format(UrlFormat, AccessToken);
        }

        internal override string AccessToken
        {
            get { return this.token; }
        }

        protected override string UrlFormat
        {
            get { return "https://api.weixin.qq.com/cgi-bin/qrcode/create?access_token={0}"; }
        }

        protected override bool NeedToken
        {
            get { return true; }
        }

        internal override void Validate()
        {
            base.Validate();
        }

        public override string GetPostContent()
        {
            string postdata = string.Empty;
            // {"expire_seconds": 604800, "action_name": "QR_SCENE", "action_info": {"scene": {"scene_id": 123}}}
            // {"action_name": "QR_LIMIT_STR_SCENE", "action_info": {"scene": {"scene_str": "123"}}}
            if (this.action_name == Action_Name.QR_SCENE)
            {
                postdata = JsonConvert.SerializeObject(new { expire_seconds = this.expire_seconds, action_name = "QR_SCENE", action_info = new { scene = new { scene_id = this.scene_id } } });
            }
            else if (this.action_name == Action_Name.QR_LIMIT_STR_SCENE)
            {
                postdata = JsonConvert.SerializeObject(new { action_name = "QR_LIMIT_STR_SCENE", action_info = new { scene = new { scene_str = this.scene_id.ToString() } } });
            }

            return postdata;

        }
    }
}
