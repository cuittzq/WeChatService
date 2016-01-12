// ***********************************************************************
// <copyright file="MMaterialNodesRelation.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.Model.MaterialModel
// Author            : 谭志强
// Created          : 2015/12/18 10:28:08
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tzq.WeChatService.Model
{
    /// <summary>
    /// 素材模板xml 标记关系
    /// </summary>
    public class MMaterialNodesRelation
    {

        /// <summary>
        ///  属性名称
        /// </summary>
        public string NodeAttributeName { get; set; }

        /// <summary>
        ///  属性值
        /// </summary>
        public string NodeAttributeValue { get; set; }

        /// <summary>
        /// 节点地址
        /// </summary>
        public string Xpath { get; set; }

        /// <summary>
        /// 节点值
        /// </summary>
        public string Value { get; set; }
    }
}
