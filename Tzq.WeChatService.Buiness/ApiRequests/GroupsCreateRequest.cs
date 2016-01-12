// ***********************************************************************
// <copyright file="GroupsCreateRequest.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.Buiness.ApiRequests
// Author            : 谭志强
// Created          : 2015/7/28 11:44:56
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
    public class GroupsCreateRequest : ApiRequestBase<GroupCreateResponse>
    {
        /// <summary>
        /// 微信分组
        /// </summary>
        private WxGroup group = null;

        /// <summary>
        /// 口令
        /// </summary>
        private string token = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupInfo"></param>
        /// <param name="token"></param>
        public GroupsCreateRequest(WxGroup groupInfo, string token)
            : base()
        {
            this.group = groupInfo;
            this.token = token;
        }

        /// <summary>
        /// 微信分组
        /// </summary>
        [JsonProperty("group", TypeNameHandling = TypeNameHandling.Objects)]
        public WxGroup Group
        {
            get { return group; }
            set { group = value; }
        }

        internal override string Method
        {
            get { return "POST"; }
        }

        internal override string GetUrl()
        {
            return String.Format(UrlFormat, AccessToken);
        }

        internal override string AccessToken
        {
            get { return this.token; }
        }

        protected override string UrlFormat
        {
            get { return "https://api.weixin.qq.com/cgi-bin/groups/create?access_token={0}"; }
        }

        protected override bool NeedToken
        {
            get { return true; }
        }

        internal override void Validate()
        {
            base.Validate();
            var namelength = this.Group.Name.Length;
            if (namelength < 0 || namelength > 30)
            {
                throw new ArgumentException("Property Name length between 1 to 30");
            }
        }

        public override string GetPostContent()
        {
            return JsonConvert.SerializeObject(new { group = Group });
        }
    }
}
