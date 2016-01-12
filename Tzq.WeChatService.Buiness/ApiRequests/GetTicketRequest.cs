// ***********************************************************************
// <copyright file="GetTicketRequest.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.Buiness.ApiRequests
// Author            : 谭志强
// Created          : 2015/10/22 10:27:27
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
    public class GetTicketRequest : ApiRequestBase<GetTicketResponse>
    {
        /// <summary>
        /// 口令
        /// </summary>
        private string token = string.Empty;

        /// <summary>
        /// 事件名称
        /// </summary>
        private string jstype = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupInfo"></param>
        /// <param name="token"></param>
        public GetTicketRequest(string token, string jstype)
            : base()
        {
            this.token = token;
            this.jstype = jstype;
        }


        internal override string Method
        {
            get { return "GET"; }
        }

        internal override string GetUrl()
        {
            return String.Format(UrlFormat, AccessToken, this.jstype);
        }

        internal override string AccessToken
        {
            get { return this.token; }
        }

        protected override string UrlFormat
        {
            get { return "https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token={0}&type={1}"; }
        }

        protected override bool NeedToken
        {
            get { return true; }
        }

        internal override void Validate()
        {
            base.Validate();
        }

        public override string GetPostContent()
        {
            throw new NotImplementedException();
        }
    }
}
