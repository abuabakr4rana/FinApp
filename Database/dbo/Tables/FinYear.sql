CREATE TABLE [dbo].[FinYear] (
    [finyrID]   INT      IDENTITY (1, 1) NOT NULL,
    [startDate] DATETIME NOT NULL,
    [endDate]   DATETIME NOT NULL,
    [status]    BIT      NOT NULL,
    CONSTRAINT [PK_FinYear] PRIMARY KEY CLUSTERED ([finyrID] ASC)
);

