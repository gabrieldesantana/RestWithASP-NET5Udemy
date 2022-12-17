--CREATE TABLE [dbo].[person](
--	[id] [bigint] IDENTITY(1,1) NOT NULL,
--	[first_name] [varchar](80) NOT NULL,
--	[last_name] [varchar](80) NOT NULL,
--	[address] [varchar](100) NOT NULL,
--	[gender] [varchar](6) NOT NULL,
	
--PRIMARY KEY CLUSTERED );

Use rest_with_asp_net_udemy

CREATE TABLE [books] (
id BIGINT NOT NULL IDENTITY(1,1) PRIMARY KEY,
[author] VARCHAR(100) NOT NULL,
[name] VARCHAR(80) NOT NULL,
[year] VARCHAR(4) NOT NULL,
)