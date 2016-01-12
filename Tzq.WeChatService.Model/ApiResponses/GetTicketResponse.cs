// ***********************************************************************
// <copyright file="GetTicketResponse.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.Model.ApiResponses
// Author            : 谭志强
// Created          : 2015/10/22 10:33:15
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tzq.WeChatService.Model
{
    public class GetTicketResponse : ApiResponses
    {
        /// <summary>
        /// 获取的ticket
        /// </summary>
        public string Ticket { get; set; }

        /// <summary>
        /// ticket的有效时间
        /// </summary>
        public int Expires_In { get; set; }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (IsError)
            {
                return base.ToString();
            }

            return String.Format("Ticket:{0}, Expires_In:{1}", Ticket, Expires_In);
        }
    }
}
