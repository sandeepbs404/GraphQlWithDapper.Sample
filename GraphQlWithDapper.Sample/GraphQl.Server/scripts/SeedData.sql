

INSERT INTO [dbo].[Form]
           ([Identification]
           ,[FormCreationDate]
           ,[FormCreationHour]
           ,[AttestationStatus]
           ,[TypeForm]
           ,[Form_Id]
           ,[UpdatedBy]
           ,[UpdatedTime])
     VALUES
           ('958C4A66-CEAB-4724-81CE-4090356F5CA8',	'10-10-2015',	'2356',	'23',	'22',	'2',	'sql',	GETDATE())

INSERT INTO [dbo].[EmployerDeclaration]
           ([Quarter]
           ,[NOSSRegistrationNbr]
           ,[Trusteeship]
           ,[NOSSLPARegistrationNbr]
           ,[CompanyID]
           ,[System5]
           ,[EmployerDeclarationPID]
           ,[EmployerDeclarationVersionNbr]
           ,[ResultCodeResearch]
           ,[AnomalySubmission]
           ,[Form_Id]
           ,[EmployerDeclaration_Id]
           ,[UpdatedBy]
           ,[UpdatedTime])
     VALUES
           (
'20181',	'qwer',	'wer',	'dfs',	'Prowareness',	NULL,'as',NULL,NULL,NULL,'2', 'ED1', 'sql',GETDATE())
GO


