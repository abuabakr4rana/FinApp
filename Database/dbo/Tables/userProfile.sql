CREATE TABLE [dbo].[userProfile] (
    [userID]         INT           NOT NULL,
    [userFirstName]  NVARCHAR (50) NOT NULL,
    [userMiddleName] NVARCHAR (50) NULL,
    [userLastName]   NVARCHAR (50) NOT NULL,
    [userEmail]      VARCHAR (100) NOT NULL,
    [userIsOfficial] BIT           NOT NULL,
    [userIsActive]   BIT           NOT NULL,
    CONSTRAINT [PK_userProfile] PRIMARY KEY CLUSTERED ([userID] ASC)
);

