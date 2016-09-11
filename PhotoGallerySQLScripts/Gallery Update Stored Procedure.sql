/****** Object:  StoredProcedure [dbo].[GalleryUPDATE] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GalleryUPDATE]
@Title varchar(150),
@GalleryID int
as

UPDATE [NDTO].[dbo].[Gallery]
   SET 
Title= @Title
   WHERE GalleryID = @GalleryID

if @@error <> 0 GOTO FAIL

SUCCESS:
select 1 as retVal
return 1

FAIL:
select 0 as retVal
return 0
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO


