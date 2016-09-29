
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/29/2016 15:16:50
-- Generated from EDMX file: E:\Work_hy\共性平台\BasePlace\BCP.Domain\Edmx\DBPlaceFinal.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BCP];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UserLoginLog]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LoginLogs] DROP CONSTRAINT [FK_UserLoginLog];
GO
IF OBJECT_ID(N'[dbo].[FK_OrganizationOrganizationOtherName]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrganizationOtherNames] DROP CONSTRAINT [FK_OrganizationOrganizationOtherName];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductStandardProductStandard]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductStandards] DROP CONSTRAINT [FK_ProductStandardProductStandard];
GO
IF OBJECT_ID(N'[dbo].[FK_IndustryCodeIndustryCode]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[IndustryCodes] DROP CONSTRAINT [FK_IndustryCodeIndustryCode];
GO
IF OBJECT_ID(N'[dbo].[FK_OrganizationOrganizationTransition]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrganizationTransitions] DROP CONSTRAINT [FK_OrganizationOrganizationTransition];
GO
IF OBJECT_ID(N'[dbo].[FK_OrganizationOrganizationTransition1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrganizationTransitions] DROP CONSTRAINT [FK_OrganizationOrganizationTransition1];
GO
IF OBJECT_ID(N'[dbo].[FK_UserUser_ContacTable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User_ContactTable] DROP CONSTRAINT [FK_UserUser_ContacTable];
GO
IF OBJECT_ID(N'[dbo].[FK_OrganizationOrganization]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[sys_Organization] DROP CONSTRAINT [FK_OrganizationOrganization];
GO
IF OBJECT_ID(N'[dbo].[FK_AdministrativecodeAdministrativecode]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Administrativecodes] DROP CONSTRAINT [FK_AdministrativecodeAdministrativecode];
GO
IF OBJECT_ID(N'[dbo].[FK_Organization_TypeOrganization_Type]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Organization_Type] DROP CONSTRAINT [FK_Organization_TypeOrganization_Type];
GO
IF OBJECT_ID(N'[dbo].[FK_SubordinateOrganizBasic]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrganizBasics] DROP CONSTRAINT [FK_SubordinateOrganizBasic];
GO
IF OBJECT_ID(N'[dbo].[FK_SpecializedSpecialized]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Specializeds] DROP CONSTRAINT [FK_SpecializedSpecialized];
GO
IF OBJECT_ID(N'[dbo].[FK_SpecializedPostbasic]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PostRequires] DROP CONSTRAINT [FK_SpecializedPostbasic];
GO
IF OBJECT_ID(N'[dbo].[FK_UserUserRelateTable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserRelateTables] DROP CONSTRAINT [FK_UserUserRelateTable];
GO
IF OBJECT_ID(N'[dbo].[FK_UserUserRelateTable1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserRelateTables] DROP CONSTRAINT [FK_UserUserRelateTable1];
GO
IF OBJECT_ID(N'[dbo].[FK_UserRelateTypeUserRelateTable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserRelateTables] DROP CONSTRAINT [FK_UserRelateTypeUserRelateTable];
GO
IF OBJECT_ID(N'[dbo].[FK_UserRelateTypeUserRelateType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserRelateTypes] DROP CONSTRAINT [FK_UserRelateTypeUserRelateType];
GO
IF OBJECT_ID(N'[dbo].[FK_DocHanderStateDocumentManage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DocumentManages] DROP CONSTRAINT [FK_DocHanderStateDocumentManage];
GO
IF OBJECT_ID(N'[dbo].[FK_DocumentTypeDocumentType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DocumentTypes] DROP CONSTRAINT [FK_DocumentTypeDocumentType];
GO
IF OBJECT_ID(N'[dbo].[FK_SecurityinfoDocumentManage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DocumentManages] DROP CONSTRAINT [FK_SecurityinfoDocumentManage];
GO
IF OBJECT_ID(N'[dbo].[FK_Organization_TypeOrganizBasic]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrganizBasics] DROP CONSTRAINT [FK_Organization_TypeOrganizBasic];
GO
IF OBJECT_ID(N'[dbo].[FK_OrganizBasicOrganicInvestor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrganicInvestors] DROP CONSTRAINT [FK_OrganizBasicOrganicInvestor];
GO
IF OBJECT_ID(N'[dbo].[FK_OrganizBasicOrgaRegisterDocment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrgaRegisterDocments] DROP CONSTRAINT [FK_OrganizBasicOrgaRegisterDocment];
GO
IF OBJECT_ID(N'[dbo].[FK_RegisterDocumentTypeOrgaRegisterDocment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrgaRegisterDocments] DROP CONSTRAINT [FK_RegisterDocumentTypeOrgaRegisterDocment];
GO
IF OBJECT_ID(N'[dbo].[FK_OrganizBasicOrganizBasic]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrganizBasics] DROP CONSTRAINT [FK_OrganizBasicOrganizBasic];
GO
IF OBJECT_ID(N'[dbo].[FK_OrganizationOrganizBasic]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrganizBasics] DROP CONSTRAINT [FK_OrganizationOrganizBasic];
GO
IF OBJECT_ID(N'[dbo].[FK_OrganizationOrganizationEvent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrganizationEvents] DROP CONSTRAINT [FK_OrganizationOrganizationEvent];
GO
IF OBJECT_ID(N'[dbo].[FK_IndustryCodeOrganizBasic]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrganizBasics] DROP CONSTRAINT [FK_IndustryCodeOrganizBasic];
GO
IF OBJECT_ID(N'[dbo].[FK_OrganizBasicOrganization_ContacTable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Organization_ContactTables] DROP CONSTRAINT [FK_OrganizBasicOrganization_ContacTable];
GO
IF OBJECT_ID(N'[dbo].[FK_AdministrativecodeOrganizBasic]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrganizBasics] DROP CONSTRAINT [FK_AdministrativecodeOrganizBasic];
GO
IF OBJECT_ID(N'[dbo].[FK_OrganizBasicOrganicInvestor1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrganicInvestors] DROP CONSTRAINT [FK_OrganizBasicOrganicInvestor1];
GO
IF OBJECT_ID(N'[dbo].[FK_UserMessageGroup]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[sys_GroupMember] DROP CONSTRAINT [FK_UserMessageGroup];
GO
IF OBJECT_ID(N'[dbo].[FK_UserGroupName]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[sys_Group] DROP CONSTRAINT [FK_UserGroupName];
GO
IF OBJECT_ID(N'[dbo].[FK_UserCustomerGoup]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[sys_CustomerGoup] DROP CONSTRAINT [FK_UserCustomerGoup];
GO
IF OBJECT_ID(N'[dbo].[FK_UserUserMessage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[sys_UserMessage] DROP CONSTRAINT [FK_UserUserMessage];
GO
IF OBJECT_ID(N'[dbo].[FK_OrganizationCustomOrganizationType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrganizationCustomTypes] DROP CONSTRAINT [FK_OrganizationCustomOrganizationType];
GO
IF OBJECT_ID(N'[dbo].[FK_CustomCategoryCustomOrganizationType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrganizationCustomTypes] DROP CONSTRAINT [FK_CustomCategoryCustomOrganizationType];
GO
IF OBJECT_ID(N'[dbo].[FK_CustomCategoryCustomCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CustomCategories] DROP CONSTRAINT [FK_CustomCategoryCustomCategory];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductStandardProduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Products] DROP CONSTRAINT [FK_ProductStandardProduct];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductProductComposition1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductCompositions] DROP CONSTRAINT [FK_ProductProductComposition1];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductProductCustomType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductCustomTypes] DROP CONSTRAINT [FK_ProductProductCustomType];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductCustomCategoryProductCustomCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductCustomCategories] DROP CONSTRAINT [FK_ProductCustomCategoryProductCustomCategory];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductCustomCategoryProductCustomType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductCustomTypes] DROP CONSTRAINT [FK_ProductCustomCategoryProductCustomType];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductProductEvent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductEvents] DROP CONSTRAINT [FK_ProductProductEvent];
GO
IF OBJECT_ID(N'[dbo].[FK_OrganizationphysicalAsset]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[physicalAssets] DROP CONSTRAINT [FK_OrganizationphysicalAsset];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductphysicalAsset]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[physicalAssets] DROP CONSTRAINT [FK_ProductphysicalAsset];
GO
IF OBJECT_ID(N'[dbo].[FK_OrganizationphysicalAsset1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[physicalAssets] DROP CONSTRAINT [FK_OrganizationphysicalAsset1];
GO
IF OBJECT_ID(N'[dbo].[FK_physicalAssetAssetUse]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AssetUses] DROP CONSTRAINT [FK_physicalAssetAssetUse];
GO
IF OBJECT_ID(N'[dbo].[FK_physicalAssetAssetMaintenance]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AssetMaintenances] DROP CONSTRAINT [FK_physicalAssetAssetMaintenance];
GO
IF OBJECT_ID(N'[dbo].[FK_AssetTypeAssetType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AssetBaseTypes] DROP CONSTRAINT [FK_AssetTypeAssetType];
GO
IF OBJECT_ID(N'[dbo].[FK_OrganizationPosition]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[sys_Position] DROP CONSTRAINT [FK_OrganizationPosition];
GO
IF OBJECT_ID(N'[dbo].[FK_DllFileStreamDllFileStream]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DllFileStreams] DROP CONSTRAINT [FK_DllFileStreamDllFileStream];
GO
IF OBJECT_ID(N'[dbo].[FK_physicalAssetOrganizationAssetType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrganizationAssetTypes] DROP CONSTRAINT [FK_physicalAssetOrganizationAssetType];
GO
IF OBJECT_ID(N'[dbo].[FK_AssetBaseTypeOrganizationAssetType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrganizationAssetTypes] DROP CONSTRAINT [FK_AssetBaseTypeOrganizationAssetType];
GO
IF OBJECT_ID(N'[dbo].[FK_UserEmployee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[sys_Employee] DROP CONSTRAINT [FK_UserEmployee];
GO
IF OBJECT_ID(N'[dbo].[FK_PostRequirePosition]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[sys_Position] DROP CONSTRAINT [FK_PostRequirePosition];
GO
IF OBJECT_ID(N'[dbo].[FK_IndustryCodeIndustrySolution]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[IndustrySolutions] DROP CONSTRAINT [FK_IndustryCodeIndustrySolution];
GO
IF OBJECT_ID(N'[dbo].[FK_PositionEmployee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[sys_Employee] DROP CONSTRAINT [FK_PositionEmployee];
GO
IF OBJECT_ID(N'[dbo].[FK_OrganizBasicProduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Products] DROP CONSTRAINT [FK_OrganizBasicProduct];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductCompositionProductComposition]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductCompositions] DROP CONSTRAINT [FK_ProductCompositionProductComposition];
GO
IF OBJECT_ID(N'[dbo].[FK_IndustrySolutionWorkSpace]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WorkSpaces] DROP CONSTRAINT [FK_IndustrySolutionWorkSpace];
GO
IF OBJECT_ID(N'[dbo].[FK_OrganizationPost]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[sys_Post] DROP CONSTRAINT [FK_OrganizationPost];
GO
IF OBJECT_ID(N'[dbo].[FK_WorkSpaceWorkSpace]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WorkSpaces] DROP CONSTRAINT [FK_WorkSpaceWorkSpace];
GO
IF OBJECT_ID(N'[dbo].[FK_OrganizationEmployee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[sys_Employee] DROP CONSTRAINT [FK_OrganizationEmployee];
GO
IF OBJECT_ID(N'[dbo].[FK_IndustrySolutionDllFileStream]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DllFileStreams] DROP CONSTRAINT [FK_IndustrySolutionDllFileStream];
GO
IF OBJECT_ID(N'[dbo].[FK_WorkModulWorkModul]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WorkModuls] DROP CONSTRAINT [FK_WorkModulWorkModul];
GO
IF OBJECT_ID(N'[dbo].[FK_WorkModulWorkSpace]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WorkSpaces] DROP CONSTRAINT [FK_WorkModulWorkSpace];
GO
IF OBJECT_ID(N'[dbo].[FK_WorkSpaceWorkSpaceRole]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WorkSpaceRoles] DROP CONSTRAINT [FK_WorkSpaceWorkSpaceRole];
GO
IF OBJECT_ID(N'[dbo].[FK_OrganizationWorkSpaceRole]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WorkSpaceRoles] DROP CONSTRAINT [FK_OrganizationWorkSpaceRole];
GO
IF OBJECT_ID(N'[dbo].[FK_WorkModulWorkSpaceRole]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WorkSpaceRoles] DROP CONSTRAINT [FK_WorkModulWorkSpaceRole];
GO
IF OBJECT_ID(N'[dbo].[FK_PostAuthorization]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Authorizations] DROP CONSTRAINT [FK_PostAuthorization];
GO
IF OBJECT_ID(N'[dbo].[FK_OrganizationProduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Products] DROP CONSTRAINT [FK_OrganizationProduct];
GO
IF OBJECT_ID(N'[dbo].[FK_PostAuthorization1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Authorizations] DROP CONSTRAINT [FK_PostAuthorization1];
GO
IF OBJECT_ID(N'[dbo].[FK_WorkModulModulProperty]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ModulProperties] DROP CONSTRAINT [FK_WorkModulModulProperty];
GO
IF OBJECT_ID(N'[dbo].[FK_ModulPropertyAuthorization]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Authorizations] DROP CONSTRAINT [FK_ModulPropertyAuthorization];
GO
IF OBJECT_ID(N'[dbo].[FK_AuthorizationWorkMessage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WorkMessages] DROP CONSTRAINT [FK_AuthorizationWorkMessage];
GO
IF OBJECT_ID(N'[dbo].[FK_UserWorkSpaceRole]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WorkSpaceRoles] DROP CONSTRAINT [FK_UserWorkSpaceRole];
GO
IF OBJECT_ID(N'[dbo].[FK_UserAuthorization]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Authorizations] DROP CONSTRAINT [FK_UserAuthorization];
GO
IF OBJECT_ID(N'[dbo].[FK_UserAuthorization1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Authorizations] DROP CONSTRAINT [FK_UserAuthorization1];
GO
IF OBJECT_ID(N'[dbo].[FK_DocumentTypeDocType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DocTypes] DROP CONSTRAINT [FK_DocumentTypeDocType];
GO
IF OBJECT_ID(N'[dbo].[FK_DocumentManageDocType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DocTypes] DROP CONSTRAINT [FK_DocumentManageDocType];
GO
IF OBJECT_ID(N'[dbo].[FK_OrganizationDocReader]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DocReaders] DROP CONSTRAINT [FK_OrganizationDocReader];
GO
IF OBJECT_ID(N'[dbo].[FK_WorkSpaceDocReader]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DocReaders] DROP CONSTRAINT [FK_WorkSpaceDocReader];
GO
IF OBJECT_ID(N'[dbo].[FK_PostDocReader]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DocReaders] DROP CONSTRAINT [FK_PostDocReader];
GO
IF OBJECT_ID(N'[dbo].[FK_UserDocReader]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DocReaders] DROP CONSTRAINT [FK_UserDocReader];
GO
IF OBJECT_ID(N'[dbo].[FK_SecurityinfoSecurityinfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Securityinfoes] DROP CONSTRAINT [FK_SecurityinfoSecurityinfo];
GO
IF OBJECT_ID(N'[dbo].[FK_DocManageStateDocManageState]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DocManageStates] DROP CONSTRAINT [FK_DocManageStateDocManageState];
GO
IF OBJECT_ID(N'[dbo].[FK_UserDocSender]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DocSenders] DROP CONSTRAINT [FK_UserDocSender];
GO
IF OBJECT_ID(N'[dbo].[FK_PostDocSender]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DocSenders] DROP CONSTRAINT [FK_PostDocSender];
GO
IF OBJECT_ID(N'[dbo].[FK_DocSenderDocComent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DocComents] DROP CONSTRAINT [FK_DocSenderDocComent];
GO
IF OBJECT_ID(N'[dbo].[FK_PostJobChange]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[JobChanges] DROP CONSTRAINT [FK_PostJobChange];
GO
IF OBJECT_ID(N'[dbo].[FK_WorkSpaceWorkSpaceType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WorkSpaceTypes] DROP CONSTRAINT [FK_WorkSpaceWorkSpaceType];
GO
IF OBJECT_ID(N'[dbo].[FK_DocumentManageworkTask]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[workTasks] DROP CONSTRAINT [FK_DocumentManageworkTask];
GO
IF OBJECT_ID(N'[dbo].[FK_workTaskworkTask]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[workTasks] DROP CONSTRAINT [FK_workTaskworkTask];
GO
IF OBJECT_ID(N'[dbo].[FK_DocumentManageDocumentContent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DocumentContents] DROP CONSTRAINT [FK_DocumentManageDocumentContent];
GO
IF OBJECT_ID(N'[dbo].[FK_DocumentContentDocumentContent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DocumentContents] DROP CONSTRAINT [FK_DocumentContentDocumentContent];
GO
IF OBJECT_ID(N'[dbo].[FK_workTaskDocumentContent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DocumentContents] DROP CONSTRAINT [FK_workTaskDocumentContent];
GO
IF OBJECT_ID(N'[dbo].[FK_CustomTableCustomTabData]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CustomTabDatas] DROP CONSTRAINT [FK_CustomTableCustomTabData];
GO
IF OBJECT_ID(N'[dbo].[FK_DocumentManageCustomTabData]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CustomTabDatas] DROP CONSTRAINT [FK_DocumentManageCustomTabData];
GO
IF OBJECT_ID(N'[dbo].[FK_DocLocationDocComent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DocComents] DROP CONSTRAINT [FK_DocLocationDocComent];
GO
IF OBJECT_ID(N'[dbo].[FK_DocLocationDocLocation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DocLocations] DROP CONSTRAINT [FK_DocLocationDocLocation];
GO
IF OBJECT_ID(N'[dbo].[FK_DocReaderDocLocation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DocLocations] DROP CONSTRAINT [FK_DocReaderDocLocation];
GO
IF OBJECT_ID(N'[dbo].[FK_DocSenderDocLocation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DocLocations] DROP CONSTRAINT [FK_DocSenderDocLocation];
GO
IF OBJECT_ID(N'[dbo].[FK_DocumentManageDocLocation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DocLocations] DROP CONSTRAINT [FK_DocumentManageDocLocation];
GO
IF OBJECT_ID(N'[dbo].[FK_WorkSpaceBaseTypeWorkSpaceBaseType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WorkSpaceBaseTypes] DROP CONSTRAINT [FK_WorkSpaceBaseTypeWorkSpaceBaseType];
GO
IF OBJECT_ID(N'[dbo].[FK_DllFileStreamWorkModul]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WorkModuls] DROP CONSTRAINT [FK_DllFileStreamWorkModul];
GO
IF OBJECT_ID(N'[dbo].[FK_WorkSpaceBaseTypeWorkSpaceType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WorkSpaceTypes] DROP CONSTRAINT [FK_WorkSpaceBaseTypeWorkSpaceType];
GO
IF OBJECT_ID(N'[dbo].[FK_WorkSpaceBaseTypeDocumentManage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DocumentManages] DROP CONSTRAINT [FK_WorkSpaceBaseTypeDocumentManage];
GO
IF OBJECT_ID(N'[dbo].[FK_DocManageStateDocumentManage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DocumentManages] DROP CONSTRAINT [FK_DocManageStateDocumentManage];
GO
IF OBJECT_ID(N'[dbo].[FK_OpenEventEventTime]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OperationDetails] DROP CONSTRAINT [FK_OpenEventEventTime];
GO
IF OBJECT_ID(N'[dbo].[FK_LoginLogOpenEvent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OperationEvents] DROP CONSTRAINT [FK_LoginLogOpenEvent];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupMemberGroupMessager]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[sys_GroupMessager] DROP CONSTRAINT [FK_GroupMemberGroupMessager];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupGroupMember]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[sys_GroupMember] DROP CONSTRAINT [FK_GroupGroupMember];
GO
IF OBJECT_ID(N'[dbo].[FK_EmployeePost]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[sys_Post] DROP CONSTRAINT [FK_EmployeePost];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupGroupMessager]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[sys_GroupMessager] DROP CONSTRAINT [FK_GroupGroupMessager];
GO
IF OBJECT_ID(N'[dbo].[FK_UserCustomGroupUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[sys_CustomGroupUser] DROP CONSTRAINT [FK_UserCustomGroupUser];
GO
IF OBJECT_ID(N'[dbo].[FK_CustomGroupCustomGroupUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[sys_CustomGroupUser] DROP CONSTRAINT [FK_CustomGroupCustomGroupUser];
GO
IF OBJECT_ID(N'[dbo].[FK_OrganizationOrgManager]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[sys_OrgManagers] DROP CONSTRAINT [FK_OrganizationOrgManager];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[sys_Organization]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sys_Organization];
GO
IF OBJECT_ID(N'[dbo].[Organization_ContactTables]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Organization_ContactTables];
GO
IF OBJECT_ID(N'[dbo].[sys_Position]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sys_Position];
GO
IF OBJECT_ID(N'[dbo].[sys_User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sys_User];
GO
IF OBJECT_ID(N'[dbo].[User_ContactTable]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User_ContactTable];
GO
IF OBJECT_ID(N'[dbo].[LoginLogs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LoginLogs];
GO
IF OBJECT_ID(N'[dbo].[OrganizationTransitions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrganizationTransitions];
GO
IF OBJECT_ID(N'[dbo].[Organization_Type]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Organization_Type];
GO
IF OBJECT_ID(N'[dbo].[DocumentManages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DocumentManages];
GO
IF OBJECT_ID(N'[dbo].[sys_UserMessage]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sys_UserMessage];
GO
IF OBJECT_ID(N'[dbo].[sys_GroupMember]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sys_GroupMember];
GO
IF OBJECT_ID(N'[dbo].[OrganizationOtherNames]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrganizationOtherNames];
GO
IF OBJECT_ID(N'[dbo].[Administrativecodes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Administrativecodes];
GO
IF OBJECT_ID(N'[dbo].[DocumentTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DocumentTypes];
GO
IF OBJECT_ID(N'[dbo].[DocManageStates]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DocManageStates];
GO
IF OBJECT_ID(N'[dbo].[BussnessVers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BussnessVers];
GO
IF OBJECT_ID(N'[dbo].[ProductStandards]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductStandards];
GO
IF OBJECT_ID(N'[dbo].[IndustryCodes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[IndustryCodes];
GO
IF OBJECT_ID(N'[dbo].[ZipCodes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ZipCodes];
GO
IF OBJECT_ID(N'[dbo].[IPCodes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[IPCodes];
GO
IF OBJECT_ID(N'[dbo].[OrganizBasics]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrganizBasics];
GO
IF OBJECT_ID(N'[dbo].[PostRequires]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PostRequires];
GO
IF OBJECT_ID(N'[dbo].[sys_Post]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sys_Post];
GO
IF OBJECT_ID(N'[dbo].[WorkSpaces]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WorkSpaces];
GO
IF OBJECT_ID(N'[dbo].[Subordinates]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Subordinates];
GO
IF OBJECT_ID(N'[dbo].[Specializeds]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Specializeds];
GO
IF OBJECT_ID(N'[dbo].[UserRelateTables]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserRelateTables];
GO
IF OBJECT_ID(N'[dbo].[UserRelateTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserRelateTypes];
GO
IF OBJECT_ID(N'[dbo].[DocumentContents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DocumentContents];
GO
IF OBJECT_ID(N'[dbo].[DocCheckStates]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DocCheckStates];
GO
IF OBJECT_ID(N'[dbo].[Securityinfoes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Securityinfoes];
GO
IF OBJECT_ID(N'[dbo].[OrganicInvestors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrganicInvestors];
GO
IF OBJECT_ID(N'[dbo].[OrgaRegisterDocments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrgaRegisterDocments];
GO
IF OBJECT_ID(N'[dbo].[RegisterDocumentTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RegisterDocumentTypes];
GO
IF OBJECT_ID(N'[dbo].[OrganizationEvents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrganizationEvents];
GO
IF OBJECT_ID(N'[dbo].[sys_GroupMessager]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sys_GroupMessager];
GO
IF OBJECT_ID(N'[dbo].[sys_Group]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sys_Group];
GO
IF OBJECT_ID(N'[dbo].[sys_CustomerGoup]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sys_CustomerGoup];
GO
IF OBJECT_ID(N'[dbo].[DllFileStreams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DllFileStreams];
GO
IF OBJECT_ID(N'[dbo].[OrganizationCustomTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrganizationCustomTypes];
GO
IF OBJECT_ID(N'[dbo].[CustomCategories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CustomCategories];
GO
IF OBJECT_ID(N'[dbo].[Products]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Products];
GO
IF OBJECT_ID(N'[dbo].[ProductEvents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductEvents];
GO
IF OBJECT_ID(N'[dbo].[ProductCompositions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductCompositions];
GO
IF OBJECT_ID(N'[dbo].[ProductCustomTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductCustomTypes];
GO
IF OBJECT_ID(N'[dbo].[ProductCustomCategories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductCustomCategories];
GO
IF OBJECT_ID(N'[dbo].[physicalAssets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[physicalAssets];
GO
IF OBJECT_ID(N'[dbo].[AssetUses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AssetUses];
GO
IF OBJECT_ID(N'[dbo].[AssetMaintenances]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AssetMaintenances];
GO
IF OBJECT_ID(N'[dbo].[AssetBaseTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AssetBaseTypes];
GO
IF OBJECT_ID(N'[dbo].[OrganizationAssetTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrganizationAssetTypes];
GO
IF OBJECT_ID(N'[dbo].[sys_Employee]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sys_Employee];
GO
IF OBJECT_ID(N'[dbo].[IndustrySolutions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[IndustrySolutions];
GO
IF OBJECT_ID(N'[dbo].[WorkModuls]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WorkModuls];
GO
IF OBJECT_ID(N'[dbo].[WorkSpaceRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WorkSpaceRoles];
GO
IF OBJECT_ID(N'[dbo].[Authorizations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Authorizations];
GO
IF OBJECT_ID(N'[dbo].[ModulProperties]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ModulProperties];
GO
IF OBJECT_ID(N'[dbo].[WorkMessages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WorkMessages];
GO
IF OBJECT_ID(N'[dbo].[DocTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DocTypes];
GO
IF OBJECT_ID(N'[dbo].[DocReaders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DocReaders];
GO
IF OBJECT_ID(N'[dbo].[DocSenders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DocSenders];
GO
IF OBJECT_ID(N'[dbo].[DocComents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DocComents];
GO
IF OBJECT_ID(N'[dbo].[JobChanges]', 'U') IS NOT NULL
    DROP TABLE [dbo].[JobChanges];
GO
IF OBJECT_ID(N'[dbo].[WorkSpaceTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WorkSpaceTypes];
GO
IF OBJECT_ID(N'[dbo].[workTasks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[workTasks];
GO
IF OBJECT_ID(N'[dbo].[CustomTables]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CustomTables];
GO
IF OBJECT_ID(N'[dbo].[CustomTabDatas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CustomTabDatas];
GO
IF OBJECT_ID(N'[dbo].[DocLocations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DocLocations];
GO
IF OBJECT_ID(N'[dbo].[WorkSpaceBaseTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WorkSpaceBaseTypes];
GO
IF OBJECT_ID(N'[dbo].[OperationDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OperationDetails];
GO
IF OBJECT_ID(N'[dbo].[OperationEvents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OperationEvents];
GO
IF OBJECT_ID(N'[dbo].[sys_CustomGroupUser]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sys_CustomGroupUser];
GO
IF OBJECT_ID(N'[dbo].[sys_OrgManagers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sys_OrgManagers];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'sys_Organization'
CREATE TABLE [dbo].[sys_Organization] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [OrganizationCode] nvarchar(max)  NULL,
    [OrgaName] nvarchar(max)  NOT NULL,
    [Certificates] nvarchar(max)  NULL,
    [ParentId] int  NULL,
    [MarkerString] nvarchar(max)  NULL,
    [Type] nvarchar(max)  NOT NULL,
    [RootId] int  NULL,
    [IsRoot] bit  NOT NULL,
    [IsDeleted] bit  NOT NULL,
    [Notes] nvarchar(max)  NOT NULL,
    [State] nvarchar(max)  NOT NULL,
    [CreateUserId] int  NULL,
    [CreateTime] datetime  NULL,
    [UpdateUserId] int  NULL,
    [UpdateTime] datetime  NULL
);
GO

-- Creating table 'Organization_ContactTables'
CREATE TABLE [dbo].[Organization_ContactTables] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [OrganizBasicID] int  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Tools] nvarchar(max)  NULL,
    [Value] nvarchar(max)  NULL,
    [IsValid] bit  NOT NULL,
    [EventTime] bigint  NOT NULL
);
GO

-- Creating table 'sys_Position'
CREATE TABLE [dbo].[sys_Position] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PositionType] nvarchar(max)  NULL,
    [Name] nvarchar(max)  NULL,
    [TaskNature] nvarchar(max)  NULL,
    [PositionID] int  NULL,
    [OrganizationID] int  NOT NULL,
    [PostRequireID] int  NULL,
    [PositionLevel] int  NOT NULL,
    [IsDeleted] nvarchar(max)  NOT NULL,
    [State] nvarchar(max)  NOT NULL,
    [Notes] nvarchar(max)  NOT NULL,
    [CreateUserId] int  NULL,
    [CreateTime] datetime  NULL,
    [UpdateUserId] int  NULL,
    [UpdateTime] datetime  NULL
);
GO

-- Creating table 'sys_User'
CREATE TABLE [dbo].[sys_User] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(50)  NOT NULL,
    [Password] nvarchar(50)  NOT NULL,
    [ActualName] nvarchar(50)  NULL,
    [LimitTime] datetime  NOT NULL,
    [Domain] nvarchar(max)  NOT NULL,
    [DomainId] nvarchar(max)  NOT NULL,
    [State] int  NOT NULL,
    [Notes] nvarchar(max)  NOT NULL,
    [CreateTime] datetime  NULL,
    [CreateUserId] int  NULL,
    [UpdateTime] datetime  NULL,
    [UpdateUserId] int  NULL,
    [IsDeleted] bit  NOT NULL
);
GO

-- Creating table 'User_ContactTable'
CREATE TABLE [dbo].[User_ContactTable] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Tools] nvarchar(max)  NOT NULL,
    [Value] nvarchar(max)  NOT NULL,
    [UserID] int  NULL,
    [EventTime] bigint  NOT NULL
);
GO

-- Creating table 'LoginLogs'
CREATE TABLE [dbo].[LoginLogs] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [LoginIP] nvarchar(max)  NOT NULL,
    [LoginTime] nvarchar(max)  NOT NULL,
    [LogoutTime] nvarchar(max)  NOT NULL,
    [UserID] int  NULL,
    [CurrentSate] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'OrganizationTransitions'
CREATE TABLE [dbo].[OrganizationTransitions] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Cause] nvarchar(max)  NOT NULL,
    [FundAlteration] nvarchar(max)  NOT NULL,
    [PropertyAlteration] nvarchar(max)  NOT NULL,
    [Time] datetime  NOT NULL,
    [Others] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [OldOrgan] int  NULL,
    [NewOrgan] int  NULL
);
GO

-- Creating table 'Organization_Type'
CREATE TABLE [dbo].[Organization_Type] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Ocode] nvarchar(max)  NOT NULL,
    [OName] nvarchar(max)  NOT NULL,
    [Descript] nvarchar(max)  NULL,
    [ParentCode] nvarchar(max)  NULL,
    [Parent] int  NULL,
    [EventTime] bigint  NOT NULL
);
GO

-- Creating table 'DocumentManages'
CREATE TABLE [dbo].[DocumentManages] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Doctype] nvarchar(max)  NOT NULL,
    [Content] nvarchar(max)  NOT NULL,
    [URL] nvarchar(max)  NOT NULL,
    [FileNumber] nvarchar(max)  NULL,
    [DocCheckStateID] int  NULL,
    [SecurityinfoID] int  NULL,
    [WorkSpaceBaseTypeId] int  NULL,
    [EventTime] bigint  NOT NULL,
    [DocManageStateID] int  NULL
);
GO

-- Creating table 'sys_UserMessage'
CREATE TABLE [dbo].[sys_UserMessage] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FromUserId] int  NULL,
    [ToUserId] int  NULL,
    [MessageType] int  NOT NULL,
    [Content] nvarchar(max)  NULL,
    [State] int  NULL,
    [Notes] nvarchar(max)  NULL,
    [CreateTime] datetime  NULL,
    [CreateUserId] int  NULL,
    [UpdateTime] datetime  NULL,
    [UpdateUserId] nvarchar(max)  NULL,
    [IsDeleted] bit  NOT NULL
);
GO

-- Creating table 'sys_GroupMember'
CREATE TABLE [dbo].[sys_GroupMember] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [GroupId] int  NULL,
    [UserId] int  NULL,
    [Name] nvarchar(50)  NULL,
    [ReferenceUserId] int  NULL,
    [ApproveUserId] int  NULL,
    [GroupRole] nvarchar(max)  NULL,
    [State] int  NULL,
    [Notes] nvarchar(max)  NULL,
    [CreateUserId] int  NULL,
    [CreateTime] datetime  NULL,
    [UpdateTiime] datetime  NULL,
    [UpdateUserId] int  NULL,
    [IsDeleted] bit  NOT NULL
);
GO

-- Creating table 'OrganizationOtherNames'
CREATE TABLE [dbo].[OrganizationOtherNames] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [OtherName] nvarchar(max)  NOT NULL,
    [OrganizationID] int  NOT NULL
);
GO

-- Creating table 'Administrativecodes'
CREATE TABLE [dbo].[Administrativecodes] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [DivisionCode] nvarchar(max)  NOT NULL,
    [RegionName] nvarchar(max)  NOT NULL,
    [ParentCode] nvarchar(max)  NOT NULL,
    [Parent] int  NULL,
    [Geometry] geography  NULL,
    [Vesion] nvarchar(max)  NOT NULL,
    [EventTime] bigint  NOT NULL
);
GO

-- Creating table 'DocumentTypes'
CREATE TABLE [dbo].[DocumentTypes] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [TypeName] nvarchar(max)  NOT NULL,
    [Type] nvarchar(max)  NOT NULL,
    [Note] nvarchar(max)  NOT NULL,
    [DocumentTypeID] int  NULL,
    [OrigId] int  NULL,
    [EventTime] bigint  NOT NULL
);
GO

-- Creating table 'DocManageStates'
CREATE TABLE [dbo].[DocManageStates] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [DState] nvarchar(max)  NOT NULL,
    [DStateName] nvarchar(max)  NOT NULL,
    [DocManageStateID] int  NULL,
    [EventTime] bigint  NOT NULL
);
GO

-- Creating table 'BussnessVers'
CREATE TABLE [dbo].[BussnessVers] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [other] nvarchar(max)  NOT NULL,
    [TimeLineTimeLineID] int  NULL
);
GO

-- Creating table 'ProductStandards'
CREATE TABLE [dbo].[ProductStandards] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ProductCode] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NULL,
    [Descript] nvarchar(max)  NULL,
    [Parent] int  NULL,
    [measureUnit] nvarchar(max)  NULL,
    [ParentCode] nvarchar(max)  NULL,
    [Vesion] nvarchar(max)  NOT NULL,
    [EventTime] bigint  NOT NULL
);
GO

-- Creating table 'IndustryCodes'
CREATE TABLE [dbo].[IndustryCodes] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Code] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NULL,
    [Descript] nvarchar(max)  NULL,
    [Parent] int  NULL,
    [ParentCode] nvarchar(max)  NULL,
    [Vesion] nvarchar(max)  NOT NULL,
    [EventTime] bigint  NOT NULL
);
GO

-- Creating table 'ZipCodes'
CREATE TABLE [dbo].[ZipCodes] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Code] nvarchar(max)  NOT NULL,
    [EventTime] bigint  NOT NULL
);
GO

-- Creating table 'IPCodes'
CREATE TABLE [dbo].[IPCodes] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [IP] nvarchar(max)  NOT NULL,
    [Company] nvarchar(max)  NULL,
    [EventTime] bigint  NOT NULL
);
GO

-- Creating table 'OrganizBasics'
CREATE TABLE [dbo].[OrganizBasics] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [RegistrationNumber] nvarchar(max)  NOT NULL,
    [Domicile] nvarchar(max)  NOT NULL,
    [LegaPersonID] int  NULL,
    [BussinessAddress] nvarchar(max)  NOT NULL,
    [BussinessAddressDetail] nvarchar(max)  NOT NULL,
    [RegisteredCapital] nvarchar(max)  NULL,
    [BusinessScope] nvarchar(max)  NULL,
    [BussinessModel] nvarchar(max)  NULL,
    [SubordinateID] int  NULL,
    [Organization_TypeID] int  NOT NULL,
    [SupervisorSection] nvarchar(max)  NULL,
    [OperatingPeriod] nvarchar(max)  NULL,
    [ApprovalDate] datetime  NULL,
    [OtherInfo] nvarchar(max)  NULL,
    [OverrideParent] int  NULL,
    [OrganizationID] int  NOT NULL,
    [IndustryCodeID] int  NOT NULL,
    [AdministrativecodeSacID] int  NOT NULL,
    [IsValid] bit  NOT NULL,
    [EventTime] bigint  NOT NULL
);
GO

-- Creating table 'PostRequires'
CREATE TABLE [dbo].[PostRequires] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [SpecializedID] int  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Ranks] nvarchar(max)  NOT NULL,
    [EducationRequirement] nvarchar(max)  NOT NULL,
    [SkillRequirement] nvarchar(max)  NOT NULL,
    [State] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'sys_Post'
CREATE TABLE [dbo].[sys_Post] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [PostName] nvarchar(max)  NOT NULL,
    [MarkerString] nvarchar(max)  NULL,
    [Descript] nvarchar(max)  NULL,
    [PostID] int  NULL,
    [OrganizationID] int  NOT NULL,
    [EmployeeId] int  NULL,
    [PositionID] int  NULL,
    [IsDeleted] nvarchar(max)  NOT NULL,
    [Notes] nvarchar(max)  NOT NULL,
    [State] nvarchar(max)  NOT NULL,
    [CreateUserId] int  NULL,
    [CreateTime] datetime  NULL,
    [UpdateUserId] int  NULL,
    [UpdateTime] datetime  NULL
);
GO

-- Creating table 'WorkSpaces'
CREATE TABLE [dbo].[WorkSpaces] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Content] nvarchar(max)  NOT NULL,
    [MarkerString] nvarchar(max)  NULL,
    [Comment] nvarchar(max)  NULL,
    [IsValid] bit  NOT NULL,
    [Descript] nvarchar(max)  NULL,
    [IndustrySolutionId] int  NULL,
    [WorkSpaceID] int  NULL,
    [WorkModulId] int  NULL,
    [EventTime] bigint  NOT NULL
);
GO

-- Creating table 'Subordinates'
CREATE TABLE [dbo].[Subordinates] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Code] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Descript] nvarchar(max)  NULL,
    [EventTime] bigint  NOT NULL
);
GO

-- Creating table 'Specializeds'
CREATE TABLE [dbo].[Specializeds] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Code] nvarchar(max)  NOT NULL,
    [SpecialName] nvarchar(max)  NOT NULL,
    [Descript] nvarchar(max)  NULL,
    [ParentCode] nvarchar(max)  NULL,
    [Parent] int  NULL
);
GO

-- Creating table 'UserRelateTables'
CREATE TABLE [dbo].[UserRelateTables] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [UserID] int  NOT NULL,
    [UserID1] int  NOT NULL,
    [UserRelateTypeID] int  NOT NULL,
    [RelateObject] nvarchar(max)  NOT NULL,
    [Notes] nvarchar(max)  NOT NULL,
    [EventTime] bigint  NOT NULL
);
GO

-- Creating table 'UserRelateTypes'
CREATE TABLE [dbo].[UserRelateTypes] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Descript] nvarchar(max)  NULL,
    [Parent] int  NULL,
    [EventTime] bigint  NOT NULL
);
GO

-- Creating table 'DocumentContents'
CREATE TABLE [dbo].[DocumentContents] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Content] nvarchar(max)  NOT NULL,
    [Message] nvarchar(max)  NOT NULL,
    [DocumentManageID] int  NULL,
    [DocumentContentID] int  NULL,
    [workTaskId] int  NULL,
    [EventTime] bigint  NOT NULL
);
GO

-- Creating table 'DocCheckStates'
CREATE TABLE [dbo].[DocCheckStates] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Post] nvarchar(max)  NOT NULL,
    [UserName] nvarchar(max)  NOT NULL,
    [CheckState] bit  NOT NULL,
    [CheckTime] datetime  NULL,
    [EventTime] bigint  NOT NULL
);
GO

-- Creating table 'Securityinfoes'
CREATE TABLE [dbo].[Securityinfoes] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [SecurityName] nvarchar(max)  NOT NULL,
    [Level] int  NOT NULL,
    [Descript] nvarchar(max)  NULL,
    [SecurityinfoID] int  NULL,
    [EventTime] bigint  NOT NULL
);
GO

-- Creating table 'OrganicInvestors'
CREATE TABLE [dbo].[OrganicInvestors] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Investor] int  NULL,
    [InvestorName] nvarchar(max)  NOT NULL,
    [InvestorNumber] int  NOT NULL,
    [CentisifierType] nvarchar(max)  NOT NULL,
    [OrganizBasicID] int  NOT NULL,
    [Amount] decimal(18,0)  NOT NULL,
    [Unit] nvarchar(max)  NOT NULL,
    [Currency] nvarchar(max)  NOT NULL,
    [EventTime] bigint  NOT NULL
);
GO

-- Creating table 'OrgaRegisterDocments'
CREATE TABLE [dbo].[OrgaRegisterDocments] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [OrganizBasicID] int  NOT NULL,
    [DocumentName] nvarchar(max)  NOT NULL,
    [RegisterDocumentTypeID] int  NOT NULL,
    [DocmentContent] varbinary(max)  NULL,
    [DocumentFormat] nvarchar(max)  NULL,
    [RecordeTime] datetime  NOT NULL,
    [EventTime] bigint  NOT NULL,
    [EventTime1] bigint  NOT NULL
);
GO

-- Creating table 'RegisterDocumentTypes'
CREATE TABLE [dbo].[RegisterDocumentTypes] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [TypeName] nvarchar(max)  NOT NULL,
    [EventTime] bigint  NOT NULL,
    [EventTime1] bigint  NOT NULL,
    [EventTime2] bigint  NOT NULL
);
GO

-- Creating table 'OrganizationEvents'
CREATE TABLE [dbo].[OrganizationEvents] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [OrganizationID] int  NOT NULL,
    [EventName] nvarchar(max)  NOT NULL,
    [EventContent] nvarchar(max)  NOT NULL,
    [EventType] nvarchar(max)  NOT NULL,
    [HanderSection] nvarchar(max)  NOT NULL,
    [Hander] nvarchar(max)  NOT NULL,
    [Result] nvarchar(max)  NOT NULL,
    [EventState] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'sys_GroupMessager'
CREATE TABLE [dbo].[sys_GroupMessager] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [GroupId] int  NULL,
    [GroupMemberId] int  NULL,
    [MessageType] int  NULL,
    [Content] nvarchar(max)  NULL,
    [Notes] nvarchar(max)  NULL,
    [CrateTime] datetime  NULL,
    [CrateUseId] int  NULL,
    [UpdateTime] datetime  NULL,
    [UpdateUserId] int  NULL,
    [IsDeleted] bit  NOT NULL
);
GO

-- Creating table 'sys_Group'
CREATE TABLE [dbo].[sys_Group] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NULL,
    [GroupNo] nvarchar(max)  NULL,
    [Name] nvarchar(50)  NULL,
    [Category] nvarchar(50)  NULL,
    [ValidattionPattern] int  NULL,
    [State] smallint  NULL,
    [Notes] nvarchar(max)  NULL,
    [CreatTime] datetime  NULL,
    [CreateUserId] int  NULL,
    [UpdateTime] datetime  NULL,
    [UpdateUserId] int  NULL,
    [IsDeleted] bit  NOT NULL
);
GO

-- Creating table 'sys_CustomerGoup'
CREATE TABLE [dbo].[sys_CustomerGoup] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [GroupName] nvarchar(max)  NULL,
    [Notes] nvarchar(max)  NULL,
    [CreatTime] datetime  NULL,
    [CreateUserId] int  NULL,
    [UpdateTime] datetime  NULL,
    [UpdateUserId] int  NULL,
    [IsDeleted] bit  NOT NULL
);
GO

-- Creating table 'DllFileStreams'
CREATE TABLE [dbo].[DllFileStreams] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [IndustrySolutionId] int  NULL,
    [DllFileStreamID] int  NULL,
    [Model] nvarchar(max)  NOT NULL,
    [DllfileStream] varbinary(max)  NOT NULL,
    [FileName] nvarchar(max)  NOT NULL,
    [MainWindowName] bit  NULL,
    [Txt2] nvarchar(max)  NULL,
    [URI] nvarchar(max)  NOT NULL,
    [Paragram] nvarchar(max)  NOT NULL,
    [EventTime] bigint  NOT NULL
);
GO

-- Creating table 'OrganizationCustomTypes'
CREATE TABLE [dbo].[OrganizationCustomTypes] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [OrganizationID] int  NOT NULL,
    [CustomCategoryID] int  NOT NULL,
    [Note] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CustomCategories'
CREATE TABLE [dbo].[CustomCategories] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [CategoryName] nvarchar(max)  NOT NULL,
    [content] nvarchar(max)  NOT NULL,
    [CustomCategoryID] int  NULL
);
GO

-- Creating table 'Products'
CREATE TABLE [dbo].[Products] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProductStandardID] int  NOT NULL,
    [Pname] nvarchar(max)  NOT NULL,
    [PModel] nvarchar(max)  NOT NULL,
    [Units] nvarchar(max)  NOT NULL,
    [SCode] nvarchar(max)  NULL,
    [FCode] nvarchar(max)  NULL,
    [PCode] nvarchar(max)  NULL,
    [OrganizBasicID] int  NULL,
    [OrganizationID] int  NULL,
    [EventTime] bigint  NOT NULL
);
GO

-- Creating table 'ProductEvents'
CREATE TABLE [dbo].[ProductEvents] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [EventName] nvarchar(max)  NOT NULL,
    [Content] nvarchar(max)  NOT NULL,
    [EventTime] datetime  NOT NULL,
    [ProductId] int  NOT NULL,
    [Creater] int  NOT NULL,
    [EventTime1] bigint  NOT NULL
);
GO

-- Creating table 'ProductCompositions'
CREATE TABLE [dbo].[ProductCompositions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ChildProductId] int  NOT NULL,
    [Function] nvarchar(max)  NOT NULL,
    [descript] nvarchar(max)  NOT NULL,
    [Value] nvarchar(max)  NOT NULL,
    [ProductCompositionId] int  NOT NULL,
    [EventTime] bigint  NOT NULL
);
GO

-- Creating table 'ProductCustomTypes'
CREATE TABLE [dbo].[ProductCustomTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProductId] int  NOT NULL,
    [ProductCustomCategoryId] int  NOT NULL,
    [Descript] nvarchar(max)  NULL,
    [EventTime] bigint  NOT NULL
);
GO

-- Creating table 'ProductCustomCategories'
CREATE TABLE [dbo].[ProductCustomCategories] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CategoryName] nvarchar(max)  NOT NULL,
    [Content] nvarchar(max)  NULL,
    [ProductCustomCategoryId] int  NOT NULL
);
GO

-- Creating table 'physicalAssets'
CREATE TABLE [dbo].[physicalAssets] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [OrganizationID] int  NOT NULL,
    [ProductId] int  NOT NULL,
    [PlaceOfBuy] nvarchar(max)  NOT NULL,
    [BuyTime] nvarchar(max)  NOT NULL,
    [Supplier] int  NULL,
    [Validity] nvarchar(max)  NOT NULL,
    [State] nvarchar(max)  NULL,
    [Value] decimal(18,0)  NOT NULL,
    [MaintenancePeriod] datetimeoffset  NULL,
    [EventTime] bigint  NOT NULL
);
GO

-- Creating table 'AssetUses'
CREATE TABLE [dbo].[AssetUses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [physicalAssetId] int  NOT NULL,
    [UseType] nvarchar(max)  NOT NULL,
    [User] nvarchar(max)  NOT NULL,
    [UseTime] nvarchar(max)  NOT NULL,
    [PlaceOfUse] nvarchar(max)  NULL,
    [EventTime] bigint  NOT NULL
);
GO

-- Creating table 'AssetMaintenances'
CREATE TABLE [dbo].[AssetMaintenances] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [physicalAssetId] int  NOT NULL,
    [Maintenancer] int  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Experience] nvarchar(max)  NULL,
    [EventTime] bigint  NOT NULL
);
GO

-- Creating table 'AssetBaseTypes'
CREATE TABLE [dbo].[AssetBaseTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TypeName] nvarchar(max)  NOT NULL,
    [Note] nvarchar(max)  NULL,
    [OrganizationID] int  NOT NULL,
    [AssetTypeId] int  NULL,
    [EventTime] bigint  NOT NULL
);
GO

-- Creating table 'OrganizationAssetTypes'
CREATE TABLE [dbo].[OrganizationAssetTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Note] nvarchar(max)  NOT NULL,
    [physicalAssetId] int  NULL,
    [AssetBaseTypeId] int  NOT NULL,
    [EventTime] bigint  NOT NULL
);
GO

-- Creating table 'sys_Employee'
CREATE TABLE [dbo].[sys_Employee] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [StartTime] datetime  NOT NULL,
    [EndTime] datetime  NOT NULL,
    [EmpCode] nvarchar(max)  NOT NULL,
    [UserID] int  NOT NULL,
    [PositionID] int  NULL,
    [OrganizationID] int  NULL,
    [IsChief] nvarchar(max)  NOT NULL,
    [IsDeleted] bit  NOT NULL,
    [State] nvarchar(max)  NOT NULL,
    [Notes] nvarchar(max)  NOT NULL,
    [CreateUserId] int  NULL,
    [CreateTime] datetime  NULL,
    [UpdateUserId] int  NULL,
    [UpdateTime] datetime  NULL
);
GO

-- Creating table 'IndustrySolutions'
CREATE TABLE [dbo].[IndustrySolutions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IndustryCodeID] int  NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Content] nvarchar(max)  NOT NULL,
    [Note] nvarchar(max)  NOT NULL,
    [EventTime] bigint  NOT NULL
);
GO

-- Creating table 'WorkModuls'
CREATE TABLE [dbo].[WorkModuls] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FunctionGroupID] int  NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Content] nvarchar(max)  NOT NULL,
    [ActivityType] nvarchar(max)  NOT NULL,
    [WorkModulId] int  NULL,
    [DllFileStreamID] int  NULL,
    [EventTime] bigint  NOT NULL
);
GO

-- Creating table 'WorkSpaceRoles'
CREATE TABLE [dbo].[WorkSpaceRoles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Type] nvarchar(max)  NOT NULL,
    [WorkSpaceID] int  NOT NULL,
    [OrganizationID] int  NOT NULL,
    [Descript] nvarchar(max)  NOT NULL,
    [WorkModulId] int  NULL,
    [UserID] int  NULL
);
GO

-- Creating table 'Authorizations'
CREATE TABLE [dbo].[Authorizations] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PostID] int  NULL,
    [PropertyValue] nvarchar(max)  NOT NULL,
    [PostRelation] nvarchar(max)  NOT NULL,
    [PostID1] int  NULL,
    [ModulPropertyId] int  NULL,
    [UserID] int  NULL,
    [UserID1] int  NULL,
    [EventTime] bigint  NOT NULL
);
GO

-- Creating table 'ModulProperties'
CREATE TABLE [dbo].[ModulProperties] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [WorkModulId] int  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Type] nvarchar(max)  NOT NULL,
    [Descript] nvarchar(max)  NOT NULL,
    [EventTime] bigint  NOT NULL
);
GO

-- Creating table 'WorkMessages'
CREATE TABLE [dbo].[WorkMessages] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AuthorizationId] int  NOT NULL,
    [Content] nvarchar(max)  NOT NULL,
    [Environment] nvarchar(max)  NOT NULL,
    [State] nvarchar(max)  NOT NULL,
    [Request] nvarchar(max)  NOT NULL,
    [Repose] nvarchar(max)  NOT NULL,
    [EventTime] bigint  NOT NULL
);
GO

-- Creating table 'DocTypes'
CREATE TABLE [dbo].[DocTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DocumentTypeID] int  NULL,
    [DocumentManageID] int  NULL
);
GO

-- Creating table 'DocReaders'
CREATE TABLE [dbo].[DocReaders] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [WorkSpaceID] int  NULL,
    [OrganizationID] int  NULL,
    [PostID] int  NULL,
    [UserID] int  NULL,
    [EventTime] bigint  NOT NULL
);
GO

-- Creating table 'DocSenders'
CREATE TABLE [dbo].[DocSenders] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserID] int  NULL,
    [PostID] int  NULL,
    [EventTime] bigint  NOT NULL
);
GO

-- Creating table 'DocComents'
CREATE TABLE [dbo].[DocComents] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DocLocationID] int  NOT NULL,
    [DocSenderId] int  NOT NULL,
    [Remark] nvarchar(max)  NOT NULL,
    [RemarkTime] datetime  NOT NULL,
    [EventTime] bigint  NOT NULL
);
GO

-- Creating table 'JobChanges'
CREATE TABLE [dbo].[JobChanges] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ChangeType] nvarchar(max)  NOT NULL,
    [Content] nvarchar(max)  NOT NULL,
    [State] bit  NOT NULL,
    [StartTime] datetime  NOT NULL,
    [PostID] int  NULL,
    [Creater] nvarchar(max)  NOT NULL,
    [EventTime] bigint  NOT NULL
);
GO

-- Creating table 'WorkSpaceTypes'
CREATE TABLE [dbo].[WorkSpaceTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ByProperty] nvarchar(max)  NOT NULL,
    [WorkSpaceID] int  NULL,
    [WorkSpaceBaseTypeId] int  NULL,
    [EventTime] bigint  NOT NULL
);
GO

-- Creating table 'workTasks'
CREATE TABLE [dbo].[workTasks] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(max)  NOT NULL,
    [Content] nvarchar(max)  NOT NULL,
    [BegeinTime] nvarchar(max)  NOT NULL,
    [EndTime] nvarchar(max)  NOT NULL,
    [State] nvarchar(max)  NOT NULL,
    [DocumentManageID] int  NULL,
    [workTaskId] int  NULL
);
GO

-- Creating table 'CustomTables'
CREATE TABLE [dbo].[CustomTables] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ColumnName] nvarchar(max)  NOT NULL,
    [DataType] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CustomTabDatas'
CREATE TABLE [dbo].[CustomTabDatas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Data] nvarchar(max)  NOT NULL,
    [CustomTableId] int  NOT NULL,
    [DocumentManageID] int  NULL
);
GO

-- Creating table 'DocLocations'
CREATE TABLE [dbo].[DocLocations] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [VisualScope] nvarchar(max)  NULL,
    [DocReaderId] int  NOT NULL,
    [DocSenderId] int  NULL,
    [IsRuleTransaction] bit  NOT NULL,
    [DocLocationID] int  NULL,
    [DocumentManageID] int  NULL,
    [EventTime] bigint  NOT NULL
);
GO

-- Creating table 'WorkSpaceBaseTypes'
CREATE TABLE [dbo].[WorkSpaceBaseTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Note] nvarchar(max)  NOT NULL,
    [WorkSpaceBaseTypeId] int  NULL,
    [EventTime] bigint  NOT NULL
);
GO

-- Creating table 'OperationDetails'
CREATE TABLE [dbo].[OperationDetails] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TabName] nvarchar(max)  NOT NULL,
    [TabRecordId] nvarchar(max)  NOT NULL,
    [HandleType] nvarchar(max)  NOT NULL,
    [OpenEventId] int  NULL,
    [Note] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'OperationEvents'
CREATE TABLE [dbo].[OperationEvents] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [OperType] nvarchar(max)  NOT NULL,
    [OperName] nvarchar(max)  NOT NULL,
    [OperModul] nvarchar(max)  NOT NULL,
    [OperTime] nvarchar(max)  NOT NULL,
    [OperSpace] nvarchar(max)  NOT NULL,
    [Note] nvarchar(max)  NOT NULL,
    [LoginLogID] int  NULL
);
GO

-- Creating table 'sys_CustomGroupUser'
CREATE TABLE [dbo].[sys_CustomGroupUser] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [GroupId] int  NULL,
    [UserId] int  NULL,
    [Notes] nvarchar(max)  NULL,
    [CreateTime] datetime  NULL,
    [CreateUserId] int  NULL,
    [UpdateTime] datetime  NULL,
    [UpdateUserId] int  NULL,
    [IsDeleted] bit  NOT NULL
);
GO

-- Creating table 'sys_OrgManagers'
CREATE TABLE [dbo].[sys_OrgManagers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [IsDeleted] bit  NOT NULL,
    [Notes] nvarchar(max)  NOT NULL,
    [State] nvarchar(max)  NOT NULL,
    [CrateUserId] int  NULL,
    [CreateTime] datetime  NULL,
    [UpdateUserId] int  NULL,
    [UpdateTime] datetime  NULL,
    [OrganizationId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'sys_Organization'
ALTER TABLE [dbo].[sys_Organization]
ADD CONSTRAINT [PK_sys_Organization]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [ID] in table 'Organization_ContactTables'
ALTER TABLE [dbo].[Organization_ContactTables]
ADD CONSTRAINT [PK_Organization_ContactTables]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [Id] in table 'sys_Position'
ALTER TABLE [dbo].[sys_Position]
ADD CONSTRAINT [PK_sys_Position]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [ID] in table 'sys_User'
ALTER TABLE [dbo].[sys_User]
ADD CONSTRAINT [PK_sys_User]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'User_ContactTable'
ALTER TABLE [dbo].[User_ContactTable]
ADD CONSTRAINT [PK_User_ContactTable]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'LoginLogs'
ALTER TABLE [dbo].[LoginLogs]
ADD CONSTRAINT [PK_LoginLogs]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'OrganizationTransitions'
ALTER TABLE [dbo].[OrganizationTransitions]
ADD CONSTRAINT [PK_OrganizationTransitions]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Organization_Type'
ALTER TABLE [dbo].[Organization_Type]
ADD CONSTRAINT [PK_Organization_Type]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'DocumentManages'
ALTER TABLE [dbo].[DocumentManages]
ADD CONSTRAINT [PK_DocumentManages]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [Id] in table 'sys_UserMessage'
ALTER TABLE [dbo].[sys_UserMessage]
ADD CONSTRAINT [PK_sys_UserMessage]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'sys_GroupMember'
ALTER TABLE [dbo].[sys_GroupMember]
ADD CONSTRAINT [PK_sys_GroupMember]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [ID] in table 'OrganizationOtherNames'
ALTER TABLE [dbo].[OrganizationOtherNames]
ADD CONSTRAINT [PK_OrganizationOtherNames]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Administrativecodes'
ALTER TABLE [dbo].[Administrativecodes]
ADD CONSTRAINT [PK_Administrativecodes]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'DocumentTypes'
ALTER TABLE [dbo].[DocumentTypes]
ADD CONSTRAINT [PK_DocumentTypes]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'DocManageStates'
ALTER TABLE [dbo].[DocManageStates]
ADD CONSTRAINT [PK_DocManageStates]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'BussnessVers'
ALTER TABLE [dbo].[BussnessVers]
ADD CONSTRAINT [PK_BussnessVers]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'ProductStandards'
ALTER TABLE [dbo].[ProductStandards]
ADD CONSTRAINT [PK_ProductStandards]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'IndustryCodes'
ALTER TABLE [dbo].[IndustryCodes]
ADD CONSTRAINT [PK_IndustryCodes]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'ZipCodes'
ALTER TABLE [dbo].[ZipCodes]
ADD CONSTRAINT [PK_ZipCodes]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'IPCodes'
ALTER TABLE [dbo].[IPCodes]
ADD CONSTRAINT [PK_IPCodes]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'OrganizBasics'
ALTER TABLE [dbo].[OrganizBasics]
ADD CONSTRAINT [PK_OrganizBasics]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'PostRequires'
ALTER TABLE [dbo].[PostRequires]
ADD CONSTRAINT [PK_PostRequires]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'sys_Post'
ALTER TABLE [dbo].[sys_Post]
ADD CONSTRAINT [PK_sys_Post]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'WorkSpaces'
ALTER TABLE [dbo].[WorkSpaces]
ADD CONSTRAINT [PK_WorkSpaces]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Subordinates'
ALTER TABLE [dbo].[Subordinates]
ADD CONSTRAINT [PK_Subordinates]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Specializeds'
ALTER TABLE [dbo].[Specializeds]
ADD CONSTRAINT [PK_Specializeds]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'UserRelateTables'
ALTER TABLE [dbo].[UserRelateTables]
ADD CONSTRAINT [PK_UserRelateTables]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'UserRelateTypes'
ALTER TABLE [dbo].[UserRelateTypes]
ADD CONSTRAINT [PK_UserRelateTypes]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'DocumentContents'
ALTER TABLE [dbo].[DocumentContents]
ADD CONSTRAINT [PK_DocumentContents]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'DocCheckStates'
ALTER TABLE [dbo].[DocCheckStates]
ADD CONSTRAINT [PK_DocCheckStates]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Securityinfoes'
ALTER TABLE [dbo].[Securityinfoes]
ADD CONSTRAINT [PK_Securityinfoes]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'OrganicInvestors'
ALTER TABLE [dbo].[OrganicInvestors]
ADD CONSTRAINT [PK_OrganicInvestors]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'OrgaRegisterDocments'
ALTER TABLE [dbo].[OrgaRegisterDocments]
ADD CONSTRAINT [PK_OrgaRegisterDocments]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'RegisterDocumentTypes'
ALTER TABLE [dbo].[RegisterDocumentTypes]
ADD CONSTRAINT [PK_RegisterDocumentTypes]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'OrganizationEvents'
ALTER TABLE [dbo].[OrganizationEvents]
ADD CONSTRAINT [PK_OrganizationEvents]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [Id] in table 'sys_GroupMessager'
ALTER TABLE [dbo].[sys_GroupMessager]
ADD CONSTRAINT [PK_sys_GroupMessager]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'sys_Group'
ALTER TABLE [dbo].[sys_Group]
ADD CONSTRAINT [PK_sys_Group]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'sys_CustomerGoup'
ALTER TABLE [dbo].[sys_CustomerGoup]
ADD CONSTRAINT [PK_sys_CustomerGoup]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [ID] in table 'DllFileStreams'
ALTER TABLE [dbo].[DllFileStreams]
ADD CONSTRAINT [PK_DllFileStreams]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'OrganizationCustomTypes'
ALTER TABLE [dbo].[OrganizationCustomTypes]
ADD CONSTRAINT [PK_OrganizationCustomTypes]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'CustomCategories'
ALTER TABLE [dbo].[CustomCategories]
ADD CONSTRAINT [PK_CustomCategories]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [Id] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [PK_Products]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProductEvents'
ALTER TABLE [dbo].[ProductEvents]
ADD CONSTRAINT [PK_ProductEvents]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProductCompositions'
ALTER TABLE [dbo].[ProductCompositions]
ADD CONSTRAINT [PK_ProductCompositions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProductCustomTypes'
ALTER TABLE [dbo].[ProductCustomTypes]
ADD CONSTRAINT [PK_ProductCustomTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProductCustomCategories'
ALTER TABLE [dbo].[ProductCustomCategories]
ADD CONSTRAINT [PK_ProductCustomCategories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'physicalAssets'
ALTER TABLE [dbo].[physicalAssets]
ADD CONSTRAINT [PK_physicalAssets]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AssetUses'
ALTER TABLE [dbo].[AssetUses]
ADD CONSTRAINT [PK_AssetUses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AssetMaintenances'
ALTER TABLE [dbo].[AssetMaintenances]
ADD CONSTRAINT [PK_AssetMaintenances]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AssetBaseTypes'
ALTER TABLE [dbo].[AssetBaseTypes]
ADD CONSTRAINT [PK_AssetBaseTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OrganizationAssetTypes'
ALTER TABLE [dbo].[OrganizationAssetTypes]
ADD CONSTRAINT [PK_OrganizationAssetTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'sys_Employee'
ALTER TABLE [dbo].[sys_Employee]
ADD CONSTRAINT [PK_sys_Employee]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'IndustrySolutions'
ALTER TABLE [dbo].[IndustrySolutions]
ADD CONSTRAINT [PK_IndustrySolutions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'WorkModuls'
ALTER TABLE [dbo].[WorkModuls]
ADD CONSTRAINT [PK_WorkModuls]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'WorkSpaceRoles'
ALTER TABLE [dbo].[WorkSpaceRoles]
ADD CONSTRAINT [PK_WorkSpaceRoles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Authorizations'
ALTER TABLE [dbo].[Authorizations]
ADD CONSTRAINT [PK_Authorizations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ModulProperties'
ALTER TABLE [dbo].[ModulProperties]
ADD CONSTRAINT [PK_ModulProperties]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'WorkMessages'
ALTER TABLE [dbo].[WorkMessages]
ADD CONSTRAINT [PK_WorkMessages]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DocTypes'
ALTER TABLE [dbo].[DocTypes]
ADD CONSTRAINT [PK_DocTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DocReaders'
ALTER TABLE [dbo].[DocReaders]
ADD CONSTRAINT [PK_DocReaders]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DocSenders'
ALTER TABLE [dbo].[DocSenders]
ADD CONSTRAINT [PK_DocSenders]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DocComents'
ALTER TABLE [dbo].[DocComents]
ADD CONSTRAINT [PK_DocComents]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'JobChanges'
ALTER TABLE [dbo].[JobChanges]
ADD CONSTRAINT [PK_JobChanges]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'WorkSpaceTypes'
ALTER TABLE [dbo].[WorkSpaceTypes]
ADD CONSTRAINT [PK_WorkSpaceTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'workTasks'
ALTER TABLE [dbo].[workTasks]
ADD CONSTRAINT [PK_workTasks]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CustomTables'
ALTER TABLE [dbo].[CustomTables]
ADD CONSTRAINT [PK_CustomTables]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CustomTabDatas'
ALTER TABLE [dbo].[CustomTabDatas]
ADD CONSTRAINT [PK_CustomTabDatas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [ID] in table 'DocLocations'
ALTER TABLE [dbo].[DocLocations]
ADD CONSTRAINT [PK_DocLocations]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [Id] in table 'WorkSpaceBaseTypes'
ALTER TABLE [dbo].[WorkSpaceBaseTypes]
ADD CONSTRAINT [PK_WorkSpaceBaseTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OperationDetails'
ALTER TABLE [dbo].[OperationDetails]
ADD CONSTRAINT [PK_OperationDetails]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OperationEvents'
ALTER TABLE [dbo].[OperationEvents]
ADD CONSTRAINT [PK_OperationEvents]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'sys_CustomGroupUser'
ALTER TABLE [dbo].[sys_CustomGroupUser]
ADD CONSTRAINT [PK_sys_CustomGroupUser]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'sys_OrgManagers'
ALTER TABLE [dbo].[sys_OrgManagers]
ADD CONSTRAINT [PK_sys_OrgManagers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserID] in table 'LoginLogs'
ALTER TABLE [dbo].[LoginLogs]
ADD CONSTRAINT [FK_UserLoginLog]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[sys_User]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserLoginLog'
CREATE INDEX [IX_FK_UserLoginLog]
ON [dbo].[LoginLogs]
    ([UserID]);
GO

-- Creating foreign key on [OrganizationID] in table 'OrganizationOtherNames'
ALTER TABLE [dbo].[OrganizationOtherNames]
ADD CONSTRAINT [FK_OrganizationOrganizationOtherName]
    FOREIGN KEY ([OrganizationID])
    REFERENCES [dbo].[sys_Organization]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrganizationOrganizationOtherName'
CREATE INDEX [IX_FK_OrganizationOrganizationOtherName]
ON [dbo].[OrganizationOtherNames]
    ([OrganizationID]);
GO

-- Creating foreign key on [Parent] in table 'ProductStandards'
ALTER TABLE [dbo].[ProductStandards]
ADD CONSTRAINT [FK_ProductStandardProductStandard]
    FOREIGN KEY ([Parent])
    REFERENCES [dbo].[ProductStandards]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductStandardProductStandard'
CREATE INDEX [IX_FK_ProductStandardProductStandard]
ON [dbo].[ProductStandards]
    ([Parent]);
GO

-- Creating foreign key on [Parent] in table 'IndustryCodes'
ALTER TABLE [dbo].[IndustryCodes]
ADD CONSTRAINT [FK_IndustryCodeIndustryCode]
    FOREIGN KEY ([Parent])
    REFERENCES [dbo].[IndustryCodes]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_IndustryCodeIndustryCode'
CREATE INDEX [IX_FK_IndustryCodeIndustryCode]
ON [dbo].[IndustryCodes]
    ([Parent]);
GO

-- Creating foreign key on [OldOrgan] in table 'OrganizationTransitions'
ALTER TABLE [dbo].[OrganizationTransitions]
ADD CONSTRAINT [FK_OrganizationOrganizationTransition]
    FOREIGN KEY ([OldOrgan])
    REFERENCES [dbo].[sys_Organization]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrganizationOrganizationTransition'
CREATE INDEX [IX_FK_OrganizationOrganizationTransition]
ON [dbo].[OrganizationTransitions]
    ([OldOrgan]);
GO

-- Creating foreign key on [NewOrgan] in table 'OrganizationTransitions'
ALTER TABLE [dbo].[OrganizationTransitions]
ADD CONSTRAINT [FK_OrganizationOrganizationTransition1]
    FOREIGN KEY ([NewOrgan])
    REFERENCES [dbo].[sys_Organization]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrganizationOrganizationTransition1'
CREATE INDEX [IX_FK_OrganizationOrganizationTransition1]
ON [dbo].[OrganizationTransitions]
    ([NewOrgan]);
GO

-- Creating foreign key on [UserID] in table 'User_ContactTable'
ALTER TABLE [dbo].[User_ContactTable]
ADD CONSTRAINT [FK_UserUser_ContacTable]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[sys_User]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserUser_ContacTable'
CREATE INDEX [IX_FK_UserUser_ContacTable]
ON [dbo].[User_ContactTable]
    ([UserID]);
GO

-- Creating foreign key on [ParentId] in table 'sys_Organization'
ALTER TABLE [dbo].[sys_Organization]
ADD CONSTRAINT [FK_OrganizationOrganization]
    FOREIGN KEY ([ParentId])
    REFERENCES [dbo].[sys_Organization]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrganizationOrganization'
CREATE INDEX [IX_FK_OrganizationOrganization]
ON [dbo].[sys_Organization]
    ([ParentId]);
GO

-- Creating foreign key on [Parent] in table 'Administrativecodes'
ALTER TABLE [dbo].[Administrativecodes]
ADD CONSTRAINT [FK_AdministrativecodeAdministrativecode]
    FOREIGN KEY ([Parent])
    REFERENCES [dbo].[Administrativecodes]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AdministrativecodeAdministrativecode'
CREATE INDEX [IX_FK_AdministrativecodeAdministrativecode]
ON [dbo].[Administrativecodes]
    ([Parent]);
GO

-- Creating foreign key on [Parent] in table 'Organization_Type'
ALTER TABLE [dbo].[Organization_Type]
ADD CONSTRAINT [FK_Organization_TypeOrganization_Type]
    FOREIGN KEY ([Parent])
    REFERENCES [dbo].[Organization_Type]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Organization_TypeOrganization_Type'
CREATE INDEX [IX_FK_Organization_TypeOrganization_Type]
ON [dbo].[Organization_Type]
    ([Parent]);
GO

-- Creating foreign key on [SubordinateID] in table 'OrganizBasics'
ALTER TABLE [dbo].[OrganizBasics]
ADD CONSTRAINT [FK_SubordinateOrganizBasic]
    FOREIGN KEY ([SubordinateID])
    REFERENCES [dbo].[Subordinates]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SubordinateOrganizBasic'
CREATE INDEX [IX_FK_SubordinateOrganizBasic]
ON [dbo].[OrganizBasics]
    ([SubordinateID]);
GO

-- Creating foreign key on [Parent] in table 'Specializeds'
ALTER TABLE [dbo].[Specializeds]
ADD CONSTRAINT [FK_SpecializedSpecialized]
    FOREIGN KEY ([Parent])
    REFERENCES [dbo].[Specializeds]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SpecializedSpecialized'
CREATE INDEX [IX_FK_SpecializedSpecialized]
ON [dbo].[Specializeds]
    ([Parent]);
GO

-- Creating foreign key on [SpecializedID] in table 'PostRequires'
ALTER TABLE [dbo].[PostRequires]
ADD CONSTRAINT [FK_SpecializedPostbasic]
    FOREIGN KEY ([SpecializedID])
    REFERENCES [dbo].[Specializeds]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SpecializedPostbasic'
CREATE INDEX [IX_FK_SpecializedPostbasic]
ON [dbo].[PostRequires]
    ([SpecializedID]);
GO

-- Creating foreign key on [UserID] in table 'UserRelateTables'
ALTER TABLE [dbo].[UserRelateTables]
ADD CONSTRAINT [FK_UserUserRelateTable]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[sys_User]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserUserRelateTable'
CREATE INDEX [IX_FK_UserUserRelateTable]
ON [dbo].[UserRelateTables]
    ([UserID]);
GO

-- Creating foreign key on [UserID1] in table 'UserRelateTables'
ALTER TABLE [dbo].[UserRelateTables]
ADD CONSTRAINT [FK_UserUserRelateTable1]
    FOREIGN KEY ([UserID1])
    REFERENCES [dbo].[sys_User]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserUserRelateTable1'
CREATE INDEX [IX_FK_UserUserRelateTable1]
ON [dbo].[UserRelateTables]
    ([UserID1]);
GO

-- Creating foreign key on [UserRelateTypeID] in table 'UserRelateTables'
ALTER TABLE [dbo].[UserRelateTables]
ADD CONSTRAINT [FK_UserRelateTypeUserRelateTable]
    FOREIGN KEY ([UserRelateTypeID])
    REFERENCES [dbo].[UserRelateTypes]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserRelateTypeUserRelateTable'
CREATE INDEX [IX_FK_UserRelateTypeUserRelateTable]
ON [dbo].[UserRelateTables]
    ([UserRelateTypeID]);
GO

-- Creating foreign key on [Parent] in table 'UserRelateTypes'
ALTER TABLE [dbo].[UserRelateTypes]
ADD CONSTRAINT [FK_UserRelateTypeUserRelateType]
    FOREIGN KEY ([Parent])
    REFERENCES [dbo].[UserRelateTypes]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserRelateTypeUserRelateType'
CREATE INDEX [IX_FK_UserRelateTypeUserRelateType]
ON [dbo].[UserRelateTypes]
    ([Parent]);
GO

-- Creating foreign key on [DocCheckStateID] in table 'DocumentManages'
ALTER TABLE [dbo].[DocumentManages]
ADD CONSTRAINT [FK_DocHanderStateDocumentManage]
    FOREIGN KEY ([DocCheckStateID])
    REFERENCES [dbo].[DocCheckStates]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DocHanderStateDocumentManage'
CREATE INDEX [IX_FK_DocHanderStateDocumentManage]
ON [dbo].[DocumentManages]
    ([DocCheckStateID]);
GO

-- Creating foreign key on [DocumentTypeID] in table 'DocumentTypes'
ALTER TABLE [dbo].[DocumentTypes]
ADD CONSTRAINT [FK_DocumentTypeDocumentType]
    FOREIGN KEY ([DocumentTypeID])
    REFERENCES [dbo].[DocumentTypes]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DocumentTypeDocumentType'
CREATE INDEX [IX_FK_DocumentTypeDocumentType]
ON [dbo].[DocumentTypes]
    ([DocumentTypeID]);
GO

-- Creating foreign key on [SecurityinfoID] in table 'DocumentManages'
ALTER TABLE [dbo].[DocumentManages]
ADD CONSTRAINT [FK_SecurityinfoDocumentManage]
    FOREIGN KEY ([SecurityinfoID])
    REFERENCES [dbo].[Securityinfoes]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SecurityinfoDocumentManage'
CREATE INDEX [IX_FK_SecurityinfoDocumentManage]
ON [dbo].[DocumentManages]
    ([SecurityinfoID]);
GO

-- Creating foreign key on [Organization_TypeID] in table 'OrganizBasics'
ALTER TABLE [dbo].[OrganizBasics]
ADD CONSTRAINT [FK_Organization_TypeOrganizBasic]
    FOREIGN KEY ([Organization_TypeID])
    REFERENCES [dbo].[Organization_Type]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Organization_TypeOrganizBasic'
CREATE INDEX [IX_FK_Organization_TypeOrganizBasic]
ON [dbo].[OrganizBasics]
    ([Organization_TypeID]);
GO

-- Creating foreign key on [OrganizBasicID] in table 'OrganicInvestors'
ALTER TABLE [dbo].[OrganicInvestors]
ADD CONSTRAINT [FK_OrganizBasicOrganicInvestor]
    FOREIGN KEY ([OrganizBasicID])
    REFERENCES [dbo].[OrganizBasics]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrganizBasicOrganicInvestor'
CREATE INDEX [IX_FK_OrganizBasicOrganicInvestor]
ON [dbo].[OrganicInvestors]
    ([OrganizBasicID]);
GO

-- Creating foreign key on [OrganizBasicID] in table 'OrgaRegisterDocments'
ALTER TABLE [dbo].[OrgaRegisterDocments]
ADD CONSTRAINT [FK_OrganizBasicOrgaRegisterDocment]
    FOREIGN KEY ([OrganizBasicID])
    REFERENCES [dbo].[OrganizBasics]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrganizBasicOrgaRegisterDocment'
CREATE INDEX [IX_FK_OrganizBasicOrgaRegisterDocment]
ON [dbo].[OrgaRegisterDocments]
    ([OrganizBasicID]);
GO

-- Creating foreign key on [RegisterDocumentTypeID] in table 'OrgaRegisterDocments'
ALTER TABLE [dbo].[OrgaRegisterDocments]
ADD CONSTRAINT [FK_RegisterDocumentTypeOrgaRegisterDocment]
    FOREIGN KEY ([RegisterDocumentTypeID])
    REFERENCES [dbo].[RegisterDocumentTypes]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RegisterDocumentTypeOrgaRegisterDocment'
CREATE INDEX [IX_FK_RegisterDocumentTypeOrgaRegisterDocment]
ON [dbo].[OrgaRegisterDocments]
    ([RegisterDocumentTypeID]);
GO

-- Creating foreign key on [OverrideParent] in table 'OrganizBasics'
ALTER TABLE [dbo].[OrganizBasics]
ADD CONSTRAINT [FK_OrganizBasicOrganizBasic]
    FOREIGN KEY ([OverrideParent])
    REFERENCES [dbo].[OrganizBasics]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrganizBasicOrganizBasic'
CREATE INDEX [IX_FK_OrganizBasicOrganizBasic]
ON [dbo].[OrganizBasics]
    ([OverrideParent]);
GO

-- Creating foreign key on [OrganizationID] in table 'OrganizBasics'
ALTER TABLE [dbo].[OrganizBasics]
ADD CONSTRAINT [FK_OrganizationOrganizBasic]
    FOREIGN KEY ([OrganizationID])
    REFERENCES [dbo].[sys_Organization]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrganizationOrganizBasic'
CREATE INDEX [IX_FK_OrganizationOrganizBasic]
ON [dbo].[OrganizBasics]
    ([OrganizationID]);
GO

-- Creating foreign key on [OrganizationID] in table 'OrganizationEvents'
ALTER TABLE [dbo].[OrganizationEvents]
ADD CONSTRAINT [FK_OrganizationOrganizationEvent]
    FOREIGN KEY ([OrganizationID])
    REFERENCES [dbo].[sys_Organization]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrganizationOrganizationEvent'
CREATE INDEX [IX_FK_OrganizationOrganizationEvent]
ON [dbo].[OrganizationEvents]
    ([OrganizationID]);
GO

-- Creating foreign key on [IndustryCodeID] in table 'OrganizBasics'
ALTER TABLE [dbo].[OrganizBasics]
ADD CONSTRAINT [FK_IndustryCodeOrganizBasic]
    FOREIGN KEY ([IndustryCodeID])
    REFERENCES [dbo].[IndustryCodes]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_IndustryCodeOrganizBasic'
CREATE INDEX [IX_FK_IndustryCodeOrganizBasic]
ON [dbo].[OrganizBasics]
    ([IndustryCodeID]);
GO

-- Creating foreign key on [OrganizBasicID] in table 'Organization_ContactTables'
ALTER TABLE [dbo].[Organization_ContactTables]
ADD CONSTRAINT [FK_OrganizBasicOrganization_ContacTable]
    FOREIGN KEY ([OrganizBasicID])
    REFERENCES [dbo].[OrganizBasics]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrganizBasicOrganization_ContacTable'
CREATE INDEX [IX_FK_OrganizBasicOrganization_ContacTable]
ON [dbo].[Organization_ContactTables]
    ([OrganizBasicID]);
GO

-- Creating foreign key on [AdministrativecodeSacID] in table 'OrganizBasics'
ALTER TABLE [dbo].[OrganizBasics]
ADD CONSTRAINT [FK_AdministrativecodeOrganizBasic]
    FOREIGN KEY ([AdministrativecodeSacID])
    REFERENCES [dbo].[Administrativecodes]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AdministrativecodeOrganizBasic'
CREATE INDEX [IX_FK_AdministrativecodeOrganizBasic]
ON [dbo].[OrganizBasics]
    ([AdministrativecodeSacID]);
GO

-- Creating foreign key on [Investor] in table 'OrganicInvestors'
ALTER TABLE [dbo].[OrganicInvestors]
ADD CONSTRAINT [FK_OrganizBasicOrganicInvestor1]
    FOREIGN KEY ([Investor])
    REFERENCES [dbo].[OrganizBasics]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrganizBasicOrganicInvestor1'
CREATE INDEX [IX_FK_OrganizBasicOrganicInvestor1]
ON [dbo].[OrganicInvestors]
    ([Investor]);
GO

-- Creating foreign key on [UserId] in table 'sys_GroupMember'
ALTER TABLE [dbo].[sys_GroupMember]
ADD CONSTRAINT [FK_UserMessageGroup]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[sys_User]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserMessageGroup'
CREATE INDEX [IX_FK_UserMessageGroup]
ON [dbo].[sys_GroupMember]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'sys_Group'
ALTER TABLE [dbo].[sys_Group]
ADD CONSTRAINT [FK_UserGroupName]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[sys_User]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserGroupName'
CREATE INDEX [IX_FK_UserGroupName]
ON [dbo].[sys_Group]
    ([UserId]);
GO

-- Creating foreign key on [CreateUserId] in table 'sys_CustomerGoup'
ALTER TABLE [dbo].[sys_CustomerGoup]
ADD CONSTRAINT [FK_UserCustomerGoup]
    FOREIGN KEY ([CreateUserId])
    REFERENCES [dbo].[sys_User]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserCustomerGoup'
CREATE INDEX [IX_FK_UserCustomerGoup]
ON [dbo].[sys_CustomerGoup]
    ([CreateUserId]);
GO

-- Creating foreign key on [FromUserId] in table 'sys_UserMessage'
ALTER TABLE [dbo].[sys_UserMessage]
ADD CONSTRAINT [FK_UserUserMessage]
    FOREIGN KEY ([FromUserId])
    REFERENCES [dbo].[sys_User]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserUserMessage'
CREATE INDEX [IX_FK_UserUserMessage]
ON [dbo].[sys_UserMessage]
    ([FromUserId]);
GO

-- Creating foreign key on [OrganizationID] in table 'OrganizationCustomTypes'
ALTER TABLE [dbo].[OrganizationCustomTypes]
ADD CONSTRAINT [FK_OrganizationCustomOrganizationType]
    FOREIGN KEY ([OrganizationID])
    REFERENCES [dbo].[sys_Organization]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrganizationCustomOrganizationType'
CREATE INDEX [IX_FK_OrganizationCustomOrganizationType]
ON [dbo].[OrganizationCustomTypes]
    ([OrganizationID]);
GO

-- Creating foreign key on [CustomCategoryID] in table 'OrganizationCustomTypes'
ALTER TABLE [dbo].[OrganizationCustomTypes]
ADD CONSTRAINT [FK_CustomCategoryCustomOrganizationType]
    FOREIGN KEY ([CustomCategoryID])
    REFERENCES [dbo].[CustomCategories]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomCategoryCustomOrganizationType'
CREATE INDEX [IX_FK_CustomCategoryCustomOrganizationType]
ON [dbo].[OrganizationCustomTypes]
    ([CustomCategoryID]);
GO

-- Creating foreign key on [CustomCategoryID] in table 'CustomCategories'
ALTER TABLE [dbo].[CustomCategories]
ADD CONSTRAINT [FK_CustomCategoryCustomCategory]
    FOREIGN KEY ([CustomCategoryID])
    REFERENCES [dbo].[CustomCategories]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomCategoryCustomCategory'
CREATE INDEX [IX_FK_CustomCategoryCustomCategory]
ON [dbo].[CustomCategories]
    ([CustomCategoryID]);
GO

-- Creating foreign key on [ProductStandardID] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_ProductStandardProduct]
    FOREIGN KEY ([ProductStandardID])
    REFERENCES [dbo].[ProductStandards]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductStandardProduct'
CREATE INDEX [IX_FK_ProductStandardProduct]
ON [dbo].[Products]
    ([ProductStandardID]);
GO

-- Creating foreign key on [ChildProductId] in table 'ProductCompositions'
ALTER TABLE [dbo].[ProductCompositions]
ADD CONSTRAINT [FK_ProductProductComposition1]
    FOREIGN KEY ([ChildProductId])
    REFERENCES [dbo].[Products]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductProductComposition1'
CREATE INDEX [IX_FK_ProductProductComposition1]
ON [dbo].[ProductCompositions]
    ([ChildProductId]);
GO

-- Creating foreign key on [ProductId] in table 'ProductCustomTypes'
ALTER TABLE [dbo].[ProductCustomTypes]
ADD CONSTRAINT [FK_ProductProductCustomType]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[Products]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductProductCustomType'
CREATE INDEX [IX_FK_ProductProductCustomType]
ON [dbo].[ProductCustomTypes]
    ([ProductId]);
GO

-- Creating foreign key on [ProductCustomCategoryId] in table 'ProductCustomCategories'
ALTER TABLE [dbo].[ProductCustomCategories]
ADD CONSTRAINT [FK_ProductCustomCategoryProductCustomCategory]
    FOREIGN KEY ([ProductCustomCategoryId])
    REFERENCES [dbo].[ProductCustomCategories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductCustomCategoryProductCustomCategory'
CREATE INDEX [IX_FK_ProductCustomCategoryProductCustomCategory]
ON [dbo].[ProductCustomCategories]
    ([ProductCustomCategoryId]);
GO

-- Creating foreign key on [ProductCustomCategoryId] in table 'ProductCustomTypes'
ALTER TABLE [dbo].[ProductCustomTypes]
ADD CONSTRAINT [FK_ProductCustomCategoryProductCustomType]
    FOREIGN KEY ([ProductCustomCategoryId])
    REFERENCES [dbo].[ProductCustomCategories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductCustomCategoryProductCustomType'
CREATE INDEX [IX_FK_ProductCustomCategoryProductCustomType]
ON [dbo].[ProductCustomTypes]
    ([ProductCustomCategoryId]);
GO

-- Creating foreign key on [ProductId] in table 'ProductEvents'
ALTER TABLE [dbo].[ProductEvents]
ADD CONSTRAINT [FK_ProductProductEvent]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[Products]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductProductEvent'
CREATE INDEX [IX_FK_ProductProductEvent]
ON [dbo].[ProductEvents]
    ([ProductId]);
GO

-- Creating foreign key on [OrganizationID] in table 'physicalAssets'
ALTER TABLE [dbo].[physicalAssets]
ADD CONSTRAINT [FK_OrganizationphysicalAsset]
    FOREIGN KEY ([OrganizationID])
    REFERENCES [dbo].[sys_Organization]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrganizationphysicalAsset'
CREATE INDEX [IX_FK_OrganizationphysicalAsset]
ON [dbo].[physicalAssets]
    ([OrganizationID]);
GO

-- Creating foreign key on [ProductId] in table 'physicalAssets'
ALTER TABLE [dbo].[physicalAssets]
ADD CONSTRAINT [FK_ProductphysicalAsset]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[Products]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductphysicalAsset'
CREATE INDEX [IX_FK_ProductphysicalAsset]
ON [dbo].[physicalAssets]
    ([ProductId]);
GO

-- Creating foreign key on [Supplier] in table 'physicalAssets'
ALTER TABLE [dbo].[physicalAssets]
ADD CONSTRAINT [FK_OrganizationphysicalAsset1]
    FOREIGN KEY ([Supplier])
    REFERENCES [dbo].[sys_Organization]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrganizationphysicalAsset1'
CREATE INDEX [IX_FK_OrganizationphysicalAsset1]
ON [dbo].[physicalAssets]
    ([Supplier]);
GO

-- Creating foreign key on [physicalAssetId] in table 'AssetUses'
ALTER TABLE [dbo].[AssetUses]
ADD CONSTRAINT [FK_physicalAssetAssetUse]
    FOREIGN KEY ([physicalAssetId])
    REFERENCES [dbo].[physicalAssets]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_physicalAssetAssetUse'
CREATE INDEX [IX_FK_physicalAssetAssetUse]
ON [dbo].[AssetUses]
    ([physicalAssetId]);
GO

-- Creating foreign key on [physicalAssetId] in table 'AssetMaintenances'
ALTER TABLE [dbo].[AssetMaintenances]
ADD CONSTRAINT [FK_physicalAssetAssetMaintenance]
    FOREIGN KEY ([physicalAssetId])
    REFERENCES [dbo].[physicalAssets]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_physicalAssetAssetMaintenance'
CREATE INDEX [IX_FK_physicalAssetAssetMaintenance]
ON [dbo].[AssetMaintenances]
    ([physicalAssetId]);
GO

-- Creating foreign key on [AssetTypeId] in table 'AssetBaseTypes'
ALTER TABLE [dbo].[AssetBaseTypes]
ADD CONSTRAINT [FK_AssetTypeAssetType]
    FOREIGN KEY ([AssetTypeId])
    REFERENCES [dbo].[AssetBaseTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AssetTypeAssetType'
CREATE INDEX [IX_FK_AssetTypeAssetType]
ON [dbo].[AssetBaseTypes]
    ([AssetTypeId]);
GO

-- Creating foreign key on [OrganizationID] in table 'sys_Position'
ALTER TABLE [dbo].[sys_Position]
ADD CONSTRAINT [FK_OrganizationPosition]
    FOREIGN KEY ([OrganizationID])
    REFERENCES [dbo].[sys_Organization]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrganizationPosition'
CREATE INDEX [IX_FK_OrganizationPosition]
ON [dbo].[sys_Position]
    ([OrganizationID]);
GO

-- Creating foreign key on [DllFileStreamID] in table 'DllFileStreams'
ALTER TABLE [dbo].[DllFileStreams]
ADD CONSTRAINT [FK_DllFileStreamDllFileStream]
    FOREIGN KEY ([DllFileStreamID])
    REFERENCES [dbo].[DllFileStreams]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DllFileStreamDllFileStream'
CREATE INDEX [IX_FK_DllFileStreamDllFileStream]
ON [dbo].[DllFileStreams]
    ([DllFileStreamID]);
GO

-- Creating foreign key on [physicalAssetId] in table 'OrganizationAssetTypes'
ALTER TABLE [dbo].[OrganizationAssetTypes]
ADD CONSTRAINT [FK_physicalAssetOrganizationAssetType]
    FOREIGN KEY ([physicalAssetId])
    REFERENCES [dbo].[physicalAssets]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_physicalAssetOrganizationAssetType'
CREATE INDEX [IX_FK_physicalAssetOrganizationAssetType]
ON [dbo].[OrganizationAssetTypes]
    ([physicalAssetId]);
GO

-- Creating foreign key on [AssetBaseTypeId] in table 'OrganizationAssetTypes'
ALTER TABLE [dbo].[OrganizationAssetTypes]
ADD CONSTRAINT [FK_AssetBaseTypeOrganizationAssetType]
    FOREIGN KEY ([AssetBaseTypeId])
    REFERENCES [dbo].[AssetBaseTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AssetBaseTypeOrganizationAssetType'
CREATE INDEX [IX_FK_AssetBaseTypeOrganizationAssetType]
ON [dbo].[OrganizationAssetTypes]
    ([AssetBaseTypeId]);
GO

-- Creating foreign key on [UserID] in table 'sys_Employee'
ALTER TABLE [dbo].[sys_Employee]
ADD CONSTRAINT [FK_UserEmployee]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[sys_User]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserEmployee'
CREATE INDEX [IX_FK_UserEmployee]
ON [dbo].[sys_Employee]
    ([UserID]);
GO

-- Creating foreign key on [PostRequireID] in table 'sys_Position'
ALTER TABLE [dbo].[sys_Position]
ADD CONSTRAINT [FK_PostRequirePosition]
    FOREIGN KEY ([PostRequireID])
    REFERENCES [dbo].[PostRequires]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PostRequirePosition'
CREATE INDEX [IX_FK_PostRequirePosition]
ON [dbo].[sys_Position]
    ([PostRequireID]);
GO

-- Creating foreign key on [IndustryCodeID] in table 'IndustrySolutions'
ALTER TABLE [dbo].[IndustrySolutions]
ADD CONSTRAINT [FK_IndustryCodeIndustrySolution]
    FOREIGN KEY ([IndustryCodeID])
    REFERENCES [dbo].[IndustryCodes]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_IndustryCodeIndustrySolution'
CREATE INDEX [IX_FK_IndustryCodeIndustrySolution]
ON [dbo].[IndustrySolutions]
    ([IndustryCodeID]);
GO

-- Creating foreign key on [PositionID] in table 'sys_Employee'
ALTER TABLE [dbo].[sys_Employee]
ADD CONSTRAINT [FK_PositionEmployee]
    FOREIGN KEY ([PositionID])
    REFERENCES [dbo].[sys_Position]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PositionEmployee'
CREATE INDEX [IX_FK_PositionEmployee]
ON [dbo].[sys_Employee]
    ([PositionID]);
GO

-- Creating foreign key on [OrganizBasicID] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_OrganizBasicProduct]
    FOREIGN KEY ([OrganizBasicID])
    REFERENCES [dbo].[OrganizBasics]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrganizBasicProduct'
CREATE INDEX [IX_FK_OrganizBasicProduct]
ON [dbo].[Products]
    ([OrganizBasicID]);
GO

-- Creating foreign key on [ProductCompositionId] in table 'ProductCompositions'
ALTER TABLE [dbo].[ProductCompositions]
ADD CONSTRAINT [FK_ProductCompositionProductComposition]
    FOREIGN KEY ([ProductCompositionId])
    REFERENCES [dbo].[ProductCompositions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductCompositionProductComposition'
CREATE INDEX [IX_FK_ProductCompositionProductComposition]
ON [dbo].[ProductCompositions]
    ([ProductCompositionId]);
GO

-- Creating foreign key on [IndustrySolutionId] in table 'WorkSpaces'
ALTER TABLE [dbo].[WorkSpaces]
ADD CONSTRAINT [FK_IndustrySolutionWorkSpace]
    FOREIGN KEY ([IndustrySolutionId])
    REFERENCES [dbo].[IndustrySolutions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_IndustrySolutionWorkSpace'
CREATE INDEX [IX_FK_IndustrySolutionWorkSpace]
ON [dbo].[WorkSpaces]
    ([IndustrySolutionId]);
GO

-- Creating foreign key on [OrganizationID] in table 'sys_Post'
ALTER TABLE [dbo].[sys_Post]
ADD CONSTRAINT [FK_OrganizationPost]
    FOREIGN KEY ([OrganizationID])
    REFERENCES [dbo].[sys_Organization]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrganizationPost'
CREATE INDEX [IX_FK_OrganizationPost]
ON [dbo].[sys_Post]
    ([OrganizationID]);
GO

-- Creating foreign key on [WorkSpaceID] in table 'WorkSpaces'
ALTER TABLE [dbo].[WorkSpaces]
ADD CONSTRAINT [FK_WorkSpaceWorkSpace]
    FOREIGN KEY ([WorkSpaceID])
    REFERENCES [dbo].[WorkSpaces]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WorkSpaceWorkSpace'
CREATE INDEX [IX_FK_WorkSpaceWorkSpace]
ON [dbo].[WorkSpaces]
    ([WorkSpaceID]);
GO

-- Creating foreign key on [OrganizationID] in table 'sys_Employee'
ALTER TABLE [dbo].[sys_Employee]
ADD CONSTRAINT [FK_OrganizationEmployee]
    FOREIGN KEY ([OrganizationID])
    REFERENCES [dbo].[sys_Organization]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrganizationEmployee'
CREATE INDEX [IX_FK_OrganizationEmployee]
ON [dbo].[sys_Employee]
    ([OrganizationID]);
GO

-- Creating foreign key on [IndustrySolutionId] in table 'DllFileStreams'
ALTER TABLE [dbo].[DllFileStreams]
ADD CONSTRAINT [FK_IndustrySolutionDllFileStream]
    FOREIGN KEY ([IndustrySolutionId])
    REFERENCES [dbo].[IndustrySolutions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_IndustrySolutionDllFileStream'
CREATE INDEX [IX_FK_IndustrySolutionDllFileStream]
ON [dbo].[DllFileStreams]
    ([IndustrySolutionId]);
GO

-- Creating foreign key on [WorkModulId] in table 'WorkModuls'
ALTER TABLE [dbo].[WorkModuls]
ADD CONSTRAINT [FK_WorkModulWorkModul]
    FOREIGN KEY ([WorkModulId])
    REFERENCES [dbo].[WorkModuls]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WorkModulWorkModul'
CREATE INDEX [IX_FK_WorkModulWorkModul]
ON [dbo].[WorkModuls]
    ([WorkModulId]);
GO

-- Creating foreign key on [WorkModulId] in table 'WorkSpaces'
ALTER TABLE [dbo].[WorkSpaces]
ADD CONSTRAINT [FK_WorkModulWorkSpace]
    FOREIGN KEY ([WorkModulId])
    REFERENCES [dbo].[WorkModuls]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WorkModulWorkSpace'
CREATE INDEX [IX_FK_WorkModulWorkSpace]
ON [dbo].[WorkSpaces]
    ([WorkModulId]);
GO

-- Creating foreign key on [WorkSpaceID] in table 'WorkSpaceRoles'
ALTER TABLE [dbo].[WorkSpaceRoles]
ADD CONSTRAINT [FK_WorkSpaceWorkSpaceRole]
    FOREIGN KEY ([WorkSpaceID])
    REFERENCES [dbo].[WorkSpaces]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WorkSpaceWorkSpaceRole'
CREATE INDEX [IX_FK_WorkSpaceWorkSpaceRole]
ON [dbo].[WorkSpaceRoles]
    ([WorkSpaceID]);
GO

-- Creating foreign key on [OrganizationID] in table 'WorkSpaceRoles'
ALTER TABLE [dbo].[WorkSpaceRoles]
ADD CONSTRAINT [FK_OrganizationWorkSpaceRole]
    FOREIGN KEY ([OrganizationID])
    REFERENCES [dbo].[sys_Organization]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrganizationWorkSpaceRole'
CREATE INDEX [IX_FK_OrganizationWorkSpaceRole]
ON [dbo].[WorkSpaceRoles]
    ([OrganizationID]);
GO

-- Creating foreign key on [WorkModulId] in table 'WorkSpaceRoles'
ALTER TABLE [dbo].[WorkSpaceRoles]
ADD CONSTRAINT [FK_WorkModulWorkSpaceRole]
    FOREIGN KEY ([WorkModulId])
    REFERENCES [dbo].[WorkModuls]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WorkModulWorkSpaceRole'
CREATE INDEX [IX_FK_WorkModulWorkSpaceRole]
ON [dbo].[WorkSpaceRoles]
    ([WorkModulId]);
GO

-- Creating foreign key on [PostID] in table 'Authorizations'
ALTER TABLE [dbo].[Authorizations]
ADD CONSTRAINT [FK_PostAuthorization]
    FOREIGN KEY ([PostID])
    REFERENCES [dbo].[sys_Post]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PostAuthorization'
CREATE INDEX [IX_FK_PostAuthorization]
ON [dbo].[Authorizations]
    ([PostID]);
GO

-- Creating foreign key on [OrganizationID] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_OrganizationProduct]
    FOREIGN KEY ([OrganizationID])
    REFERENCES [dbo].[sys_Organization]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrganizationProduct'
CREATE INDEX [IX_FK_OrganizationProduct]
ON [dbo].[Products]
    ([OrganizationID]);
GO

-- Creating foreign key on [PostID1] in table 'Authorizations'
ALTER TABLE [dbo].[Authorizations]
ADD CONSTRAINT [FK_PostAuthorization1]
    FOREIGN KEY ([PostID1])
    REFERENCES [dbo].[sys_Post]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PostAuthorization1'
CREATE INDEX [IX_FK_PostAuthorization1]
ON [dbo].[Authorizations]
    ([PostID1]);
GO

-- Creating foreign key on [WorkModulId] in table 'ModulProperties'
ALTER TABLE [dbo].[ModulProperties]
ADD CONSTRAINT [FK_WorkModulModulProperty]
    FOREIGN KEY ([WorkModulId])
    REFERENCES [dbo].[WorkModuls]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WorkModulModulProperty'
CREATE INDEX [IX_FK_WorkModulModulProperty]
ON [dbo].[ModulProperties]
    ([WorkModulId]);
GO

-- Creating foreign key on [ModulPropertyId] in table 'Authorizations'
ALTER TABLE [dbo].[Authorizations]
ADD CONSTRAINT [FK_ModulPropertyAuthorization]
    FOREIGN KEY ([ModulPropertyId])
    REFERENCES [dbo].[ModulProperties]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ModulPropertyAuthorization'
CREATE INDEX [IX_FK_ModulPropertyAuthorization]
ON [dbo].[Authorizations]
    ([ModulPropertyId]);
GO

-- Creating foreign key on [AuthorizationId] in table 'WorkMessages'
ALTER TABLE [dbo].[WorkMessages]
ADD CONSTRAINT [FK_AuthorizationWorkMessage]
    FOREIGN KEY ([AuthorizationId])
    REFERENCES [dbo].[Authorizations]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AuthorizationWorkMessage'
CREATE INDEX [IX_FK_AuthorizationWorkMessage]
ON [dbo].[WorkMessages]
    ([AuthorizationId]);
GO

-- Creating foreign key on [UserID] in table 'WorkSpaceRoles'
ALTER TABLE [dbo].[WorkSpaceRoles]
ADD CONSTRAINT [FK_UserWorkSpaceRole]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[sys_User]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserWorkSpaceRole'
CREATE INDEX [IX_FK_UserWorkSpaceRole]
ON [dbo].[WorkSpaceRoles]
    ([UserID]);
GO

-- Creating foreign key on [UserID] in table 'Authorizations'
ALTER TABLE [dbo].[Authorizations]
ADD CONSTRAINT [FK_UserAuthorization]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[sys_User]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserAuthorization'
CREATE INDEX [IX_FK_UserAuthorization]
ON [dbo].[Authorizations]
    ([UserID]);
GO

-- Creating foreign key on [UserID1] in table 'Authorizations'
ALTER TABLE [dbo].[Authorizations]
ADD CONSTRAINT [FK_UserAuthorization1]
    FOREIGN KEY ([UserID1])
    REFERENCES [dbo].[sys_User]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserAuthorization1'
CREATE INDEX [IX_FK_UserAuthorization1]
ON [dbo].[Authorizations]
    ([UserID1]);
GO

-- Creating foreign key on [DocumentTypeID] in table 'DocTypes'
ALTER TABLE [dbo].[DocTypes]
ADD CONSTRAINT [FK_DocumentTypeDocType]
    FOREIGN KEY ([DocumentTypeID])
    REFERENCES [dbo].[DocumentTypes]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DocumentTypeDocType'
CREATE INDEX [IX_FK_DocumentTypeDocType]
ON [dbo].[DocTypes]
    ([DocumentTypeID]);
GO

-- Creating foreign key on [DocumentManageID] in table 'DocTypes'
ALTER TABLE [dbo].[DocTypes]
ADD CONSTRAINT [FK_DocumentManageDocType]
    FOREIGN KEY ([DocumentManageID])
    REFERENCES [dbo].[DocumentManages]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DocumentManageDocType'
CREATE INDEX [IX_FK_DocumentManageDocType]
ON [dbo].[DocTypes]
    ([DocumentManageID]);
GO

-- Creating foreign key on [OrganizationID] in table 'DocReaders'
ALTER TABLE [dbo].[DocReaders]
ADD CONSTRAINT [FK_OrganizationDocReader]
    FOREIGN KEY ([OrganizationID])
    REFERENCES [dbo].[sys_Organization]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrganizationDocReader'
CREATE INDEX [IX_FK_OrganizationDocReader]
ON [dbo].[DocReaders]
    ([OrganizationID]);
GO

-- Creating foreign key on [WorkSpaceID] in table 'DocReaders'
ALTER TABLE [dbo].[DocReaders]
ADD CONSTRAINT [FK_WorkSpaceDocReader]
    FOREIGN KEY ([WorkSpaceID])
    REFERENCES [dbo].[WorkSpaces]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WorkSpaceDocReader'
CREATE INDEX [IX_FK_WorkSpaceDocReader]
ON [dbo].[DocReaders]
    ([WorkSpaceID]);
GO

-- Creating foreign key on [PostID] in table 'DocReaders'
ALTER TABLE [dbo].[DocReaders]
ADD CONSTRAINT [FK_PostDocReader]
    FOREIGN KEY ([PostID])
    REFERENCES [dbo].[sys_Post]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PostDocReader'
CREATE INDEX [IX_FK_PostDocReader]
ON [dbo].[DocReaders]
    ([PostID]);
GO

-- Creating foreign key on [UserID] in table 'DocReaders'
ALTER TABLE [dbo].[DocReaders]
ADD CONSTRAINT [FK_UserDocReader]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[sys_User]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserDocReader'
CREATE INDEX [IX_FK_UserDocReader]
ON [dbo].[DocReaders]
    ([UserID]);
GO

-- Creating foreign key on [SecurityinfoID] in table 'Securityinfoes'
ALTER TABLE [dbo].[Securityinfoes]
ADD CONSTRAINT [FK_SecurityinfoSecurityinfo]
    FOREIGN KEY ([SecurityinfoID])
    REFERENCES [dbo].[Securityinfoes]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SecurityinfoSecurityinfo'
CREATE INDEX [IX_FK_SecurityinfoSecurityinfo]
ON [dbo].[Securityinfoes]
    ([SecurityinfoID]);
GO

-- Creating foreign key on [DocManageStateID] in table 'DocManageStates'
ALTER TABLE [dbo].[DocManageStates]
ADD CONSTRAINT [FK_DocManageStateDocManageState]
    FOREIGN KEY ([DocManageStateID])
    REFERENCES [dbo].[DocManageStates]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DocManageStateDocManageState'
CREATE INDEX [IX_FK_DocManageStateDocManageState]
ON [dbo].[DocManageStates]
    ([DocManageStateID]);
GO

-- Creating foreign key on [UserID] in table 'DocSenders'
ALTER TABLE [dbo].[DocSenders]
ADD CONSTRAINT [FK_UserDocSender]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[sys_User]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserDocSender'
CREATE INDEX [IX_FK_UserDocSender]
ON [dbo].[DocSenders]
    ([UserID]);
GO

-- Creating foreign key on [PostID] in table 'DocSenders'
ALTER TABLE [dbo].[DocSenders]
ADD CONSTRAINT [FK_PostDocSender]
    FOREIGN KEY ([PostID])
    REFERENCES [dbo].[sys_Post]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PostDocSender'
CREATE INDEX [IX_FK_PostDocSender]
ON [dbo].[DocSenders]
    ([PostID]);
GO

-- Creating foreign key on [DocSenderId] in table 'DocComents'
ALTER TABLE [dbo].[DocComents]
ADD CONSTRAINT [FK_DocSenderDocComent]
    FOREIGN KEY ([DocSenderId])
    REFERENCES [dbo].[DocSenders]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DocSenderDocComent'
CREATE INDEX [IX_FK_DocSenderDocComent]
ON [dbo].[DocComents]
    ([DocSenderId]);
GO

-- Creating foreign key on [PostID] in table 'JobChanges'
ALTER TABLE [dbo].[JobChanges]
ADD CONSTRAINT [FK_PostJobChange]
    FOREIGN KEY ([PostID])
    REFERENCES [dbo].[sys_Post]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PostJobChange'
CREATE INDEX [IX_FK_PostJobChange]
ON [dbo].[JobChanges]
    ([PostID]);
GO

-- Creating foreign key on [WorkSpaceID] in table 'WorkSpaceTypes'
ALTER TABLE [dbo].[WorkSpaceTypes]
ADD CONSTRAINT [FK_WorkSpaceWorkSpaceType]
    FOREIGN KEY ([WorkSpaceID])
    REFERENCES [dbo].[WorkSpaces]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WorkSpaceWorkSpaceType'
CREATE INDEX [IX_FK_WorkSpaceWorkSpaceType]
ON [dbo].[WorkSpaceTypes]
    ([WorkSpaceID]);
GO

-- Creating foreign key on [DocumentManageID] in table 'workTasks'
ALTER TABLE [dbo].[workTasks]
ADD CONSTRAINT [FK_DocumentManageworkTask]
    FOREIGN KEY ([DocumentManageID])
    REFERENCES [dbo].[DocumentManages]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DocumentManageworkTask'
CREATE INDEX [IX_FK_DocumentManageworkTask]
ON [dbo].[workTasks]
    ([DocumentManageID]);
GO

-- Creating foreign key on [workTaskId] in table 'workTasks'
ALTER TABLE [dbo].[workTasks]
ADD CONSTRAINT [FK_workTaskworkTask]
    FOREIGN KEY ([workTaskId])
    REFERENCES [dbo].[workTasks]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_workTaskworkTask'
CREATE INDEX [IX_FK_workTaskworkTask]
ON [dbo].[workTasks]
    ([workTaskId]);
GO

-- Creating foreign key on [DocumentManageID] in table 'DocumentContents'
ALTER TABLE [dbo].[DocumentContents]
ADD CONSTRAINT [FK_DocumentManageDocumentContent]
    FOREIGN KEY ([DocumentManageID])
    REFERENCES [dbo].[DocumentManages]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DocumentManageDocumentContent'
CREATE INDEX [IX_FK_DocumentManageDocumentContent]
ON [dbo].[DocumentContents]
    ([DocumentManageID]);
GO

-- Creating foreign key on [DocumentContentID] in table 'DocumentContents'
ALTER TABLE [dbo].[DocumentContents]
ADD CONSTRAINT [FK_DocumentContentDocumentContent]
    FOREIGN KEY ([DocumentContentID])
    REFERENCES [dbo].[DocumentContents]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DocumentContentDocumentContent'
CREATE INDEX [IX_FK_DocumentContentDocumentContent]
ON [dbo].[DocumentContents]
    ([DocumentContentID]);
GO

-- Creating foreign key on [workTaskId] in table 'DocumentContents'
ALTER TABLE [dbo].[DocumentContents]
ADD CONSTRAINT [FK_workTaskDocumentContent]
    FOREIGN KEY ([workTaskId])
    REFERENCES [dbo].[workTasks]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_workTaskDocumentContent'
CREATE INDEX [IX_FK_workTaskDocumentContent]
ON [dbo].[DocumentContents]
    ([workTaskId]);
GO

-- Creating foreign key on [CustomTableId] in table 'CustomTabDatas'
ALTER TABLE [dbo].[CustomTabDatas]
ADD CONSTRAINT [FK_CustomTableCustomTabData]
    FOREIGN KEY ([CustomTableId])
    REFERENCES [dbo].[CustomTables]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomTableCustomTabData'
CREATE INDEX [IX_FK_CustomTableCustomTabData]
ON [dbo].[CustomTabDatas]
    ([CustomTableId]);
GO

-- Creating foreign key on [DocumentManageID] in table 'CustomTabDatas'
ALTER TABLE [dbo].[CustomTabDatas]
ADD CONSTRAINT [FK_DocumentManageCustomTabData]
    FOREIGN KEY ([DocumentManageID])
    REFERENCES [dbo].[DocumentManages]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DocumentManageCustomTabData'
CREATE INDEX [IX_FK_DocumentManageCustomTabData]
ON [dbo].[CustomTabDatas]
    ([DocumentManageID]);
GO

-- Creating foreign key on [DocLocationID] in table 'DocComents'
ALTER TABLE [dbo].[DocComents]
ADD CONSTRAINT [FK_DocLocationDocComent]
    FOREIGN KEY ([DocLocationID])
    REFERENCES [dbo].[DocLocations]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DocLocationDocComent'
CREATE INDEX [IX_FK_DocLocationDocComent]
ON [dbo].[DocComents]
    ([DocLocationID]);
GO

-- Creating foreign key on [DocLocationID] in table 'DocLocations'
ALTER TABLE [dbo].[DocLocations]
ADD CONSTRAINT [FK_DocLocationDocLocation]
    FOREIGN KEY ([DocLocationID])
    REFERENCES [dbo].[DocLocations]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DocLocationDocLocation'
CREATE INDEX [IX_FK_DocLocationDocLocation]
ON [dbo].[DocLocations]
    ([DocLocationID]);
GO

-- Creating foreign key on [DocReaderId] in table 'DocLocations'
ALTER TABLE [dbo].[DocLocations]
ADD CONSTRAINT [FK_DocReaderDocLocation]
    FOREIGN KEY ([DocReaderId])
    REFERENCES [dbo].[DocReaders]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DocReaderDocLocation'
CREATE INDEX [IX_FK_DocReaderDocLocation]
ON [dbo].[DocLocations]
    ([DocReaderId]);
GO

-- Creating foreign key on [DocSenderId] in table 'DocLocations'
ALTER TABLE [dbo].[DocLocations]
ADD CONSTRAINT [FK_DocSenderDocLocation]
    FOREIGN KEY ([DocSenderId])
    REFERENCES [dbo].[DocSenders]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DocSenderDocLocation'
CREATE INDEX [IX_FK_DocSenderDocLocation]
ON [dbo].[DocLocations]
    ([DocSenderId]);
GO

-- Creating foreign key on [DocumentManageID] in table 'DocLocations'
ALTER TABLE [dbo].[DocLocations]
ADD CONSTRAINT [FK_DocumentManageDocLocation]
    FOREIGN KEY ([DocumentManageID])
    REFERENCES [dbo].[DocumentManages]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DocumentManageDocLocation'
CREATE INDEX [IX_FK_DocumentManageDocLocation]
ON [dbo].[DocLocations]
    ([DocumentManageID]);
GO

-- Creating foreign key on [WorkSpaceBaseTypeId] in table 'WorkSpaceBaseTypes'
ALTER TABLE [dbo].[WorkSpaceBaseTypes]
ADD CONSTRAINT [FK_WorkSpaceBaseTypeWorkSpaceBaseType]
    FOREIGN KEY ([WorkSpaceBaseTypeId])
    REFERENCES [dbo].[WorkSpaceBaseTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WorkSpaceBaseTypeWorkSpaceBaseType'
CREATE INDEX [IX_FK_WorkSpaceBaseTypeWorkSpaceBaseType]
ON [dbo].[WorkSpaceBaseTypes]
    ([WorkSpaceBaseTypeId]);
GO

-- Creating foreign key on [DllFileStreamID] in table 'WorkModuls'
ALTER TABLE [dbo].[WorkModuls]
ADD CONSTRAINT [FK_DllFileStreamWorkModul]
    FOREIGN KEY ([DllFileStreamID])
    REFERENCES [dbo].[DllFileStreams]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DllFileStreamWorkModul'
CREATE INDEX [IX_FK_DllFileStreamWorkModul]
ON [dbo].[WorkModuls]
    ([DllFileStreamID]);
GO

-- Creating foreign key on [WorkSpaceBaseTypeId] in table 'WorkSpaceTypes'
ALTER TABLE [dbo].[WorkSpaceTypes]
ADD CONSTRAINT [FK_WorkSpaceBaseTypeWorkSpaceType]
    FOREIGN KEY ([WorkSpaceBaseTypeId])
    REFERENCES [dbo].[WorkSpaceBaseTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WorkSpaceBaseTypeWorkSpaceType'
CREATE INDEX [IX_FK_WorkSpaceBaseTypeWorkSpaceType]
ON [dbo].[WorkSpaceTypes]
    ([WorkSpaceBaseTypeId]);
GO

-- Creating foreign key on [WorkSpaceBaseTypeId] in table 'DocumentManages'
ALTER TABLE [dbo].[DocumentManages]
ADD CONSTRAINT [FK_WorkSpaceBaseTypeDocumentManage]
    FOREIGN KEY ([WorkSpaceBaseTypeId])
    REFERENCES [dbo].[WorkSpaceBaseTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WorkSpaceBaseTypeDocumentManage'
CREATE INDEX [IX_FK_WorkSpaceBaseTypeDocumentManage]
ON [dbo].[DocumentManages]
    ([WorkSpaceBaseTypeId]);
GO

-- Creating foreign key on [DocManageStateID] in table 'DocumentManages'
ALTER TABLE [dbo].[DocumentManages]
ADD CONSTRAINT [FK_DocManageStateDocumentManage]
    FOREIGN KEY ([DocManageStateID])
    REFERENCES [dbo].[DocManageStates]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DocManageStateDocumentManage'
CREATE INDEX [IX_FK_DocManageStateDocumentManage]
ON [dbo].[DocumentManages]
    ([DocManageStateID]);
GO

-- Creating foreign key on [OpenEventId] in table 'OperationDetails'
ALTER TABLE [dbo].[OperationDetails]
ADD CONSTRAINT [FK_OpenEventEventTime]
    FOREIGN KEY ([OpenEventId])
    REFERENCES [dbo].[OperationEvents]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OpenEventEventTime'
CREATE INDEX [IX_FK_OpenEventEventTime]
ON [dbo].[OperationDetails]
    ([OpenEventId]);
GO

-- Creating foreign key on [LoginLogID] in table 'OperationEvents'
ALTER TABLE [dbo].[OperationEvents]
ADD CONSTRAINT [FK_LoginLogOpenEvent]
    FOREIGN KEY ([LoginLogID])
    REFERENCES [dbo].[LoginLogs]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LoginLogOpenEvent'
CREATE INDEX [IX_FK_LoginLogOpenEvent]
ON [dbo].[OperationEvents]
    ([LoginLogID]);
GO

-- Creating foreign key on [GroupMemberId] in table 'sys_GroupMessager'
ALTER TABLE [dbo].[sys_GroupMessager]
ADD CONSTRAINT [FK_GroupMemberGroupMessager]
    FOREIGN KEY ([GroupMemberId])
    REFERENCES [dbo].[sys_GroupMember]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GroupMemberGroupMessager'
CREATE INDEX [IX_FK_GroupMemberGroupMessager]
ON [dbo].[sys_GroupMessager]
    ([GroupMemberId]);
GO

-- Creating foreign key on [GroupId] in table 'sys_GroupMember'
ALTER TABLE [dbo].[sys_GroupMember]
ADD CONSTRAINT [FK_GroupGroupMember]
    FOREIGN KEY ([GroupId])
    REFERENCES [dbo].[sys_Group]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GroupGroupMember'
CREATE INDEX [IX_FK_GroupGroupMember]
ON [dbo].[sys_GroupMember]
    ([GroupId]);
GO

-- Creating foreign key on [EmployeeId] in table 'sys_Post'
ALTER TABLE [dbo].[sys_Post]
ADD CONSTRAINT [FK_EmployeePost]
    FOREIGN KEY ([EmployeeId])
    REFERENCES [dbo].[sys_Employee]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeePost'
CREATE INDEX [IX_FK_EmployeePost]
ON [dbo].[sys_Post]
    ([EmployeeId]);
GO

-- Creating foreign key on [GroupId] in table 'sys_GroupMessager'
ALTER TABLE [dbo].[sys_GroupMessager]
ADD CONSTRAINT [FK_GroupGroupMessager]
    FOREIGN KEY ([GroupId])
    REFERENCES [dbo].[sys_Group]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GroupGroupMessager'
CREATE INDEX [IX_FK_GroupGroupMessager]
ON [dbo].[sys_GroupMessager]
    ([GroupId]);
GO

-- Creating foreign key on [UserId] in table 'sys_CustomGroupUser'
ALTER TABLE [dbo].[sys_CustomGroupUser]
ADD CONSTRAINT [FK_UserCustomGroupUser]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[sys_User]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserCustomGroupUser'
CREATE INDEX [IX_FK_UserCustomGroupUser]
ON [dbo].[sys_CustomGroupUser]
    ([UserId]);
GO

-- Creating foreign key on [GroupId] in table 'sys_CustomGroupUser'
ALTER TABLE [dbo].[sys_CustomGroupUser]
ADD CONSTRAINT [FK_CustomGroupCustomGroupUser]
    FOREIGN KEY ([GroupId])
    REFERENCES [dbo].[sys_CustomerGoup]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomGroupCustomGroupUser'
CREATE INDEX [IX_FK_CustomGroupCustomGroupUser]
ON [dbo].[sys_CustomGroupUser]
    ([GroupId]);
GO

-- Creating foreign key on [OrganizationId] in table 'sys_OrgManagers'
ALTER TABLE [dbo].[sys_OrgManagers]
ADD CONSTRAINT [FK_OrganizationOrgManager]
    FOREIGN KEY ([OrganizationId])
    REFERENCES [dbo].[sys_Organization]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrganizationOrgManager'
CREATE INDEX [IX_FK_OrganizationOrgManager]
ON [dbo].[sys_OrgManagers]
    ([OrganizationId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------