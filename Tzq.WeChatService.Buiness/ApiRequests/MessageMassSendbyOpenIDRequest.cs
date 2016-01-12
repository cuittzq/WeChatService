// ***********************************************************************
// <copyright file="MessageMassSendAllRequest.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.Buiness.ApiRequests
// Author            : 谭志强
// Created          : 2015/12/10 10:23:36
// <summary></summary>
// ***********************************************************************

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
    /// 消息群发
    /// </summary>
    public class MessageMassSendbyOpenIDRequest : ApiRequestBase<MessageMassSendbyOpenIDResponse>
    {
        MWeixinParam weixinParam = null;

        /// <summary>
        /// 口令
        /// </summary>
        private string token = string.Empty;

        /// <summary>
        /// 群发的openids
        /// </summary>
        private List<string> toUsers = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="weixinParam"></param>
        /// <param name="toUsers"></param>
        public MessageMassSendbyOpenIDRequest(string token, MWeixinParam weixinParam, List<string> toUsers, string mediaId)
            : base(weixinParam)
        {
            this.token = token;
            this.weixinParam = weixinParam;
            this.toUsers = toUsers;
            this.MPNews = new SendMPNews()
            {
                MediaId = mediaId
            };
        }

        internal override string Method
        {
            get { return "POST"; }
        }

        protected override string UrlFormat
        {
            get { return "https://api.weixin.qq.com/cgi-bin/message/mass/send?access_token={0}"; }
        }

        internal override string GetUrl()
        {
            return String.Format(UrlFormat, AccessToken);
        }

        protected override bool NeedToken
        {
            get { return true; }
        }

        public override string GetPostContent()
        {
            return JsonConvert.SerializeObject(this);
        }

        /// <summary>
        /// token
        /// </summary>
        internal override string AccessToken
        {
            get { return this.token; }
        }


        [JsonProperty("touser")]
        public List<string> ToUsers
        {
            get { return toUsers; }
            set { toUsers = value; }
        }

        [JsonProperty("mpnews")]
        public SendMPNews MPNews
        {
            get;
            set;
        }

        [JsonProperty("msgtype")]
        public string MsageType
        {
            get { return "mpnews"; }
        }
    }

    public class SendMPNews
    {
        [JsonProperty("media_id")]
        public string MediaId { get; set; }
    }
}
