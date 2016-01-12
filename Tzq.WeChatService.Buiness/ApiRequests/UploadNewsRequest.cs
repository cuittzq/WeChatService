// ***********************************************************************
// <copyright file="UploadNewsRequest.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.Buiness.ApiRequests
// Author            : 谭志强
// Created          : 2015/12/15 10:42:36
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
    public class UploadNewsRequest : ApiRequestBase<UploadNewsResponse>
    {
        MWeixinParam weixinParam = null;

        /// <summary>
        /// 口令
        /// </summary>
        private string token = string.Empty;

        /// <summary>
        /// 图文素材
        /// </summary>
        private List<Article> articles = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="weixinParam"></param>
        /// <param name="toUsers"></param>
        public UploadNewsRequest(MWeixinParam weixinParam, string token, List<Article> articles)
            : base(weixinParam)
        {
            this.weixinParam = weixinParam;
            this.articles = articles;
            this.token = token;
        }

        internal override string Method
        {
            get { return "POST"; }
        }

        protected override string UrlFormat
        {
            get { return "https://api.weixin.qq.com/cgi-bin/media/uploadnews?access_token={0}"; }
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

        [JsonProperty("articles")]
        public List<Article> Articles
        {
            get { return articles; }
            set { articles = value; }
        }
    }
}
