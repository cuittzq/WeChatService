// ***********************************************************************
// <copyright file="UserInfoRequest.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.Buiness.ApiRequests
// Author            : 谭志强
// Created          : 2015/7/27 11:21:10
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
    /// <summary>
    /// 
    /// </summary>
    public class UserInfoRequest : ApiRequestBase<UserInfoResponse>
    {

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="openId"></param>
        /// <param name="lang"></param>
        /// <param name="token"></param>
        public UserInfoRequest(string openId, string lang, string token)
            : base()
        {
            this.OpenId = openId;
            this.Lang = lang;
            this.Token = token;
        }

        /// <summary>
        /// 用户的标识，对当前公众号唯一
        /// </summary>
        public string OpenId { get; set; }

        /// <summary>
        /// 返回国家地区语言版本，zh_CN 简体，zh_TW 繁体，en 英语
        /// </summary>
        public string Lang { get; set; }

        /// <summary>
        /// 令牌
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// get
        /// </summary>
        internal override string Method
        {
            get { return "GET"; }
        }

        /// <summary>
        /// 令牌
        /// </summary>
        internal override string AccessToken
        {
            get { return this.Token; }
        }

        /// <summary>
        /// 构建请求参数
        /// </summary>
        protected override string UrlFormat
        {
            get { return "https://api.weixin.qq.com/cgi-bin/user/info?access_token={0}&openid={1}&lang={2}"; }
        }

        /// <summary>
        /// 获取请求地址
        /// </summary>
        /// <returns></returns>
        internal override string GetUrl()
        {
            return String.Format(UrlFormat, this.Token, this.OpenId, this.Lang);
        }

        /// <summary>
        /// 是否需要token
        /// </summary>
        protected override bool NeedToken
        {
            get { return true; }
        }

        /// <summary>
        /// 获取返回数据
        /// </summary>
        /// <returns></returns>
        public override string GetPostContent()
        {
            throw new NotImplementedException();
        }
    }
}
