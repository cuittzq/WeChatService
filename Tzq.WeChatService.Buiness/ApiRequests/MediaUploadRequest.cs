// ***********************************************************************
// <copyright file="MediaUploadRequest.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.Buiness.ApiRequests
// Author            : 谭志强
// Created          : 2015/12/15 11:30:53
// <summary></summary>
// ***********************************************************************

using Tzq.WeChatService.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tzq.WeChatService.Buiness
{
    /// <summary>
    /// 注意事项
    /// 上传的临时多媒体文件有格式和大小限制，如下：
    /// 图片（image）: 1M，支持JPG格式
    /// 语音（voice）：2M，播放长度不超过60s，支持AMR\MP3格式
    /// 视频（video）：10MB，支持MP4格式
    /// 缩略图（thumb）：64KB，支持JPG格式
    /// </summary>
    public class MediaUploadRequest : ApiRequestBase<MediaUploadResponse>
    {
        private string filePath = string.Empty;

        public string accessToken = string.Empty;


        public MediaUploadRequest(string filePath, string token)
            : base()
        {
            this.accessToken = token;
            this.filePath = filePath;
        }

        internal override string Method
        {
            get { return "FILE"; }
        }

        protected override string UrlFormat
        {
            get { return "http://file.api.weixin.qq.com/cgi-bin/media/upload?access_token={0}&type={1}"; }
        }

        internal override string GetUrl()
        {
            return String.Format(UrlFormat, AccessToken, MediaType);
        }

        protected override bool NeedToken
        {
            get { return true; }
        }

        public override string GetPostContent()
        {
            return filePath;
        }

        public MediaType MediaType { get; set; }

        internal override void Validate()
        {
            base.Validate();
            FileInfo file = new FileInfo(this.filePath);
            if (!file.Exists)
            {
                throw new FileNotFoundException();
            }

            if (file.Extension != ".jpg" &&
                file.Extension != ".amr" &&
                file.Extension != ".mp3" &&
                file.Extension != ".mp4")
            {
                throw new NotSupportedException("不支持上传的文件类型");
            }
        }

        internal override string AccessToken
        {
            get { return this.accessToken; }
        }
    }
}
