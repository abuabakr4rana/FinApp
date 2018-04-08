CREATE TABLE [dbo].[fin_InvoiceItems] (
    [invItemId]          UNIQUEIDENTIFIER NOT NULL,
    [invUid]             UNIQUEIDENTIFIER NOT NULL,
    [invItemAccId]       INT              NOT NULL,
    [transId]            INT              NOT NULL,
    [invItemDescription] NVARCHAR (1000)  NULL,
    [invItemCost]        MONEY            NOT NULL,
    [invItemQty]         INT              NOT NULL,
    [invItemTax1Id]      INT              NULL,
    [invItemTax1Rate]    DECIMAL (18, 2)  NULL,
    [invItemTax1Amount]  MONEY            NULL,
    [invItemTax2Id]      INT              NULL,
    [invItemTax2Rate]    DECIMAL (18, 2)  NULL,
    [invItemTax2Amount]  MONEY            NULL,
    [invItemCreatedOn]   DATETIME         NOT NULL,
    [invItemCreatedBy]   INT              NOT NULL,
    [invItemCreationIP]  VARCHAR (50)     NOT NULL,
    [invItemStatus]      TINYINT          NOT NULL,
    [invItemDeptId]      INT              NULL,
    CONSTRAINT [PK_fin_InvoiceItems] PRIMARY KEY CLUSTERED ([invItemId] ASC)
);

