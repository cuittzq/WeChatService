// ***********************************************************************
// <copyright file="UploadImageRequest.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.Buiness.ApiRequests
// Author            : 谭志强
// Created          : 2015/12/17 16:13:22
// <summary></summary>
// ***********************************************************************

using Newtonsoft.Json;
using Tzq.WeChatService.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tzq.WeChatService.Buiness
{
    public class UploadImageRequest : ApiRequestBase<UploadImageResponse>
    {
        private string filePath = string.Empty;

        public string accessToken = string.Empty;


        public UploadImageRequest(string filePath, string token)
            : base()
        {
            this.accessToken = token;
            this.filePath = filePath;
        }

        internal override string Method
        {
            get { return "POSTFILE"; }
        }

        protected override string UrlFormat
        {
            get { return "https://api.weixin.qq.com/cgi-bin/media/uploadimg?access_token={0}&type={1}"; }
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
            return this.filePath;
        }

        public MediaType MediaType
        {
            get { return MediaType.Image; }
        }

        internal override void Validate()
        {
            base.Validate();
            FileInfo file = new FileInfo(this.filePath);
            if (!file.Exists)
            {
                throw new FileNotFoundException();
            }

            if (file.Extension != ".jpg")
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
