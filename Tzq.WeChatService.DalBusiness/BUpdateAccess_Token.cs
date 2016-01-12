// ***********************************************************************
// <copyright file="BUpdateAccess_Token.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.DalBusiness
// Author            : 谭志强
// Created          : 2015/7/27 16:40:21
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DBUtility;
using Tzq.WeChatService.DAL;
using Tzq.WeChatService.Factory;

namespace Tzq.WeChatService.DalBusiness
{
    /// <summary>
    /// 更新口令
    /// </summary>
    public class BUpdateAccess_Token : DbTransaction
    {
        /// <summary>
        /// 主键
        /// </summary>
        private string keyID = string.Empty;

        /// <summary>
        /// 口令（加密）
        /// </summary>
        private string tokenstr = string.Empty;

        private string refreshToken = string.Empty;

        /// <summary>
        /// 失效时间
        /// </summary>
        private DateTime outTime;

        /// <summary>
        /// 令牌数据接口
        /// </summary>
        private DAccess_Token access_TokenDal = null;

        /// <summary>
        /// 产品销售情况查询
        /// </summary>
        public BUpdateAccess_Token(string keyID, string tokenstr, string refreshToken, DateTime outTime)
        {
            this.keyID = keyID;
            this.tokenstr = tokenstr;
            this.outTime = outTime;
            this.refreshToken = refreshToken;
            this.Connection = ConnectionFactory.WeChatDBWrite;
            this.IsBeginTransaction = false;
            this.access_TokenDal = new DAccess_Token();
        }

        /// <summary>
        /// 结果
        /// </summary>
        public bool Result
        {
            get;
            set;
        }

        /// <summary>
        /// 执行
        /// </summary>
        protected override void ExecuteMethods()
        {
            this.Result = this.access_TokenDal.UpdateAccess_Token(null, this.Connection, this.keyID, this.tokenstr, this.refreshToken, this.outTime);
        }
    }
}
