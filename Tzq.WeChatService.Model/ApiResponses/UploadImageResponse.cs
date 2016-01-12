// ***********************************************************************
// <copyright file="UploadImageResponse.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.Model.ApiResponses
// Author            : 谭志强
// Created          : 2015/12/17 16:13:56
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
    public class UploadImageResponse : ApiResponses
    {

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
