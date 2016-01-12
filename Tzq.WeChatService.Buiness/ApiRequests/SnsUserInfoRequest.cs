// ***********************************************************************
// <copyright file="SnsUserInfoRequest.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.Buiness.ApiRequests
// Author            : 谭志强
// Created          : 2015/7/29 11:36:18
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
    public class SnsUserInfoRequest : ApiRequestBase<SnsUserInfoResponse>
    {
        /// <summary>
        /// OauthToken
        /// </summary>
        private string oAuthToken = string.Empty;

        /// <summary>
        /// OpenID
        /// </summary>
        private string openId = string.Empty;

        /// <summary>
        /// 语言类型
        /// </summary>
        private Language languagetype = Language.CN;

        /// <summary>
        /// 语言
        /// </summary>
        private string langString = string.Empty;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="oAuthToken">OauthToken</param>
        /// <param name="openId">openId</param>
        /// <param name="languagetype">语言类型</param>
        public SnsUserInfoRequest(string oAuthToken, string openId, Language languagetype)
        {
            this.oAuthToken = oAuthToken;
            this.openId = openId;
            this.languagetype = languagetype;
        }

        /// <summary>
        /// 请求方式
        /// </summary>
        internal override string Method
        {
            get { return "GET"; }
        }

        /// <summary>
        /// 获取请求地址
        /// </summary>
        /// <returns></returns>
        internal override string GetUrl()
        {
            return String.Format(UrlFormat, this.oAuthToken, this.openId, this.langString);
        }

        /// <summary>
        /// accessToken
        /// </summary>
        internal override string AccessToken
        {
            get { return string.Empty; }
        }

        /// <summary>
        /// 构建请求地址
        /// </summary>
        protected override string UrlFormat
        {
            get { return "https://api.weixin.qq.com/sns/userinfo?access_token={0}&openid={1}&lang={2}"; }
        }

        /// <summary>
        /// 是否需要accessToken
        /// </summary>
        protected override bool NeedToken
        {
            get { return false; }
        }

        /// <summary>
        /// 获取post数据
        /// </summary>
        /// <returns></returns>
        public override string GetPostContent()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 校验
        /// </summary>
        internal override void Validate()
        {
            base.Validate();
            if (String.IsNullOrEmpty(this.oAuthToken))
            {
                throw new ArgumentNullException("Need OAuth AccessToken");
            }
            if (String.IsNullOrEmpty(this.openId))
            {
                throw new ArgumentNullException("Need OpenID");
            }
            switch (this.languagetype)
            {
                case Language.TW:
                    this.langString = "zh_TW";
                    break;
                case Language.EN:
                    this.langString = "en";
                    break;
                case Language.CN:
                default:
                    this.langString = "zh_CN";
                    break;
            }
        }
    }
}
