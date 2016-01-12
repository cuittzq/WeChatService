// ***********************************************************************
// <copyright file="ApiClient.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.Buiness.WeixinAPI
// Author            : 谭志强
// Created          : 2015/7/27 10:41:27
// <summary></summary>
// ***********************************************************************

using Common.TxtLog;
using Newtonsoft.Json;
using Tzq.WeChatService.Common;
using Tzq.WeChatService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Tzq.WeChatService.Buiness;

namespace Tzq.WeChatService.Buiness
{
    /// <summary>
    /// 
    /// </summary>
    public class ApiClient
    {
        /// <summary>
        /// 执行请求
        /// </summary>
        /// <typeparam name="T">响应</typeparam>
        /// <param name="request">请求</param>
        /// <returns>响应</returns>
        public T Execute<T>(ApiRequestBase<T> request)
        where T : ApiResponses, new()
        {
            request.Validate();

            var execResult = DoExecute(request);
            T result = null;
            try
            {
                result = JsonConvert.DeserializeObject<T>(execResult);
            }
            catch (Exception ex)
            {
                Log(ex);
                result = null;
            }

            if (result == null)
            {
                if (request.NotHasResponse)
                {
                    return new T();
                }
                else
                {
                    //  throw new WebException();

                    return new T();
                }
            }

            return result;
        }


        /// <summary>
        /// 执行网络请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public virtual string DoExecute<T>(ApiRequestBase<T> request)
            where T : ApiResponses
        {
            var url = request.GetUrl();
            //Log(url);
            var result = String.Empty;
            switch (request.Method)
            {
                case "FILE":
                    result = HttpHelper.HttpUploadFile(url, request.GetPostContent());
                    break;
                case "POST":
                    result = HttpHelper.HttpPost(url, request.GetPostContent());
                    break;
                case "POSTFILE":
                    result = HttpHelper.FilePostRequest(url, request.GetPostContent());
                    break;
                case "GET":
                default:
                    result = HttpHelper.HttpGet(url);
                    break;
            }

            return result;
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
