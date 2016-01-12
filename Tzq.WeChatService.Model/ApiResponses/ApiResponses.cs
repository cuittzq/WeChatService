// ***********************************************************************
// <copyright file="ApiResponses.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.Buiness
// Author            : 谭志强
// Created          : 2015/7/27 10:53:13
// <summary></summary>
// ***********************************************************************

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tzq.WeChatService.Model
{
    public abstract class ApiResponses
    {
        public bool IsError
        {
            get
            {
                return ErrorCode != 0;
            }
        }

        [JsonProperty("errcode")]
        public int ErrorCode { get; set; }

        [JsonProperty("errmsg")]
        public string ErrorMessage { get; set; }

        public override string ToString()
        {
            if (IsError)
            {
                return String.Format("errcode:{0}, errmsg:{1}", ErrorCode, ErrorMessage);
            }

            return base.ToString();
        }
    }
}
