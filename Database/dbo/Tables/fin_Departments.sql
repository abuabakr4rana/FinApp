CREATE TABLE [dbo].[fin_Departments] (
    [deptId]          INT           NOT NULL,
    [deptTitle]       NVARCHAR (50) NOT NULL,
    [deptCode]        VARCHAR (5)   NOT NULL,
    [deptDescription] VARCHAR (500) NULL,
    CONSTRAINT [PK_fin_Departments] PRIMARY KEY CLUSTERED ([deptId] ASC)
);

