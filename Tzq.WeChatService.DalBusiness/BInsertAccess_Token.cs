// ***********************************************************************
// <copyright file="DInsertAccess_Token.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.DalBusiness
// Author            : 谭志强
// Created          : 2015/7/27 12:30:30
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DBUtility;
using Tzq.WeChatService.Model;
using Tzq.WeChatService.Factory;
using Tzq.WeChatService.DAL;

namespace Tzq.WeChatService.DalBusiness
{
    public class BInsertAccess_Token : DbTransaction
    {
        /// <summary>
        /// 令牌信息
        /// </summary>
        private MAccess_Token access_TokenInfo = null;

        /// <summary>
        /// 令牌数据接口
        /// </summary>
        private DAccess_Token access_TokenDal = null;

        /// <summary>
        /// 插入token
        /// </summary>
        public BInsertAccess_Token(MAccess_Token access_Token)
        {
            this.access_TokenInfo = access_Token;
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
            this.access_TokenInfo.KeyID = Common.KeyIDFactory.KeyIDFactory.NewKeyID(Common.KeyIDFactory.DataBase.QQtyl, "WeixinUser");
            this.Result = this.access_TokenDal.InsertAccess_Token(null, this.Connection, this.access_TokenInfo);
        }
    }
}
