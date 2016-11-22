--select * from [GusDev].[dbo].[VitalityGP] order by firstname

--delete from [GusDev].[dbo].[VitalityGP]

INSERT INTO [GusDev].[dbo].[VitalityGP]
				   (  --[Active]
					  --,[Salutation]
					  [Title]
					  ,[FirstName]
					  ,[LastName]
					  ,[Email]
					  ,[Phone]
					  ,[Shortname]
					 ,[UserID] --should be uniqueidentifier
					  --,[CRM] --should be int
					  --,[CreatedBy]
					  ,[CreatedAt]
					 -- --,[ModifiedBy]
					  ,[ModifiedAt]
					 -- --,[OptimisticLockField]
					 -- --,[GCRecord]
					  )
	SELECT   
		pp.Pers_Salutation,
		pp.Pers_FirstName,
		pp.Pers_LastName,
		Email,
		Pers_PhoneNumber,
		UserName,
		ap.userid, -- userid
		--au.UserId, -- CRM
		--Pers_CreatedBy, -- should come from [GusDev].[dbo].[User].[OID]
		CreateDate,
		LastUpdatedDate
	  FROM [VitalityGPMembership].[dbo].[aspnet_Profile] ap
   		INNER JOIN [CRM].[dbo].[Person] pp on pp.Pers_PersonId  = Cast(ap.[PropertyValuesString] As NVarchar(Max))
   		INNER JOIN [VitalityGPMembership].[dbo].[aspnet_Membership] am on am.UserId = ap.userid
   		INNER JOIN [VitalityGPMembership].[dbo].[aspnet_Users] au on au.userid = am.[UserId]
		AND NOT EXISTS (
							SELECT  vgp.userid
							FROM    [GusDev].[dbo].[VitalityGP] vgp
							WHERE   vgp.[UserID] =   	ap.userid 
						)