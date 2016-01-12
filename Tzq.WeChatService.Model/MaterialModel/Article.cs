// ***********************************************************************
// <copyright file="Article.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.Model.MaterialModel
// Author            : 谭志强
// Created          : 2015/12/16 11:17:32
// <summary></summary>
// ***********************************************************************

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tzq.WeChatService.Model
{
    public class Article
    {

        /* title	 是	 标题
        thumb_media_id	 是	 图文消息的封面图片素材id（必须是永久mediaID）
        author	 是	 作者
        digest	 是	 图文消息的摘要，仅有单图文消息才有摘要，多图文此处为空
        show_cover_pic	 是	 是否显示封面，0为false，即不显示，1为true，即显示
        content	 是	 图文消息的具体内容，支持HTML标签，必须少于2万字符，小于1M，且此处会去除JS
        content_source_url	 是	 图文消息的原文地址，即点击“阅读原文”后的URL*/

        /// <summary>
        /// Title
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// 图文消息的封面图片素材id（必须是永久mediaID）
        /// </summary>
        [JsonProperty("thumb_media_id")]
        public string ThumbMediaId { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        [JsonProperty("author")]
        public string Author { get; set; }

        /// <summary>
        /// 图文消息的摘要，仅有单图文消息才有摘要，多图文此处为空
        /// </summary>
        [JsonProperty("digest")]
        public string Description { get; set; }

        /// <summary>
        /// 是否显示封面，0为false，即不显示，1为true，即显示
        /// </summary>
        [JsonProperty("show_cover_pic")]
        public int ShowcoverPic { get; set; }

        /// <summary>
        /// 图文消息的具体内容，支持HTML标签，必须少于2万字符，小于1M，且此处会去除JS
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; set; }

        /// <summary>
        /// 图文消息的原文地址
        /// </summary>
        [JsonProperty("content_source_url")]
        public string ContentSourceUrl { get; set; }
    }
}
