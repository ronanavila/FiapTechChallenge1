USE TechChallenge
GO

CREATE TABLE dbo.Contact(
	[Guid] UNIQUEIDENTIFIER NOT NULL,
    [Name] VARCHAR(150) NOT NULL,
    [Email] VARCHAR(150) NOT NULL,
    [Phone] VARCHAR(10) NOT NULL,
    [RegionDDD] INT NOT NULL,
    
    CONSTRAINT PK_Contact PRIMARY KEY ([Guid]),
    CONSTRAINT FK_Contact_Region FOREIGN KEY ([RegionDDD]) REFERENCES dbo.Region([DDD])     
)
GO

INSERT INTO dbo.Contact([Guid], [Name], [Email], [Phone], [RegionDDD])
VALUES 
(NEWID(), 'José', 'jose@jose.com.br', '111144444', 11),
(NEWID(), 'João', 'joao@joao.com.br', '444445555', 12),
(NEWID(), 'Pedro', 'pedro@pedro.com.br', '333366666', 19);
GO