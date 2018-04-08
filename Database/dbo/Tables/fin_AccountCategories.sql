CREATE TABLE [dbo].[fin_AccountCategories] (
    [accCatID]          INT           NOT NULL,
    [accCatTitle]       VARCHAR (50)  NOT NULL,
    [accCatDescription] VARCHAR (MAX) NULL,
    CONSTRAINT [PK_fin_AccountCategories] PRIMARY KEY CLUSTERED ([accCatID] ASC)
);

