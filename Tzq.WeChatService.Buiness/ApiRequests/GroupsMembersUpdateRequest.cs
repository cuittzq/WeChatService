// ***********************************************************************
// <copyright file="GroupsMembersUpdateRequest.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.Buiness.ApiRequests
// Author            : 谭志强
// Created          : 2015/7/28 16:04:29
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
    public class GroupsMembersUpdateRequest : ApiRequestBase<GroupsMembersUpdateResponse>
    {
        /// <summary>
        /// openId
        /// </summary>
        private string openId = string.Empty;

        /// <summary>
        /// 移动到分组ID
        /// </summary>
        private int to_groupid = -1;

        /// <summary>
        /// 口令
        /// </summary>
        private string token = string.Empty;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="openId">openId</param>
        /// <param name="token">口令</param>
        public GroupsMembersUpdateRequest(string openId, int toGroupId, string token)
            : base()
        {
            this.openId = openId;
            this.to_groupid = toGroupId;
            this.token = token;
        }

        /// <summary>
        /// 请求方式
        /// </summary>
        internal override string Method
        {
            get { return "POST"; }
        }

        /// <summary>
        /// 获取请求URL
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
            get { return "https://api.weixin.qq.com/cgi-bin/groups/members/update?access_token={0}"; }
        }

        protected override bool NeedToken
        {
            get { return true; }
        }

        /// <summary>
        /// 获取Post数据
        /// </summary>
        /// <returns></returns>
        public override string GetPostContent()
        {
            return JsonConvert.SerializeObject(new { openid = this.openId, to_groupid = this.to_groupid });
        }
    }
}
