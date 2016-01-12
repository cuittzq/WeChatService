// ***********************************************************************
// <copyright file="MenuInfo.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.Model.DataModel
// Author            : 谭志强
// Created          : 2015/8/5 12:10:15
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tzq.WeChatService.Model
{
    public class MenuInfo
    {
        ///// <summary>
        ///// 菜单的响应动作类型
        ///// </summary>
        //private string type = MenuType.click.ToString();

        ///// <summary>
        ///// 菜单标题，不超过16个字节，子菜单不超过40个字节
        ///// </summary>
        //private string name = string.Empty;

        ///// <summary>
        ///// click等点击类型必须	 菜单KEY值，用于消息接口推送，不超过128字节
        ///// </summary>
        //private string key = string.Empty;

        ///// <summary>
        /////  view类型必须	 网页链接，用户点击菜单可打开链接，不超过256字节
        ///// </summary>
        //private string url = string.Empty;

        ///// <summary>
        ///// media_id类型和view_limited类型必须	 调用新增永久素材接口返回的合法media_id
        ///// </summary>
        //private string media_id = string.Empty;

        ///// <summary>
        ///// 子菜单
        ///// </summary>
        //private List<MenuInfo> sub_Button = null;

        /// <summary>
        /// 菜单的响应动作类型
        /// </summary>
        public string type
        {
            get;
            set;
        }

        /// <summary>
        /// 菜单标题，不超过16个字节，子菜单不超过40个字节
        /// </summary>
        public string name
        {
            get;
            set;
        }

        /// <summary>
        /// click等点击类型必须	 菜单KEY值，用于消息接口推送，不超过128字节
        /// </summary>
        public string key
        {
            get;
            set;
        }

        /// <summary>
        ///  view类型必须	 网页链接，用户点击菜单可打开链接，不超过256字节
        /// </summary>
        public string url
        {
            get;
            set;
        }

        /// <summary>
        /// media_id类型和view_limited类型必须	 调用新增永久素材接口返回的合法media_id
        /// </summary>
        public string media_id
        {
            get;
            set;
        }

        /// <summary>
        /// 子菜单
        /// </summary>
        public List<MenuInfo> sub_button
        {
            get;
            set;
        }
    }
}
