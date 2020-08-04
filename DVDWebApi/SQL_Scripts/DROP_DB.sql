
EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'DvdLibrary'
GO
use [DvdLibrary];
GO
use [master];
GO
ALTER DATABASE [DvdLibrary] SET  SINGLE_USER WITH ROLLBACK IMMEDIATE
GO
USE [master]
GO
DROP DATABASE [DvdLibrary]
GO
USE [master]
GO
DROP LOGIN [DvdLibraryApp]
GO

