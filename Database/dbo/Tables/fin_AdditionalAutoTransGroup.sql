CREATE TABLE [dbo].[fin_AdditionalAutoTransGroup] (
    [atgID]                  INT           NOT NULL,
    [transGroupTitle]        VARCHAR (300) NOT NULL,
    [transGroupPrefixNo]     INT           NOT NULL,
    [transGroupPrefixString] VARCHAR (5)   NOT NULL,
    [transGroupForeNumber]   INT           NOT NULL,
    CONSTRAINT [PK_fin_AdditionalAutoTransGroup] PRIMARY KEY CLUSTERED ([atgID] ASC)
);

