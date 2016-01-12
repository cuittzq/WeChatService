// ***********************************************************************
// <copyright file="ApiRequestBase.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.Buiness
// Author            : 谭志强
// Created          : 2015/7/27 9:38:58
// <summary></summary>
// ***********************************************************************

using Common.TxtLog;
using Tzq.WeChatService.Factory;
using Tzq.WeChatService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tzq.WeChatService.Buiness
{
    public abstract class ApiRequestBase<T>
        where T : ApiResponses
    {
        protected const string POSTMETHOD = "POST";
        protected const string GETMETHOD = "GET";

        /// <summary>
        /// 应用程序参数
        /// </summary>
        private MWeixinParam weixinParam = null;

        /// <summary>
        /// 
        /// </summary>
        private string errcode = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        private string errmsg = string.Empty;


        public ApiRequestBase(MWeixinParam weixinParam)
        {
            this.WeixinParam = weixinParam;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public ApiRequestBase()
        {
            this.WeixinParam = new MWeixinParam(AppSettingFactory.GetAppID(), AppSettingFactory.GetAppSecret());
        }

        /// <summary>
        /// 应用程序参数
        /// </summary>
        public MWeixinParam WeixinParam
        {
            get { return weixinParam; }
            set { weixinParam = value; }
        }

        /// <summary>
        /// url格式
        /// </summary>
        protected abstract string UrlFormat { get; }

        /// <summary>
        /// 获取请求地址
        /// </summary>
        /// <returns></returns>
        internal abstract string GetUrl();

        /// <summary>
        /// 请求方式
        /// </summary>
        internal abstract string Method { get; }

        /// <summary>
        /// 是否需要token
        /// </summary>
        protected abstract bool NeedToken { get; }

        /// <summary>
        /// 令牌
        /// </summary>
        internal abstract string AccessToken { get; }

        /// <summary>
        /// 是否有返回数据
        /// </summary>
        internal virtual bool NotHasResponse
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// 获取post数据
        /// </summary>
        /// <returns></returns>
        public abstract string GetPostContent();

        /// <summary>
        /// 验证
        /// </summary>
        internal virtual void Validate()
        {
            Dictionary<string, object> debugLog = new Dictionary<string, object>();
            debugLog.Add("url", GetUrl());
            debugLog.Add("AppID", this.WeixinParam.AppID);
            debugLog.Add("AppSecret", this.WeixinParam.AppSecret);
            debugLog.Add("AccessToken", this.AccessToken);
            Log(debugLog);
            if (NeedToken && String.IsNullOrEmpty(this.AccessToken))
            {
                throw new Exception("AccessToken 过期或者 AccessToken为空");
            }
        }

        /// <summary>
        /// 记录异常
        /// </summary>
        /// <param name="ex"></param>
        public void Log(Exception ex)
        {
            TxtLogHelper.WriteLog_Day(new TxtLogInfoObject()
            {
                LogType = EnumLogType.Error,
                LogMessage = string.Format("错误信息{0}；堆栈信息{1}", ex.Message, ex.StackTrace),
            });
        }

        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="debugLog"></param>
        public void Log(Dictionary<string, object> debugLog)
        {
            TxtLogHelper.WriteDebugLog(debugLog);
        }
    }
}
