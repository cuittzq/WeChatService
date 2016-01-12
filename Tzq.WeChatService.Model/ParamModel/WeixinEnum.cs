// ***********************************************************************
// <copyright file="WeixinEnum.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.Model
// Author            : 谭志强
// Created          : 2015/7/24 14:21:25
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Tzq.WeChatService.Model
{
    public enum MsgType
    {
        Text,
        Image,
        Voice,
        Video,
        Location,
        Link,
        Event,
        News,
        Music,
        ShortVideo,
        transfer_customer_service
    }

    public enum Event
    {
        Subscribe,
        Unsubscribe,
        Scan,
        Location,
        Click,
        MASSSENDJOBFINISH,
        View,
        Merchant_Order,
        TEMPLATESENDJOBFINISH //模板消息 2014-09-23
    }

    public enum MediaType
    {
        Image,
        Voice,
        Video,
        Thumb
    }

    public enum OAuthScope
    {
        Base,
        UserInfo
    }

    public enum Language
    {
        CN,
        TW,
        EN
    }

    /// <summary>
    /// 行业模板
    /// </summary>
    public enum TemplateIndustry
    {
        /// <summary>
        /// 互联网/电子商务	
        /// </summary>
        ITNetAndBusiness = 1,
        /// <summary>
        /// IT软件与服务	
        /// </summary>
        ITSoftAndServices = 2,
        /// <summary>
        /// IT硬件与设备	
        /// </summary>
        ITHardware = 3,
        /// <summary>
        /// 电子技术	
        /// </summary>
        ITElectronicTech = 4,
        /// <summary>
        /// 通信运营商
        /// </summary>
        ITOperators = 5,
        /// <summary>
        /// 网络游戏
        /// </summary>
        ITGames = 6,
        /// <summary>
        /// 银行
        /// </summary>
        FBank = 7,
        /// <summary>
        /// 基金|理财|信托
        /// </summary>
        FInvestment = 8,
        /// <summary>
        /// 保险
        /// </summary>
        FInsurance = 9,
        /// <summary>
        /// 餐饮
        /// </summary>
        Catering = 10,
        /// <summary>
        /// 酒店
        /// </summary>
        Hotel = 11,
        /// <summary>
        /// 旅游
        /// </summary>
        Travel = 12,
        /// <summary>
        /// 快递
        /// </summary>
        Express = 13,
        /// <summary>
        /// 物流
        /// </summary>
        Logistics = 14,
        /// <summary>
        /// 仓储
        /// </summary>
        Store = 15,
        /// <summary>
        /// 培训
        /// </summary>
        Cultivate = 16,
        /// <summary>
        /// 院校
        /// </summary>
        School = 17,
        /// <summary>
        /// 学术和科研
        /// </summary>
        AcademicResearch = 18,
        /// <summary>
        /// 交警
        /// </summary>
        TrafficPolice = 19,
        /// <summary>
        /// 博物馆
        /// </summary>
        Museum = 20,
        /// <summary>
        /// 公共事业
        /// </summary>
        PublicUtilities = 21,
        /// <summary>
        /// 医药医疗	
        /// </summary>
        Medical = 22,
        /// <summary>
        /// 美容
        /// </summary>
        Cosmetology = 23,
        /// <summary>
        /// 保健与卫生
        /// </summary>
        HealthCare = 24,
        /// <summary>
        /// 汽车业
        /// </summary>
        Auto = 25,
        /// <summary>
        /// 摩托车
        /// </summary>
        Motor = 26,
        /// <summary>
        /// 火车
        /// </summary>
        Train = 27,
        /// <summary>
        /// 飞机业
        /// </summary>
        Plane = 28,
        /// <summary>
        /// 建筑业
        /// </summary>
        Building = 29,
        /// <summary>
        /// 物业
        /// </summary>
        Property = 30,
        /// <summary>
        /// 消费品
        /// </summary>
        ConsumerGoods = 31,
        /// <summary>
        /// 法律
        /// </summary>
        Law = 32,
        /// <summary>
        /// 会展
        /// </summary>
        Exhibition = 33,
        /// <summary>
        /// 中介服务
        /// </summary>
        Intermediary = 34,
        /// <summary>
        /// 认证
        /// </summary>
        Authentication = 35,
        /// <summary>
        /// 审计
        /// </summary>
        Audit = 36,
        /// <summary>
        /// 传媒
        /// </summary>
        Media = 37,
        /// <summary>
        /// 体育
        /// </summary>
        Sports = 38,
        /// <summary>
        /// 娱乐和休闲
        /// </summary>
        Entertainment = 39,
        /// <summary>
        /// 印刷
        /// </summary>
        Printing = 40,
        /// <summary>
        /// 其他
        /// </summary>
        Other = 41
    }

    public enum MenuType
    {
        /// <summary>
        /// 用户点击click类型按钮后，
        /// 微信服务器会通过消息接口推送消息类型为event	的结构给开发者（参考消息接口指南），
        /// 并且带上按钮中开发者填写的key值，开发者可以通过自定义的key值与用户进行交互；
        /// </summary>
        click,

        /// <summary>
        /// 用户点击view类型按钮后，
        /// 微信客户端将会打开开发者在按钮中填写的网页URL，
        /// 可与网页授权获取用户基本信息接口结合，获得用户基本信息。
        /// </summary>
        view,

        /// <summary>
        /// 用户点击按钮后，
        /// 微信客户端将调起扫一扫工具，
        /// 完成扫码操作后显示扫描结果（如果是URL，将进入URL），
        /// 且会将扫码的结果传给开发者，开发者可以下发消息。
        /// </summary>
        scancode_push,

        /// <summary>
        /// 扫码推事件且弹出提示框
        /// 用户点击按钮后，
        /// 微信客户端将调起扫一扫工具，
        /// 完成扫码操作后，将扫码的结果传给开发者，
        /// 同时收起扫一扫工具，然后弹出“消息接收中”提示框，
        /// 随后可能会收到开发者下发的消息。
        /// </summary>
        scancode_waitmsg,
        /// <summary>
        /// 弹出系统拍照发图
        /// 用户点击按钮后，
        /// 微信客户端将调起系统相机，
        /// 完成拍照操作后，会将拍摄的相片发送给开发者，
        /// 并推送事件给开发者，同时收起系统相机，随后可能会收到开发者下发的消息。
        /// </summary>
        pic_sysphoto,

        /// <summary>
        /// 弹出拍照或者相册发图
        /// 用户点击按钮后，
        /// 微信客户端将弹出选择器供用户选择“拍照”或者“从手机相册选择”。
        /// 用户选择后即走其他两种流程。
        /// </summary>
        pic_photo_or_album,

        /// <summary>
        /// 弹出微信相册发图器
        /// 用户点击按钮后，
        /// 微信客户端将调起微信相册，完成选择操作后，
        /// 将选择的相片发送给开发者的服务器，并推送事件给开发者，
        /// 同时收起相册，随后可能会收到开发者下发的消息。
        /// </summary>
        pic_weixin,

        /// <summary>
        /// 用户点击按钮后，
        /// 微信客户端将调起地理位置选择工具，
        /// 完成选择操作后，将选择的地理位置发送给开发者的服务器，
        /// 同时收起位置选择工具，随后可能会收到开发者下发的消息。
        /// </summary>
        location_select,

        /// <summary>
        /// 下发消息
        /// 用户点击media_id类型按钮后，
        /// 微信服务器会将开发者填写的永久素材id对应的素材下发给用户，
        /// 永久素材类型可以是图片、音频、视频、图文消息。请注意：永久素材id必须是在“素材管理/新增永久素材”接口上传后获得的合法id。
        /// </summary>
        media_id,

        /// <summary>
        /// 跳转图文消息URL
        /// 用户点击view_limited类型按钮后，
        /// 微信客户端将打开开发者在按钮中填写的永久素材id对应的图文消息URL，
        /// 永久素材类型只支持图文消息。请注意：永久素材id必须是在“素材管理/新增永久素材”接口上传后获得的合法id。
        /// </summary>
        view_limited

    }

    /// <summary>
    /// 二维码类型
    /// </summary>
    public enum Action_Name
    {
        /// <summary>
        /// 临时二维码
        /// </summary>
        QR_SCENE,
        /// <summary>
        /// 永久二维码
        /// </summary>
        QR_LIMIT_STR_SCENE
    }

    public enum GroupName
    {
        店主 = 102,
        加盟商 = 103,
        普通客户 = 104
    }

}
