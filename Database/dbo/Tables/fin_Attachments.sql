CREATE TABLE [dbo].[fin_Attachments] (
    [attachmentId]               INT           NOT NULL,
    [attachmentOriginalFileName] VARCHAR (100) NOT NULL,
    [attachmentMaskedFileName]   VARCHAR (100) NOT NULL,
    [transGroupID]               INT           NOT NULL,
    CONSTRAINT [PK_fin_Attachments] PRIMARY KEY CLUSTERED ([attachmentId] ASC)
);

