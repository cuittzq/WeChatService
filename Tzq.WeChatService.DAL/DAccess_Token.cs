// ***********************************************************************
// <copyright file="DAccess_Token.cs" company="四川全球通">
// Copyright (c) 四川全球通. All rights reserved.</copyright>
// Assembly         : Tzq.WeChatService.DAL
// Author            : 谭志强
// Created          : 2015/7/24 10:39:51
// <summary></summary>
// ***********************************************************************

using Better.SecurityUtility;
using Common.DBUtility;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tzq.WeChatService.Model;

namespace Tzq.WeChatService.DAL
{
    /// <summary>
    /// 微信Access_Token管理表
    /// </summary>
    public class DAccess_Token
    {
        /// <summary>
        /// 记录token
        /// </summary>
        /// <param name="trans">事物</param>
        /// <param name="conn">连接</param>
        /// <param name="access_Token">令牌</param>
        /// <returns>是否成功</returns>
        public bool InsertAccess_Token(IDbTransaction trans, IDbConnection conn, MAccess_Token access_Token)
        {
            string insertsql = @"Insert into  Access_Token(KeyID,AppID,WeixinID,AppSecret,Access_Token,RefreshToken,Grant_Type,OpenID,Scope,UnionID,AddTime,OutTime,ModifyTime,IsDelete
                                            )VALUES(@KeyID,@AppID,@WeixinID,@AppSecret,@Access_Token,@RefreshToken,@Grant_Type,@OpenID,@Scope,@UnionID,now(),@OutTime,now(),0);";
            MySqlParameters parameters = new MySqlParameters();
            parameters.Add(new MySqlParameter() { ParameterName = "@KeyID", MySqlDbType = MySqlDbType.VarChar, Value = access_Token.KeyID });
            parameters.Add(new MySqlParameter() { ParameterName = "@AppID", MySqlDbType = MySqlDbType.VarChar, Value = access_Token.AppID });
            parameters.Add(new MySqlParameter() { ParameterName = "@WeixinID", MySqlDbType = MySqlDbType.VarChar, Value = access_Token.WeixinID });
            parameters.Add(new MySqlParameter() { ParameterName = "@AppSecret", MySqlDbType = MySqlDbType.VarChar, Value = access_Token.AppSecret });
            parameters.Add(new MySqlParameter() { ParameterName = "@Access_Token", MySqlDbType = MySqlDbType.VarChar, Value = access_Token.Access_Token });
            parameters.Add(new MySqlParameter() { ParameterName = "@RefreshToken", MySqlDbType = MySqlDbType.VarChar, Value = access_Token.RefreshToken });
            parameters.Add(new MySqlParameter() { ParameterName = "@Grant_Type", MySqlDbType = MySqlDbType.VarChar, Value = access_Token.Grant_Type });
            parameters.Add(new MySqlParameter() { ParameterName = "@OpenID", MySqlDbType = MySqlDbType.VarChar, Value = access_Token.OpenID });
            parameters.Add(new MySqlParameter() { ParameterName = "@Scope", MySqlDbType = MySqlDbType.VarChar, Value = access_Token.Scope });
            parameters.Add(new MySqlParameter() { ParameterName = "@UnionID", MySqlDbType = MySqlDbType.VarChar, Value = access_Token.UnionID });
            parameters.Add(new MySqlParameter() { ParameterName = "@OutTime", MySqlDbType = MySqlDbType.DateTime, Value = access_Token.OutTime });
            return Common.DBUtility.MySqlHelper.ExecuteSql(trans, conn, insertsql, parameters.ToArray()) == 1;
        }

        /// <summary>
        /// 更新令牌
        /// </summary>
        /// <param name="trans">事物</param>
        /// <param name="conn">连接</param>
        /// <param name="tokenstr">口令</param>
        /// <param name="outTime">失效时间</param>
        /// <returns>是否更新成功</returns>
        public bool UpdateAccess_Token(IDbTransaction trans, IDbConnection conn, string keyID, string tokenstr, string refreshToken, DateTime outTime)
        {
            string insertsql = @"UPDATE Access_Token SET Access_Token = @Access_Token,OutTime = @OutTime";
            MySqlParameters parameters = new MySqlParameters();
            if (!string.IsNullOrEmpty(refreshToken))
            {
                insertsql += " ,RefreshToken = @RefreshToken ";
                parameters.Add(new MySqlParameter() { ParameterName = "@RefreshToken", MySqlDbType = MySqlDbType.VarChar, Value = refreshToken });
            }

            insertsql += " WHERE KeyID=@KeyID and IsDelete = 0 limit 1";
            parameters.Add(new MySqlParameter() { ParameterName = "@KeyID", MySqlDbType = MySqlDbType.VarChar, Value = keyID });
            parameters.Add(new MySqlParameter() { ParameterName = "@Access_Token", MySqlDbType = MySqlDbType.VarChar, Value = tokenstr });
            parameters.Add(new MySqlParameter() { ParameterName = "@OutTime", MySqlDbType = MySqlDbType.DateTime, Value = outTime });
            return Common.DBUtility.MySqlHelper.ExecuteSql(null, conn, insertsql, parameters.ToArray()) == 1;
        }

