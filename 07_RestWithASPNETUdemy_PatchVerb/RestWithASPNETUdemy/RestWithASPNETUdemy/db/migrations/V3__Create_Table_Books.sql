Use rest_with_asp_net_udemy
CREATE TABLE [books] (
id BIGINT NOT NULL IDENTITY(1,1) PRIMARY KEY,
[author] VARCHAR(100) NOT NULL,
[lauch_date] DATETIME2 NOT NULL,
[price] DECIMAL NOT NULL,
[title] VARCHAR(80) NOT NULL
)