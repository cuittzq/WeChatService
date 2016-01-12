// ***********************************************************************
// <copyright file="AccessTokenResponse.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.Buiness.ApiResponses
// Author            : 谭志强
// Created          : 2015/7/27 10:58:53
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tzq.WeChatService.Model
{
    public class AccessTokenResponse : ApiResponses
    {
        /// <summary>
        /// Access_Token
        /// </summary>
        public string Access_Token { get; set; }

        /// <summary>
        /// Expires_In
        /// </summary>
        public int Expires_In { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (IsError)
                return base.ToString();

            return String.Format("accesstoken:{0}, expires_in:{1}", Access_Token, Expires_In);
        }
    }
}
