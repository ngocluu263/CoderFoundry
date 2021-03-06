﻿CREATE PROCEDURE [Security].[IsUserInRole]
@userId int, @role nvarchar(50)
as

SELECT cast(
	(CASE
		WHEN EXISTS(
			SELECT NULL
			FROM [Security].[UserRoles] ur
			INNER JOIN [Security].[Roles] r on r.[Id] = ur.[RoleId] 
			WHERE (ur.[UserId] = @userId AND r.[Name] = @role )
			) 
			THEN 1
		ELSE 0
	END) as bit)