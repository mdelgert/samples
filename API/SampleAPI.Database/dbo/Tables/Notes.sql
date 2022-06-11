CREATE TABLE [dbo].[Notes] (
    [NoteId]      INT            IDENTITY (1, 1) NOT NULL,
    [NoteMessage] NVARCHAR (MAX) NOT NULL,
    [CreateDate]  DATETIME       CONSTRAINT [DF_Notes_CreateDate] DEFAULT (sysdatetime()) NOT NULL,
    [UpdateDate]  DATETIME       CONSTRAINT [DF_Notes_UpdateDate] DEFAULT (sysdatetime()) NOT NULL,
    CONSTRAINT [PK_Notes] PRIMARY KEY CLUSTERED ([NoteId] ASC)
);









