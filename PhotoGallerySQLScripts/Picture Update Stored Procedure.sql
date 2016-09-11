/****** Object:  StoredProcedure [dbo].[PictureUPDATE] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[PictureUPDATE]
@GalleryID int,
@PictureID int,
@Title varchar(150),
@PictureDescription varchar(450),
@FrontImage int
as

BEGIN
IF @FrontImage = 1
UPDATE Picture SET FrontImage=0 WHERE FrontImage=1 and GalleryID = @GalleryID
END

UPDATE [NDTO].[dbo].[Picture]
   SET 
Title= @Title,
PictureDescription=@PictureDescription,
FrontImage=@FrontImage 
   WHERE PictureID = @PictureID

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


