INSERT INTO [dbo].[MembershipTypes] ([Id], [SignupFee], [DurationInMonths], [DiscountRate], [Name]) VALUES (1, 0, 0, 0, N'')
INSERT INTO [dbo].[MembershipTypes] ([Id], [SignupFee], [DurationInMonths], [DiscountRate], [Name]) VALUES (2, 30, 1, 10, N'')
INSERT INTO [dbo].[MembershipTypes] ([Id], [SignupFee], [DurationInMonths], [DiscountRate], [Name]) VALUES (3, 90, 3, 15, N'')
INSERT INTO [dbo].[MembershipTypes] ([Id], [SignupFee], [DurationInMonths], [DiscountRate], [Name]) VALUES (4, 300, 12, 20, N'')
            UPDATE MembershipTypes SET Name = 'Pay as You Go' WHERE Id = 1
            UPDATE MembershipTypes SET Name = 'Monthly' WHERE Id = 2
            UPDATE MembershipTypes SET Name = 'Quarterly' WHERE Id = 3
            UPDATE MembershipTypes SET Name = 'Annual' WHERE Id = 4
