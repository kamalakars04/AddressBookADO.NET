USE [Address_BookDB]
GO

/****** Object:  StoredProcedure [dbo].[GetAllContacts]    Script Date: 27-12-2020 15:42:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllContacts]
	@firstName varchar(30) = null,
	@lastName varchar(30) = null
AS
begin
if(@firstName is null and @lastName is null)
begin
	SELECT CD.* , Z1.city,Z1.State,CM1.AddressBookName,CM1.ContactType from contactdetails CD inner join ZipTable Z1 on CD.Zip = Z1.Zip
	inner join(select AddressBookName,ContactType, FirstName,LastName from BookNameContactType BC 
				inner join ContactTypeMap CM on BC.NameTypeid = CM.NameTypeid) CM1 
    on CD.FirstName = CM1.FirstName and CD.LastName=CM1.LastName
end
else
begin
SELECT CD.* , Z1.city,Z1.State,CM1.AddressBookName,CM1.ContactType from contactdetails CD inner join ZipTable Z1 on CD.Zip = Z1.Zip
	inner join(select AddressBookName,ContactType, FirstName,LastName from BookNameContactType BC 
				inner join ContactTypeMap CM on BC.NameTypeid = CM.NameTypeid) CM1 
    on CD.FirstName = CM1.FirstName and CD.LastName=CM1.LastName where CD.FirstName = @firstName and CD.LastName =@lastName;
end
end
RETURN 0
GO

