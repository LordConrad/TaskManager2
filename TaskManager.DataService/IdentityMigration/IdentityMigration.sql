SET IDENTITY_INSERT [TaskManagerDb2].[dbo].[AspNetUsers] ON

  INSERT INTO [TaskManagerDb2].[dbo].[AspNetUsers]
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

SET IDENTITY_INSERT [TaskManagerDb2].[dbo].[AspNetUsers] OFF

GO
SET IDENTITY_INSERT [TaskManagerDb2].[dbo].[AspNetRoles] ON
INSERT INTO [TaskManagerDb2].[dbo].[AspNetRoles]
(Id, Name)
SELECT RoleId, RoleName
FROM [TaskManagerDb].[dbo].[webpages_Roles]
SET IDENTITY_INSERT [TaskManagerDb2].[dbo].[AspNetRoles] OFF

GO
INSERT INTO [TaskManagerDb2].[dbo].[AspNetUserRoles]
(RoleId, UserId)
SELECT RoleId, UserId
FROM [TaskManagerDb].[dbo].[webpages_UsersInRoles]

GO
SET IDENTITY_INSERT [TaskManagerDb2].[dbo].[Priority] ON
INSERT INTO [TaskManagerDb2].[dbo].[Priority]
(PriorityId, PriorityName)
SELECT PriorityId, PriorityName FROM [TaskManagerDb].[dbo].[Priority]
SET IDENTITY_INSERT [TaskManagerDb2].[dbo].[Priority] OFF

GO
SET IDENTITY_INSERT [TaskManagerDb2].[dbo].[Task] ON
INSERT INTO [TaskManagerDb2].[dbo].[Task]
(AssignDateTime,
 AcceptCpmpleteDate,
 CompleteDate,
 CreateDate, 
 Deadline, 
 IsRecipientViewed, 
 PriorityId, 
 RecipientId, 
 ResultComment, 
 SenderId, 
 TaskId, 
 TaskText)
SELECT AssignDateTime,
AcceptCpmpleteDate,
CompleteDate,
CreateDate,
Deadline,
IsRecipientViewed,
PriorityId,
RecipientId,
ResultComment,
SenderId,
TaskId,
TaskText
 FROM [TaskManagerDb].[dbo].[Task]
SET IDENTITY_INSERT [TaskManagerDb2].[dbo].[Task] OFF


GO
SET IDENTITY_INSERT [TaskManagerDb2].[dbo].[TaskEventLog] ON
INSERT INTO [TaskManagerDb2].[dbo].[TaskEventLog]
(TaskEventLogId, EventDateTime, OldValue, NewValue, PropertyName, TaskId, UserId)
SELECT TaskEventLogId, EventDateTime, OldValue, NewValue, PropertyName, TaskId, UserId 
FROM [TaskManagerDb].[dbo].[TaskEventLog]
SET IDENTITY_INSERT [TaskManagerDb2].[dbo].[TaskEventLog] OFF

GO
SET IDENTITY_INSERT [TaskManagerDb2].[dbo].[Comment] ON
INSERT INTO [TaskManagerDb2].[dbo].[Comment]
(TaskId, AuthorId, CommentDate, CommentId, CommentText)
SELECT TaskId, AuthorId, CommentDate, CommentId, CommentText 
FROM [TaskManagerDb].[dbo].[Comment]
SET IDENTITY_INSERT [TaskManagerDb2].[dbo].[Comment] OFF