        /// <summary>
        /// 获取口令(公众号)
        /// </summary>
        /// <param name="trans">事物</param>
        /// <param name="conn">连接</param>
        /// <param name="appid">appid</param>
        /// <param name="appSecret">appSecret</param>
        /// <param name="grant_Type">grant_Type</param>
        /// <returns></returns>
        public MAccess_Token GetAccess_Token(IDbTransaction trans, IDbConnection conn, string appid, string appSecret, string grant_Type)
        {
            string sqlText = @"select KeyID,WeixinID,AppID,AppSecret,Access_Token,Grant_Type,AddTime,OutTime,ModifyTime,IsDelete  from Access_Token 
WHERE AppID = @AppID and  AppSecret= @AppSecret and Grant_Type=@Grant_Type and IsDelete = 0 limit 1";
            MySqlParameters destionParameters = new MySqlParameters();
            destionParameters.Add(new MySqlParameter() { ParameterName = "@AppID", MySqlDbType = MySqlDbType.VarChar, Value = appid });
            destionParameters.Add(new MySqlParameter() { ParameterName = "@AppSecret", MySqlDbType = MySqlDbType.VarChar, Value = appSecret });
            destionParameters.Add(new MySqlParameter() { ParameterName = "@Grant_Type", MySqlDbType = MySqlDbType.VarChar, Value = grant_Type });
            MAccess_Token access_Token = null;
            using (MySqlDataReader reader = Common.DBUtility.MySqlHelper.ExecuteReader(trans, conn, sqlText, destionParameters.ToArray()))
            {
                while (reader.Read())
                {
                    access_Token = new MAccess_Token();
                    access_Token.KeyID = reader["KeyID"] == DBNull.Value ? string.Empty : reader["KeyID"].ToString();
                    access_Token.AppID = reader["AppID"] == DBNull.Value ? string.Empty : reader["AppID"].ToString();
                    access_Token.AppSecret = reader["AppSecret"] == DBNull.Value ? string.Empty : reader["AppSecret"].ToString();
                    access_Token.WeixinID = reader["WeixinID"] == DBNull.Value ? string.Empty : reader["WeixinID"].ToString();
                    access_Token.Access_Token = reader["Access_Token"] == DBNull.Value ? string.Empty : SecurityUtility.DecryptString(reader["Access_Token"].ToString());
                    access_Token.Grant_Type = reader["Grant_Type"] == DBNull.Value ? string.Empty : reader["Grant_Type"].ToString();
                    access_Token.AddTime = reader["AddTime"] == DBNull.Value ? new DateTime(1990, 1, 1) : Convert.ToDateTime(reader["AddTime"]);
                    access_Token.OutTime = reader["OutTime"] == DBNull.Value ? new DateTime(1990, 1, 1) : Convert.ToDateTime(reader["OutTime"]);
                }
            }

            return access_Token;
        }

