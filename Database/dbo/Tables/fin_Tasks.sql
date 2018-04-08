CREATE TABLE [dbo].[fin_Tasks] (
    [taskId]            UNIQUEIDENTIFIER NOT NULL,
    [userId]            INT              NOT NULL,
    [taskTitle]         VARCHAR (MAX)    NOT NULL,
    [taskDescription]   VARCHAR (MAX)    NULL,
    [taskCreatedBy]     INT              NOT NULL,
    [taskCreatedOn]     DATETIME         NOT NULL,
    [taskCreatedIP]     VARCHAR (50)     NOT NULL,
    [taskType]          TINYINT          NOT NULL,
    [taskStatus]        TINYINT          NOT NULL,
    [taskLastUpdatedOn] DATETIME         NOT NULL,
    [taskLastUpdatedBy] INT              NOT NULL,
    [taskLastUpdatedIP] VARCHAR (50)     NOT NULL,
    CONSTRAINT [PK_fin_Tasks] PRIMARY KEY CLUSTERED ([taskId] ASC)
);

