// ***********************************************************************
// <copyright file="ConnectionFactory.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.Factory
// Author            : 谭志强
// Created          : 2015/7/24 9:34:39
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tzq.WeChatService.Factory
{
    public class ConnectionFactory
    {
        /// <summary>
        /// 全球通产品读库
        /// </summary>
        public static IDbConnection WeChatDBRead
        {
            get { return ConnectionConfig.GetConnection("WeChatDBRead"); }
        }

        /// <summary>
        /// 全球通产品写库
        /// </summary>
        public static IDbConnection WeChatDBWrite
        {
            get { return ConnectionConfig.GetConnection("WeChatDBWrite"); }
        }
    }
}
