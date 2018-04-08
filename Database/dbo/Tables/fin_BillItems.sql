CREATE TABLE [dbo].[fin_BillItems] (
    [billItemId]          UNIQUEIDENTIFIER NOT NULL,
    [billUid]             UNIQUEIDENTIFIER NOT NULL,
    [billItemAccId]       INT              NOT NULL,
    [transId]             INT              NOT NULL,
    [billItemDescription] NVARCHAR (1000)  NULL,
    [billItemCost]        MONEY            NOT NULL,
    [billItemQty]         INT              NOT NULL,
    [billItemTax1Id]      INT              NULL,
    [billItemTax1Rate]    DECIMAL (18, 2)  NULL,
    [billItemTax1Amount]  MONEY            NULL,
    [billItemTax2Id]      INT              NULL,
    [billItemTax2Rate]    DECIMAL (18, 2)  NULL,
    [billItemTax2Amount]  MONEY            NULL,
    [billItemCreatedOn]   DATETIME         NOT NULL,
    [billItemCreatedBy]   INT              NOT NULL,
    [billItemCreationIP]  VARCHAR (50)     NOT NULL,
    [billItemStatus]      TINYINT          NOT NULL,
    [billItemDeptId]      INT              NULL,
    CONSTRAINT [PK_fin_BillItems] PRIMARY KEY CLUSTERED ([billItemId] ASC)
);

