SET IDENTITY_INSERT [dbo].[Customers] ON
INSERT INTO [dbo].[Customers] ([Id], [Name], [IsSubscribeToNewsLetter], [MembershipTypeId]) VALUES (1, N'Johnsmith', 0, 1)
INSERT INTO [dbo].[Customers] ([Id], [Name], [IsSubscribeToNewsLetter], [MembershipTypeId]) VALUES (2, N'MaryWilliams', 1, 2)
SET IDENTITY_INSERT [dbo].[Customers] OFF
DBCC CHECKIDENT (mytable, RESEED, 0)