// ***********************************************************************
// <copyright file="GroupCreateResponse.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.Buiness.ApiResponses
// Author            : 谭志强
// Created          : 2015/7/28 11:45:07
// <summary></summary>
// ***********************************************************************

using Tzq.WeChatService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tzq.WeChatService.Model
{
    public class GroupCreateResponse : ApiResponses
    {
        /// <summary>
        /// 微信分组信息
        /// </summary>
        public WxGroup Group { get; set; }

        public override string ToString()
        {
            if (IsError)
                return base.ToString();

            return String.Format("groupname:{0}, groupid:{1}", Group.Name, Group.ID);
        }
    }
}
