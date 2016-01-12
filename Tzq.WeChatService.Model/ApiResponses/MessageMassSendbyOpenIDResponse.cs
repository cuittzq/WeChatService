// ***********************************************************************
// <copyright file="MessageMassSendAllResponse.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.Model.ApiResponses
// Author            : 谭志强
// Created          : 2015/12/10 10:24:12
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Tzq.WeChatService.Model
{
    /// <summary>
    /// 消息群发响应
    /// </summary>
    public class MessageMassSendbyOpenIDResponse : ApiResponses
    {
        [JsonProperty("msg_id")]
        public int MsgId { get; set; }
    }
}
