Use rest_with_asp_net_udemy
CREATE TABLE [user] (
id BIGINT NOT NULL IDENTITY(1,1) PRIMARY KEY,
[user_name] VARCHAR(50) DEFAULT '0' NOT NULL,
[password] VARCHAR(130)  DEFAULT '0' NOT NULL,
[full_name] VARCHAR(120) NOT NULL,
[refresh_token] VARCHAR(500)  DEFAULT '0' NOT NULL,
[refresh_token_expiry_time] DATETIME NOT NULL DEFAULT NULL
)