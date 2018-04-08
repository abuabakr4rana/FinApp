CREATE TABLE [dbo].[fin_Generic_PaymentTypes] (
    [paymentTypeId] TINYINT      NOT NULL,
    [paymentTitle]  VARCHAR (50) NOT NULL,
    [paymentTitle2] VARCHAR (50) NULL,
    CONSTRAINT [PK_fin_Generic_PaymentTypes] PRIMARY KEY CLUSTERED ([paymentTypeId] ASC)
);

