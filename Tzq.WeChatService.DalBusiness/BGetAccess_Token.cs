// ***********************************************************************
// <copyright file="BGetAccess_Token.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.DalBusiness
// Author            : 谭志强
// Created          : 2015/7/27 16:54:12
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
using Tzq.WeChatService.Model;

namespace Tzq.WeChatService.DalBusiness
{
    /// <summary>
    /// 根据appid和appSecret，grant_Type 获取口令
    /// </summary>
    public class BGetAccess_Token : DbTransaction
    {
        /// <summary>
        /// appid
        /// </summary>
        private string appid = string.Empty;

        /// <summary>
        /// 口令密匙
        /// </summary>
        private string appSecret = string.Empty;

        /// <summary>
        /// grant_Type
        /// </summary>
        private string grant_Type;

        /// <summary>
        /// openID
        /// </summary>
        private string openID = string.Empty;

        /// <summary>
        /// scope
        /// </summary>
        private string scope = "snsapi_base";

        /// <summary>
        /// 令牌数据接口
        /// </summary>
        private DAccess_Token access_TokenDal = null;

        /// <summary>
        /// 获取类型
        /// </summary>
        private int type = 0;


        /// <summary>
        /// 获取口令(公众号)
        /// </summary>
        public BGetAccess_Token(string appid, string appSecret, string grant_Type)
        {
            this.appid = appid;
            this.appSecret = appSecret;
            this.grant_Type = grant_Type;
            this.Connection = ConnectionFactory.WeChatDBWrite;
            this.IsBeginTransaction = false;
            this.access_TokenDal = new DAccess_Token();
            this.type = 0;
        }

        /// <summary>
        /// 获取口令（用户的）
        /// </summary>
        /// <param name="appid"></param>
        /// <param name="appSecret"></param>
        /// <param name="openID"></param>
        /// <param name="scope"></param>
        public BGetAccess_Token(string appid, string appSecret, string openID, string scope)
        {
            this.appid = appid;
            this.appSecret = appSecret;
            this.openID = openID;
            this.scope = scope;
            this.Connection = ConnectionFactory.WeChatDBWrite;
            this.IsBeginTransaction = false;
            this.access_TokenDal = new DAccess_Token();
            this.type = 1;
        }


        /// <summary>
        /// 获取全部公众号口令信息
        /// </summary>
        public BGetAccess_Token(string grant_Type)
        {
            this.grant_Type = grant_Type;
            this.Connection = ConnectionFactory.WeChatDBWrite;
            this.IsBeginTransaction = false;
            this.access_TokenDal = new DAccess_Token();
            this.type = 2;
            this.Access_TokenInfoDic = new Dictionary<string, MAccess_Token>();
            this.WeixinAppInfoDic = new Dictionary<string, MWeixinParam>();
        }

        /// <summary>
        /// 结果
        /// </summary>
        public MAccess_Token Access_TokenInfo
        {
            get;
            set;
        }

        /// <summary>
        /// 微信公众号授权集合 key- appID
        /// </summary>
        public Dictionary<string, MAccess_Token> Access_TokenInfoDic
        {
            get;
            set;
        }


        /// <summary>
        /// 公众号信息集合 key - WeixinID
        /// </summary>
        public Dictionary<string, MWeixinParam> WeixinAppInfoDic
        {
            get;
            set;
        }


        /// <summary>
        /// 执行
        /// </summary>
        protected override void ExecuteMethods()
        {
            switch (this.type)
            {
                case 0:
                    this.Access_TokenInfo = this.access_TokenDal.GetAccess_Token(null, this.Connection, this.appid, this.appSecret, this.grant_Type);
                    break;
                case 1:
                    this.Access_TokenInfo = this.access_TokenDal.GetAccess_Token(null, this.Connection, this.appid, this.appSecret, this.openID, this.scope);
                    break;
                case 2:
                    List<MAccess_Token> access_Tokens = this.access_TokenDal.GetAccess_Token(null, this.Connection, this.grant_Type);
                    if (access_Tokens != null && access_Tokens.Count > 0)
                    {
                        foreach (var item in access_Tokens)
                        {
                            // 这三者任意一个为空都不行
                            if (string.IsNullOrEmpty(item.AppID) || string.IsNullOrEmpty(item.AppSecret) || string.IsNullOrEmpty(item.WeixinID))
                            {
                                continue;
                            }

                            if (this.Access_TokenInfoDic.ContainsKey(item.AppID))
                            {
                                this.Access_TokenInfoDic[item.AppID] = item;
                            }
                            else
                            {
                                this.Access_TokenInfoDic.Add(item.AppID, item);
                            }

                            if (this.WeixinAppInfoDic.ContainsKey(item.WeixinID))
                            {
                                this.WeixinAppInfoDic[item.WeixinID] = new MWeixinParam(item.AppID, item.AppSecret);
                            }
                            else
                            {
                                this.WeixinAppInfoDic.Add(item.WeixinID, new MWeixinParam(item.AppID, item.AppSecret));
                            }
                        }
                    }
                    break;
            }

        }
    }
}
