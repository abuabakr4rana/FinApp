CREATE TABLE [dbo].[fin_Generic_BillStatus] (
    [billStatusId]     INT          NOT NULL,
    [billStatusTitle]  VARCHAR (50) NOT NULL,
    [billStatusTitle2] VARCHAR (50) NULL,
    [billStatusTitle3] VARCHAR (50) NULL,
    CONSTRAINT [PK_fin_Generic_BillStatus] PRIMARY KEY CLUSTERED ([billStatusId] ASC)
);

