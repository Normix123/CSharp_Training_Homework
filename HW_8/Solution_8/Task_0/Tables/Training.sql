CREATE TABLE [dbo].[Training]
(
    [Id] UNIQUEIDENTIFIER CONSTRAINT [PK_dbo_Training] PRIMARY KEY,
    [Name] NVARCHAR(64) NOT NULL,
    [DateStart] DATE NOT NULL CHECK(DateStart >= '20010101'),
    [DateEnd] DATE NOT NULL CHECK(DateEnd >= DateStart),
    [Description] NVARCHAR(MAX)
);

GO