/****** Object:  StoredProcedure [dbo].[GalleryINSERT] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GalleryINSERT]
@Title varchar(150)
as

INSERT INTO [NDTO].[dbo].[Gallery]
           (Title)
     VALUES
           (@Title)

if @@error <> 0 GOTO FAIL

SUCCESS:
select 1 as retVal, @@identity as GalleryID
return 1

FAIL:
select 0 as retVal
return 0
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO


