// ***********************************************************************
// <copyright file="MTicketInfo.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.Model.DataModel
// Author            : 谭志强
// Created          : 2015/10/22 11:07:03
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tzq.WeChatService.Model
{
    public class MTicketInfo
    {
        /// <summary>
        ///  微信Access_Token
        /// </summary>
        private string access_Token = string.Empty;

        /// <summary>
        /// ticket
        /// </summary>
        private string ticket = string.Empty;

        /// <summary>
        ///  失效时间
        /// </summary>
        private DateTime outTime;

        /// <summary>
        /// ticket
        /// </summary>
        public string Ticket
        {
            get { return ticket; }
            set { ticket = value; }
        }
        /// <summary>
        ///  微信Access_Token
        /// </summary>
        public string Access_Token
        {
            get { return access_Token; }
            set { access_Token = value; }
        }

        /// <summary>
        ///  失效时间
        /// </summary>
        public DateTime OutTime
        {
            get { return outTime; }
            set { outTime = value; }
        }
    }
}
