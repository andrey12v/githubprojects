/****** Object:  StoredProcedure [dbo].[GalleryDELETE] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GalleryDELETE]
@GalleryID int
as

Delete From [NDTO].[dbo].[Gallery]
WHERE Gallery.GalleryID = @GalleryID

Delete From [NDTO].[dbo].[Picture]
WHERE Picture.GalleryID = @GalleryID

if @@error <> 0 GOTO FAIL

SUCCESS:
select 1 as retVal
return 1

FAIL:
select 0 as retVal
return 0
GO


