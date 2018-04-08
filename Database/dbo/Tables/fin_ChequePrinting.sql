CREATE TABLE [dbo].[fin_ChequePrinting] (
    [chequeId]             INT             IDENTITY (1, 1) NOT NULL,
    [bankId]               INT             NOT NULL,
    [chequeTitle]          NVARCHAR (100)  NOT NULL,
    [chequeAmount]         NVARCHAR (500)  NOT NULL,
    [chequeAmountFig]      DECIMAL (18, 1) NOT NULL,
    [chequeDate]           DATETIME        NULL,
    [chequeNo]             VARCHAR (20)    NULL,
    [chequeReceivedBy]     VARCHAR (50)    NULL,
    [chequeReceiverPhone]  VARCHAR (15)    NULL,
    [chequeReceiverIDCard] VARCHAR (15)    NULL,
    [chequeCreatedBy]      INT             NULL,
    [chequeCreatedOn]      DATETIME        NULL,
    [chequeStatus]         TINYINT         NULL,
    CONSTRAINT [PK_fin_ChequePrinting] PRIMARY KEY CLUSTERED ([chequeId] ASC)
);

