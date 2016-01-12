// ***********************************************************************
// <copyright file="CreateMenuRequest.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.Buiness.ApiRequests
// Author            : 谭志强
// Created          : 2015/8/5 11:42:09
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
    public class CreateMenuRequest : ApiRequestBase<CreateMenuResponse>
    {
        /// <summary>
        /// menu
        /// </summary>
        private string menu = string.Empty;

        /// <summary>
        /// 口令
        /// </summary>
        private string token = string.Empty;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="menu">菜单json</param>
        /// <param name="token">口令</param>
        public CreateMenuRequest(string menu, string token)
            : base()
        {
            this.menu = menu;
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
            get { return "https://api.weixin.qq.com/cgi-bin/menu/create?access_token={0}"; }
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
            return this.menu;
        }
    }
}
