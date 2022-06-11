-- =============================================
-- Author:		Matthew Elgert
-- Create date: 6/10/2022
-- Description:	Insert update notes.
-- EXEC [dbo].[sp_insertNotes] @noteMessage='test'
-- =============================================
CREATE PROCEDURE [dbo].[sp_insertNotes]
(
    @noteId INT = NULL,
    @noteMessage NVARCHAR(MAX)
)
AS
SET XACT_ABORT, NOCOUNT ON
BEGIN TRY
    BEGIN TRANSACTION
    MERGE dbo.Notes AS [t]
    USING
    (
        VALUES
            (
			@noteId, 
			@noteMessage)
    ) AS s (
	noteId, 
	noteMessage)
    ON (t.NoteId = s.NoteId)
    WHEN NOT MATCHED THEN
        INSERT
        (
            NoteMessage,
            CreateDate,
            UpdateDate
        )
        VALUES
        (
		@noteMessage, 
		SYSDATETIME(), 
		SYSDATETIME()
		)
    WHEN MATCHED THEN
        UPDATE SET t.NoteMessage = s.noteMessage,
                   t.UpdateDate = SYSDATETIME();
    COMMIT TRANSACTION
    SELECT *
    FROM dbo.Notes
    WHERE NoteId = SCOPE_IDENTITY()
END TRY
BEGIN CATCH
    IF @@trancount > 0
        ROLLBACK TRANSACTION
    DECLARE @msg nvarchar(2048) = error_message()
    RAISERROR(@msg, 16, 1)
    RETURN 55555
END CATCH