        /// <summary>
        /// 获取口令（用户的）
        /// </summary>
        /// <param name="trans">事物</param>
        /// <param name="conn">连接</param>
        /// <param name="appid">appid</param>
        /// <param name="appSecret">appSecret</param>
        /// <param name="openID">OpendID</param>
        /// <param name="scope">Scope</param>
        /// <returns>用户令牌</returns>
        public MAccess_Token GetAccess_Token(IDbTransaction trans, IDbConnection conn, string appid, string appSecret, string openID, string scope)
        {
            string sqlText = @"select KeyID,AppID,AppSecret,WeixinID,Access_Token, RefreshToken,Grant_Type,OpenID,Scope,UnionID,AddTime,OutTime,ModifyTime,IsDelete from Access_Token 
WHERE AppID = @AppID and  AppSecret= @AppSecret and OpenID=@OpenID and Scope=@Scope and IsDelete = 0 limit 1";
            MySqlParameters destionParameters = new MySqlParameters();
            destionParameters.Add(new MySqlParameter() { ParameterName = "@AppID", MySqlDbType = MySqlDbType.VarChar, Value = appid });
            destionParameters.Add(new MySqlParameter() { ParameterName = "@AppSecret", MySqlDbType = MySqlDbType.VarChar, Value = appSecret });
            destionParameters.Add(new MySqlParameter() { ParameterName = "@OpenID", MySqlDbType = MySqlDbType.VarChar, Value = openID });
            destionParameters.Add(new MySqlParameter() { ParameterName = "@Scope", MySqlDbType = MySqlDbType.VarChar, Value = scope });

            MAccess_Token access_Token = null;
            using (MySqlDataReader reader = Common.DBUtility.MySqlHelper.ExecuteReader(trans, conn, sqlText, destionParameters.ToArray()))
            {
                while (reader.Read())
                {
                    access_Token = new MAccess_Token();
                    access_Token.KeyID = reader["KeyID"] == DBNull.Value ? string.Empty : reader["KeyID"].ToString();
                    access_Token.AppID = reader["AppID"] == DBNull.Value ? string.Empty : reader["AppID"].ToString();
                    access_Token.AppSecret = reader["AppSecret"] == DBNull.Value ? string.Empty : reader["AppSecret"].ToString();
                    access_Token.WeixinID = reader["WeixinID"] == DBNull.Value ? string.Empty : reader["WeixinID"].ToString();
                    access_Token.Access_Token = reader["Access_Token"] == DBNull.Value ? string.Empty : SecurityUtility.DecryptString(reader["Access_Token"].ToString());
                    access_Token.RefreshToken = reader["RefreshToken"] == DBNull.Value ? string.Empty : SecurityUtility.DecryptString(reader["RefreshToken"].ToString());
                    access_Token.Grant_Type = reader["Grant_Type"] == DBNull.Value ? string.Empty : reader["Grant_Type"].ToString();
                    access_Token.OpenID = reader["OpenID"] == DBNull.Value ? string.Empty : reader["OpenID"].ToString();
                    access_Token.Scope = reader["Scope"] == DBNull.Value ? string.Empty : reader["Scope"].ToString();
                    access_Token.UnionID = reader["UnionID"] == DBNull.Value ? string.Empty : reader["UnionID"].ToString();
                    access_Token.AddTime = reader["AddTime"] == DBNull.Value ? new DateTime(1990, 1, 1) : Convert.ToDateTime(reader["AddTime"]);
                    access_Token.OutTime = reader["OutTime"] == DBNull.Value ? new DateTime(1990, 1, 1) : Convert.ToDateTime(reader["OutTime"]);
                }
            }

            return access_Token;
        }

        /// <summary>
        /// 获取口令(公众号)
        /// </summary>
        /// <param name="trans">事物</param>
        /// <param name="conn">连接</param>
        /// <param name="grant_Type">grant_Type</param>
        /// <returns></returns>
        public List<MAccess_Token> GetAccess_Token(IDbTransaction trans, IDbConnection conn, string grant_Type)
        {
            string sqlText = @"select KeyID,AppID,WeixinID,AppSecret,Access_Token,Grant_Type,AddTime,OutTime,ModifyTime,IsDelete  from Access_Token WHERE  Grant_Type=@Grant_Type and IsDelete = 0 ";
            MySqlParameters destionParameters = new MySqlParameters();
            destionParameters.Add(new MySqlParameter() { ParameterName = "@Grant_Type", MySqlDbType = MySqlDbType.VarChar, Value = grant_Type });

            List<MAccess_Token> access_TokenList = new List<MAccess_Token>();

            using (MySqlDataReader reader = Common.DBUtility.MySqlHelper.ExecuteReader(trans, conn, sqlText, destionParameters.ToArray()))
            {
                MAccess_Token access_Token = null;
                while (reader.Read())
                {
                    access_Token = new MAccess_Token();
                    access_Token.KeyID = reader["KeyID"] == DBNull.Value ? string.Empty : reader["KeyID"].ToString();
                    access_Token.AppID = reader["AppID"] == DBNull.Value ? string.Empty : reader["AppID"].ToString();
                    access_Token.WeixinID = reader["WeixinID"] == DBNull.Value ? string.Empty : reader["WeixinID"].ToString();
                    access_Token.AppSecret = reader["AppSecret"] == DBNull.Value ? string.Empty : reader["AppSecret"].ToString();
                    access_Token.Access_Token = reader["Access_Token"] == DBNull.Value ? string.Empty : SecurityUtility.DecryptString(reader["Access_Token"].ToString());
                    access_Token.Grant_Type = reader["Grant_Type"] == DBNull.Value ? string.Empty : reader["Grant_Type"].ToString();
                    access_Token.AddTime = reader["AddTime"] == DBNull.Value ? new DateTime(1990, 1, 1) : Convert.ToDateTime(reader["AddTime"]);
                    access_Token.OutTime = reader["OutTime"] == DBNull.Value ? new DateTime(1990, 1, 1) : Convert.ToDateTime(reader["OutTime"]);
                    access_TokenList.Add(access_Token);
                }
            }

            return access_TokenList;
        }
    }
}
