CREATE TABLE [dbo].[fin_Transactions] (
    [transID]             INT             NOT NULL,
    [transSystemIndex]    TINYINT         NOT NULL,
    [transParticipantID]  INT             NULL,
    [transRefID]          NVARCHAR (50)   NULL,
    [transAttachedFiles]  NVARCHAR (500)  NULL,
    [transInvoiceID]      INT             NULL,
    [transDrAccount]      INT             NULL,
    [transCrAccount]      INT             NULL,
    [transNarration]      NVARCHAR (250)  NOT NULL,
    [transAmount]         DECIMAL (18, 2) NOT NULL,
    [transCreatedOn]      DATETIME        NOT NULL,
    [transCreatedBy]      INT             NOT NULL,
    [transUpdatedOn]      DATETIME        NULL,
    [transUpdatedBy]      INT             NULL,
    [transStatus]         TINYINT         NOT NULL,
    [transSystemRestrict] BIT             CONSTRAINT [DF_fin_Transactions_transSystemRestrict] DEFAULT ((0)) NOT NULL,
    [transGroupID]        INT             NULL,
    [transIsCompound]     BIT             CONSTRAINT [DF_fin_Transactions_transIsCompound] DEFAULT ((0)) NOT NULL,
    [transType]           INT             NULL,
    [deptId]              INT             NULL,
    CONSTRAINT [PK_fin_Transactions] PRIMARY KEY CLUSTERED ([transID] ASC)
);

