CREATE TABLE [dbo].[fin_AdditionalAutoTrans] (
    [autoTransID]                INT             NOT NULL,
    [additionalTransId]          INT             NOT NULL,
    [autoTransAccountId]         INT             NOT NULL,
    [autoTransIsDebit]           BIT             NULL,
    [autoTransAmountMultiplier]  DECIMAL (18, 2) NOT NULL,
    [autoTransIsOfficial]        BIT             NOT NULL,
    [autoTransNarration]         VARCHAR (150)   NOT NULL,
    [autoTransIsSeparateVouchar] BIT             NOT NULL,
    [autoTransSeparateID]        INT             NULL,
    [autoTransIsPredefinedItem]  BIT             NULL,
    CONSTRAINT [PK_fin_AdditionalAutoTrans] PRIMARY KEY CLUSTERED ([autoTransID] ASC)
);

