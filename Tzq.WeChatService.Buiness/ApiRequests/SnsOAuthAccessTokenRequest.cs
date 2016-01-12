// ***********************************************************************
// <copyright file="SnsOAuthAccessTokenRequest.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.Buiness.ApiRequests
// Author            : 谭志强
// Created          : 2015/7/28 17:52:14
// <summary></summary>
// ***********************************************************************

using Tzq.WeChatService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tzq.WeChatService.Buiness
{
    public class SnsOAuthAccessTokenRequest : ApiRequestBase<SnsOAuthAccessTokenResponse>
    {
        /// <summary>
        /// code
        /// </summary>
        private string code = string.Empty;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="code"></param>
        public SnsOAuthAccessTokenRequest(string code)
        {
            this.code = code;
        }

        internal override string Method
        {
            get { return "GET"; }
        }

        internal override string AccessToken
        {
            get { return string.Empty; }
        }

        protected override string UrlFormat
        {
            get { return "https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code"; }
        }

        internal override string GetUrl()
        {
            return String.Format(UrlFormat, base.WeixinParam.AppID, base.WeixinParam.AppSecret, this.code);
        }

        protected override bool NeedToken
        {
            get { return false; }
        }

        public override string GetPostContent()
        {
            throw new NotImplementedException();
        }
    }
}
