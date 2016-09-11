/****** Object:  StoredProcedure [dbo].[PictureINSERT] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[PictureINSERT]
@GalleryID int,
@Title varchar(150),
@PictureDescription varchar(450)
as

INSERT INTO [NDTO].[dbo].[Picture]
           (GalleryID, Title, PictureDescription)
     VALUES
           (@GalleryID, @Title, @PictureDescription)

if @@error <> 0 GOTO FAIL

SUCCESS:
select 1 as retVal, @@identity as PictureID
return 1

FAIL:
select 0 as retVal
return 0
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO


