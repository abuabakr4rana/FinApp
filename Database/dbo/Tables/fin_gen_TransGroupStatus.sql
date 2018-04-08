CREATE TABLE [dbo].[fin_gen_TransGroupStatus] (
    [transGroupStatus]       INT          NOT NULL,
    [transGroupStatusTitle]  VARCHAR (50) NOT NULL,
    [transGroupStatusTitle2] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_fin_gen_TransGroupStatus] PRIMARY KEY CLUSTERED ([transGroupStatus] ASC)
);

