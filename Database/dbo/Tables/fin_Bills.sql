CREATE TABLE [dbo].[fin_Bills] (
    [billUid]             UNIQUEIDENTIFIER NOT NULL,
    [billUserGroupId]     INT              NOT NULL,
    [billUserGroupbillId] INT              NOT NULL,
    [billCreatedBy]       INT              NOT NULL,
    [billCreatedOn]       DATETIME         NOT NULL,
    [billCreatedIP]       VARCHAR (50)     NOT NULL,
    [billPoUid]           UNIQUEIDENTIFIER NULL,
    [billToEntityId]      INT              NOT NULL,
    [billDate]            DATE             NOT NULL,
    [billPaymentTerms]    NVARCHAR (MAX)   NULL,
    [billNotes]           NVARCHAR (MAX)   NULL,
    [billDiscountId]      INT              NULL,
    [billDiscountAmount]  MONEY            NULL,
    [billStatus]          TINYINT          NOT NULL,
    [billDescription]     NVARCHAR (1000)  NOT NULL,
    [billRefId]           VARCHAR (50)     NULL,
    [billDueDate]         DATE             NULL,
    CONSTRAINT [PK_fin_Bills] PRIMARY KEY CLUSTERED ([billUid] ASC)
);

