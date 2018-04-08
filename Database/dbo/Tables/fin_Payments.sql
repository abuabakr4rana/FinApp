﻿CREATE TABLE [dbo].[fin_Payments] (
    [paymentUid]            UNIQUEIDENTIFIER NOT NULL,
    [itemUid]               UNIQUEIDENTIFIER NOT NULL,
    [paymentPayDate]        DATETIME         NOT NULL,
    [paymentCreatedBy]      INT              NOT NULL,
    [paymentCreatedOn]      DATETIME         NOT NULL,
    [paymentIP]             VARCHAR (50)     NOT NULL,
    [paymentAmount]         MONEY            NOT NULL,
    [paymentTransGroupId]   INT              NOT NULL,
    [paymentTransAccountId] INT              NULL,
    [paymentNotes]          VARCHAR (500)    NULL,
    [paymentNotes2]         VARCHAR (500)    NULL,
    [paymentType]           TINYINT          NOT NULL,
    [paymentStatus]         TINYINT          NOT NULL,
    [paymentVendorId]       INT              NULL,
    [paymentDeptId]         INT              NULL,
    [paymentTax1]           INT              NULL,
    [paymentTax1Amount]     MONEY            NULL,
    [paymentTax2]           INT              NULL,
    [paymentTax2Amount]     MONEY            NULL,
    [paymentImageURL]       VARCHAR (500)    NULL,
    [paymentDebitAccId]     INT              NOT NULL,
    [paymentCreditAccId]    INT              NOT NULL,
    CONSTRAINT [PK_fin_Payments] PRIMARY KEY CLUSTERED ([paymentUid] ASC)
);

