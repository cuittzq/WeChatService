// ***********************************************************************
// <copyright file="SnsUserInfoResponse.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.Buiness.ApiResponses
// Author            : 谭志强
// Created          : 2015/7/29 11:36:33
// <summary></summary>
// ***********************************************************************

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tzq.WeChatService.Model
{
    public class SnsUserInfoResponse : ApiResponses
    {
        public string OpenId { get; set; }

        public string NickName { get; set; }

        public int Sex { get; set; }

        public string Province { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        [JsonProperty("headimgurl")]
        public string HeadImageUrl { get; set; }

        [JsonProperty("privilege")]
        public IEnumerable<string> Privilege { get; set; }

    }
}
