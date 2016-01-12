// ***********************************************************************
// <copyright file="AccessTokenRequest.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.Buiness
// Author            : 谭志强
// Created          : 2015/7/27 10:18:43
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
    public class AccessTokenRequest : ApiRequestBase<AccessTokenResponse>
    {

        public AccessTokenRequest(MWeixinParam weixinParam)
            : base(weixinParam)
        {

        }

        internal override string Method
        {
            get { return "GET"; }
        }

        protected override string UrlFormat
        {
            get { return "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}"; }
        }

        internal override string GetUrl()
        {
            return String.Format(UrlFormat, base.WeixinParam.AppID, base.WeixinParam.AppSecret);
        }

        protected override bool NeedToken
        {
            get { return false; }
        }

        /// <summary>
        /// 令牌
        /// </summary>
        internal override string AccessToken
        {
            get { return string.Empty; }
        }

        internal override void Validate()
        {
            if (base.WeixinParam == null)
            {
                throw new ArgumentNullException("AppIdentity");
            }
        }

        public override string GetPostContent()
        {
            throw new NotImplementedException();
        }
    }
}
