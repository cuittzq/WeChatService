// ***********************************************************************
// <copyright file="UploadNewsResponse.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.Model.ApiResponses
// Author            : 谭志强
// Created          : 2015/12/15 10:43:19
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
    public class UploadNewsResponse : ApiResponses
    {
        /// <summary>
        /// 媒体文件类型，分别有图片（image）、语音（voice）、视频（video）和缩略图（thumb），次数为news，即图文消息
        /// </summary>
        [JsonProperty("type")]
        public MsgType Type { get; set; }

        [JsonProperty("media_id")]
        public string Media_ID { get; set; }

        [JsonProperty("created_at")]
        public string Created_At { get; set; }
    }
}
