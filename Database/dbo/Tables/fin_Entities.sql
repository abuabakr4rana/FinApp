﻿CREATE TABLE [dbo].[fin_Entities] (
    [entityId]            INT            NOT NULL,
    [entityType]          INT            NOT NULL,
    [entityTitle]         NVARCHAR (50)  NOT NULL,
    [entityDescription]   VARCHAR (500)  NULL,
    [entityFirstName]     NVARCHAR (30)  NULL,
    [entityLastName]      NVARCHAR (30)  NULL,
    [entityEmail]         VARCHAR (50)   NULL,
    [entityAltEmail]      VARCHAR (50)   NULL,
    [entityAddress]       NVARCHAR (500) NULL,
    [entityCity]          NVARCHAR (100) NULL,
    [entityZip]           VARCHAR (10)   NULL,
    [entityCountry]       INT            NULL,
    [entityState]         VARCHAR (50)   NULL,
    [entityPhone]         VARCHAR (20)   NULL,
    [entityAltPhone]      VARCHAR (20)   NULL,
    [entityMobile]        VARCHAR (20)   NULL,
    [entityAltMobile]     VARCHAR (20)   NULL,
    [entityFax]           VARCHAR (20)   NULL,
    [entityAltFax]        VARCHAR (20)   NULL,
    [entityStatus]        TINYINT        NOT NULL,
    [entityAccountId]     INT            NOT NULL,
    [entityAccountTitle]  VARCHAR (150)  NOT NULL,
    [entityCreatedOn]     DATETIME       NOT NULL,
    [entityCreatedBy]     INT            NOT NULL,
    [entityLastUpdatedBy] INT            NOT NULL,
    [entityLastUpdateOn]  DATETIME       NOT NULL,
    CONSTRAINT [PK_fin_Entities] PRIMARY KEY CLUSTERED ([entityId] ASC),
    CONSTRAINT [FK_fin_Entities_fin_gen_entityTypes] FOREIGN KEY ([entityType]) REFERENCES [dbo].[fin_gen_entityTypes] ([entityType])
);

