// ***********************************************************************
// <copyright file="MCMDResultObject.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.Model.ApiResponses
// Author            : 谭志强
// Created          : 2015/12/17 17:44:03
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tzq.WeChatService.Model
{
    public class MCMDResultObject
    {
        /// <summary>
        /// 执行返回的消息
        /// </summary>
        private string message = string.Empty;

        /// <summary>
        /// 执行返回的bool值结果
        /// </summary>
        private bool result = false;

        /// <summary>
        /// 执行返回的数据
        /// </summary>
        private object returnObject = null;

        /// <summary>
        /// Wmi管理方法执行结果
        /// </summary>
        public MCMDResultObject()
        {
        }

        /// <summary>
        /// 执行返回的消息
        /// </summary>
        public string Message
        {
            get { return this.message; }
            set { this.message = value; }
        }

        /// <summary>
        /// 执行返回的bool值结果
        /// </summary>
        public bool Result
        {
            get { return this.result; }
            set { this.result = value; }
        }

        /// <summary>
        /// 执行返回的数据
        /// </summary>
        public object ReturnObject
        {
            get { return this.returnObject; }
            set { this.returnObject = value; }
        }
    }
}
