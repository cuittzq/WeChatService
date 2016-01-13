using Common.TxtLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using Tzq.WeChatService.MessageBuiness;

namespace Tzq.WeChatService.WebUI
{
    public partial class MsgHandle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Dictionary<string, object> bugobj = new Dictionary<string, object>();
            try
            {
                bugobj.Add("HttpMethod", Request.HttpMethod.ToString());
                //微信服务器一直把用户发过来的消息，post过来
                if (Request.HttpMethod.ToUpper() == "POST")
                {
                    XDocument doc = null;
                    if (Request.InputStream != null)
                    {
                        var reader = XmlReader.Create(Request.InputStream);
                        doc = XDocument.Load(reader);
                    }

                    if (doc != null)
                    {
                        var xml = doc.Element("xml");
                        // 解析xml消息
                        var msg = new HandleMessage(xml);
                        if (msg != null)
                        {
                            bugobj.Add("消息主体", msg.Element.ToString());
                            TxtLogHelper.WriteDebugLog(bugobj);
                            var responseMessage = new WebMessageRole().MessageRole(msg).HandlerRequestMessage();
                            if (responseMessage != null)
                            {
                                Response.Write(responseMessage.Serializable());
                                bugobj.Add("响应", responseMessage.Serializable());
                            }
                        }
                        else
                        {
                            Response.Write("post数据为空");
                        }
                    }
                    else
                    {
                        Response.Write("post数据为空");
                    }

                }
                else if (Request.HttpMethod.ToUpper() == "GET") //微信服务器在首次验证时，需要进行一些验证，但。。。。
                {
                    bugobj.Add("signature", Request["signature"]);
                    bugobj.Add("timestamp", Request["timestamp"]);
                    bugobj.Add("nonce", Request["nonce"]);
                    bugobj.Add("微信验证", Request["echostr"]);
                    string echostr = string.Empty;
                    if (Request["echostr"] != null)
                    {
                        echostr = Request["echostr"].ToString();
                    }

                    //我仅需返回给他echostr中的值，就为验证成功，可能微信觉得这些安全策略是为了保障我的服务器，要不要随你吧
                    Response.Write(echostr);
                    return;
                }
            }
            catch (Exception ex)
            {
                TxtLogHelper.WriteLog_Day(new TxtLogInfoObject()
                {
                    LogType = EnumLogType.Error,
                    LogMessage = string.Format("错误信息{0}；堆栈信息{1}", ex.Message, ex.StackTrace),
                    LogObject = ex,
                });

                Response.Write("post数据为空");
            }
            finally
            {
                TxtLogHelper.WriteDebugLog(bugobj);
            }
        }
    }
}