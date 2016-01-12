// ***********************************************************************
// <copyright file="SnsOauthRefreshTokenRequest.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.Buiness.ApiRequests
// Author            : 谭志强
// Created          : 2015/7/29 11:18:38
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
    public class SnsOauthRefreshTokenRequest : ApiRequestBase<SnsOAuthAccessTokenResponse>
    {
        /// <summary>
        /// code
        /// </summary>
        private string refreshToken = string.Empty;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="code"></param>
        public SnsOauthRefreshTokenRequest(string refreshToken)
        {
            this.refreshToken = refreshToken;
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
            get { return "https://api.weixin.qq.com/sns/oauth2/refresh_token?appid={0}&grant_type=refresh_token&refresh_token={1}"; }
        }

        internal override string GetUrl()
        {
            return String.Format(UrlFormat, base.WeixinParam.AppID, this.refreshToken);
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
