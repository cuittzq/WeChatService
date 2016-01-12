// ***********************************************************************
// Copyright (c) . All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.Factory
// Author            : 谭志强
// Created          : 2015/7/24 9:28:58
// <summary></summary>
// ***********************************************************************

using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using MySql.Data.MySqlClient;

namespace Tzq.WeChatService.Factory
{
    public class ConnectionConfig
    {
        /// <summary>
        /// 解密连接字符串
        /// </summary>
        /// <param name="conn">原始字符串</param>
        /// <returns>解密后的串</returns>
        internal static string Conn(string conn)
        {
            StringBuilder strBuilder = new StringBuilder();
            string[] connArr = conn.Split(new char[] { ';' });
            foreach (string con in connArr)
            {
                if (con.ToUpper().IndexOf("UID") >= 0 || con.ToUpper().IndexOf("PWD") >= 0)
                {
                    string[] conPwdUser = con.Split(new char[] { '=' });
                    strBuilder.Append(conPwdUser[0]);
                    strBuilder.Append("=");
                }
                else
                {
                    strBuilder.Append(con);
                }

                strBuilder.Append(";");
            }

            strBuilder.Remove(strBuilder.Length - 1, 1);
            return strBuilder.ToString();
        }

        /// <summary>
        /// 获取连接对象
        /// </summary>
        /// <param name="connectionKey">连接Key</param>
        /// <returns>连接对象</returns>
        internal static IDbConnection GetConnection(string connectionKey)
        {
            IDbConnection connection = null;
            ConnectionStringSettings connectionSetting = ConfigurationManager.ConnectionStrings[connectionKey];
            string oriConnectionString = connectionSetting.ConnectionString;
            string providerName = connectionSetting.ProviderName;
            if ("MySql.Data.MySqlClient".Equals(providerName))
            {
                connection = new MySqlConnection(oriConnectionString);
            }
            else
            {
                connection = new SqlConnection(oriConnectionString);
            }

            return connection;
        }
    }
}
