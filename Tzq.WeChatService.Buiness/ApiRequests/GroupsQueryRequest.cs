// ***********************************************************************
// <copyright file="GroupsQueryRequest.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.Buiness.ApiRequests
// Author            : 谭志强
// Created          : 2015/7/28 12:13:13
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
    /// 获取所有分组信息
    /// </summary>
    public class GroupsQueryRequest : ApiRequestBase<GroupsQueryResponse>
    {
        /// <summary>
        /// 口令
        /// </summary>
        private string token = string.Empty;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="tokeninfo">token</param>
        public GroupsQueryRequest(string tokeninfo)
        {
            this.token = tokeninfo;
        }

        /// <summary>
        /// 请求方式
        /// </summary>
        internal override string Method
        {
            get { return "GET"; }
        }

        /// <summary>
        /// 获取url
        /// </summary>
        /// <returns></returns>
        internal override string GetUrl()
        {
            return String.Format(UrlFormat, AccessToken);
        }

        /// <summary>
        /// token
        /// </summary>
        internal override string AccessToken
        {
            get { return this.token; }
        }

        /// <summary>
        /// 构建请求
        /// </summary>
        protected override string UrlFormat
        {
            get { return "https://api.weixin.qq.com/cgi-bin/groups/get?access_token={0}"; }
        }

        /// <summary>
        /// 是否需要token
        /// </summary>
        protected override bool NeedToken
        {
            get { return true; }
        }

        /// <summary>
        /// 获取post数据
        /// </summary>
        /// <returns></returns>
        public override string GetPostContent()
        {
            throw new NotImplementedException();
        }
    }
}
