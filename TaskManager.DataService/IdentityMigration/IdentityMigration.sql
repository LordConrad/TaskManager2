SET IDENTITY_INSERT [TaskManagerDb].[dbo].[AspNetUsers] ON

  INSERT INTO [TaskManagerDb].[dbo].[AspNetUsers]
  (Id, UserName, PasswordHash, SecurityStamp, EmailConfirmed, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnabled, AccessFailedCount)
  SELECT
	mshp.UserId,
	usr.UserName,
	mshp.[Password],
	NEWID(),
	0, 0, 0, 0, 0
	
  FROM [TaskManagerDb].[dbo].[webpages_Membership] mshp
  JOIN [TaskManagerDb].[dbo].[UserProfile] usr ON usr.UserId = mshp.UserId

SET IDENTITY_INSERT [TaskManagerDb].[dbo].[AspNetUsers] OFF

SET IDENTITY_INSERT [TaskManagerDb].[dbo].[AspNetRoles] ON

INSERT INTO [TaskManagerDb].[dbo].[AspNetRoles]
(Id, Name)
SELECT RoleId, RoleName
FROM [TaskManagerDb].[dbo].[webpages_Roles]

SET IDENTITY_INSERT [TaskManagerDb].[dbo].[AspNetRoles] OFF

INSERT INTO [TaskManagerDb].[dbo].[AspNetUserRoles]
(RoleId, UserId)
SELECT RoleId, UserId
FROM [TaskManagerDb].[dbo].[webpages_UsersInRoles]