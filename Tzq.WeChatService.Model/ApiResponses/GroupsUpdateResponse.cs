// ***********************************************************************
// <copyright file="GroupsUpdateResponse.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.Buiness.ApiResponses
// Author            : 谭志强
// Created          : 2015/7/28 12:27:42
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tzq.WeChatService.Model
{
    public class GroupsUpdateResponse : ApiResponses
    {
        public override string ToString()
        {
            if (IsError)
                return base.ToString();
            return String.Format("success, msg:{0}", ErrorMessage);
        }
    }
}
