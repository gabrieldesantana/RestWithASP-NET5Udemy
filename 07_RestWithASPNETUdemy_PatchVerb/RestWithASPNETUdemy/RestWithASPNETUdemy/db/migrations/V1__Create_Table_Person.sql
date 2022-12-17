--CREATE TABLE [dbo].[person](
--	[id] [bigint] IDENTITY(1,1) NOT NULL,
--	[first_name] [varchar](80) NOT NULL,
--	[last_name] [varchar](80) NOT NULL,
--	[address] [varchar](100) NOT NULL,
--	[gender] [varchar](6) NOT NULL,
	
--PRIMARY KEY CLUSTERED );
Use rest_with_asp_net_udemy
CREATE TABLE [person] (
id BIGINT NOT NULL IDENTITY(1,1) PRIMARY KEY,
[address] VARCHAR(100) NOT NULL,
[first_name] VARCHAR(80) NOT NULL,
[gender] VARCHAR(6) NOT NULL,
[last_name] VARCHAR(80) NOT NULL
)