CREATE TABLE [dbo].[CatchErrors] (
    [EID]     INT           IDENTITY (1, 1) NOT NULL,
    [ErrMsg]  TEXT          NOT NULL,
    [ErrRoot] VARCHAR (250) NOT NULL,
    [ErrTime] DATETIME      NOT NULL,
    CONSTRAINT [PK_CatchErrors] PRIMARY KEY CLUSTERED ([EID] ASC)
);

