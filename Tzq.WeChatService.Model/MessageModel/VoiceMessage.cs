// ***********************************************************************
// <copyright file="VoiceMessage.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.Model.MessageModel
// Author            : 谭志强
// Created          : 2015/9/2 11:27:06
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
    public class VoiceMessage
    {
        [JsonProperty("media_id")]
        public string MediaId { get; set; }
    }
}
