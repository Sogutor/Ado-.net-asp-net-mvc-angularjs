CREATE TABLE [dbo].[Cars] (
    [Id]           INT        NOT NULL IDENTITY,
    [CustomerName] TEXT       NULL,
    [MobilePhone]  TEXT       NULL,
    [CarNumber]    NCHAR (10) NULL,
    [MarkId]   int FOREIGN KEY REFERENCES CarMarks(Id),
    [ModelId]   int FOREIGN KEY REFERENCES CarModels(Id),
    PRIMARY KEY CLUSTERED ([Id] ASC)
);