CREATE TABLE [dbo].[fin_ModuleItems] (
    [additionalTransId]             INT             NOT NULL,
    [moduleId]                      INT             NOT NULL,
    [additionalTransTitle]          VARCHAR (50)    NOT NULL,
    [addtionalTransAmountDependent] BIT             NOT NULL,
    [additionalTransAmount]         DECIMAL (18, 2) NULL,
    [additionalTransDescription]    VARCHAR (100)   NULL,
    [addtionalTransIsOfficial]      BIT             NULL,
    [moduleIParameterId]            INT             NULL,
    CONSTRAINT [PK_fin_ModuleItems] PRIMARY KEY CLUSTERED ([additionalTransId] ASC)
);

