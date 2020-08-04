USE [master]
GO
CREATE LOGIN [DvdLibraryApp] WITH PASSWORD=N'testing123', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=ON
GO
USE [DvdLibrary]
GO
CREATE USER [DvdLibrayApp] FOR LOGIN [DvdLibraryApp] WITH DEFAULT_SCHEMA=[dbo]
GO


GRANT DELETE ON [dbo].[DVDS] TO [DvdLibrayApp]
GO
GRANT INSERT ON [dbo].[DVDS] TO [DvdLibrayApp]
GO
GRANT SELECT ON [dbo].[DVDS] TO [DvdLibrayApp]
GO
GRANT UPDATE ON [dbo].[DVDS] TO [DvdLibrayApp]
GO
GRANT DELETE ON [dbo].[DVD] TO [DvdLibrayApp]
GO
GRANT INSERT ON [dbo].[DVD] TO [DvdLibrayApp]
GO
GRANT SELECT ON [dbo].[DVD] TO [DvdLibrayApp]
GO
GRANT UPDATE ON [dbo].[DVD] TO [DvdLibrayApp]
GO
GRANT EXECUTE ON [dbo].[CreateNewDvd] TO [DvdLibrayApp]
GO
GRANT EXECUTE ON [dbo].[DeleteDvd] TO [DvdLibrayApp]
GO
GRANT EXECUTE ON [dbo].[EditDvd] TO [DvdLibrayApp]
GO
GRANT EXECUTE ON [dbo].[RetreiveDvdByID] TO [DvdLibrayApp]
GO
GRANT EXECUTE ON [dbo].[RetreivingAllDvds] TO [DvdLibrayApp]
GO
GRANT EXECUTE ON [dbo].[RetrievingByDirector] TO [DvdLibrayApp]
GO
GRANT EXECUTE ON [dbo].[RetrievingByRating] TO [DvdLibrayApp]
GO
GRANT EXECUTE ON [dbo].[RetrievingByTitle] TO [DvdLibrayApp]
GO
GRANT EXECUTE ON [dbo].[RetrievingByYear] TO [DvdLibrayApp]
GO