/****** Object:  StoredProcedure [dbo].[BIUsersINSERT] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[BIUsersINSERT]
	@FirstName varchar(50),
	@LastName varchar(50),
	@JobTitle varchar(50),
	@Company varchar(50),
	@UserAddress varchar(50),
	@City varchar(50),
	@StateProvince varchar(50),
	@Country varchar(50),
	@PostalCode varchar(50),
	@Email varchar(50),
	@Website varchar(50),
	@Phone varchar(50),
	@Fax varchar(50),
	@ProductInterest varchar(50),
	@OtherProductInterest varchar(50),
	@VisitorStatus varchar(50),
	@OtherVisitorStatus varchar(50),
	@PurposeVisit varchar(50),
	@OtherPurposeVisit varchar(50),
	@CropInterest varchar(50),
	@OtherCropInterest varchar(50),
	@Interpreter bit,
	@UserLanguage varchar(50)

as

INSERT INTO [NDTO].[dbo].[BIUsers]
           (FirstName, LastName, JobTitle, Company, UserAddress, City, StateProvince, Country, PostalCode, Email, Website, Phone, Fax, 
            ProductInterest, OtherProductInterest, VisitorStatus, OtherVisitorStatus, PurposeVisit, OtherPurposeVisit, CropInterest, OtherCropInterest, Interpreter, UserLanguage)
     VALUES
           (@FirstName, @LastName, @JobTitle, @Company, @UserAddress, @City, @StateProvince, @Country, @PostalCode, @Email, @Website, @Phone, @Fax, 
            @ProductInterest, @OtherProductInterest, @VisitorStatus, @OtherVisitorStatus, @PurposeVisit, @OtherPurposeVisit, @CropInterest, @OtherCropInterest, @Interpreter, @UserLanguage)

if @@error <> 0 GOTO FAIL

SUCCESS:
select 1 as retVal, @@identity as UserID
return 1

FAIL:
select 0 as retVal
return 0
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO


