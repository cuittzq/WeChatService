// ***********************************************************************
// <copyright file="Class1.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.Model
// Author            : 谭志强
// Created          : 2015/7/23 17:43:33
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Tzq.WeChatService.Model
{
    /// <summary>
    /// 微信Access_Token管理表
    /// </summary>
    [DataContract]
    public class MAccess_Token
    {
        #region private members

        /// <summary>
        ///  主键ID
        /// </summary>
        private string keyID = string.Empty;

        /// <summary>
        ///  微信AppID
        /// </summary>
        private string appID = string.Empty;

        /// <summary>
        ///  微信AppSecret
        /// </summary>
        private string appSecret = string.Empty;

        /// <summary>
        ///  微信Access_Token
        /// </summary>
        private string access_Token = string.Empty;

        /// <summary>
        /// 刷新token
        /// </summary>
        private string refreshToken = string.Empty;

        /// <summary>
        /// 微信公众号ID
        /// </summary>
        private string weixinID = string.Empty;

        /// <summary>
        /// Token类型	
        /// </summary>
        private string grant_Type = string.Empty;

        /// <summary>
        /// 用户唯一标识
        /// </summary>
        private string openID = string.Empty;

        /// <summary>
        /// 用户授权的作用域
        /// </summary>
        private string scope = string.Empty;

        /// <summary>
        /// 唯一标识
        /// </summary>
        private string unionID = string.Empty;

        /// <summary>
        ///  添加时间
        /// </summary>
        private DateTime addTime;

        /// <summary>
        ///  失效时间
        /// </summary>
        private DateTime outTime;

        /// <summary>
        ///  删除标志
        /// </summary>
        private int isDelete;

        private int companyID;

        /// <summary>
        /// 企业名称
        /// </summary>
        private string companyName = string.Empty;




        #endregion

        #region construction

        /// <summary>
        /// 构造函数
        /// </summary>
        public MAccess_Token()
        {
        }

        #endregion

        #region public members

        /// <summary>
        /// 主键ID
        /// </summary>
        [DataMember]
        public string KeyID
        {
            get { return this.keyID; }
            set { this.keyID = value; }
        }

        /// <summary>
        /// 微信AppID
        /// </summary>
        [DataMember]
        public string AppID
        {
            get { return this.appID; }
            set { this.appID = value; }
        }

        /// <summary>
        /// 微信AppSecret
        /// </summary>
        [DataMember]
        public string AppSecret
        {
            get { return this.appSecret; }
            set { this.appSecret = value; }
        }

        /// <summary>
        /// Token类型	
        /// </summary>
        [DataMember]
        public string Grant_Type
        {
            get { return grant_Type; }
            set { grant_Type = value; }
        }
        /// <summary>
        /// 刷新token
        /// </summary>
        [DataMember]
        public string RefreshToken
        {
            get { return refreshToken; }
            set { refreshToken = value; }
        }

        /// <summary>
        /// 微信Access_Token
        /// </summary>
        [DataMember]
        public string Access_Token
        {
            get { return this.access_Token; }
            set { this.access_Token = value; }
        }

        /// <summary>
        /// 用户唯一标识
        /// </summary>
        [DataMember]
        public string OpenID
        {
            get { return openID; }
            set { openID = value; }
        }

        /// <summary>
        /// 用户授权的作用域
        /// </summary>
        [DataMember]
        public string Scope
        {
            get { return scope; }
            set { scope = value; }
        }

        /// <summary>
        /// 微信公众号ID
        /// </summary>
        [DataMember]
        public string WeixinID
        {
            get { return weixinID; }
            set { weixinID = value; }
        }

        /// <summary>
        /// 唯一标识
        /// </summary>
        [DataMember]
        public string UnionID
        {
            get { return unionID; }
            set { unionID = value; }
        }

        /// <summary>
        /// 添加时间
        /// </summary>
        [DataMember]
        public DateTime AddTime
        {
            get { return this.addTime; }
            set { this.addTime = value; }
        }

        /// <summary>
        /// 失效时间
        /// </summary>
        [DataMember]
        public DateTime OutTime
        {
            get { return this.outTime; }
            set { this.outTime = value; }
        }

        /// <summary>
        /// 删除标志
        /// </summary>
        [DataMember]
        public int IsDelete
        {
            get { return this.isDelete; }
            set { this.isDelete = value; }
        }

        [DataMember]
        public int CompanyID
        {
            get { return companyID; }
            set { companyID = value; }
        }

        /// <summary>
        /// 企业名称
        /// </summary>
        [DataMember]
        public string CompanyName
        {
            get { return companyName; }
            set { companyName = value; }
        }
        #endregion

    }
}