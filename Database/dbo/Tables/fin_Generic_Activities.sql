CREATE TABLE [dbo].[fin_Generic_Activities] (
    [activityUid]         UNIQUEIDENTIFIER NOT NULL,
    [activityTitle]       NVARCHAR (500)   NOT NULL,
    [activityDescription] NVARCHAR (MAX)   NULL,
    [activityUserId]      INT              NOT NULL,
    [activityMadeOn]      DATETIME         NOT NULL,
    [activityIP]          VARCHAR (50)     NOT NULL,
    CONSTRAINT [PK_fin_Generic_Activities] PRIMARY KEY CLUSTERED ([activityUid] ASC)
);

