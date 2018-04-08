CREATE TABLE [dbo].[fin_Expenses] (
    [expenseId]    UNIQUEIDENTIFIER NOT NULL,
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
    [expenseDate]  DATETIME         NULL,
    [transGroupId] INT              NULL,
    CONSTRAINT [PK_fin_Expenses] PRIMARY KEY CLUSTERED ([expenseId] ASC)
);

