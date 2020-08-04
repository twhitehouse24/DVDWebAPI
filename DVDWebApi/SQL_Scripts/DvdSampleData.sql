USE [DvdLibrary]

Delete from DVD
Delete from DVDS

SET IDENTITY_INSERT [dbo].[DVD] ON 

INSERT [dbo].[DVD] ([DvdID], [Title], [ReleaseYear], [Director], [Rating], [Notes]) VALUES (1, N'A Great Tale', N'2011', 'Tom Wells', 'PG', N'This is a really great tale!')
INSERT [dbo].[DVD] ([DvdID], [Title], [ReleaseYear], [Director], [Rating], [Notes]) VALUES (2, N'A Good Tale', N'1971', 'Brad Pitt', 'PG-13', N'This is a good tale!')
INSERT [dbo].[DVD] ([DvdID], [Title], [ReleaseYear], [Director], [Rating], [Notes]) VALUES (3, N'A Bad Tale', N'1999', 'Captain America', 'R', N'This is a bad tale!!!')
INSERT [dbo].[DVD] ([DvdID], [Title], [ReleaseYear], [Director], [Rating], [Notes]) VALUES (4, N'A Tale of Two Cities', N'1940', 'Joe Smith', 'G', N'A Novel Tale')
SET IDENTITY_INSERT [dbo].[DVD] OFF
GO

SET IDENTITY_INSERT [dbo].[DVDS] ON 
INSERT [dbo].[DVDS] ([DvdID], [Title], [ReleaseYear], [Director], [Rating], [Notes]) VALUES (1, N'A Great Tale', N'2011', 'Tom Wells', 'PG', N'This is a really great tale!')
INSERT [dbo].[DVDS] ([DvdID], [Title], [ReleaseYear], [Director], [Rating], [Notes]) VALUES (2, N'A Good Tale', N'1971', 'Brad Pitt', 'PG-13', N'This is a good tale!')
INSERT [dbo].[DVDS] ([DvdID], [Title], [ReleaseYear], [Director], [Rating], [Notes]) VALUES (3, N'A Bad Tale', N'1999', 'Captain America', 'R', N'This is a bad tale!!!')
INSERT [dbo].[DVDS] ([DvdID], [Title], [ReleaseYear], [Director], [Rating], [Notes]) VALUES (4, N'A Tale of Two Cities', N'1940', 'Joe Smith', 'G', N'A Novel Tale')
SET IDENTITY_INSERT [dbo].[DVDS] OFF
GO


