CREATE TABLE [dbo].[fin_Invoices] (
    [invUid]            UNIQUEIDENTIFIER NOT NULL,
    [invUserGroupId]    INT              NOT NULL,
    [invUserGroupInvId] INT              NOT NULL,
    [invCreatedBy]      INT              NOT NULL,
    [invCreatedOn]      DATETIME         NOT NULL,
    [invCreatedIP]      VARCHAR (50)     NOT NULL,
    [invPoUid]          UNIQUEIDENTIFIER NULL,
    [invToEntityId]     INT              NOT NULL,
    [invDate]           DATE             NOT NULL,
    [invPaymentTerms]   NVARCHAR (MAX)   NULL,
    [invNotes]          NVARCHAR (MAX)   NULL,
    [invDiscountId]     INT              NULL,
    [invDiscountAmount] MONEY            NULL,
    [invStatus]         TINYINT          NOT NULL,
    [invDescription]    NVARCHAR (1000)  NOT NULL,
    [invRefId]          VARCHAR (50)     NULL,
    [invDueDate]        DATE             NULL,
    CONSTRAINT [PK_fin_Invoices] PRIMARY KEY CLUSTERED ([invUid] ASC)
);

