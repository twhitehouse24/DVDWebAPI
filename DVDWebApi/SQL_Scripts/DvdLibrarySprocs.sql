USE [DvdLibrary]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RetreivingAllDvds]

AS
BEGIN
    SELECT DvdID, Title, ReleaseYear,Director,Rating, Notes
    FROM DVD 
END
GO
CREATE PROCEDURE [dbo].[RetreiveDvdByID] (
    @DvdId INT 
)
AS
    SELECT DvdID, Title, ReleaseYear,Director,Rating, Notes
    FROM DVD
    WHERE DvdID = @DvdID
GO

CREATE PROCEDURE [dbo].[DeleteDvd] (
	@DvdId int
)
AS
	DELETE FROM DVD
	WHERE DvdID = @DvdId
GO

USE [DvdLibrary]
GO
CREATE PROCEDURE [dbo].[CreateNewDvd](
   @DvdId INT,
   @Title CHAR(200),
   @Director CHAR(40),
   @Rating CHAR(20), 
   @ReleaseYear INT,
   @Notes CHAR(200)
)
AS
   begin
 
     INSERT INTO DVD(Title,ReleaseYear,Director,Rating,Notes) VALUES(@Title,@ReleaseYear,@Director,@Rating, @Notes)
	   
 end
GO


CREATE PROCEDURE [dbo].[EditDvd] (
   @DvdId INT,
   @Title CHAR(200),
   @Director CHAR(40),
   @Rating CHAR(20), 
   @ReleaseYear INT,
   @Notes CHAR(200)

)
AS
	  begin
   if exists(
   select*from DVD
   where dvd.DvdID=@DvdId
   )
   begin
  

   update DVD
   set Title=@Title,
   ReleaseYear=@ReleaseYear,
   Director=@Director,
   Rating=@Rating,
   Notes=@Notes
   where DvdID=@DvdId
 end
 end
GO


CREATE PROCEDURE [dbo].[RetrievingByYear]
 
@ReleaseYear int

AS
BEGIN
    SELECT DvdID, Title, ReleaseYear,Director,Rating, Notes
    FROM DVD 
	Where ReleaseYear = @ReleaseYear

END
GO

CREATE PROCEDURE [dbo].[RetrievingByTitle]
 
@Title char(200)

AS
BEGIN
    SELECT DvdID, Title, ReleaseYear,Director,Rating, Notes
    FROM DVD 
	Where Title Like '%'+@Title+'%'

END
GO

CREATE PROCEDURE [dbo].[RetrievingByRating]
 
@Rating varchar(5)

AS
BEGIN
    SELECT DvdID, Title, ReleaseYear,Director,Rating, Notes
    FROM DVD 
	Where Rating Like '%'+@Rating+'%'

END
GO

CREATE PROCEDURE [dbo].[RetrievingByDirector]
 
@Director varchar(100)

AS
BEGIN
    SELECT DvdID, Title, ReleaseYear,Director,Rating, Notes
    FROM DVD 
	Where Director Like '%'+@Director+'%'

END
GO