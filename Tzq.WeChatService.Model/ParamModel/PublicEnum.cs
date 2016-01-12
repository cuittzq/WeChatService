// ***********************************************************************
// <copyright file="PublicEnum.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.Model.ParamModel
// Author            : 谭志强
// Created          : 2015/7/30 15:19:57
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
    /// 用户类型
    /// </summary>
    public enum UserType
    {
        店主登录 = 1,
        客户登录 = 2,
    }

    /// <summary>
    /// 登录方式 
    /// </summary>
    public enum LoginType
    {
        账号密码 = 1,
        微信绑定登录 = 2,
    }

    [Serializable]
    public enum ShopStatus
    {
        等待审核 = 0,
        审核通过 = 1,
        审核不通过 = 2,
        禁用 = 3
    }

    [Serializable]
    public enum UserStatus
    {
        启用 = 0,
        禁用 = 1
    }
}
