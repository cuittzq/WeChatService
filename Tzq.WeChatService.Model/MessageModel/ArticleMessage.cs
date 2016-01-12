// ***********************************************************************
// <copyright file="ArticleMessage.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.Model.MessageModel
// Author            : 谭志强
// Created          : 2015/8/27 12:10:32
// <summary></summary>
// ***********************************************************************

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Tzq.WeChatService.Model
{
    /// <summary>
    /// 图文消息
    /// </summary>
    public class ArticleMessage
    {
        protected XmlDocument doc = new XmlDocument();

        [XmlIgnore]
        [JsonProperty("title")]
        public string Title { get; set; }

        [XmlIgnore]
        [JsonProperty("digest")]
        public string Description { get; set; }

        [XmlIgnore]
        [JsonIgnore]
        public string PicUrl { get; set; }

        [XmlIgnore]
        [JsonProperty("thumb_media_id")]
        public string ThumbMediaId { get; set; }

        [XmlIgnore]
        [JsonProperty("content_source_url")]
        public string Url { get; set; }

        [XmlIgnore]
        [JsonProperty("content")]
        public string Content { get; set; }

        [XmlIgnore]
        [JsonProperty("author")]
        public string Author { get; set; }

        [XmlElement("Title")]
        [JsonIgnore]
        public XmlCDataSection CTitle
        {
            get
            {
                return doc.CreateCDataSection(Title);
            }
            set
            {
                Title = value.Value;
            }
        }

        [XmlElement("Description")]
        [JsonIgnore]
        public XmlCDataSection CDescription
        {
            get
            {
                return doc.CreateCDataSection(Description);
            }
            set
            {
                Description = value.Value;
            }
        }

        [XmlElement("PicUrl")]
        [JsonIgnore]
        public XmlCDataSection CPicUrl
        {
            get
            {
                return doc.CreateCDataSection(PicUrl);
            }
            set
            {
                PicUrl = value.Value;
            }
        }

        [XmlElement("Url")]
        [JsonIgnore]
        public XmlCDataSection CUrl
        {
            get
            {
                return doc.CreateCDataSection(Url);
            }
            set
            {
                Url = value.Value;
            }
        }
    }
}
