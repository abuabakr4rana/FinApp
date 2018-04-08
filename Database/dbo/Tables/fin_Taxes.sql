CREATE TABLE [dbo].[fin_Taxes] (
    [taxId]             INT           IDENTITY (1, 1) NOT NULL,
    [taxTitle]          VARCHAR (50)  NOT NULL,
    [taxValue]          MONEY         NOT NULL,
    [taxTypeIsPercent]  BIT           NOT NULL,
    [taxCreatedBy]      INT           NOT NULL,
    [taxCreatedOn]      DATETIME      NOT NULL,
    [taxCreatedIP]      VARCHAR (50)  NOT NULL,
    [taxAccountId]      INT           NOT NULL,
    [taxTransNarration] VARCHAR (500) NOT NULL,
    CONSTRAINT [PK_fin_Taxes] PRIMARY KEY CLUSTERED ([taxId] ASC)
);

