// ***********************************************************************
// <copyright file="GroupsUpdateRequest.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.Buiness.ApiRequests
// Author            : 谭志强
// Created          : 2015/7/28 12:27:30
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
    /// 重命名分组
    /// </summary>
    public class GroupsUpdateRequest : ApiRequestBase<GroupsUpdateResponse>
    {
        /// <summary>
        /// 口令
        /// </summary>
        private string token = string.Empty;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="groupid"></param>
        /// <param name="groupName"></param>
        /// <param name="accessToken"></param>
        public GroupsUpdateRequest(int groupid, string groupName, string accessToken)
            : base()
        {
            this.token = accessToken;
            this.Group = new WxGroup
                {
                    Name = groupName,
                    ID = groupid
                };
        }

        /// <summary>
        /// 微信分组
        /// </summary>
        [JsonProperty("group")]
        public WxGroup Group { get; set; }

        /// <summary>
        /// 请求方式
        /// </summary>
        internal override string Method
        {
            get { return "POST"; }
        }

        /// <summary>
        /// 获取请求地址
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
            get { return "https://api.weixin.qq.com/cgi-bin/groups/update?access_token={0}"; }
        }

        /// <summary>
        /// 是否需要token
        /// </summary>
        protected override bool NeedToken
        {
            get { return true; }
        }

        /// <summary>
        /// post请求数据
        /// </summary>
        /// <returns></returns>
        public override string GetPostContent()
        {
            return JsonConvert.SerializeObject(new { group = Group });
        }
    }
}
