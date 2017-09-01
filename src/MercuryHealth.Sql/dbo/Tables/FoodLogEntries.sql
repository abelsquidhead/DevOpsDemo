CREATE TABLE [dbo].[FoodLogEntries] (
/* here is my comment */
    [Id]                   INT             IDENTITY (1, 1) NOT NULL,
    [Description]          NVARCHAR (MAX)  NULL,
    [Quantity]             REAL            NOT NULL,
    [MealTime]             DATETIME        NOT NULL,
    [Tags]                 NVARCHAR (MAX)  NULL,
    [Calories]             INT             NOT NULL,
    [ProteinInGrams]       DECIMAL (18, 2) NOT NULL,
    [FatInGrams]           DECIMAL (18, 2) NOT NULL,
    [CarbohydratesInGrams] DECIMAL (18, 2) NOT NULL,
    [SodiumInGrams]        DECIMAL (18, 2) NOT NULL,
    [MemberProfile_Id]     INT             NULL,
    CONSTRAINT [PK_dbo.FoodLogEntries] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.FoodLogEntries_dbo.MemberProfiles_MemberProfile_Id] FOREIGN KEY ([MemberProfile_Id]) REFERENCES [dbo].[MemberProfiles] ([Id])
);




GO
CREATE NONCLUSTERED INDEX [IX_MemberProfile_Id]
    ON [dbo].[FoodLogEntries]([MemberProfile_Id] ASC);

