using Better.SecurityUtility;
using Common.TxtLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tzq.WeChatService.DalBusiness;
using Tzq.WeChatService.Factory;
using Tzq.WeChatService.Model;

namespace Tzq.WeChatService.Buiness
{
    public class ApiAccessTokenManager
    {
        private ApiClient m_client;

        /// <summary>
        /// 
        /// </summary>
        private static ApiAccessTokenManager m_instance;

        /// <summary>
        /// 静态锁
        /// </summary>
        private static object m_lock = new object();

        /// <summary>
        /// 初始化获取所有授权信息
        /// </summary>
        public ApiAccessTokenManager()
        {
            BGetAccess_Token getAccess_Token = new BGetAccess_Token("client_credential");
            getAccess_Token.Execute();
            this.Access_TokenInfoDic = getAccess_Token.Access_TokenInfoDic;
            this.WeixinAppInfoDic = getAccess_Token.WeixinAppInfoDic;
            this.WeixinTicketDic = new Dictionary<string, MTicketInfo>();
        }

        /// <summary>
        /// 实例化
        /// </summary>
        public static ApiAccessTokenManager Instance
        {
            get
            {
                if (m_instance == null)
                {
                    lock (m_lock)
                    {
                        m_instance = new ApiAccessTokenManager();
                    }
                }

                return m_instance;
            }
        }

