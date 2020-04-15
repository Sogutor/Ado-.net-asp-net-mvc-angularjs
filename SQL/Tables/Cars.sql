CREATE TABLE [dbo].[Cars] (
    [Id]           INT        IDENTITY (1, 1) NOT NULL,
    [CustomerName] TEXT       NULL,
    [MobilePhone]  TEXT       NULL,
    [CarNumber]    NCHAR (10) NULL,
    [MarkId]       INT        NULL,
    [ModelId]      INT        NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

