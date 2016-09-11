/****** Object:  StoredProcedure [dbo].[PictureDELETE]  ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[PictureDELETE]
@PictureID int
as

Delete From [NDTO].[dbo].[Picture]
WHERE Picture.PictureID = @PictureID

if @@error <> 0 GOTO FAIL

SUCCESS:
select 1 as retVal
return 1

FAIL:
select 0 as retVal
return 0
GO


