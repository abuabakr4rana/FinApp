CREATE TABLE [dbo].[fin_Income] (
    [incomeId]     UNIQUEIDENTIFIER NOT NULL,
    [amount]       MONEY            NOT NULL,
    [createdOn]    DATETIME         NOT NULL,
    [createdBy]    INT              NOT NULL,
    [vendorId]     INT              NOT NULL,
    [deptId]       INT              NULL,
    [notes]        VARCHAR (500)    NULL,
    [tax1_Id]      INT              NULL,
    [tax1_Amount]  INT              NULL,
    [tax2_Id]      INT              NULL,
    [tax2_Amount]  INT              NULL,
    [consumerId]   INT              NULL,
    [imageUrl]     VARCHAR (500)    NULL,
    [incomeDate]   DATETIME         NULL,
    [transGroupId] INT              NULL,
    CONSTRAINT [PK_fin_Income] PRIMARY KEY CLUSTERED ([incomeId] ASC)
);

