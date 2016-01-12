// ***********************************************************************
// <copyright file="GroupsGetIdResponse.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.Buiness.ApiResponses
// Author            : 谭志强
// Created          : 2015/7/28 15:38:59
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tzq.WeChatService.Model
{
    /// <summary>
    /// 通过用户的OpenID查询其所在的GroupID
    /// </summary>
    public class GroupsGetIdResponse : ApiResponses
    {
        /// <summary>
        /// 所属分组ID
        /// </summary>
        public int GroupId { get; set; }

        public override string ToString()
        {
            if (IsError)
            {
                return base.ToString();
            }

            return String.Format("groupId:{0}", GroupId);
        }
    }
}
