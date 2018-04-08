CREATE TABLE [dbo].[fin_Generic_InvoiceStatus] (
    [invStatusId]     INT          NOT NULL,
    [invStatusTitle]  VARCHAR (50) NOT NULL,
    [invStatusTitle2] VARCHAR (50) NOT NULL,
    [invStatusTitle3] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_fin_Generic_InvoiceStatus] PRIMARY KEY CLUSTERED ([invStatusId] ASC)
);

