/****** Object:  StoredProcedure [dbo].[BIUsersDELETE]  ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[BIUsersDELETE]
@UserID int
as

Delete From [NDTO].[dbo].[BIUsers]
WHERE BIUsers.UserID = @UserID

if @@error <> 0 GOTO FAIL

SUCCESS:
select 1 as retVal
return 1

FAIL:
select 0 as retVal
return 0
GO