        /// <summary>
        /// 获取公众号token
        /// </summary>
        /// <returns></returns>
        public string GetCurrentToken(string appID)
        {
            if (Access_TokenInfoDic.ContainsKey(appID))
            {
                if (String.IsNullOrEmpty(Access_TokenInfoDic[appID].Access_Token) || DateTime.Now >= Access_TokenInfoDic[appID].OutTime)
                {
                    RefeshToken(appID);
                }

                return Access_TokenInfoDic[appID].Access_Token;
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 获取默认公众号token
        /// </summary>
        /// <returns></returns>
        public string GetDefaultToken()
        {
            if (Access_TokenInfoDic.ContainsKey(AppSettingFactory.GetAppID()))
            {
                if (String.IsNullOrEmpty(Access_TokenInfoDic[AppSettingFactory.GetAppID()].Access_Token) || DateTime.Now >= Access_TokenInfoDic[AppSettingFactory.GetAppID()].OutTime)
                {
                    RefeshToken(AppSettingFactory.GetAppID());
                }

                return Access_TokenInfoDic[AppSettingFactory.GetAppID()].Access_Token;
            }
            else
            {
                return string.Empty;
            }

        }

        /// <summary>
        /// 获取默认微信信息
        /// </summary>
        /// <returns></returns>
        public MAccess_Token GetDefaultWeixinInfo()
        {
            if (Access_TokenInfoDic.ContainsKey(AppSettingFactory.GetAppID()))
            {
                if (String.IsNullOrEmpty(Access_TokenInfoDic[AppSettingFactory.GetAppID()].Access_Token) || DateTime.Now >= Access_TokenInfoDic[AppSettingFactory.GetAppID()].OutTime)
                {
                    RefeshToken(AppSettingFactory.GetAppID());
                }

                return Access_TokenInfoDic[AppSettingFactory.GetAppID()];
            }
            else
            {
                return new MAccess_Token() { AppID = AppSettingFactory.GetAppID(), AppSecret = AppSettingFactory.GetAppSecret(), WeixinID = AppSettingFactory.GetWeixinID() };
            }
        }


        /// <summary>
        /// 获取微信公众号授权信息
        /// </summary>
        /// <param name="appid"></param>
        /// <returns></returns>
        public MWeixinParam GetWeixinAppInfo(string weixinID)
        {
            if (WeixinAppInfoDic.ContainsKey(weixinID))
            {
                return WeixinAppInfoDic[weixinID];
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 根据微信ID获取微信授权token
        /// </summary>
        /// <param name="appid"></param>
        /// <returns></returns>
        public string GetTokenByWeixinID(string weixinID)
        {
            if (WeixinAppInfoDic.ContainsKey(weixinID))
            {
                MWeixinParam weixinParam = WeixinAppInfoDic[weixinID];

                if (Access_TokenInfoDic.ContainsKey(weixinParam.AppID))
                {
                    if (String.IsNullOrEmpty(Access_TokenInfoDic[weixinParam.AppID].Access_Token) || DateTime.Now >= Access_TokenInfoDic[weixinParam.AppID].OutTime)
                    {
                        RefeshToken(weixinParam.AppID);
                    }

                    return Access_TokenInfoDic[weixinParam.AppID].Access_Token;
                }
                else
                {
                    return string.Empty;
                }

            }
            else
            {
                return string.Empty;
            }
        }


        /// <summary>
        /// 获取默认ticket
        /// </summary>
        /// <returns></returns>
        public string GetDefaultTicket()
        {
            string ticket = string.Empty;
            if (Access_TokenInfoDic.ContainsKey(AppSettingFactory.GetAppID()))
            {
                if (String.IsNullOrEmpty(Access_TokenInfoDic[AppSettingFactory.GetAppID()].Access_Token) || DateTime.Now >= Access_TokenInfoDic[AppSettingFactory.GetAppID()].OutTime)
                {
                    RefeshToken(AppSettingFactory.GetAppID());
                }

                if (WeixinTicketDic.ContainsKey(Access_TokenInfoDic[AppSettingFactory.GetAppID()].Access_Token))
                {
                    ticket = WeixinTicketDic[Access_TokenInfoDic[AppSettingFactory.GetAppID()].Access_Token].Ticket;
                }
            }
            else
            {
                ticket = string.Empty;
            }

            return ticket;
        }


        /// <summary>
        /// 根据微信ID获取ticket
        /// </summary>
        /// <param name="weixinID"></param>
        /// <returns></returns>
        public string GetTicketByWeixinID(string weixinID)
        {
            Dictionary<string, object> bugobjd = new Dictionary<string, object>();
            string ticket = string.Empty;
            try
            {
                bugobjd.Add("根据微信ID获取ticket", "根据微信ID获取ticket");
                bugobjd.Add("WeixinAppInfoDic", WeixinAppInfoDic);
                if (WeixinAppInfoDic.ContainsKey(weixinID))
                {

                    MWeixinParam weixinParam = WeixinAppInfoDic[weixinID];

                    bugobjd.Add("weixinParam", weixinParam);

                    if (Access_TokenInfoDic.ContainsKey(weixinParam.AppID))
                    {
                        MAccess_Token access_Token = Access_TokenInfoDic[weixinParam.AppID];

                        if (String.IsNullOrEmpty(access_Token.Access_Token) || DateTime.Now >= access_Token.OutTime)
                        {
                            RefeshToken(weixinParam.AppID);
                            access_Token = Access_TokenInfoDic[weixinParam.AppID];
                        }

                        if (WeixinTicketDic.ContainsKey(access_Token.Access_Token))
                        {
                            if (String.IsNullOrEmpty(WeixinTicketDic[access_Token.Access_Token].Ticket) || DateTime.Now >= WeixinTicketDic[access_Token.Access_Token].OutTime)
                            {
                                RefeshTicket(Access_TokenInfoDic[weixinParam.AppID].Access_Token);
                            }
                        }
                        else
                        {
                            RefeshTicket(Access_TokenInfoDic[weixinParam.AppID].Access_Token);
                        }

                        bugobjd.Add(" Access_TokenInfo", Access_TokenInfoDic[weixinParam.AppID]);
                        bugobjd.Add(" WeixinTicket", WeixinTicketDic[Access_TokenInfoDic[weixinParam.AppID].Access_Token]);
                        ticket = WeixinTicketDic[Access_TokenInfoDic[weixinParam.AppID].Access_Token].Ticket;
                    }
                }
            }
            catch (Exception ex)
            {
                TxtLogHelper.WriteLog_Day(new TxtLogInfoObject()
                {
                    LogType = EnumLogType.Error,
                    LogMessage = string.Format(" 根据微信ID获取ticket错误信息{0}；堆栈信息{1}", ex.Message, ex.StackTrace),
                });
                throw;
            }
            finally
            {
                TxtLogHelper.WriteDebugLog(bugobjd);
            }

            return ticket;
        }

        /// <summary>
        /// 刷新ticket
        /// </summary>
        /// <param name="access_Token"></param>
        private void RefeshTicket(string access_Token)
        {
            Dictionary<string, object> bugobjd = new Dictionary<string, object>();
            try
            {
                bugobjd.Add("方法名", "刷新ticket");
                bugobjd.Add("access_Token", access_Token);
                // 更新ticket
                GetTicketRequest ticketInfo = new GetTicketRequest(access_Token, "jsapi");

                ApiClient client = new ApiClient();
                DateTime now = DateTime.Now;
                var ticketResponse = client.Execute(ticketInfo);
                bugobjd.Add("ticketResponse", ticketResponse);
                if (this.WeixinTicketDic == null)
                {
                    this.WeixinTicketDic = new Dictionary<string, MTicketInfo>();
                }

                if (this.WeixinTicketDic.ContainsKey(access_Token))
                {
                    this.WeixinTicketDic[access_Token].Ticket = ticketResponse.Ticket;
                    this.WeixinTicketDic[access_Token].OutTime = now.AddSeconds(ticketResponse.Expires_In);
                }
                else
                {
                    this.WeixinTicketDic.Add(access_Token, new MTicketInfo()
                    {
                        Ticket = ticketResponse.Ticket,
                        Access_Token = access_Token,
                        OutTime = now.AddSeconds(ticketResponse.Expires_In)
                    });
                }

                bugobjd.Add("WeixinTicketDic", WeixinTicketDic);
            }
            catch (Exception ex)
            {
                TxtLogHelper.WriteLog_Day(new TxtLogInfoObject()
                {
                    LogType = EnumLogType.Error,
                    LogMessage = string.Format(" 刷新ticket 错误信息{0}；堆栈信息{1}", ex.Message, ex.StackTrace),
                });
                throw;
            }
            finally
            {
                TxtLogHelper.WriteDebugLog(bugobjd);
            }
        }

        /// <summary>
        /// 刷新公众号token
        /// </summary>
        private void RefeshToken(string appID)
        {
            if (Access_TokenInfoDic.ContainsKey(appID))
            {

                DateTime now = DateTime.Now;
                MWeixinParam weixinParam = null;
                // 如果已经超时
                if (Access_TokenInfoDic[appID].OutTime <= now)
                {
                    weixinParam = new MWeixinParam(Access_TokenInfoDic[appID].AppID, Access_TokenInfoDic[appID].AppSecret);
                    AccessTokenRequest request = new AccessTokenRequest(weixinParam);
                    // 重新获取token
                    var response = Client.Execute(request);
                    if (response.IsError)
                    {
                        throw new Exception(response.ErrorMessage);
                    }
                    // 修改授权
                    Access_TokenInfoDic[appID].OutTime = now.AddSeconds(response.Expires_In);
                    Access_TokenInfoDic[appID].Access_Token = response.Access_Token;

                    // 更新
                    BUpdateAccess_Token updateToken = new BUpdateAccess_Token(Access_TokenInfoDic[appID].KeyID, SecurityUtility.EncryptDES(Access_TokenInfoDic[appID].Access_Token), string.Empty, Access_TokenInfoDic[appID].OutTime);
                    updateToken.Execute();


                    // 更新ticket
                    this.RefeshTicket(response.Access_Token);
                }
            }

        }

        /// <summary>
        /// api客户端
        /// </summary>
        private ApiClient Client
        {
            get
            {
                if (m_client == null)
                {
                    m_client = new ApiClient();
                }

                return m_client;
            }
        }

        /// <summary>
        /// 公众号授权集合
        /// </summary>
        public Dictionary<string, MAccess_Token> Access_TokenInfoDic
        {
            get;
            set;
        }

        /// <summary>
        /// 公众号信息集合
        /// </summary>
        public Dictionary<string, MWeixinParam> WeixinAppInfoDic
        {
            get;
            set;
        }

        /// <summary>
        /// 微信Ticket
        /// </summary>
        public Dictionary<string, MTicketInfo> WeixinTicketDic
        {
            get;
            set;
        }
    }
}
