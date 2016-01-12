/****** 对象:  Table Access_Token    脚本日期: 2016/1/12 22:47:04 ******/
/****** 字段数据长度 = 13468 字节 ******/
DROP TABLE IF EXISTS `Access_Token`;
CREATE TABLE `Access_Token`(
	`KeyID`                            char(28)             NOT NULL DEFAULT ''                    COMMENT '主键ID',
	`AppID`                            varchar(50)          NOT NULL DEFAULT ''                    COMMENT '微信AppID',
	`AppSecret`                        varchar(100)         NOT NULL DEFAULT ''                    COMMENT '微信AppSecret',
	`Access_Token`                     varchar(2048)        NOT NULL DEFAULT ''                    COMMENT '微信Access_Token',
	`RefreshToken`                     varchar(2048)        NOT NULL DEFAULT ''                    COMMENT '微信RefreshToken',
	`Grant_Type`                       varchar(100)         NOT NULL DEFAULT ''                    COMMENT 'Token类型',
	`OpenID`                           varchar(50)          NOT NULL DEFAULT ''                    COMMENT '用户唯一标识:用户唯一标识，请注意，在未关注公众号时，用户访问公众号的网页，也会产生一个用户和公众号唯一的OpenID',
	`Scope`                            varchar(20)          NOT NULL DEFAULT ''                    COMMENT '用户授权的作用域:应用授权作用域，snsapi_base （不弹出授权页面，直接跳转，只能获取用户openid），snsapi_userinfo （弹出授权页面，可通过openid拿到昵称、性别、所在地。并且，即使在未关注的情况下，只要用户授权，也能获取其信息）',
	`UnionID`                          varchar(50)          NOT NULL DEFAULT ''                    COMMENT '唯一标识:只有在用户将公众号绑定到微信开放平台帐号后，才会出现该字段。详见：获取用户个人信息（UnionID机制）',
	`AddTime`                          datetime             NOT NULL DEFAULT '1900-01-01 00:00:00' COMMENT '添加时间',
	`OutTime`                          datetime             NOT NULL DEFAULT '1900-01-01 00:00:00' COMMENT '失效时间',
	`ModifyTime`                       timestamp            NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '修改时间(CURRENT_TIMESTAMP)',
	`IsDelete`                         tinyint(4) unsigned  NOT NULL DEFAULT 0                     COMMENT '删除标志(0:未删除  / 1:已删除)',
	PRIMARY KEY ( `KeyID` )
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='微信Access_Token管理表:微信Access_Token管理表';
