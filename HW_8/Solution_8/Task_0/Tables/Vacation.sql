CREATE TABLE [dbo].[Vacation]
(
	[Id] UNIQUEIDENTIFIER CONSTRAINT [PK_dbo_Vacation] PRIMARY KEY,
	[DateStart] DATE NOT NULL CHECK(DateStart >= '01.01.2001'),
    [DateEnd] DATE NOT NULL CHECK(DateEnd >= DateStart),
	[EmployeeId] UNIQUEIDENTIFIER CONSTRAINT [FK_dbo_Vacation_dbo_Employee] FOREIGN KEY REFERENCES [dbo].[Employee]([Id]) ON DELETE CASCADE,
)

GO
CREATE INDEX [IX_dbo_Vacation_dbo_Employee] ON [dbo].[Vacation]([EmployeeId]);

GO