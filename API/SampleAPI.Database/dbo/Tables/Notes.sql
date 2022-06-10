CREATE TABLE [dbo].[Notes] (
    [RecId]      INT            IDENTITY (1, 1) NOT NULL,
    [Note]       NVARCHAR (MAX) NOT NULL,
    [CreateDate] DATETIME       CONSTRAINT [DF_Notes_CreateDate] DEFAULT (getdate()) NOT NULL,
    [UpdateDate] DATETIME       CONSTRAINT [DF_Notes_UpdateDate] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Notes] PRIMARY KEY CLUSTERED ([RecId] ASC)
);

