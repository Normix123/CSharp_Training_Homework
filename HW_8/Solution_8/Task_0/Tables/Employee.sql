﻿CREATE TABLE [dbo].[Employee]
(
    [Id] UNIQUEIDENTIFIER CONSTRAINT [PK_dbo_Employee] PRIMARY KEY,
    [Email] NVARCHAR(128) NOT NULL UNIQUE,
    [FirstName] NVARCHAR(128) NOT NULL,
    [LastName] NVARCHAR(128) NOT NULL
);

GO