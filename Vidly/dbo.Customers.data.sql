SET IDENTITY_INSERT [dbo].[Customers] ON
INSERT INTO [dbo].[Customers] ([Id], [Name], [IsSubscribeToNewsLetter], [MembershipTypeId], [BirthDate]) VALUES (1, N'Johnsmith', 0, 1, N'1980-01-01 00:00:00')
INSERT INTO [dbo].[Customers] ([Id], [Name], [IsSubscribeToNewsLetter], [MembershipTypeId], [BirthDate]) VALUES (2, N'MaryWilliams', 1, 2, NULL)
INSERT INTO [dbo].[Customers] ([Id], [Name], [IsSubscribeToNewsLetter], [MembershipTypeId], [BirthDate]) VALUES (3, N'amr', 1, 4, N'1997-03-01 00:00:00')
INSERT INTO [dbo].[Customers] ([Id], [Name], [IsSubscribeToNewsLetter], [MembershipTypeId], [BirthDate]) VALUES (4, N'mohammed', 0, 1, N'2007-01-01 00:00:00')
INSERT INTO [dbo].[Customers] ([Id], [Name], [IsSubscribeToNewsLetter], [MembershipTypeId], [BirthDate]) VALUES (5, N'nada', 1, 3, N'2000-11-01 00:00:00')
INSERT INTO [dbo].[Customers] ([Id], [Name], [IsSubscribeToNewsLetter], [MembershipTypeId], [BirthDate]) VALUES (6, N'ali', 0, 4, NULL)
INSERT INTO [dbo].[Customers] ([Id], [Name], [IsSubscribeToNewsLetter], [MembershipTypeId], [BirthDate]) VALUES (7, N'nasser', 1, 2, N'1963-04-01 00:00:00')
INSERT INTO [dbo].[Customers] ([Id], [Name], [IsSubscribeToNewsLetter], [MembershipTypeId], [BirthDate]) VALUES (8, N'ahmed hussein', 0, 1, N'1980-01-01 00:00:00')
SET IDENTITY_INSERT [dbo].[Customers] OFF
