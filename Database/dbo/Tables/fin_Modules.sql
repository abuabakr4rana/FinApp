CREATE TABLE [dbo].[fin_Modules] (
    [moduleId]          INT           NOT NULL,
    [moduleTitle]       VARCHAR (100) NOT NULL,
    [moduleDescription] VARCHAR (500) NULL,
    [moduleIsOffial]    BIT           NOT NULL,
    [CField1]           VARCHAR (50)  NULL,
    [CField2]           VARCHAR (50)  NULL,
    [CField3]           VARCHAR (50)  NULL,
    [CField4]           VARCHAR (50)  NULL,
    CONSTRAINT [PK_fin_Modules] PRIMARY KEY CLUSTERED ([moduleId] ASC)
);

