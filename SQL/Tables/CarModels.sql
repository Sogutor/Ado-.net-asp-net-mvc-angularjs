CREATE TABLE [dbo].[CarModels] (
    [Id]     INT  IDENTITY (1, 1) NOT NULL,
    [Name]   TEXT NULL,
    [MarkId] INT  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([MarkId]) REFERENCES [dbo].[CarMarks] ([Id])
);

