SET IDENTITY_INSERT [dbo].[Movies] ON
INSERT INTO [dbo].[Movies] ([Id], [Name], [ReleaseDate], [DateAdded], [NumberInStock], [GenreId], [NumberAvailable]) VALUES (3, N'beforeme', N'2002-01-08 00:00:00', N'1994-05-06 00:00:00', 1, 5, 0)
INSERT INTO [dbo].[Movies] ([Id], [Name], [ReleaseDate], [DateAdded], [NumberInStock], [GenreId], [NumberAvailable]) VALUES (4, N'friends', N'2010-01-01 00:00:00', N'2021-07-30 08:32:46', 2, 5, 2)
INSERT INTO [dbo].[Movies] ([Id], [Name], [ReleaseDate], [DateAdded], [NumberInStock], [GenreId], [NumberAvailable]) VALUES (5, N'angry', N'2000-01-01 00:00:00', N'2021-07-30 08:53:19', 1, 2, 0)
INSERT INTO [dbo].[Movies] ([Id], [Name], [ReleaseDate], [DateAdded], [NumberInStock], [GenreId], [NumberAvailable]) VALUES (6, N'Angry Birds', N'2020-12-01 00:00:00', N'2021-08-01 08:58:30', 3, 2, 0)
INSERT INTO [dbo].[Movies] ([Id], [Name], [ReleaseDate], [DateAdded], [NumberInStock], [GenreId], [NumberAvailable]) VALUES (3009, N'titani', N'2021-12-01 00:00:00', N'2021-08-07 09:25:29', 10, 4, 0)
INSERT INTO [dbo].[Movies] ([Id], [Name], [ReleaseDate], [DateAdded], [NumberInStock], [GenreId], [NumberAvailable]) VALUES (3011, N'love me ', N'2018-07-01 00:00:00', N'2021-08-07 09:50:50', 6, 1, 0)
INSERT INTO [dbo].[Movies] ([Id], [Name], [ReleaseDate], [DateAdded], [NumberInStock], [GenreId], [NumberAvailable]) VALUES (3012, N'Die hare', N'2021-12-01 00:00:00', N'2021-08-07 13:44:18', 15, 2, 0)
INSERT INTO [dbo].[Movies] ([Id], [Name], [ReleaseDate], [DateAdded], [NumberInStock], [GenreId], [NumberAvailable]) VALUES (3013, N'wanted', N'2012-05-01 00:00:00', N'2021-08-07 13:44:42', 13, 4, 0)
INSERT INTO [dbo].[Movies] ([Id], [Name], [ReleaseDate], [DateAdded], [NumberInStock], [GenreId], [NumberAvailable]) VALUES (3014, N'believe', N'2020-06-01 00:00:00', N'2021-08-07 13:48:11', 9, 3, 0)
SET IDENTITY_INSERT [dbo].[Movies] OFF
UPDATE Movies SET NumberAvailable = NumberInStock
