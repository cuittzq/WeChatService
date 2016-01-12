// ***********************************************************************
// <copyright file="CreateMenuResponse.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.Model.ApiResponses
// Author            : 谭志强
// Created          : 2015/8/5 11:42:46
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tzq.WeChatService.Model
{
    public class CreateMenuResponse : ApiResponses
    {
        public override string ToString()
        {
            if (IsError)
                return base.ToString();
            return String.Format("errcode:{0}, errmsg:{1}", this.ErrorCode, this.ErrorMessage);
        }
    }
}
