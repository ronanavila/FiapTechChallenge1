USE TechChallenge
GO

CREATE TABLE dbo.Region(
	[DDD] int NOT NULL,
	[Location] varchar(100) NOT NULL,

    CONSTRAINT PK_Region PRIMARY KEY ([DDD])
)
GO

INSERT INTO dbo.Region([DDD], [Location])
VALUES 
(12, 'Rio Preto'),
(19, 'Campinas'),
(11, 'São Paulo');
GO
