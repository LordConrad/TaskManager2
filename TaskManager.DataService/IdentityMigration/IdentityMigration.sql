SET IDENTITY_INSERT [TaskManagerDb2].[dbo].[ApplicationUsers] ON

  INSERT INTO [TaskManagerDb2].[dbo].[ApplicationUsers]
  (Id, UserName, FullName, PasswordHash, SecurityStamp, EmailConfirmed, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnabled, AccessFailedCount)
  SELECT
	mshp.UserId,
	usr.UserName,
	usr.UserFullName,
	mshp.[Password],
	NEWID(),
	0, 0, 0, 0, 0
	
  FROM [TaskManagerDb].[dbo].[webpages_Membership] mshp
  JOIN [TaskManagerDb].[dbo].[UserProfile] usr ON usr.UserId = mshp.UserId

SET IDENTITY_INSERT [TaskManagerDb2].[dbo].[ApplicationUsers] OFF

SET IDENTITY_INSERT [TaskManagerDb2].[dbo].[ApplicationRoles] ON

INSERT INTO [TaskManagerDb2].[dbo].[ApplicationRoles]
(Id, Name)
SELECT RoleId, RoleName
FROM [TaskManagerDb].[dbo].[webpages_Roles]

SET IDENTITY_INSERT [TaskManagerDb2].[dbo].[ApplicationRoles] OFF

INSERT INTO [TaskManagerDb2].[dbo].[ApplicationUserRoles]
(RoleId, ApplicationRole_Id, ApplicationUser_Id)
SELECT 0, RoleId, UserId
FROM [TaskManagerDb].[dbo].[webpages_UsersInRoles]
