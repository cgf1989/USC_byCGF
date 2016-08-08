
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/08/2016 13:50:39
-- Generated from EDMX file: E:\USC_git\USC_byCGF\USC_byCGF\BaseDataLayout\DatabasePlace.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Database1];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UserLoginLog]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LoginLogs] DROP CONSTRAINT [FK_UserLoginLog];
GO
IF OBJECT_ID(N'[dbo].[FK_Land_TypeLand_Type]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Land_Types] DROP CONSTRAINT [FK_Land_TypeLand_Type];
GO
IF OBJECT_ID(N'[dbo].[FK_LoginLogUserMessage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserMessages] DROP CONSTRAINT [FK_LoginLogUserMessage];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectProject_Expense]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Project_Expense] DROP CONSTRAINT [FK_ProjectProject_Expense];
GO
IF OBJECT_ID(N'[dbo].[FK_TaskIncurredExpense]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[IncurredExpenses] DROP CONSTRAINT [FK_TaskIncurredExpense];
GO
IF OBJECT_ID(N'[dbo].[FK_TaskTaskEquipment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TaskEquipments] DROP CONSTRAINT [FK_TaskTaskEquipment];
GO
IF OBJECT_ID(N'[dbo].[FK_OrganizationOrganizationOtherName]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrganizationOtherNames] DROP CONSTRAINT [FK_OrganizationOrganizationOtherName];
GO
IF OBJECT_ID(N'[dbo].[FK_Land_TaskTypeLand_ImplementSchedule]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Land_Graph_Handles] DROP CONSTRAINT [FK_Land_TaskTypeLand_ImplementSchedule];
GO
IF OBJECT_ID(N'[dbo].[FK_TaskStateTask]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tasks] DROP CONSTRAINT [FK_TaskStateTask];
GO
IF OBJECT_ID(N'[dbo].[FK_Land_managerLand_Image]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Land_Image] DROP CONSTRAINT [FK_Land_managerLand_Image];
GO
IF OBJECT_ID(N'[dbo].[FK_Geo_GraphLand_manager]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Land_manager] DROP CONSTRAINT [FK_Geo_GraphLand_manager];
GO
IF OBJECT_ID(N'[dbo].[FK_Land_TypeLand_manager]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Land_manager] DROP CONSTRAINT [FK_Land_TypeLand_manager];
GO
IF OBJECT_ID(N'[dbo].[FK_Land_TypeLand_manager1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Land_manager] DROP CONSTRAINT [FK_Land_TypeLand_manager1];
GO
IF OBJECT_ID(N'[dbo].[FK_Land_managerLand_Ownership]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Land_Ownerships] DROP CONSTRAINT [FK_Land_managerLand_Ownership];
GO
IF OBJECT_ID(N'[dbo].[FK_Land_managerLand_DemolitionContract]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Land_DemolitionContracts] DROP CONSTRAINT [FK_Land_managerLand_DemolitionContract];
GO
IF OBJECT_ID(N'[dbo].[FK_Land_managerLand_Video]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Land_Video] DROP CONSTRAINT [FK_Land_managerLand_Video];
GO
IF OBJECT_ID(N'[dbo].[FK_Land_managerLand_Graph_Handle]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Land_Graph_Handles] DROP CONSTRAINT [FK_Land_managerLand_Graph_Handle];
GO
IF OBJECT_ID(N'[dbo].[FK_StandardadministrativecodeLand_manager]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Land_manager] DROP CONSTRAINT [FK_StandardadministrativecodeLand_manager];
GO
IF OBJECT_ID(N'[dbo].[FK_BussnessVerLand_manager]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Land_manager] DROP CONSTRAINT [FK_BussnessVerLand_manager];
GO
IF OBJECT_ID(N'[dbo].[FK_TaskTaskItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TaskItems] DROP CONSTRAINT [FK_TaskTaskItem];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductStandardProductStandard]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductStandards] DROP CONSTRAINT [FK_ProductStandardProductStandard];
GO
IF OBJECT_ID(N'[dbo].[FK_IndustryCodeIndustryCode]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[IndustryCodes] DROP CONSTRAINT [FK_IndustryCodeIndustryCode];
GO
IF OBJECT_ID(N'[dbo].[FK_DocProcessTypeProject_Document]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DocumentManages] DROP CONSTRAINT [FK_DocProcessTypeProject_Document];
GO
IF OBJECT_ID(N'[dbo].[FK_Project_DocumentProject_Document]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DocumentManages] DROP CONSTRAINT [FK_Project_DocumentProject_Document];
GO
IF OBJECT_ID(N'[dbo].[FK_AdministrativecodeZipCode]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ZipCodes] DROP CONSTRAINT [FK_AdministrativecodeZipCode];
GO
IF OBJECT_ID(N'[dbo].[FK_AdministrativecodeIPCode]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[IPCodes] DROP CONSTRAINT [FK_AdministrativecodeIPCode];
GO
IF OBJECT_ID(N'[dbo].[FK_OrganizationOrganizationTransition]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrganizationTransitions] DROP CONSTRAINT [FK_OrganizationOrganizationTransition];
GO
IF OBJECT_ID(N'[dbo].[FK_OrganizationOrganizationTransition1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrganizationTransitions] DROP CONSTRAINT [FK_OrganizationOrganizationTransition1];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectLand_manager]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Land_manager] DROP CONSTRAINT [FK_ProjectLand_manager];
GO
IF OBJECT_ID(N'[dbo].[FK_UserUser_ContacTable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User_ContactTable] DROP CONSTRAINT [FK_UserUser_ContacTable];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectTask]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tasks] DROP CONSTRAINT [FK_ProjectTask];
GO
IF OBJECT_ID(N'[dbo].[FK_OrganizationOrganization]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Organizations] DROP CONSTRAINT [FK_OrganizationOrganization];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectProject]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Projects] DROP CONSTRAINT [FK_ProjectProject];
GO
IF OBJECT_ID(N'[dbo].[FK_TaskTask]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tasks] DROP CONSTRAINT [FK_TaskTask];
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
IF OBJECT_ID(N'[dbo].[FK_GBT_13923_2006GBT_13923_2006]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GBT_13923_2006s] DROP CONSTRAINT [FK_GBT_13923_2006GBT_13923_2006];
GO
IF OBJECT_ID(N'[dbo].[FK_BussnessVerGBT_13923_2006]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GBT_13923_2006s] DROP CONSTRAINT [FK_BussnessVerGBT_13923_2006];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectProjectMap]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProjectLocations] DROP CONSTRAINT [FK_ProjectProjectMap];
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
IF OBJECT_ID(N'[dbo].[FK_PositionPosition]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Positions] DROP CONSTRAINT [FK_PositionPosition];
GO
IF OBJECT_ID(N'[dbo].[FK_OrganizBasicOrganicInvestor1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrganicInvestors] DROP CONSTRAINT [FK_OrganizBasicOrganicInvestor1];
GO
IF OBJECT_ID(N'[dbo].[FK_UserMessageGroup]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserGroups] DROP CONSTRAINT [FK_UserMessageGroup];
GO
IF OBJECT_ID(N'[dbo].[FK_MessageGroupMessageGroupMessager]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MessageGroupMessagers] DROP CONSTRAINT [FK_MessageGroupMessageGroupMessager];
GO
IF OBJECT_ID(N'[dbo].[FK_UserMessageUserMessage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserMessages] DROP CONSTRAINT [FK_UserMessageUserMessage];
GO
IF OBJECT_ID(N'[dbo].[FK_UserGroupName]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupNames] DROP CONSTRAINT [FK_UserGroupName];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupNameUserGroup]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserGroups] DROP CONSTRAINT [FK_GroupNameUserGroup];
GO
IF OBJECT_ID(N'[dbo].[FK_UserCustomerGoup]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CustomerGoups] DROP CONSTRAINT [FK_UserCustomerGoup];
GO
IF OBJECT_ID(N'[dbo].[FK_UserUserMessage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserMessages] DROP CONSTRAINT [FK_UserUserMessage];
GO
IF OBJECT_ID(N'[dbo].[FK_F_unitgroupF_measureunit]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[F_measureunit] DROP CONSTRAINT [FK_F_unitgroupF_measureunit];
GO
IF OBJECT_ID(N'[dbo].[FK_F_itemclassF_item]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[F_item] DROP CONSTRAINT [FK_F_itemclassF_item];
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
IF OBJECT_ID(N'[dbo].[FK_CustomGeographicTypeCustomGeographicType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CustomGeographicTypes] DROP CONSTRAINT [FK_CustomGeographicTypeCustomGeographicType];
GO
IF OBJECT_ID(N'[dbo].[FK_Geo_GraphDesktopGeoManage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DesktopGeoManages] DROP CONSTRAINT [FK_Geo_GraphDesktopGeoManage];
GO
IF OBJECT_ID(N'[dbo].[FK_CustomGeographicTypeDesktopGeoManage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DesktopGeoManages] DROP CONSTRAINT [FK_CustomGeographicTypeDesktopGeoManage];
GO
IF OBJECT_ID(N'[dbo].[FK_TaskTaskLink]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TaskLinks] DROP CONSTRAINT [FK_TaskTaskLink];
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
    ALTER TABLE [dbo].[Positions] DROP CONSTRAINT [FK_OrganizationPosition];
GO
IF OBJECT_ID(N'[dbo].[FK_DllFileStreamDllFileStream]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DllFileStreams] DROP CONSTRAINT [FK_DllFileStreamDllFileStream];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectProjectChangeEvent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProjectChangeEvents] DROP CONSTRAINT [FK_ProjectProjectChangeEvent];
GO
IF OBJECT_ID(N'[dbo].[FK_Tudi_spqxTudi_ydjh]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tudi_ydjh] DROP CONSTRAINT [FK_Tudi_spqxTudi_ydjh];
GO
IF OBJECT_ID(N'[dbo].[FK_Tudi_ywlcTudi_ydjh]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tudi_ydjh] DROP CONSTRAINT [FK_Tudi_ywlcTudi_ydjh];
GO
IF OBJECT_ID(N'[dbo].[FK_gtgl_TaskTypegtgl_TaskType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tudi_TaskTypeCode] DROP CONSTRAINT [FK_gtgl_TaskTypegtgl_TaskType];
GO
IF OBJECT_ID(N'[dbo].[FK_gtgl_TaskTypegtgl_TaskCode]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tudi_gtgl_TaskCode] DROP CONSTRAINT [FK_gtgl_TaskTypegtgl_TaskCode];
GO
IF OBJECT_ID(N'[dbo].[FK_Tudi_projInfoTudi_ApproveInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tudi_ApproveInfo] DROP CONSTRAINT [FK_Tudi_projInfoTudi_ApproveInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectTudi_projInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tudi_projInfo] DROP CONSTRAINT [FK_ProjectTudi_projInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_Tudi_projTypeTudi_projInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tudi_projInfo] DROP CONSTRAINT [FK_Tudi_projTypeTudi_projInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_Tudi_projKindTudi_projInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tudi_projInfo] DROP CONSTRAINT [FK_Tudi_projKindTudi_projInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_Tudi_shenpiqxTudi_projInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tudi_projInfo] DROP CONSTRAINT [FK_Tudi_shenpiqxTudi_projInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_Tudi_shenpiStateTudi_projInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tudi_projInfo] DROP CONSTRAINT [FK_Tudi_shenpiStateTudi_projInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_SubordinateTudi_shenpiqx]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tudi_shenpiqx] DROP CONSTRAINT [FK_SubordinateTudi_shenpiqx];
GO
IF OBJECT_ID(N'[dbo].[FK_Tudi_handleStateTudi_ApproveInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tudi_ApproveInfo] DROP CONSTRAINT [FK_Tudi_handleStateTudi_ApproveInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_Tudi_shenpiqxTudi_st_approveInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tudi_st_approveInfo] DROP CONSTRAINT [FK_Tudi_shenpiqxTudi_st_approveInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_Tudi_shenpiStateTudi_st_approveInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tudi_st_approveInfo] DROP CONSTRAINT [FK_Tudi_shenpiStateTudi_st_approveInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_Tudi_projInfoTudi_st_approveInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tudi_st_approveInfo] DROP CONSTRAINT [FK_Tudi_projInfoTudi_st_approveInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_Tudi_projInfoTudi_stph_ApproveInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tudi_stph_ApproveInfo] DROP CONSTRAINT [FK_Tudi_projInfoTudi_stph_ApproveInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_Tudi_gtgl_TaskCodeTudi_sjydbbjhfl]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tudi_sjydbbjhfl] DROP CONSTRAINT [FK_Tudi_gtgl_TaskCodeTudi_sjydbbjhfl];
GO
IF OBJECT_ID(N'[dbo].[FK_Tudi_sjydbbjhflTudi_ydjh]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tudi_ydjh] DROP CONSTRAINT [FK_Tudi_sjydbbjhflTudi_ydjh];
GO
IF OBJECT_ID(N'[dbo].[FK_SubordinateTudi_gtgl_TaskCode]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tudi_gtgl_TaskCode] DROP CONSTRAINT [FK_SubordinateTudi_gtgl_TaskCode];
GO
IF OBJECT_ID(N'[dbo].[FK_AdministrativecodeTudi_gtgl_TaskCode]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tudi_gtgl_TaskCode] DROP CONSTRAINT [FK_AdministrativecodeTudi_gtgl_TaskCode];
GO
IF OBJECT_ID(N'[dbo].[FK_Geo_GraphTudi_plotInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tudi_plotInfo] DROP CONSTRAINT [FK_Geo_GraphTudi_plotInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_Tudi_st_approveInfoTudi_st_approveInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tudi_st_approveInfo] DROP CONSTRAINT [FK_Tudi_st_approveInfoTudi_st_approveInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_Tudi_stph_ApproveInfoTudi_stph_ApproveInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tudi_stph_ApproveInfo] DROP CONSTRAINT [FK_Tudi_stph_ApproveInfoTudi_stph_ApproveInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_Tudi_dikuaiyongtuTudi_plotInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tudi_plotInfo] DROP CONSTRAINT [FK_Tudi_dikuaiyongtuTudi_plotInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_Tudi_projInfoTudi_plotInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tudi_plotInfo] DROP CONSTRAINT [FK_Tudi_projInfoTudi_plotInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_Tudi_st_approveInfoTudi_Approve_PlotInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tudi_Approve_PlotInfo] DROP CONSTRAINT [FK_Tudi_st_approveInfoTudi_Approve_PlotInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_Tudi_ApproveInfoTudi_Approve_PlotInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tudi_Approve_PlotInfo] DROP CONSTRAINT [FK_Tudi_ApproveInfoTudi_Approve_PlotInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_Tudi_stph_ApproveInfoTudi_Approve_PlotInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tudi_Approve_PlotInfo] DROP CONSTRAINT [FK_Tudi_stph_ApproveInfoTudi_Approve_PlotInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_Tudi_plotInfoTudi_Approve_PlotInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tudi_Approve_PlotInfo] DROP CONSTRAINT [FK_Tudi_plotInfoTudi_Approve_PlotInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_Tudi_dikuaiyongtuTudi_Approve_PlotInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tudi_Approve_PlotInfo] DROP CONSTRAINT [FK_Tudi_dikuaiyongtuTudi_Approve_PlotInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_physicalAssetOrganizationAssetType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrganizationAssetTypes] DROP CONSTRAINT [FK_physicalAssetOrganizationAssetType];
GO
IF OBJECT_ID(N'[dbo].[FK_AssetBaseTypeOrganizationAssetType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrganizationAssetTypes] DROP CONSTRAINT [FK_AssetBaseTypeOrganizationAssetType];
GO
IF OBJECT_ID(N'[dbo].[FK_UserEmployee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees1] DROP CONSTRAINT [FK_UserEmployee];
GO
IF OBJECT_ID(N'[dbo].[FK_PostRequirePosition]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Positions] DROP CONSTRAINT [FK_PostRequirePosition];
GO
IF OBJECT_ID(N'[dbo].[FK_PostPost]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Posts] DROP CONSTRAINT [FK_PostPost];
GO
IF OBJECT_ID(N'[dbo].[FK_IndustryCodeIndustrySolution]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[IndustrySolutions] DROP CONSTRAINT [FK_IndustryCodeIndustrySolution];
GO
IF OBJECT_ID(N'[dbo].[FK_PositionEmployee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees1] DROP CONSTRAINT [FK_PositionEmployee];
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
    ALTER TABLE [dbo].[Posts] DROP CONSTRAINT [FK_OrganizationPost];
GO
IF OBJECT_ID(N'[dbo].[FK_WorkSpaceWorkSpace]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WorkSpaces] DROP CONSTRAINT [FK_WorkSpaceWorkSpace];
GO
IF OBJECT_ID(N'[dbo].[FK_OrganizationEmployee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees1] DROP CONSTRAINT [FK_OrganizationEmployee];
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
IF OBJECT_ID(N'[dbo].[FK_IndustrySolutionWorkModul]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WorkModuls] DROP CONSTRAINT [FK_IndustrySolutionWorkModul];
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
IF OBJECT_ID(N'[dbo].[FK_UserCustomerGoup1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CustomerGoups] DROP CONSTRAINT [FK_UserCustomerGoup1];
GO
IF OBJECT_ID(N'[dbo].[FK_EmployeeJobChange]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[JobChanges] DROP CONSTRAINT [FK_EmployeeJobChange];
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

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Organizations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Organizations];
GO
IF OBJECT_ID(N'[dbo].[Organization_ContactTables]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Organization_ContactTables];
GO
IF OBJECT_ID(N'[dbo].[Positions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Positions];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[User_ContactTable]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User_ContactTable];
GO
IF OBJECT_ID(N'[dbo].[Tasks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tasks];
GO
IF OBJECT_ID(N'[dbo].[Projects]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Projects];
GO
IF OBJECT_ID(N'[dbo].[LoginLogs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LoginLogs];
GO
IF OBJECT_ID(N'[dbo].[Land_Graphs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Land_Graphs];
GO
IF OBJECT_ID(N'[dbo].[Land_Types]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Land_Types];
GO
IF OBJECT_ID(N'[dbo].[Land_Image]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Land_Image];
GO
IF OBJECT_ID(N'[dbo].[Land_Video]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Land_Video];
GO
IF OBJECT_ID(N'[dbo].[IncurredExpenses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[IncurredExpenses];
GO
IF OBJECT_ID(N'[dbo].[Project_Expense]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Project_Expense];
GO
IF OBJECT_ID(N'[dbo].[Land_DemolitionContracts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Land_DemolitionContracts];
GO
IF OBJECT_ID(N'[dbo].[OrganizationTransitions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrganizationTransitions];
GO
IF OBJECT_ID(N'[dbo].[Land_Graph_Handles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Land_Graph_Handles];
GO
IF OBJECT_ID(N'[dbo].[Land_Ownerships]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Land_Ownerships];
GO
IF OBJECT_ID(N'[dbo].[TaskEquipments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TaskEquipments];
GO
IF OBJECT_ID(N'[dbo].[Organization_Type]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Organization_Type];
GO
IF OBJECT_ID(N'[dbo].[DocumentManages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DocumentManages];
GO
IF OBJECT_ID(N'[dbo].[UserMessages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserMessages];
GO
IF OBJECT_ID(N'[dbo].[UserGroups]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserGroups];
GO
IF OBJECT_ID(N'[dbo].[OrganizationOtherNames]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrganizationOtherNames];
GO
IF OBJECT_ID(N'[dbo].[Land_TaskType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Land_TaskType];
GO
IF OBJECT_ID(N'[dbo].[TaskStates]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TaskStates];
GO
IF OBJECT_ID(N'[dbo].[Land_manager]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Land_manager];
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
IF OBJECT_ID(N'[dbo].[TaskItems]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TaskItems];
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
IF OBJECT_ID(N'[dbo].[Posts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Posts];
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
IF OBJECT_ID(N'[dbo].[GBT_13923_2006s]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GBT_13923_2006s];
GO
IF OBJECT_ID(N'[dbo].[ProjectLocations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProjectLocations];
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
IF OBJECT_ID(N'[dbo].[MessageGroupMessagers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MessageGroupMessagers];
GO
IF OBJECT_ID(N'[dbo].[GroupNames]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GroupNames];
GO
IF OBJECT_ID(N'[dbo].[CustomerGoups]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CustomerGoups];
GO
IF OBJECT_ID(N'[dbo].[DllFileStreams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DllFileStreams];
GO
IF OBJECT_ID(N'[dbo].[F_Currency]', 'U') IS NOT NULL
    DROP TABLE [dbo].[F_Currency];
GO
IF OBJECT_ID(N'[dbo].[F_unitgroup]', 'U') IS NOT NULL
    DROP TABLE [dbo].[F_unitgroup];
GO
IF OBJECT_ID(N'[dbo].[F_measureunit]', 'U') IS NOT NULL
    DROP TABLE [dbo].[F_measureunit];
GO
IF OBJECT_ID(N'[dbo].[F_account]', 'U') IS NOT NULL
    DROP TABLE [dbo].[F_account];
GO
IF OBJECT_ID(N'[dbo].[F_itemclass]', 'U') IS NOT NULL
    DROP TABLE [dbo].[F_itemclass];
GO
IF OBJECT_ID(N'[dbo].[F_item]', 'U') IS NOT NULL
    DROP TABLE [dbo].[F_item];
GO
IF OBJECT_ID(N'[dbo].[FinaceAccoutTabs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FinaceAccoutTabs];
GO
IF OBJECT_ID(N'[dbo].[OrganizationCustomTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrganizationCustomTypes];
GO
IF OBJECT_ID(N'[dbo].[CustomCategories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CustomCategories];
GO
IF OBJECT_ID(N'[dbo].[DesktopGeoManages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DesktopGeoManages];
GO
IF OBJECT_ID(N'[dbo].[CustomGeographicTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CustomGeographicTypes];
GO
IF OBJECT_ID(N'[dbo].[TaskLinks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TaskLinks];
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
IF OBJECT_ID(N'[dbo].[ProjectChangeEvents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProjectChangeEvents];
GO
IF OBJECT_ID(N'[dbo].[Tudi_spqx]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tudi_spqx];
GO
IF OBJECT_ID(N'[dbo].[Tudi_ywlc]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tudi_ywlc];
GO
IF OBJECT_ID(N'[dbo].[Tudi_ydjh]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tudi_ydjh];
GO
IF OBJECT_ID(N'[dbo].[Tudi_sjydbbjhfl]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tudi_sjydbbjhfl];
GO
IF OBJECT_ID(N'[dbo].[Tudi_TaskTypeCode]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tudi_TaskTypeCode];
GO
IF OBJECT_ID(N'[dbo].[Tudi_gtgl_TaskCode]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tudi_gtgl_TaskCode];
GO
IF OBJECT_ID(N'[dbo].[Tudi_projInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tudi_projInfo];
GO
IF OBJECT_ID(N'[dbo].[Tudi_plotInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tudi_plotInfo];
GO
IF OBJECT_ID(N'[dbo].[Tudi_projType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tudi_projType];
GO
IF OBJECT_ID(N'[dbo].[Tudi_shenpiState]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tudi_shenpiState];
GO
IF OBJECT_ID(N'[dbo].[Tudi_shenpiqx]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tudi_shenpiqx];
GO
IF OBJECT_ID(N'[dbo].[Tudi_dikuaiyongtu]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tudi_dikuaiyongtu];
GO
IF OBJECT_ID(N'[dbo].[Tudi_projKind]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tudi_projKind];
GO
IF OBJECT_ID(N'[dbo].[Tudi_handleState]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tudi_handleState];
GO
IF OBJECT_ID(N'[dbo].[Tudi_ApproveInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tudi_ApproveInfo];
GO
IF OBJECT_ID(N'[dbo].[Tudi_st_approveInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tudi_st_approveInfo];
GO
IF OBJECT_ID(N'[dbo].[Tudi_stph_ApproveInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tudi_stph_ApproveInfo];
GO
IF OBJECT_ID(N'[dbo].[Tudi_HandleStep_State]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tudi_HandleStep_State];
GO
IF OBJECT_ID(N'[dbo].[Tudi_Approve_PlotInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tudi_Approve_PlotInfo];
GO
IF OBJECT_ID(N'[dbo].[OrganizationAssetTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrganizationAssetTypes];
GO
IF OBJECT_ID(N'[dbo].[GeoGraphs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GeoGraphs];
GO
IF OBJECT_ID(N'[dbo].[Employees1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees1];
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

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Organizations'
CREATE TABLE [dbo].[Organizations] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [OrganizationCode] nvarchar(max)  NULL,
    [OrgaName] nvarchar(max)  NOT NULL,
    [Certificates] nvarchar(max)  NULL,
    [EstablishmentDate] datetime  NULL,
    [Parent] int  NULL,
    [MarkerString] nvarchar(max)  NULL,
    [IsValid] bit  NOT NULL,
    [Type] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Organization_ContactTables'
CREATE TABLE [dbo].[Organization_ContactTables] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [OrganizBasicID] int  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Tools] nvarchar(max)  NULL,
    [Value] nvarchar(max)  NULL,
    [IsValid] bit  NOT NULL
);
GO

-- Creating table 'Positions'
CREATE TABLE [dbo].[Positions] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [IsValid] bit  NOT NULL,
    [PositionType] nvarchar(max)  NULL,
    [PositionTile] nvarchar(max)  NULL,
    [TaskNature] nvarchar(max)  NULL,
    [WorkLocation] nvarchar(max)  NULL,
    [SolaryStandard] nvarchar(max)  NULL,
    [PositionID] int  NULL,
    [OrganizationID] int  NOT NULL,
    [IsAdministrator] bit  NOT NULL,
    [PostRequireID] int  NULL,
    [PositionLevel] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [ActualName] nvarchar(max)  NULL,
    [Status] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'User_ContactTable'
CREATE TABLE [dbo].[User_ContactTable] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Tools] nvarchar(max)  NOT NULL,
    [Value] nvarchar(max)  NOT NULL,
    [UserID] int  NULL
);
GO

-- Creating table 'Tasks'
CREATE TABLE [dbo].[Tasks] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Content] nvarchar(max)  NOT NULL,
    [Creater] nvarchar(max)  NULL,
    [PreviousTask] nvarchar(max)  NOT NULL,
    [Task_TypeID] int  NULL,
    [TaskStateID] int  NOT NULL,
    [ProjectID] int  NOT NULL,
    [ParentTask] int  NULL,
    [StartTime] datetime  NULL,
    [EndTime] datetime  NULL
);
GO

-- Creating table 'Projects'
CREATE TABLE [dbo].[Projects] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ProjectName] nvarchar(max)  NOT NULL,
    [ProjectContent] nvarchar(max)  NOT NULL,
    [BeginTime] datetime  NULL,
    [EndTime] datetime  NULL,
    [Creater] int  NULL,
    [CreatTime] datetime  NOT NULL,
    [ProjectID] int  NULL,
    [WorkSpaceId] int  NULL,
    [WorkSpaceManageId] int  NULL
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

-- Creating table 'Land_Graphs'
CREATE TABLE [dbo].[Land_Graphs] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Geometry] geometry  NULL,
    [Area] nvarchar(max)  NULL,
    [geography] geography  NULL,
    [Points] nvarchar(max)  NULL,
    [X3DPoints] nvarchar(max)  NULL,
    [CoordinarySystem] nvarchar(max)  NULL,
    [SourcesTable] nvarchar(max)  NULL,
    [SourcesID] nvarchar(max)  NULL,
    [GeometryType] nvarchar(max)  NULL,
    [GraphName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Land_Types'
CREATE TABLE [dbo].[Land_Types] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Content] nvarchar(max)  NULL,
    [Level] int  NOT NULL,
    [Keys] nvarchar(max)  NOT NULL,
    [ParentID] int  NULL,
    [Type_Code] nvarchar(max)  NOT NULL,
    [ParentCode] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Land_Image'
CREATE TABLE [dbo].[Land_Image] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Publisher] nvarchar(max)  NULL,
    [PhotoDate] nvarchar(max)  NULL,
    [PhotoPath] nvarchar(max)  NULL,
    [Land_managerID] int  NOT NULL,
    [Photo] varbinary(max)  NULL
);
GO

-- Creating table 'Land_Video'
CREATE TABLE [dbo].[Land_Video] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [VideoPath] nvarchar(max)  NULL,
    [Publisher] nvarchar(max)  NULL,
    [VideoDate] nvarchar(max)  NULL,
    [Name] nvarchar(max)  NOT NULL,
    [VideoStream] varbinary(max)  NULL,
    [Land_GraphID] int  NOT NULL,
    [Land_managerID] int  NOT NULL
);
GO

-- Creating table 'IncurredExpenses'
CREATE TABLE [dbo].[IncurredExpenses] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [ContentDescription] nvarchar(max)  NOT NULL,
    [Place] nvarchar(max)  NOT NULL,
    [ReceiptNumber] nvarchar(max)  NOT NULL,
    [Amount] nvarchar(max)  NOT NULL,
    [TaskID] int  NOT NULL,
    [ExpenseType] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Project_Expense'
CREATE TABLE [dbo].[Project_Expense] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [CurrencyType] nvarchar(max)  NOT NULL,
    [EstimateExpense] nvarchar(max)  NOT NULL,
    [ProjectID] int  NOT NULL
);
GO

-- Creating table 'Land_DemolitionContracts'
CREATE TABLE [dbo].[Land_DemolitionContracts] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Number] nvarchar(max)  NOT NULL,
    [Department] nvarchar(max)  NULL,
    [Land_GraphID] int  NOT NULL,
    [ContractPath] nvarchar(100)  NULL,
    [Land_managerID] int  NOT NULL,
    [binary] varbinary(max)  NULL
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

-- Creating table 'Land_Graph_Handles'
CREATE TABLE [dbo].[Land_Graph_Handles] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [TaskContent] nvarchar(max)  NOT NULL,
    [ChangeDate] nvarchar(max)  NOT NULL,
    [CurrentState] int  NOT NULL,
    [Notes] nvarchar(max)  NOT NULL,
    [Land_TaskTypeID] int  NOT NULL,
    [Implementer] nvarchar(max)  NOT NULL,
    [Land_managerID] int  NOT NULL
);
GO

-- Creating table 'Land_Ownerships'
CREATE TABLE [dbo].[Land_Ownerships] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [OwnerName] nvarchar(max)  NOT NULL,
    [Type] nvarchar(max)  NULL,
    [Certificate] nvarchar(max)  NULL,
    [Note] nvarchar(max)  NULL,
    [Situation] nvarchar(max)  NULL,
    [Attitude] nvarchar(max)  NULL,
    [Land_managerID] int  NOT NULL
);
GO

-- Creating table 'TaskEquipments'
CREATE TABLE [dbo].[TaskEquipments] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [ModelID] nvarchar(max)  NOT NULL,
    [Standard] nvarchar(max)  NOT NULL,
    [TaskSheetID] int  NULL,
    [TaskID] int  NOT NULL
);
GO

-- Creating table 'Organization_Type'
CREATE TABLE [dbo].[Organization_Type] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Ocode] nvarchar(max)  NOT NULL,
    [OName] nvarchar(max)  NOT NULL,
    [Descript] nvarchar(max)  NULL,
    [ParentCode] nvarchar(max)  NULL,
    [Parent] int  NULL
);
GO

-- Creating table 'DocumentManages'
CREATE TABLE [dbo].[DocumentManages] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Doctype] nvarchar(max)  NOT NULL,
    [Content] nvarchar(max)  NOT NULL,
    [URL] nvarchar(max)  NOT NULL,
    [Handler] nvarchar(max)  NULL,
    [DocManageStateID] int  NOT NULL,
    [DocumentTypeID] int  NULL,
    [HandeTime] nvarchar(max)  NOT NULL,
    [EventTimeEventTimeID] int  NULL,
    [DocCheckStateID] int  NOT NULL,
    [SecurityinfoID] int  NULL
);
GO

-- Creating table 'UserMessages'
CREATE TABLE [dbo].[UserMessages] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Content] nvarchar(max)  NOT NULL,
    [ReplyID] int  NULL,
    [CreateTime] datetime  NOT NULL,
    [State] nvarchar(max)  NOT NULL,
    [LoginLogID] int  NULL,
    [SenderID] int  NOT NULL
);
GO

-- Creating table 'UserGroups'
CREATE TABLE [dbo].[UserGroups] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Creator] nvarchar(max)  NOT NULL,
    [UserID] int  NOT NULL,
    [CreateTime] datetime  NOT NULL,
    [State] nvarchar(max)  NOT NULL,
    [GroupNameID] int  NOT NULL,
    [Rule] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'OrganizationOtherNames'
CREATE TABLE [dbo].[OrganizationOtherNames] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [OtherName] nvarchar(max)  NOT NULL,
    [OrganizationID] int  NOT NULL
);
GO

-- Creating table 'Land_TaskType'
CREATE TABLE [dbo].[Land_TaskType] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [TypeName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'TaskStates'
CREATE TABLE [dbo].[TaskStates] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [TaskStateName] nvarchar(max)  NOT NULL,
    [State] nvarchar(max)  NOT NULL,
    [Descript] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Land_manager'
CREATE TABLE [dbo].[Land_manager] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Geo_GraphID] int  NOT NULL,
    [Land_TypeID] int  NOT NULL,
    [Land_Item] int  NULL,
    [HanderState] int  NOT NULL,
    [StandardadministrativecodeSacID] int  NOT NULL,
    [BussnessVerID] int  NOT NULL,
    [ProjectID] int  NULL
);
GO

-- Creating table 'Administrativecodes'
CREATE TABLE [dbo].[Administrativecodes] (
    [SacID] int IDENTITY(1,1) NOT NULL,
    [DivisionCode] nvarchar(max)  NOT NULL,
    [RegionName] nvarchar(max)  NOT NULL,
    [ParentCode] nvarchar(max)  NOT NULL,
    [Parent] int  NULL,
    [Geometry] geography  NULL
);
GO

-- Creating table 'DocumentTypes'
CREATE TABLE [dbo].[DocumentTypes] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [TypeName] nvarchar(max)  NOT NULL,
    [Type] nvarchar(max)  NOT NULL,
    [Note] nvarchar(max)  NOT NULL,
    [DocumentTypeID] int  NULL,
    [OrigId] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'DocManageStates'
CREATE TABLE [dbo].[DocManageStates] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [DState] nvarchar(max)  NOT NULL,
    [DStateName] nvarchar(max)  NOT NULL,
    [DocManageStateID] int  NULL
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

-- Creating table 'TaskItems'
CREATE TABLE [dbo].[TaskItems] (
    [TaskItemID] int IDENTITY(1,1) NOT NULL,
    [ItemName] nvarchar(max)  NOT NULL,
    [ItemContent] nvarchar(max)  NOT NULL,
    [TaskID] int  NOT NULL,
    [BeginTime] nvarchar(max)  NOT NULL,
    [EndTime] nvarchar(max)  NOT NULL
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
    [ParentCode] nvarchar(max)  NULL
);
GO

-- Creating table 'IndustryCodes'
CREATE TABLE [dbo].[IndustryCodes] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Code] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NULL,
    [Descript] nvarchar(max)  NULL,
    [Parent] int  NULL,
    [ParentCode] nvarchar(max)  NULL
);
GO

-- Creating table 'ZipCodes'
CREATE TABLE [dbo].[ZipCodes] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Code] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'IPCodes'
CREATE TABLE [dbo].[IPCodes] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [IP] nvarchar(max)  NOT NULL,
    [Company] nvarchar(max)  NULL
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
    [IsValid] bit  NOT NULL
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

-- Creating table 'Posts'
CREATE TABLE [dbo].[Posts] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [PostName] nvarchar(max)  NOT NULL,
    [DepartmentID] int  NOT NULL,
    [Descript] nvarchar(max)  NULL,
    [MarkerString] nvarchar(max)  NULL,
    [IsValid] bit  NOT NULL,
    [Jobname] nvarchar(max)  NOT NULL,
    [PositionID] int  NOT NULL,
    [PostID] int  NULL,
    [OrganizationID] int  NOT NULL,
    [PositionID1] int  NULL
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
    [WorkModulId] int  NULL
);
GO

-- Creating table 'Subordinates'
CREATE TABLE [dbo].[Subordinates] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Code] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Descript] nvarchar(max)  NULL
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
    [Notes] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'UserRelateTypes'
CREATE TABLE [dbo].[UserRelateTypes] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Descript] nvarchar(max)  NULL,
    [Parent] int  NULL
);
GO

-- Creating table 'GBT_13923_2006s'
CREATE TABLE [dbo].[GBT_13923_2006s] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Code] nvarchar(max)  NOT NULL,
    [FeatureName] nvarchar(max)  NOT NULL,
    [t5_2K] bit  NULL,
    [K5_100K] bit  NULL,
    [K25_M] bit  NULL,
    [Parent] int  NULL,
    [BussnessVerID] int  NOT NULL,
    [Extend] nvarchar(max)  NULL,
    [Descript] nvarchar(max)  NULL
);
GO

-- Creating table 'ProjectLocations'
CREATE TABLE [dbo].[ProjectLocations] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ProjectID] int  NULL,
    [Geometry] geometry  NULL,
    [CoordinarySystem] nvarchar(max)  NULL
);
GO

-- Creating table 'DocumentContents'
CREATE TABLE [dbo].[DocumentContents] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Content] nvarchar(max)  NOT NULL,
    [Message] nvarchar(max)  NOT NULL,
    [DocumentManageID] int  NULL,
    [DocumentContentID] int  NULL,
    [workTaskId] int  NULL
);
GO

-- Creating table 'DocCheckStates'
CREATE TABLE [dbo].[DocCheckStates] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Post] nvarchar(max)  NOT NULL,
    [UserName] nvarchar(max)  NOT NULL,
    [CheckState] bit  NOT NULL,
    [CheckTime] datetime  NULL
);
GO

-- Creating table 'Securityinfoes'
CREATE TABLE [dbo].[Securityinfoes] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [SecurityName] nvarchar(max)  NOT NULL,
    [Level] int  NOT NULL,
    [Descript] nvarchar(max)  NULL,
    [SecurityinfoID] int  NULL
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
    [Currency] nvarchar(max)  NOT NULL
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
    [RecordeTime] datetime  NOT NULL
);
GO

-- Creating table 'RegisterDocumentTypes'
CREATE TABLE [dbo].[RegisterDocumentTypes] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [TypeName] nvarchar(max)  NOT NULL
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

-- Creating table 'MessageGroupMessagers'
CREATE TABLE [dbo].[MessageGroupMessagers] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Content] nvarchar(max)  NOT NULL,
    [MessageGroupID] int  NOT NULL,
    [SendTime] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'GroupNames'
CREATE TABLE [dbo].[GroupNames] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [CreatTime] nvarchar(max)  NOT NULL,
    [UserID] int  NOT NULL,
    [GroupNumber] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CustomerGoups'
CREATE TABLE [dbo].[CustomerGoups] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [GroupName] nvarchar(max)  NOT NULL,
    [CreatID] int  NOT NULL,
    [UserID] int  NULL
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
    [Paragram] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'F_Currency'
CREATE TABLE [dbo].[F_Currency] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [CurrencyName] nvarchar(max)  NOT NULL,
    [CurrencyType] nvarchar(max)  NOT NULL,
    [Symbol] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'F_unitgroup'
CREATE TABLE [dbo].[F_unitgroup] (
    [ID] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'F_measureunit'
CREATE TABLE [dbo].[F_measureunit] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [F_unitgroupID] int  NOT NULL
);
GO

-- Creating table 'F_account'
CREATE TABLE [dbo].[F_account] (
    [ID] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'F_itemclass'
CREATE TABLE [dbo].[F_itemclass] (
    [ID] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'F_item'
CREATE TABLE [dbo].[F_item] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [F_itemclassID] int  NOT NULL
);
GO

-- Creating table 'FinaceAccoutTabs'
CREATE TABLE [dbo].[FinaceAccoutTabs] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Code] float  NULL,
    [Fname] nvarchar(255)  NULL,
    [Scope] nvarchar(255)  NULL,
    [Parent] nvarchar(255)  NULL
);
GO

-- Creating table 'OrganizationCustomTypes'
CREATE TABLE [dbo].[OrganizationCustomTypes] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [OrganizationID] int  NOT NULL,
    [CustomCategoryID] int  NOT NULL,
    [note] nvarchar(max)  NOT NULL
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

-- Creating table 'DesktopGeoManages'
CREATE TABLE [dbo].[DesktopGeoManages] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Tile] nvarchar(max)  NOT NULL,
    [EventTimeEventTimeID] int  NULL,
    [Content] nvarchar(max)  NOT NULL,
    [Descript] nvarchar(max)  NOT NULL,
    [link] nvarchar(max)  NOT NULL,
    [Geo_GraphID] int  NOT NULL,
    [CustomGeographicTypeID] int  NOT NULL
);
GO

-- Creating table 'CustomGeographicTypes'
CREATE TABLE [dbo].[CustomGeographicTypes] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [TypeName] nvarchar(max)  NOT NULL,
    [Descript] nvarchar(max)  NOT NULL,
    [CustomGeographicTypeID] int  NULL,
    [EventTimeEventTimeID] int  NULL
);
GO

-- Creating table 'TaskLinks'
CREATE TABLE [dbo].[TaskLinks] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [LinkName] nvarchar(max)  NOT NULL,
    [LinkType] nvarchar(max)  NOT NULL,
    [Location] nvarchar(max)  NOT NULL,
    [Descript] nvarchar(max)  NOT NULL,
    [TaskID] int  NULL
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
    [OrganizationID] int  NULL
);
GO

-- Creating table 'ProductEvents'
CREATE TABLE [dbo].[ProductEvents] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [EventName] nvarchar(max)  NOT NULL,
    [Content] nvarchar(max)  NOT NULL,
    [EventTime] datetime  NOT NULL,
    [ProductId] int  NOT NULL,
    [Creater] int  NOT NULL
);
GO

-- Creating table 'ProductCompositions'
CREATE TABLE [dbo].[ProductCompositions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ChildProductId] int  NOT NULL,
    [Function] nvarchar(max)  NOT NULL,
    [descript] nvarchar(max)  NOT NULL,
    [Value] nvarchar(max)  NOT NULL,
    [ProductCompositionId] int  NOT NULL
);
GO

-- Creating table 'ProductCustomTypes'
CREATE TABLE [dbo].[ProductCustomTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProductId] int  NOT NULL,
    [ProductCustomCategoryId] int  NOT NULL,
    [Descript] nvarchar(max)  NULL
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
    [MaintenancePeriod] datetimeoffset  NULL
);
GO

-- Creating table 'AssetUses'
CREATE TABLE [dbo].[AssetUses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [physicalAssetId] int  NOT NULL,
    [UseType] nvarchar(max)  NOT NULL,
    [User] nvarchar(max)  NOT NULL,
    [UseTime] nvarchar(max)  NOT NULL,
    [PlaceOfUse] nvarchar(max)  NULL
);
GO

-- Creating table 'AssetMaintenances'
CREATE TABLE [dbo].[AssetMaintenances] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [physicalAssetId] int  NOT NULL,
    [Maintenancer] int  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Experience] nvarchar(max)  NULL
);
GO

-- Creating table 'AssetBaseTypes'
CREATE TABLE [dbo].[AssetBaseTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TypeName] nvarchar(max)  NOT NULL,
    [Note] nvarchar(max)  NULL,
    [OrganizationID] int  NOT NULL,
    [AssetTypeId] int  NULL
);
GO

-- Creating table 'ProjectChangeEvents'
CREATE TABLE [dbo].[ProjectChangeEvents] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProjectID] int  NOT NULL,
    [Cause] nvarchar(max)  NOT NULL,
    [FielName] nvarchar(max)  NOT NULL,
    [Value] nvarchar(max)  NOT NULL,
    [Changer] nvarchar(max)  NOT NULL,
    [ChangeTime] datetime  NOT NULL
);
GO

-- Creating table 'Tudi_spqx'
CREATE TABLE [dbo].[Tudi_spqx] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Code] nvarchar(max)  NOT NULL,
    [Level] nvarchar(max)  NOT NULL,
    [Note] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Tudi_ywlc'
CREATE TABLE [dbo].[Tudi_ywlc] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Code] nvarchar(max)  NOT NULL,
    [Note] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Tudi_ydjh'
CREATE TABLE [dbo].[Tudi_ydjh] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TypeName] nvarchar(max)  NOT NULL,
    [Content] nvarchar(max)  NOT NULL,
    [exchangecontent] nvarchar(max)  NOT NULL,
    [exchangeFormat] nvarchar(max)  NOT NULL,
    [Tudi_spqxId] int  NOT NULL,
    [Tudi_ywlcId] int  NOT NULL,
    [Tudi_sjydbbjhflId] int  NOT NULL
);
GO

-- Creating table 'Tudi_sjydbbjhfl'
CREATE TABLE [dbo].[Tudi_sjydbbjhfl] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Tudi_gtgl_TaskCodeId] int  NOT NULL,
    [Code] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Tudi_TaskTypeCode'
CREATE TABLE [dbo].[Tudi_TaskTypeCode] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Code] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Parent] int  NULL
);
GO

-- Creating table 'Tudi_gtgl_TaskCode'
CREATE TABLE [dbo].[Tudi_gtgl_TaskCode] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AdministrativecodeSacID] int  NOT NULL,
    [TypeCode] int  NOT NULL,
    [xzjb] nvarchar(max)  NOT NULL,
    [SubordinateID] int  NULL
);
GO

-- Creating table 'Tudi_projInfo'
CREATE TABLE [dbo].[Tudi_projInfo] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProjectID] int  NOT NULL,
    [proj_no] nvarchar(max)  NOT NULL,
    [proj_name] nvarchar(max)  NOT NULL,
    [canton_code] nvarchar(max)  NOT NULL,
    [Tudi_projTypeId] int  NOT NULL,
    [accept_date] nvarchar(max)  NOT NULL,
    [Tudi_projKindId] int  NOT NULL,
    [Farm_Tot] nvarchar(max)  NOT NULL,
    [Farm_State] nvarchar(max)  NOT NULL,
    [Farm_Group] nvarchar(max)  NOT NULL,
    [Tilth_State] nvarchar(max)  NOT NULL,
    [Tilth_Group] nvarchar(max)  NOT NULL,
    [BF_Group] nvarchar(max)  NOT NULL,
    [Build_Tot] nvarchar(max)  NOT NULL,
    [Build_Group] nvarchar(max)  NOT NULL,
    [Build_State] nvarchar(max)  NOT NULL,
    [UnUsed_Tot] nvarchar(max)  NOT NULL,
    [UnUsed_Group] nvarchar(max)  NOT NULL,
    [UnUsed_State] nvarchar(max)  NOT NULL,
    [Pay_std] nvarchar(max)  NOT NULL,
    [Reset_Farmer] nvarchar(max)  NOT NULL,
    [Labour_Force] nvarchar(max)  NOT NULL,
    [put_way] nvarchar(max)  NOT NULL,
    [approve_state] nvarchar(max)  NOT NULL,
    [Tudi_shenpiStateId] int  NOT NULL,
    [Tudi_Approve_type] int  NOT NULL
);
GO

-- Creating table 'Tudi_plotInfo'
CREATE TABLE [dbo].[Tudi_plotInfo] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [proj_no] nvarchar(max)  NOT NULL,
    [Plotid] nvarchar(max)  NOT NULL,
    [plotname] nvarchar(max)  NOT NULL,
    [total_area] nvarchar(max)  NOT NULL,
    [Geo_GraphID] int  NULL,
    [Tudi_dikuaiyongtuId] int  NOT NULL,
    [Tudi_projInfoId] int  NOT NULL
);
GO

-- Creating table 'Tudi_projType'
CREATE TABLE [dbo].[Tudi_projType] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [StringCode] nvarchar(max)  NOT NULL,
    [Content] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Tudi_shenpiState'
CREATE TABLE [dbo].[Tudi_shenpiState] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [State] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Tudi_shenpiqx'
CREATE TABLE [dbo].[Tudi_shenpiqx] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SubordinateID] int  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [LevelCode] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Tudi_dikuaiyongtu'
CREATE TABLE [dbo].[Tudi_dikuaiyongtu] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Note] nvarchar(max)  NULL
);
GO

-- Creating table 'Tudi_projKind'
CREATE TABLE [dbo].[Tudi_projKind] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Note] nvarchar(max)  NULL
);
GO

-- Creating table 'Tudi_handleState'
CREATE TABLE [dbo].[Tudi_handleState] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Tudi_ApproveInfo'
CREATE TABLE [dbo].[Tudi_ApproveInfo] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Tudi_projInfoId] int  NOT NULL,
    [Proj_no] nvarchar(max)  NOT NULL,
    [Proj_name] nvarchar(max)  NOT NULL,
    [Receivtime] nvarchar(max)  NOT NULL,
    [Xmstate] nvarchar(max)  NOT NULL,
    [Tudi_handleStateId] int  NOT NULL,
    [Chargerarea] nvarchar(max)  NOT NULL,
    [Notetime] nvarchar(max)  NOT NULL,
    [Chargevalue] nvarchar(max)  NOT NULL,
    [Responsetime] nvarchar(max)  NOT NULL,
    [ResponseNo] nvarchar(max)  NOT NULL,
    [Responsarea] nvarchar(max)  NOT NULL,
    [Fram_tot] nvarchar(max)  NOT NULL,
    [Fram_state] nvarchar(max)  NOT NULL,
    [Fram_group] nvarchar(max)  NOT NULL,
    [Tilth_state] nvarchar(max)  NOT NULL,
    [Tilth_group] nvarchar(max)  NOT NULL,
    [BF_group] nvarchar(max)  NOT NULL,
    [Build_tot] nvarchar(max)  NOT NULL,
    [Build_group] nvarchar(max)  NOT NULL,
    [Build_state] nvarchar(max)  NOT NULL,
    [Unused_tot] nvarchar(max)  NOT NULL,
    [Unused_Group] nvarchar(max)  NOT NULL,
    [Unused_state] nvarchar(max)  NOT NULL,
    [Pay_std] nvarchar(max)  NOT NULL,
    [Reset_farmer] nvarchar(max)  NOT NULL,
    [Labour_force] nvarchar(max)  NOT NULL,
    [Pay_way] nvarchar(max)  NOT NULL,
    [check_Area] nvarchar(max)  NOT NULL,
    [Chk_Tilth_Area] nvarchar(max)  NOT NULL,
    [Responsefile] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Tudi_st_approveInfo'
CREATE TABLE [dbo].[Tudi_st_approveInfo] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Proj_no] nvarchar(max)  NOT NULL,
    [Approve_notion] nvarchar(max)  NOT NULL,
    [Fram_tot] nvarchar(max)  NOT NULL,
    [Fram_state] nvarchar(max)  NOT NULL,
    [Fram_group] nvarchar(max)  NOT NULL,
    [Tilth_State] nvarchar(max)  NOT NULL,
    [Tilth_group] nvarchar(max)  NOT NULL,
    [BF_group] nvarchar(max)  NOT NULL,
    [Build_tot] nvarchar(max)  NOT NULL,
    [Build_state] nvarchar(max)  NOT NULL,
    [Build_group] nvarchar(max)  NOT NULL,
    [Unused_tot] nvarchar(max)  NOT NULL,
    [Unused_state] nvarchar(max)  NOT NULL,
    [Unuserd_group] nvarchar(max)  NOT NULL,
    [Pay_std] nvarchar(max)  NOT NULL,
    [Reset_farmer] nvarchar(max)  NOT NULL,
    [Labour_force] nvarchar(max)  NOT NULL,
    [Pay_way] nvarchar(max)  NOT NULL,
    [Check_Area] nvarchar(max)  NOT NULL,
    [Chk_Tilth_Area] nvarchar(max)  NOT NULL,
    [Approve_state] nvarchar(max)  NOT NULL,
    [Approve_type] nvarchar(max)  NOT NULL,
    [Tudi_shenpiqxId] int  NOT NULL,
    [Tudi_shenpiStateId] int  NOT NULL,
    [Tudi_projInfoId] int  NOT NULL,
    [Tudi_st_approveInfoId] int  NULL
);
GO

-- Creating table 'Tudi_stph_ApproveInfo'
CREATE TABLE [dbo].[Tudi_stph_ApproveInfo] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Proj_no] nvarchar(max)  NOT NULL,
    [Approve_notion] nvarchar(max)  NOT NULL,
    [Appr_no] nvarchar(max)  NOT NULL,
    [App_date] nvarchar(max)  NOT NULL,
    [Appr_date] nvarchar(max)  NOT NULL,
    [Appr_area] nvarchar(max)  NOT NULL,
    [Farm_tot] nvarchar(max)  NOT NULL,
    [Grp_farm_area] nvarchar(max)  NOT NULL,
    [State_farm_area] nvarchar(max)  NOT NULL,
    [Grp_tilth_area] nvarchar(max)  NOT NULL,
    [State_tilth_area] nvarchar(max)  NOT NULL,
    [Bf_group] nvarchar(max)  NOT NULL,
    [Build_tot] nvarchar(max)  NOT NULL,
    [Grp_bld_area] nvarchar(max)  NOT NULL,
    [State_bld_area] nvarchar(max)  NOT NULL,
    [Unused_tot] nvarchar(max)  NOT NULL,
    [Grp_unused_area] nvarchar(max)  NOT NULL,
    [State_unused_area] nvarchar(max)  NOT NULL,
    [Check_area] nvarchar(max)  NOT NULL,
    [Chk_tilth_area] nvarchar(max)  NOT NULL,
    [Supply_tilth_area] nvarchar(max)  NOT NULL,
    [Plan_tilth_area] nvarchar(max)  NOT NULL,
    [Plan_tlth_Area] nvarchar(max)  NOT NULL,
    [Posit_tilth_pop] nvarchar(max)  NOT NULL,
    [Posit_labour] nvarchar(max)  NOT NULL,
    [Put_way] nvarchar(max)  NOT NULL,
    [Transfer_area] nvarchar(max)  NOT NULL,
    [Remise_area] nvarchar(max)  NOT NULL,
    [Remise_money] nvarchar(max)  NOT NULL,
    [Lease_area] nvarchar(max)  NOT NULL,
    [Year_money] nvarchar(max)  NOT NULL,
    [Stock_area] nvarchar(max)  NOT NULL,
    [Stock_money] nvarchar(max)  NOT NULL,
    [Approve_state] nvarchar(max)  NOT NULL,
    [Approve_type] nvarchar(max)  NOT NULL,
    [Tudi_projInfoId] int  NOT NULL,
    [Tudi_stph_ApproveInfoId] int  NULL
);
GO

-- Creating table 'Tudi_HandleStep_State'
CREATE TABLE [dbo].[Tudi_HandleStep_State] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Step] nvarchar(max)  NOT NULL,
    [State] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Tudi_Approve_PlotInfo'
CREATE TABLE [dbo].[Tudi_Approve_PlotInfo] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Tudi_st_approveInfoId] int  NULL,
    [Tudi_ApproveInfoId] int  NULL,
    [Tudi_stph_ApproveInfoId] int  NULL,
    [Tudi_plotInfoId] int  NOT NULL,
    [Tudi_dikuaiyongtuId] int  NOT NULL
);
GO

-- Creating table 'OrganizationAssetTypes'
CREATE TABLE [dbo].[OrganizationAssetTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Note] nvarchar(max)  NOT NULL,
    [physicalAssetId] int  NULL,
    [AssetBaseTypeId] int  NOT NULL
);
GO

-- Creating table 'GeoGraphs'
CREATE TABLE [dbo].[GeoGraphs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Content] nvarchar(max)  NOT NULL,
    [GeometryType] nvarchar(max)  NOT NULL,
    [Geometry] nvarchar(max)  NOT NULL,
    [Geogrphy] nvarchar(max)  NOT NULL,
    [Points] nvarchar(max)  NOT NULL,
    [Point3D] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Employees1'
CREATE TABLE [dbo].[Employees1] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [StartTime] nvarchar(max)  NOT NULL,
    [EndTime] nvarchar(max)  NOT NULL,
    [EmpCode] nvarchar(max)  NOT NULL,
    [UserID] int  NOT NULL,
    [Isvalid] nvarchar(max)  NOT NULL,
    [PositionID] int  NULL,
    [OrganizationID] int  NULL
);
GO

-- Creating table 'IndustrySolutions'
CREATE TABLE [dbo].[IndustrySolutions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IndustryCodeID] int  NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Content] nvarchar(max)  NOT NULL,
    [Note] nvarchar(max)  NOT NULL
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
    [DllFileStreamID] int  NULL
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
    [Creater] nvarchar(max)  NOT NULL,
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
    [UserID1] int  NULL
);
GO

-- Creating table 'ModulProperties'
CREATE TABLE [dbo].[ModulProperties] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [WorkModulId] int  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Type] nvarchar(max)  NOT NULL,
    [Descript] nvarchar(max)  NOT NULL
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
    [Repose] nvarchar(max)  NOT NULL
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
    [UserID] int  NULL
);
GO

-- Creating table 'DocSenders'
CREATE TABLE [dbo].[DocSenders] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserID] int  NULL,
    [PostID] int  NULL
);
GO

-- Creating table 'DocComents'
CREATE TABLE [dbo].[DocComents] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DocLocationID] int  NOT NULL,
    [DocSenderId] int  NOT NULL,
    [Remark] nvarchar(max)  NOT NULL,
    [RemarkTime] datetime  NOT NULL
);
GO

-- Creating table 'JobChanges'
CREATE TABLE [dbo].[JobChanges] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [EmployeeId] int  NULL,
    [PostID] int  NULL,
    [State] bit  NOT NULL,
    [StartTime] datetime  NOT NULL,
    [EndTime] datetime  NOT NULL,
    [Creater] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'WorkSpaceTypes'
CREATE TABLE [dbo].[WorkSpaceTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ByProperty] nvarchar(max)  NOT NULL,
    [WorkSpaceID] int  NULL,
    [WorkSpaceBaseTypeId] int  NULL
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
    [VisualScope] nvarchar(max)  NOT NULL,
    [DocReaderId] int  NOT NULL,
    [DocSenderId] int  NULL,
    [IsRuleTransaction] bit  NOT NULL,
    [DocLocationID] int  NULL,
    [DocumentManageID] int  NULL,
    [WorkSpaceBaseTypeId] int  NULL
);
GO

-- Creating table 'WorkSpaceBaseTypes'
CREATE TABLE [dbo].[WorkSpaceBaseTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Note] nvarchar(max)  NOT NULL,
    [WorkSpaceBaseTypeId] int  NULL
);
GO

-- Creating table 'EventTimes'
CREATE TABLE [dbo].[EventTimes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TimePoint] nvarchar(max)  NOT NULL,
    [SpacePoint] nvarchar(max)  NOT NULL,
    [EventName] nvarchar(max)  NOT NULL,
    [EventType] nvarchar(max)  NOT NULL,
    [District] nvarchar(max)  NOT NULL,
    [LoginLogID] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Organizations'
ALTER TABLE [dbo].[Organizations]
ADD CONSTRAINT [PK_Organizations]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Organization_ContactTables'
ALTER TABLE [dbo].[Organization_ContactTables]
ADD CONSTRAINT [PK_Organization_ContactTables]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Positions'
ALTER TABLE [dbo].[Positions]
ADD CONSTRAINT [PK_Positions]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'User_ContactTable'
ALTER TABLE [dbo].[User_ContactTable]
ADD CONSTRAINT [PK_User_ContactTable]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Tasks'
ALTER TABLE [dbo].[Tasks]
ADD CONSTRAINT [PK_Tasks]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Projects'
ALTER TABLE [dbo].[Projects]
ADD CONSTRAINT [PK_Projects]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'LoginLogs'
ALTER TABLE [dbo].[LoginLogs]
ADD CONSTRAINT [PK_LoginLogs]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Land_Graphs'
ALTER TABLE [dbo].[Land_Graphs]
ADD CONSTRAINT [PK_Land_Graphs]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Land_Types'
ALTER TABLE [dbo].[Land_Types]
ADD CONSTRAINT [PK_Land_Types]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Land_Image'
ALTER TABLE [dbo].[Land_Image]
ADD CONSTRAINT [PK_Land_Image]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Land_Video'
ALTER TABLE [dbo].[Land_Video]
ADD CONSTRAINT [PK_Land_Video]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'IncurredExpenses'
ALTER TABLE [dbo].[IncurredExpenses]
ADD CONSTRAINT [PK_IncurredExpenses]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Project_Expense'
ALTER TABLE [dbo].[Project_Expense]
ADD CONSTRAINT [PK_Project_Expense]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Land_DemolitionContracts'
ALTER TABLE [dbo].[Land_DemolitionContracts]
ADD CONSTRAINT [PK_Land_DemolitionContracts]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'OrganizationTransitions'
ALTER TABLE [dbo].[OrganizationTransitions]
ADD CONSTRAINT [PK_OrganizationTransitions]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Land_Graph_Handles'
ALTER TABLE [dbo].[Land_Graph_Handles]
ADD CONSTRAINT [PK_Land_Graph_Handles]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Land_Ownerships'
ALTER TABLE [dbo].[Land_Ownerships]
ADD CONSTRAINT [PK_Land_Ownerships]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'TaskEquipments'
ALTER TABLE [dbo].[TaskEquipments]
ADD CONSTRAINT [PK_TaskEquipments]
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

-- Creating primary key on [ID] in table 'UserMessages'
ALTER TABLE [dbo].[UserMessages]
ADD CONSTRAINT [PK_UserMessages]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'UserGroups'
ALTER TABLE [dbo].[UserGroups]
ADD CONSTRAINT [PK_UserGroups]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'OrganizationOtherNames'
ALTER TABLE [dbo].[OrganizationOtherNames]
ADD CONSTRAINT [PK_OrganizationOtherNames]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Land_TaskType'
ALTER TABLE [dbo].[Land_TaskType]
ADD CONSTRAINT [PK_Land_TaskType]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'TaskStates'
ALTER TABLE [dbo].[TaskStates]
ADD CONSTRAINT [PK_TaskStates]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Land_manager'
ALTER TABLE [dbo].[Land_manager]
ADD CONSTRAINT [PK_Land_manager]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [SacID] in table 'Administrativecodes'
ALTER TABLE [dbo].[Administrativecodes]
ADD CONSTRAINT [PK_Administrativecodes]
    PRIMARY KEY CLUSTERED ([SacID] ASC);
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

-- Creating primary key on [TaskItemID] in table 'TaskItems'
ALTER TABLE [dbo].[TaskItems]
ADD CONSTRAINT [PK_TaskItems]
    PRIMARY KEY CLUSTERED ([TaskItemID] ASC);
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

-- Creating primary key on [ID] in table 'Posts'
ALTER TABLE [dbo].[Posts]
ADD CONSTRAINT [PK_Posts]
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

-- Creating primary key on [ID] in table 'GBT_13923_2006s'
ALTER TABLE [dbo].[GBT_13923_2006s]
ADD CONSTRAINT [PK_GBT_13923_2006s]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'ProjectLocations'
ALTER TABLE [dbo].[ProjectLocations]
ADD CONSTRAINT [PK_ProjectLocations]
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

-- Creating primary key on [ID] in table 'MessageGroupMessagers'
ALTER TABLE [dbo].[MessageGroupMessagers]
ADD CONSTRAINT [PK_MessageGroupMessagers]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'GroupNames'
ALTER TABLE [dbo].[GroupNames]
ADD CONSTRAINT [PK_GroupNames]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'CustomerGoups'
ALTER TABLE [dbo].[CustomerGoups]
ADD CONSTRAINT [PK_CustomerGoups]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'DllFileStreams'
ALTER TABLE [dbo].[DllFileStreams]
ADD CONSTRAINT [PK_DllFileStreams]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'F_Currency'
ALTER TABLE [dbo].[F_Currency]
ADD CONSTRAINT [PK_F_Currency]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'F_unitgroup'
ALTER TABLE [dbo].[F_unitgroup]
ADD CONSTRAINT [PK_F_unitgroup]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'F_measureunit'
ALTER TABLE [dbo].[F_measureunit]
ADD CONSTRAINT [PK_F_measureunit]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'F_account'
ALTER TABLE [dbo].[F_account]
ADD CONSTRAINT [PK_F_account]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'F_itemclass'
ALTER TABLE [dbo].[F_itemclass]
ADD CONSTRAINT [PK_F_itemclass]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'F_item'
ALTER TABLE [dbo].[F_item]
ADD CONSTRAINT [PK_F_item]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'FinaceAccoutTabs'
ALTER TABLE [dbo].[FinaceAccoutTabs]
ADD CONSTRAINT [PK_FinaceAccoutTabs]
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

-- Creating primary key on [ID] in table 'DesktopGeoManages'
ALTER TABLE [dbo].[DesktopGeoManages]
ADD CONSTRAINT [PK_DesktopGeoManages]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'CustomGeographicTypes'
ALTER TABLE [dbo].[CustomGeographicTypes]
ADD CONSTRAINT [PK_CustomGeographicTypes]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'TaskLinks'
ALTER TABLE [dbo].[TaskLinks]
ADD CONSTRAINT [PK_TaskLinks]
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

-- Creating primary key on [Id] in table 'ProjectChangeEvents'
ALTER TABLE [dbo].[ProjectChangeEvents]
ADD CONSTRAINT [PK_ProjectChangeEvents]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tudi_spqx'
ALTER TABLE [dbo].[Tudi_spqx]
ADD CONSTRAINT [PK_Tudi_spqx]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tudi_ywlc'
ALTER TABLE [dbo].[Tudi_ywlc]
ADD CONSTRAINT [PK_Tudi_ywlc]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tudi_ydjh'
ALTER TABLE [dbo].[Tudi_ydjh]
ADD CONSTRAINT [PK_Tudi_ydjh]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tudi_sjydbbjhfl'
ALTER TABLE [dbo].[Tudi_sjydbbjhfl]
ADD CONSTRAINT [PK_Tudi_sjydbbjhfl]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tudi_TaskTypeCode'
ALTER TABLE [dbo].[Tudi_TaskTypeCode]
ADD CONSTRAINT [PK_Tudi_TaskTypeCode]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tudi_gtgl_TaskCode'
ALTER TABLE [dbo].[Tudi_gtgl_TaskCode]
ADD CONSTRAINT [PK_Tudi_gtgl_TaskCode]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tudi_projInfo'
ALTER TABLE [dbo].[Tudi_projInfo]
ADD CONSTRAINT [PK_Tudi_projInfo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tudi_plotInfo'
ALTER TABLE [dbo].[Tudi_plotInfo]
ADD CONSTRAINT [PK_Tudi_plotInfo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tudi_projType'
ALTER TABLE [dbo].[Tudi_projType]
ADD CONSTRAINT [PK_Tudi_projType]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tudi_shenpiState'
ALTER TABLE [dbo].[Tudi_shenpiState]
ADD CONSTRAINT [PK_Tudi_shenpiState]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tudi_shenpiqx'
ALTER TABLE [dbo].[Tudi_shenpiqx]
ADD CONSTRAINT [PK_Tudi_shenpiqx]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tudi_dikuaiyongtu'
ALTER TABLE [dbo].[Tudi_dikuaiyongtu]
ADD CONSTRAINT [PK_Tudi_dikuaiyongtu]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tudi_projKind'
ALTER TABLE [dbo].[Tudi_projKind]
ADD CONSTRAINT [PK_Tudi_projKind]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tudi_handleState'
ALTER TABLE [dbo].[Tudi_handleState]
ADD CONSTRAINT [PK_Tudi_handleState]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tudi_ApproveInfo'
ALTER TABLE [dbo].[Tudi_ApproveInfo]
ADD CONSTRAINT [PK_Tudi_ApproveInfo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tudi_st_approveInfo'
ALTER TABLE [dbo].[Tudi_st_approveInfo]
ADD CONSTRAINT [PK_Tudi_st_approveInfo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tudi_stph_ApproveInfo'
ALTER TABLE [dbo].[Tudi_stph_ApproveInfo]
ADD CONSTRAINT [PK_Tudi_stph_ApproveInfo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tudi_HandleStep_State'
ALTER TABLE [dbo].[Tudi_HandleStep_State]
ADD CONSTRAINT [PK_Tudi_HandleStep_State]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tudi_Approve_PlotInfo'
ALTER TABLE [dbo].[Tudi_Approve_PlotInfo]
ADD CONSTRAINT [PK_Tudi_Approve_PlotInfo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OrganizationAssetTypes'
ALTER TABLE [dbo].[OrganizationAssetTypes]
ADD CONSTRAINT [PK_OrganizationAssetTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'GeoGraphs'
ALTER TABLE [dbo].[GeoGraphs]
ADD CONSTRAINT [PK_GeoGraphs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Employees1'
ALTER TABLE [dbo].[Employees1]
ADD CONSTRAINT [PK_Employees1]
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

-- Creating primary key on [Id] in table 'EventTimes'
ALTER TABLE [dbo].[EventTimes]
ADD CONSTRAINT [PK_EventTimes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserID] in table 'LoginLogs'
ALTER TABLE [dbo].[LoginLogs]
ADD CONSTRAINT [FK_UserLoginLog]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserLoginLog'
CREATE INDEX [IX_FK_UserLoginLog]
ON [dbo].[LoginLogs]
    ([UserID]);
GO

-- Creating foreign key on [ParentID] in table 'Land_Types'
ALTER TABLE [dbo].[Land_Types]
ADD CONSTRAINT [FK_Land_TypeLand_Type]
    FOREIGN KEY ([ParentID])
    REFERENCES [dbo].[Land_Types]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Land_TypeLand_Type'
CREATE INDEX [IX_FK_Land_TypeLand_Type]
ON [dbo].[Land_Types]
    ([ParentID]);
GO

-- Creating foreign key on [LoginLogID] in table 'UserMessages'
ALTER TABLE [dbo].[UserMessages]
ADD CONSTRAINT [FK_LoginLogUserMessage]
    FOREIGN KEY ([LoginLogID])
    REFERENCES [dbo].[LoginLogs]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LoginLogUserMessage'
CREATE INDEX [IX_FK_LoginLogUserMessage]
ON [dbo].[UserMessages]
    ([LoginLogID]);
GO

-- Creating foreign key on [ProjectID] in table 'Project_Expense'
ALTER TABLE [dbo].[Project_Expense]
ADD CONSTRAINT [FK_ProjectProject_Expense]
    FOREIGN KEY ([ProjectID])
    REFERENCES [dbo].[Projects]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectProject_Expense'
CREATE INDEX [IX_FK_ProjectProject_Expense]
ON [dbo].[Project_Expense]
    ([ProjectID]);
GO

-- Creating foreign key on [TaskID] in table 'IncurredExpenses'
ALTER TABLE [dbo].[IncurredExpenses]
ADD CONSTRAINT [FK_TaskIncurredExpense]
    FOREIGN KEY ([TaskID])
    REFERENCES [dbo].[Tasks]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TaskIncurredExpense'
CREATE INDEX [IX_FK_TaskIncurredExpense]
ON [dbo].[IncurredExpenses]
    ([TaskID]);
GO

-- Creating foreign key on [TaskID] in table 'TaskEquipments'
ALTER TABLE [dbo].[TaskEquipments]
ADD CONSTRAINT [FK_TaskTaskEquipment]
    FOREIGN KEY ([TaskID])
    REFERENCES [dbo].[Tasks]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TaskTaskEquipment'
CREATE INDEX [IX_FK_TaskTaskEquipment]
ON [dbo].[TaskEquipments]
    ([TaskID]);
GO

-- Creating foreign key on [OrganizationID] in table 'OrganizationOtherNames'
ALTER TABLE [dbo].[OrganizationOtherNames]
ADD CONSTRAINT [FK_OrganizationOrganizationOtherName]
    FOREIGN KEY ([OrganizationID])
    REFERENCES [dbo].[Organizations]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrganizationOrganizationOtherName'
CREATE INDEX [IX_FK_OrganizationOrganizationOtherName]
ON [dbo].[OrganizationOtherNames]
    ([OrganizationID]);
GO

-- Creating foreign key on [Land_TaskTypeID] in table 'Land_Graph_Handles'
ALTER TABLE [dbo].[Land_Graph_Handles]
ADD CONSTRAINT [FK_Land_TaskTypeLand_ImplementSchedule]
    FOREIGN KEY ([Land_TaskTypeID])
    REFERENCES [dbo].[Land_TaskType]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Land_TaskTypeLand_ImplementSchedule'
CREATE INDEX [IX_FK_Land_TaskTypeLand_ImplementSchedule]
ON [dbo].[Land_Graph_Handles]
    ([Land_TaskTypeID]);
GO

-- Creating foreign key on [TaskStateID] in table 'Tasks'
ALTER TABLE [dbo].[Tasks]
ADD CONSTRAINT [FK_TaskStateTask]
    FOREIGN KEY ([TaskStateID])
    REFERENCES [dbo].[TaskStates]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TaskStateTask'
CREATE INDEX [IX_FK_TaskStateTask]
ON [dbo].[Tasks]
    ([TaskStateID]);
GO

-- Creating foreign key on [Land_managerID] in table 'Land_Image'
ALTER TABLE [dbo].[Land_Image]
ADD CONSTRAINT [FK_Land_managerLand_Image]
    FOREIGN KEY ([Land_managerID])
    REFERENCES [dbo].[Land_manager]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Land_managerLand_Image'
CREATE INDEX [IX_FK_Land_managerLand_Image]
ON [dbo].[Land_Image]
    ([Land_managerID]);
GO

-- Creating foreign key on [Geo_GraphID] in table 'Land_manager'
ALTER TABLE [dbo].[Land_manager]
ADD CONSTRAINT [FK_Geo_GraphLand_manager]
    FOREIGN KEY ([Geo_GraphID])
    REFERENCES [dbo].[Land_Graphs]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Geo_GraphLand_manager'
CREATE INDEX [IX_FK_Geo_GraphLand_manager]
ON [dbo].[Land_manager]
    ([Geo_GraphID]);
GO

-- Creating foreign key on [Land_TypeID] in table 'Land_manager'
ALTER TABLE [dbo].[Land_manager]
ADD CONSTRAINT [FK_Land_TypeLand_manager]
    FOREIGN KEY ([Land_TypeID])
    REFERENCES [dbo].[Land_Types]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Land_TypeLand_manager'
CREATE INDEX [IX_FK_Land_TypeLand_manager]
ON [dbo].[Land_manager]
    ([Land_TypeID]);
GO

-- Creating foreign key on [Land_Item] in table 'Land_manager'
ALTER TABLE [dbo].[Land_manager]
ADD CONSTRAINT [FK_Land_TypeLand_manager1]
    FOREIGN KEY ([Land_Item])
    REFERENCES [dbo].[Land_Types]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Land_TypeLand_manager1'
CREATE INDEX [IX_FK_Land_TypeLand_manager1]
ON [dbo].[Land_manager]
    ([Land_Item]);
GO

-- Creating foreign key on [Land_managerID] in table 'Land_Ownerships'
ALTER TABLE [dbo].[Land_Ownerships]
ADD CONSTRAINT [FK_Land_managerLand_Ownership]
    FOREIGN KEY ([Land_managerID])
    REFERENCES [dbo].[Land_manager]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Land_managerLand_Ownership'
CREATE INDEX [IX_FK_Land_managerLand_Ownership]
ON [dbo].[Land_Ownerships]
    ([Land_managerID]);
GO

-- Creating foreign key on [Land_managerID] in table 'Land_DemolitionContracts'
ALTER TABLE [dbo].[Land_DemolitionContracts]
ADD CONSTRAINT [FK_Land_managerLand_DemolitionContract]
    FOREIGN KEY ([Land_managerID])
    REFERENCES [dbo].[Land_manager]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Land_managerLand_DemolitionContract'
CREATE INDEX [IX_FK_Land_managerLand_DemolitionContract]
ON [dbo].[Land_DemolitionContracts]
    ([Land_managerID]);
GO

-- Creating foreign key on [Land_managerID] in table 'Land_Video'
ALTER TABLE [dbo].[Land_Video]
ADD CONSTRAINT [FK_Land_managerLand_Video]
    FOREIGN KEY ([Land_managerID])
    REFERENCES [dbo].[Land_manager]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Land_managerLand_Video'
CREATE INDEX [IX_FK_Land_managerLand_Video]
ON [dbo].[Land_Video]
    ([Land_managerID]);
GO

-- Creating foreign key on [Land_managerID] in table 'Land_Graph_Handles'
ALTER TABLE [dbo].[Land_Graph_Handles]
ADD CONSTRAINT [FK_Land_managerLand_Graph_Handle]
    FOREIGN KEY ([Land_managerID])
    REFERENCES [dbo].[Land_manager]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Land_managerLand_Graph_Handle'
CREATE INDEX [IX_FK_Land_managerLand_Graph_Handle]
ON [dbo].[Land_Graph_Handles]
    ([Land_managerID]);
GO

-- Creating foreign key on [StandardadministrativecodeSacID] in table 'Land_manager'
ALTER TABLE [dbo].[Land_manager]
ADD CONSTRAINT [FK_StandardadministrativecodeLand_manager]
    FOREIGN KEY ([StandardadministrativecodeSacID])
    REFERENCES [dbo].[Administrativecodes]
        ([SacID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StandardadministrativecodeLand_manager'
CREATE INDEX [IX_FK_StandardadministrativecodeLand_manager]
ON [dbo].[Land_manager]
    ([StandardadministrativecodeSacID]);
GO

-- Creating foreign key on [BussnessVerID] in table 'Land_manager'
ALTER TABLE [dbo].[Land_manager]
ADD CONSTRAINT [FK_BussnessVerLand_manager]
    FOREIGN KEY ([BussnessVerID])
    REFERENCES [dbo].[BussnessVers]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BussnessVerLand_manager'
CREATE INDEX [IX_FK_BussnessVerLand_manager]
ON [dbo].[Land_manager]
    ([BussnessVerID]);
GO

-- Creating foreign key on [TaskID] in table 'TaskItems'
ALTER TABLE [dbo].[TaskItems]
ADD CONSTRAINT [FK_TaskTaskItem]
    FOREIGN KEY ([TaskID])
    REFERENCES [dbo].[Tasks]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TaskTaskItem'
CREATE INDEX [IX_FK_TaskTaskItem]
ON [dbo].[TaskItems]
    ([TaskID]);
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

-- Creating foreign key on [DocManageStateID] in table 'DocumentManages'
ALTER TABLE [dbo].[DocumentManages]
ADD CONSTRAINT [FK_DocProcessTypeProject_Document]
    FOREIGN KEY ([DocManageStateID])
    REFERENCES [dbo].[DocManageStates]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DocProcessTypeProject_Document'
CREATE INDEX [IX_FK_DocProcessTypeProject_Document]
ON [dbo].[DocumentManages]
    ([DocManageStateID]);
GO

-- Creating foreign key on [OldOrgan] in table 'OrganizationTransitions'
ALTER TABLE [dbo].[OrganizationTransitions]
ADD CONSTRAINT [FK_OrganizationOrganizationTransition]
    FOREIGN KEY ([OldOrgan])
    REFERENCES [dbo].[Organizations]
        ([ID])
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
    REFERENCES [dbo].[Organizations]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrganizationOrganizationTransition1'
CREATE INDEX [IX_FK_OrganizationOrganizationTransition1]
ON [dbo].[OrganizationTransitions]
    ([NewOrgan]);
GO

-- Creating foreign key on [ProjectID] in table 'Land_manager'
ALTER TABLE [dbo].[Land_manager]
ADD CONSTRAINT [FK_ProjectLand_manager]
    FOREIGN KEY ([ProjectID])
    REFERENCES [dbo].[Projects]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectLand_manager'
CREATE INDEX [IX_FK_ProjectLand_manager]
ON [dbo].[Land_manager]
    ([ProjectID]);
GO

-- Creating foreign key on [UserID] in table 'User_ContactTable'
ALTER TABLE [dbo].[User_ContactTable]
ADD CONSTRAINT [FK_UserUser_ContacTable]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserUser_ContacTable'
CREATE INDEX [IX_FK_UserUser_ContacTable]
ON [dbo].[User_ContactTable]
    ([UserID]);
GO

-- Creating foreign key on [ProjectID] in table 'Tasks'
ALTER TABLE [dbo].[Tasks]
ADD CONSTRAINT [FK_ProjectTask]
    FOREIGN KEY ([ProjectID])
    REFERENCES [dbo].[Projects]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectTask'
CREATE INDEX [IX_FK_ProjectTask]
ON [dbo].[Tasks]
    ([ProjectID]);
GO

-- Creating foreign key on [Parent] in table 'Organizations'
ALTER TABLE [dbo].[Organizations]
ADD CONSTRAINT [FK_OrganizationOrganization]
    FOREIGN KEY ([Parent])
    REFERENCES [dbo].[Organizations]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrganizationOrganization'
CREATE INDEX [IX_FK_OrganizationOrganization]
ON [dbo].[Organizations]
    ([Parent]);
GO

-- Creating foreign key on [ProjectID] in table 'Projects'
ALTER TABLE [dbo].[Projects]
ADD CONSTRAINT [FK_ProjectProject]
    FOREIGN KEY ([ProjectID])
    REFERENCES [dbo].[Projects]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectProject'
CREATE INDEX [IX_FK_ProjectProject]
ON [dbo].[Projects]
    ([ProjectID]);
GO

-- Creating foreign key on [ParentTask] in table 'Tasks'
ALTER TABLE [dbo].[Tasks]
ADD CONSTRAINT [FK_TaskTask]
    FOREIGN KEY ([ParentTask])
    REFERENCES [dbo].[Tasks]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TaskTask'
CREATE INDEX [IX_FK_TaskTask]
ON [dbo].[Tasks]
    ([ParentTask]);
GO

-- Creating foreign key on [Parent] in table 'Administrativecodes'
ALTER TABLE [dbo].[Administrativecodes]
ADD CONSTRAINT [FK_AdministrativecodeAdministrativecode]
    FOREIGN KEY ([Parent])
    REFERENCES [dbo].[Administrativecodes]
        ([SacID])
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
    REFERENCES [dbo].[Users]
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
    REFERENCES [dbo].[Users]
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

-- Creating foreign key on [Parent] in table 'GBT_13923_2006s'
ALTER TABLE [dbo].[GBT_13923_2006s]
ADD CONSTRAINT [FK_GBT_13923_2006GBT_13923_2006]
    FOREIGN KEY ([Parent])
    REFERENCES [dbo].[GBT_13923_2006s]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GBT_13923_2006GBT_13923_2006'
CREATE INDEX [IX_FK_GBT_13923_2006GBT_13923_2006]
ON [dbo].[GBT_13923_2006s]
    ([Parent]);
GO

-- Creating foreign key on [BussnessVerID] in table 'GBT_13923_2006s'
ALTER TABLE [dbo].[GBT_13923_2006s]
ADD CONSTRAINT [FK_BussnessVerGBT_13923_2006]
    FOREIGN KEY ([BussnessVerID])
    REFERENCES [dbo].[BussnessVers]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BussnessVerGBT_13923_2006'
CREATE INDEX [IX_FK_BussnessVerGBT_13923_2006]
ON [dbo].[GBT_13923_2006s]
    ([BussnessVerID]);
GO

-- Creating foreign key on [ProjectID] in table 'ProjectLocations'
ALTER TABLE [dbo].[ProjectLocations]
ADD CONSTRAINT [FK_ProjectProjectMap]
    FOREIGN KEY ([ProjectID])
    REFERENCES [dbo].[Projects]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectProjectMap'
CREATE INDEX [IX_FK_ProjectProjectMap]
ON [dbo].[ProjectLocations]
    ([ProjectID]);
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
    REFERENCES [dbo].[Organizations]
        ([ID])
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
    REFERENCES [dbo].[Organizations]
        ([ID])
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
        ([SacID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AdministrativecodeOrganizBasic'
CREATE INDEX [IX_FK_AdministrativecodeOrganizBasic]
ON [dbo].[OrganizBasics]
    ([AdministrativecodeSacID]);
GO

-- Creating foreign key on [PositionID] in table 'Positions'
ALTER TABLE [dbo].[Positions]
ADD CONSTRAINT [FK_PositionPosition]
    FOREIGN KEY ([PositionID])
    REFERENCES [dbo].[Positions]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PositionPosition'
CREATE INDEX [IX_FK_PositionPosition]
ON [dbo].[Positions]
    ([PositionID]);
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

-- Creating foreign key on [UserID] in table 'UserGroups'
ALTER TABLE [dbo].[UserGroups]
ADD CONSTRAINT [FK_UserMessageGroup]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserMessageGroup'
CREATE INDEX [IX_FK_UserMessageGroup]
ON [dbo].[UserGroups]
    ([UserID]);
GO

-- Creating foreign key on [MessageGroupID] in table 'MessageGroupMessagers'
ALTER TABLE [dbo].[MessageGroupMessagers]
ADD CONSTRAINT [FK_MessageGroupMessageGroupMessager]
    FOREIGN KEY ([MessageGroupID])
    REFERENCES [dbo].[UserGroups]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MessageGroupMessageGroupMessager'
CREATE INDEX [IX_FK_MessageGroupMessageGroupMessager]
ON [dbo].[MessageGroupMessagers]
    ([MessageGroupID]);
GO

-- Creating foreign key on [ReplyID] in table 'UserMessages'
ALTER TABLE [dbo].[UserMessages]
ADD CONSTRAINT [FK_UserMessageUserMessage]
    FOREIGN KEY ([ReplyID])
    REFERENCES [dbo].[UserMessages]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserMessageUserMessage'
CREATE INDEX [IX_FK_UserMessageUserMessage]
ON [dbo].[UserMessages]
    ([ReplyID]);
GO

-- Creating foreign key on [UserID] in table 'GroupNames'
ALTER TABLE [dbo].[GroupNames]
ADD CONSTRAINT [FK_UserGroupName]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserGroupName'
CREATE INDEX [IX_FK_UserGroupName]
ON [dbo].[GroupNames]
    ([UserID]);
GO

-- Creating foreign key on [GroupNameID] in table 'UserGroups'
ALTER TABLE [dbo].[UserGroups]
ADD CONSTRAINT [FK_GroupNameUserGroup]
    FOREIGN KEY ([GroupNameID])
    REFERENCES [dbo].[GroupNames]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GroupNameUserGroup'
CREATE INDEX [IX_FK_GroupNameUserGroup]
ON [dbo].[UserGroups]
    ([GroupNameID]);
GO

-- Creating foreign key on [CreatID] in table 'CustomerGoups'
ALTER TABLE [dbo].[CustomerGoups]
ADD CONSTRAINT [FK_UserCustomerGoup]
    FOREIGN KEY ([CreatID])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserCustomerGoup'
CREATE INDEX [IX_FK_UserCustomerGoup]
ON [dbo].[CustomerGoups]
    ([CreatID]);
GO

-- Creating foreign key on [SenderID] in table 'UserMessages'
ALTER TABLE [dbo].[UserMessages]
ADD CONSTRAINT [FK_UserUserMessage]
    FOREIGN KEY ([SenderID])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserUserMessage'
CREATE INDEX [IX_FK_UserUserMessage]
ON [dbo].[UserMessages]
    ([SenderID]);
GO

-- Creating foreign key on [F_unitgroupID] in table 'F_measureunit'
ALTER TABLE [dbo].[F_measureunit]
ADD CONSTRAINT [FK_F_unitgroupF_measureunit]
    FOREIGN KEY ([F_unitgroupID])
    REFERENCES [dbo].[F_unitgroup]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_F_unitgroupF_measureunit'
CREATE INDEX [IX_FK_F_unitgroupF_measureunit]
ON [dbo].[F_measureunit]
    ([F_unitgroupID]);
GO

-- Creating foreign key on [F_itemclassID] in table 'F_item'
ALTER TABLE [dbo].[F_item]
ADD CONSTRAINT [FK_F_itemclassF_item]
    FOREIGN KEY ([F_itemclassID])
    REFERENCES [dbo].[F_itemclass]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_F_itemclassF_item'
CREATE INDEX [IX_FK_F_itemclassF_item]
ON [dbo].[F_item]
    ([F_itemclassID]);
GO

-- Creating foreign key on [OrganizationID] in table 'OrganizationCustomTypes'
ALTER TABLE [dbo].[OrganizationCustomTypes]
ADD CONSTRAINT [FK_OrganizationCustomOrganizationType]
    FOREIGN KEY ([OrganizationID])
    REFERENCES [dbo].[Organizations]
        ([ID])
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

-- Creating foreign key on [CustomGeographicTypeID] in table 'CustomGeographicTypes'
ALTER TABLE [dbo].[CustomGeographicTypes]
ADD CONSTRAINT [FK_CustomGeographicTypeCustomGeographicType]
    FOREIGN KEY ([CustomGeographicTypeID])
    REFERENCES [dbo].[CustomGeographicTypes]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomGeographicTypeCustomGeographicType'
CREATE INDEX [IX_FK_CustomGeographicTypeCustomGeographicType]
ON [dbo].[CustomGeographicTypes]
    ([CustomGeographicTypeID]);
GO

-- Creating foreign key on [Geo_GraphID] in table 'DesktopGeoManages'
ALTER TABLE [dbo].[DesktopGeoManages]
ADD CONSTRAINT [FK_Geo_GraphDesktopGeoManage]
    FOREIGN KEY ([Geo_GraphID])
    REFERENCES [dbo].[Land_Graphs]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Geo_GraphDesktopGeoManage'
CREATE INDEX [IX_FK_Geo_GraphDesktopGeoManage]
ON [dbo].[DesktopGeoManages]
    ([Geo_GraphID]);
GO

-- Creating foreign key on [CustomGeographicTypeID] in table 'DesktopGeoManages'
ALTER TABLE [dbo].[DesktopGeoManages]
ADD CONSTRAINT [FK_CustomGeographicTypeDesktopGeoManage]
    FOREIGN KEY ([CustomGeographicTypeID])
    REFERENCES [dbo].[CustomGeographicTypes]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomGeographicTypeDesktopGeoManage'
CREATE INDEX [IX_FK_CustomGeographicTypeDesktopGeoManage]
ON [dbo].[DesktopGeoManages]
    ([CustomGeographicTypeID]);
GO

-- Creating foreign key on [TaskID] in table 'TaskLinks'
ALTER TABLE [dbo].[TaskLinks]
ADD CONSTRAINT [FK_TaskTaskLink]
    FOREIGN KEY ([TaskID])
    REFERENCES [dbo].[Tasks]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TaskTaskLink'
CREATE INDEX [IX_FK_TaskTaskLink]
ON [dbo].[TaskLinks]
    ([TaskID]);
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
    REFERENCES [dbo].[Organizations]
        ([ID])
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
    REFERENCES [dbo].[Organizations]
        ([ID])
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

-- Creating foreign key on [OrganizationID] in table 'Positions'
ALTER TABLE [dbo].[Positions]
ADD CONSTRAINT [FK_OrganizationPosition]
    FOREIGN KEY ([OrganizationID])
    REFERENCES [dbo].[Organizations]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrganizationPosition'
CREATE INDEX [IX_FK_OrganizationPosition]
ON [dbo].[Positions]
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

-- Creating foreign key on [ProjectID] in table 'ProjectChangeEvents'
ALTER TABLE [dbo].[ProjectChangeEvents]
ADD CONSTRAINT [FK_ProjectProjectChangeEvent]
    FOREIGN KEY ([ProjectID])
    REFERENCES [dbo].[Projects]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectProjectChangeEvent'
CREATE INDEX [IX_FK_ProjectProjectChangeEvent]
ON [dbo].[ProjectChangeEvents]
    ([ProjectID]);
GO

-- Creating foreign key on [Tudi_spqxId] in table 'Tudi_ydjh'
ALTER TABLE [dbo].[Tudi_ydjh]
ADD CONSTRAINT [FK_Tudi_spqxTudi_ydjh]
    FOREIGN KEY ([Tudi_spqxId])
    REFERENCES [dbo].[Tudi_spqx]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tudi_spqxTudi_ydjh'
CREATE INDEX [IX_FK_Tudi_spqxTudi_ydjh]
ON [dbo].[Tudi_ydjh]
    ([Tudi_spqxId]);
GO

-- Creating foreign key on [Tudi_ywlcId] in table 'Tudi_ydjh'
ALTER TABLE [dbo].[Tudi_ydjh]
ADD CONSTRAINT [FK_Tudi_ywlcTudi_ydjh]
    FOREIGN KEY ([Tudi_ywlcId])
    REFERENCES [dbo].[Tudi_ywlc]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tudi_ywlcTudi_ydjh'
CREATE INDEX [IX_FK_Tudi_ywlcTudi_ydjh]
ON [dbo].[Tudi_ydjh]
    ([Tudi_ywlcId]);
GO

-- Creating foreign key on [Parent] in table 'Tudi_TaskTypeCode'
ALTER TABLE [dbo].[Tudi_TaskTypeCode]
ADD CONSTRAINT [FK_gtgl_TaskTypegtgl_TaskType]
    FOREIGN KEY ([Parent])
    REFERENCES [dbo].[Tudi_TaskTypeCode]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_gtgl_TaskTypegtgl_TaskType'
CREATE INDEX [IX_FK_gtgl_TaskTypegtgl_TaskType]
ON [dbo].[Tudi_TaskTypeCode]
    ([Parent]);
GO

-- Creating foreign key on [TypeCode] in table 'Tudi_gtgl_TaskCode'
ALTER TABLE [dbo].[Tudi_gtgl_TaskCode]
ADD CONSTRAINT [FK_gtgl_TaskTypegtgl_TaskCode]
    FOREIGN KEY ([TypeCode])
    REFERENCES [dbo].[Tudi_TaskTypeCode]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_gtgl_TaskTypegtgl_TaskCode'
CREATE INDEX [IX_FK_gtgl_TaskTypegtgl_TaskCode]
ON [dbo].[Tudi_gtgl_TaskCode]
    ([TypeCode]);
GO

-- Creating foreign key on [Tudi_projInfoId] in table 'Tudi_ApproveInfo'
ALTER TABLE [dbo].[Tudi_ApproveInfo]
ADD CONSTRAINT [FK_Tudi_projInfoTudi_ApproveInfo]
    FOREIGN KEY ([Tudi_projInfoId])
    REFERENCES [dbo].[Tudi_projInfo]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tudi_projInfoTudi_ApproveInfo'
CREATE INDEX [IX_FK_Tudi_projInfoTudi_ApproveInfo]
ON [dbo].[Tudi_ApproveInfo]
    ([Tudi_projInfoId]);
GO

-- Creating foreign key on [ProjectID] in table 'Tudi_projInfo'
ALTER TABLE [dbo].[Tudi_projInfo]
ADD CONSTRAINT [FK_ProjectTudi_projInfo]
    FOREIGN KEY ([ProjectID])
    REFERENCES [dbo].[Projects]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectTudi_projInfo'
CREATE INDEX [IX_FK_ProjectTudi_projInfo]
ON [dbo].[Tudi_projInfo]
    ([ProjectID]);
GO

-- Creating foreign key on [Tudi_projTypeId] in table 'Tudi_projInfo'
ALTER TABLE [dbo].[Tudi_projInfo]
ADD CONSTRAINT [FK_Tudi_projTypeTudi_projInfo]
    FOREIGN KEY ([Tudi_projTypeId])
    REFERENCES [dbo].[Tudi_projType]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tudi_projTypeTudi_projInfo'
CREATE INDEX [IX_FK_Tudi_projTypeTudi_projInfo]
ON [dbo].[Tudi_projInfo]
    ([Tudi_projTypeId]);
GO

-- Creating foreign key on [Tudi_projKindId] in table 'Tudi_projInfo'
ALTER TABLE [dbo].[Tudi_projInfo]
ADD CONSTRAINT [FK_Tudi_projKindTudi_projInfo]
    FOREIGN KEY ([Tudi_projKindId])
    REFERENCES [dbo].[Tudi_projKind]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tudi_projKindTudi_projInfo'
CREATE INDEX [IX_FK_Tudi_projKindTudi_projInfo]
ON [dbo].[Tudi_projInfo]
    ([Tudi_projKindId]);
GO

-- Creating foreign key on [Tudi_Approve_type] in table 'Tudi_projInfo'
ALTER TABLE [dbo].[Tudi_projInfo]
ADD CONSTRAINT [FK_Tudi_shenpiqxTudi_projInfo]
    FOREIGN KEY ([Tudi_Approve_type])
    REFERENCES [dbo].[Tudi_shenpiqx]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tudi_shenpiqxTudi_projInfo'
CREATE INDEX [IX_FK_Tudi_shenpiqxTudi_projInfo]
ON [dbo].[Tudi_projInfo]
    ([Tudi_Approve_type]);
GO

-- Creating foreign key on [Tudi_shenpiStateId] in table 'Tudi_projInfo'
ALTER TABLE [dbo].[Tudi_projInfo]
ADD CONSTRAINT [FK_Tudi_shenpiStateTudi_projInfo]
    FOREIGN KEY ([Tudi_shenpiStateId])
    REFERENCES [dbo].[Tudi_shenpiState]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tudi_shenpiStateTudi_projInfo'
CREATE INDEX [IX_FK_Tudi_shenpiStateTudi_projInfo]
ON [dbo].[Tudi_projInfo]
    ([Tudi_shenpiStateId]);
GO

-- Creating foreign key on [SubordinateID] in table 'Tudi_shenpiqx'
ALTER TABLE [dbo].[Tudi_shenpiqx]
ADD CONSTRAINT [FK_SubordinateTudi_shenpiqx]
    FOREIGN KEY ([SubordinateID])
    REFERENCES [dbo].[Subordinates]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SubordinateTudi_shenpiqx'
CREATE INDEX [IX_FK_SubordinateTudi_shenpiqx]
ON [dbo].[Tudi_shenpiqx]
    ([SubordinateID]);
GO

-- Creating foreign key on [Tudi_handleStateId] in table 'Tudi_ApproveInfo'
ALTER TABLE [dbo].[Tudi_ApproveInfo]
ADD CONSTRAINT [FK_Tudi_handleStateTudi_ApproveInfo]
    FOREIGN KEY ([Tudi_handleStateId])
    REFERENCES [dbo].[Tudi_handleState]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tudi_handleStateTudi_ApproveInfo'
CREATE INDEX [IX_FK_Tudi_handleStateTudi_ApproveInfo]
ON [dbo].[Tudi_ApproveInfo]
    ([Tudi_handleStateId]);
GO

-- Creating foreign key on [Tudi_shenpiqxId] in table 'Tudi_st_approveInfo'
ALTER TABLE [dbo].[Tudi_st_approveInfo]
ADD CONSTRAINT [FK_Tudi_shenpiqxTudi_st_approveInfo]
    FOREIGN KEY ([Tudi_shenpiqxId])
    REFERENCES [dbo].[Tudi_shenpiqx]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tudi_shenpiqxTudi_st_approveInfo'
CREATE INDEX [IX_FK_Tudi_shenpiqxTudi_st_approveInfo]
ON [dbo].[Tudi_st_approveInfo]
    ([Tudi_shenpiqxId]);
GO

-- Creating foreign key on [Tudi_shenpiStateId] in table 'Tudi_st_approveInfo'
ALTER TABLE [dbo].[Tudi_st_approveInfo]
ADD CONSTRAINT [FK_Tudi_shenpiStateTudi_st_approveInfo]
    FOREIGN KEY ([Tudi_shenpiStateId])
    REFERENCES [dbo].[Tudi_shenpiState]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tudi_shenpiStateTudi_st_approveInfo'
CREATE INDEX [IX_FK_Tudi_shenpiStateTudi_st_approveInfo]
ON [dbo].[Tudi_st_approveInfo]
    ([Tudi_shenpiStateId]);
GO

-- Creating foreign key on [Tudi_projInfoId] in table 'Tudi_st_approveInfo'
ALTER TABLE [dbo].[Tudi_st_approveInfo]
ADD CONSTRAINT [FK_Tudi_projInfoTudi_st_approveInfo]
    FOREIGN KEY ([Tudi_projInfoId])
    REFERENCES [dbo].[Tudi_projInfo]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tudi_projInfoTudi_st_approveInfo'
CREATE INDEX [IX_FK_Tudi_projInfoTudi_st_approveInfo]
ON [dbo].[Tudi_st_approveInfo]
    ([Tudi_projInfoId]);
GO

-- Creating foreign key on [Tudi_projInfoId] in table 'Tudi_stph_ApproveInfo'
ALTER TABLE [dbo].[Tudi_stph_ApproveInfo]
ADD CONSTRAINT [FK_Tudi_projInfoTudi_stph_ApproveInfo]
    FOREIGN KEY ([Tudi_projInfoId])
    REFERENCES [dbo].[Tudi_projInfo]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tudi_projInfoTudi_stph_ApproveInfo'
CREATE INDEX [IX_FK_Tudi_projInfoTudi_stph_ApproveInfo]
ON [dbo].[Tudi_stph_ApproveInfo]
    ([Tudi_projInfoId]);
GO

-- Creating foreign key on [Tudi_gtgl_TaskCodeId] in table 'Tudi_sjydbbjhfl'
ALTER TABLE [dbo].[Tudi_sjydbbjhfl]
ADD CONSTRAINT [FK_Tudi_gtgl_TaskCodeTudi_sjydbbjhfl]
    FOREIGN KEY ([Tudi_gtgl_TaskCodeId])
    REFERENCES [dbo].[Tudi_gtgl_TaskCode]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tudi_gtgl_TaskCodeTudi_sjydbbjhfl'
CREATE INDEX [IX_FK_Tudi_gtgl_TaskCodeTudi_sjydbbjhfl]
ON [dbo].[Tudi_sjydbbjhfl]
    ([Tudi_gtgl_TaskCodeId]);
GO

-- Creating foreign key on [Tudi_sjydbbjhflId] in table 'Tudi_ydjh'
ALTER TABLE [dbo].[Tudi_ydjh]
ADD CONSTRAINT [FK_Tudi_sjydbbjhflTudi_ydjh]
    FOREIGN KEY ([Tudi_sjydbbjhflId])
    REFERENCES [dbo].[Tudi_sjydbbjhfl]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tudi_sjydbbjhflTudi_ydjh'
CREATE INDEX [IX_FK_Tudi_sjydbbjhflTudi_ydjh]
ON [dbo].[Tudi_ydjh]
    ([Tudi_sjydbbjhflId]);
GO

-- Creating foreign key on [SubordinateID] in table 'Tudi_gtgl_TaskCode'
ALTER TABLE [dbo].[Tudi_gtgl_TaskCode]
ADD CONSTRAINT [FK_SubordinateTudi_gtgl_TaskCode]
    FOREIGN KEY ([SubordinateID])
    REFERENCES [dbo].[Subordinates]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SubordinateTudi_gtgl_TaskCode'
CREATE INDEX [IX_FK_SubordinateTudi_gtgl_TaskCode]
ON [dbo].[Tudi_gtgl_TaskCode]
    ([SubordinateID]);
GO

-- Creating foreign key on [AdministrativecodeSacID] in table 'Tudi_gtgl_TaskCode'
ALTER TABLE [dbo].[Tudi_gtgl_TaskCode]
ADD CONSTRAINT [FK_AdministrativecodeTudi_gtgl_TaskCode]
    FOREIGN KEY ([AdministrativecodeSacID])
    REFERENCES [dbo].[Administrativecodes]
        ([SacID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AdministrativecodeTudi_gtgl_TaskCode'
CREATE INDEX [IX_FK_AdministrativecodeTudi_gtgl_TaskCode]
ON [dbo].[Tudi_gtgl_TaskCode]
    ([AdministrativecodeSacID]);
GO

-- Creating foreign key on [Geo_GraphID] in table 'Tudi_plotInfo'
ALTER TABLE [dbo].[Tudi_plotInfo]
ADD CONSTRAINT [FK_Geo_GraphTudi_plotInfo]
    FOREIGN KEY ([Geo_GraphID])
    REFERENCES [dbo].[Land_Graphs]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Geo_GraphTudi_plotInfo'
CREATE INDEX [IX_FK_Geo_GraphTudi_plotInfo]
ON [dbo].[Tudi_plotInfo]
    ([Geo_GraphID]);
GO

-- Creating foreign key on [Tudi_st_approveInfoId] in table 'Tudi_st_approveInfo'
ALTER TABLE [dbo].[Tudi_st_approveInfo]
ADD CONSTRAINT [FK_Tudi_st_approveInfoTudi_st_approveInfo]
    FOREIGN KEY ([Tudi_st_approveInfoId])
    REFERENCES [dbo].[Tudi_st_approveInfo]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tudi_st_approveInfoTudi_st_approveInfo'
CREATE INDEX [IX_FK_Tudi_st_approveInfoTudi_st_approveInfo]
ON [dbo].[Tudi_st_approveInfo]
    ([Tudi_st_approveInfoId]);
GO

-- Creating foreign key on [Tudi_stph_ApproveInfoId] in table 'Tudi_stph_ApproveInfo'
ALTER TABLE [dbo].[Tudi_stph_ApproveInfo]
ADD CONSTRAINT [FK_Tudi_stph_ApproveInfoTudi_stph_ApproveInfo]
    FOREIGN KEY ([Tudi_stph_ApproveInfoId])
    REFERENCES [dbo].[Tudi_stph_ApproveInfo]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tudi_stph_ApproveInfoTudi_stph_ApproveInfo'
CREATE INDEX [IX_FK_Tudi_stph_ApproveInfoTudi_stph_ApproveInfo]
ON [dbo].[Tudi_stph_ApproveInfo]
    ([Tudi_stph_ApproveInfoId]);
GO

-- Creating foreign key on [Tudi_dikuaiyongtuId] in table 'Tudi_plotInfo'
ALTER TABLE [dbo].[Tudi_plotInfo]
ADD CONSTRAINT [FK_Tudi_dikuaiyongtuTudi_plotInfo]
    FOREIGN KEY ([Tudi_dikuaiyongtuId])
    REFERENCES [dbo].[Tudi_dikuaiyongtu]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tudi_dikuaiyongtuTudi_plotInfo'
CREATE INDEX [IX_FK_Tudi_dikuaiyongtuTudi_plotInfo]
ON [dbo].[Tudi_plotInfo]
    ([Tudi_dikuaiyongtuId]);
GO

-- Creating foreign key on [Tudi_projInfoId] in table 'Tudi_plotInfo'
ALTER TABLE [dbo].[Tudi_plotInfo]
ADD CONSTRAINT [FK_Tudi_projInfoTudi_plotInfo]
    FOREIGN KEY ([Tudi_projInfoId])
    REFERENCES [dbo].[Tudi_projInfo]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tudi_projInfoTudi_plotInfo'
CREATE INDEX [IX_FK_Tudi_projInfoTudi_plotInfo]
ON [dbo].[Tudi_plotInfo]
    ([Tudi_projInfoId]);
GO

-- Creating foreign key on [Tudi_st_approveInfoId] in table 'Tudi_Approve_PlotInfo'
ALTER TABLE [dbo].[Tudi_Approve_PlotInfo]
ADD CONSTRAINT [FK_Tudi_st_approveInfoTudi_Approve_PlotInfo]
    FOREIGN KEY ([Tudi_st_approveInfoId])
    REFERENCES [dbo].[Tudi_st_approveInfo]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tudi_st_approveInfoTudi_Approve_PlotInfo'
CREATE INDEX [IX_FK_Tudi_st_approveInfoTudi_Approve_PlotInfo]
ON [dbo].[Tudi_Approve_PlotInfo]
    ([Tudi_st_approveInfoId]);
GO

-- Creating foreign key on [Tudi_ApproveInfoId] in table 'Tudi_Approve_PlotInfo'
ALTER TABLE [dbo].[Tudi_Approve_PlotInfo]
ADD CONSTRAINT [FK_Tudi_ApproveInfoTudi_Approve_PlotInfo]
    FOREIGN KEY ([Tudi_ApproveInfoId])
    REFERENCES [dbo].[Tudi_ApproveInfo]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tudi_ApproveInfoTudi_Approve_PlotInfo'
CREATE INDEX [IX_FK_Tudi_ApproveInfoTudi_Approve_PlotInfo]
ON [dbo].[Tudi_Approve_PlotInfo]
    ([Tudi_ApproveInfoId]);
GO

-- Creating foreign key on [Tudi_stph_ApproveInfoId] in table 'Tudi_Approve_PlotInfo'
ALTER TABLE [dbo].[Tudi_Approve_PlotInfo]
ADD CONSTRAINT [FK_Tudi_stph_ApproveInfoTudi_Approve_PlotInfo]
    FOREIGN KEY ([Tudi_stph_ApproveInfoId])
    REFERENCES [dbo].[Tudi_stph_ApproveInfo]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tudi_stph_ApproveInfoTudi_Approve_PlotInfo'
CREATE INDEX [IX_FK_Tudi_stph_ApproveInfoTudi_Approve_PlotInfo]
ON [dbo].[Tudi_Approve_PlotInfo]
    ([Tudi_stph_ApproveInfoId]);
GO

-- Creating foreign key on [Tudi_plotInfoId] in table 'Tudi_Approve_PlotInfo'
ALTER TABLE [dbo].[Tudi_Approve_PlotInfo]
ADD CONSTRAINT [FK_Tudi_plotInfoTudi_Approve_PlotInfo]
    FOREIGN KEY ([Tudi_plotInfoId])
    REFERENCES [dbo].[Tudi_plotInfo]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tudi_plotInfoTudi_Approve_PlotInfo'
CREATE INDEX [IX_FK_Tudi_plotInfoTudi_Approve_PlotInfo]
ON [dbo].[Tudi_Approve_PlotInfo]
    ([Tudi_plotInfoId]);
GO

-- Creating foreign key on [Tudi_dikuaiyongtuId] in table 'Tudi_Approve_PlotInfo'
ALTER TABLE [dbo].[Tudi_Approve_PlotInfo]
ADD CONSTRAINT [FK_Tudi_dikuaiyongtuTudi_Approve_PlotInfo]
    FOREIGN KEY ([Tudi_dikuaiyongtuId])
    REFERENCES [dbo].[Tudi_dikuaiyongtu]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tudi_dikuaiyongtuTudi_Approve_PlotInfo'
CREATE INDEX [IX_FK_Tudi_dikuaiyongtuTudi_Approve_PlotInfo]
ON [dbo].[Tudi_Approve_PlotInfo]
    ([Tudi_dikuaiyongtuId]);
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

-- Creating foreign key on [UserID] in table 'Employees1'
ALTER TABLE [dbo].[Employees1]
ADD CONSTRAINT [FK_UserEmployee]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserEmployee'
CREATE INDEX [IX_FK_UserEmployee]
ON [dbo].[Employees1]
    ([UserID]);
GO

-- Creating foreign key on [PostRequireID] in table 'Positions'
ALTER TABLE [dbo].[Positions]
ADD CONSTRAINT [FK_PostRequirePosition]
    FOREIGN KEY ([PostRequireID])
    REFERENCES [dbo].[PostRequires]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PostRequirePosition'
CREATE INDEX [IX_FK_PostRequirePosition]
ON [dbo].[Positions]
    ([PostRequireID]);
GO

-- Creating foreign key on [PostID] in table 'Posts'
ALTER TABLE [dbo].[Posts]
ADD CONSTRAINT [FK_PostPost]
    FOREIGN KEY ([PostID])
    REFERENCES [dbo].[Posts]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PostPost'
CREATE INDEX [IX_FK_PostPost]
ON [dbo].[Posts]
    ([PostID]);
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

-- Creating foreign key on [PositionID] in table 'Employees1'
ALTER TABLE [dbo].[Employees1]
ADD CONSTRAINT [FK_PositionEmployee]
    FOREIGN KEY ([PositionID])
    REFERENCES [dbo].[Positions]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PositionEmployee'
CREATE INDEX [IX_FK_PositionEmployee]
ON [dbo].[Employees1]
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

-- Creating foreign key on [OrganizationID] in table 'Posts'
ALTER TABLE [dbo].[Posts]
ADD CONSTRAINT [FK_OrganizationPost]
    FOREIGN KEY ([OrganizationID])
    REFERENCES [dbo].[Organizations]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrganizationPost'
CREATE INDEX [IX_FK_OrganizationPost]
ON [dbo].[Posts]
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

-- Creating foreign key on [OrganizationID] in table 'Employees1'
ALTER TABLE [dbo].[Employees1]
ADD CONSTRAINT [FK_OrganizationEmployee]
    FOREIGN KEY ([OrganizationID])
    REFERENCES [dbo].[Organizations]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrganizationEmployee'
CREATE INDEX [IX_FK_OrganizationEmployee]
ON [dbo].[Employees1]
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
    REFERENCES [dbo].[Organizations]
        ([ID])
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
    REFERENCES [dbo].[Posts]
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
    REFERENCES [dbo].[Organizations]
        ([ID])
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
    REFERENCES [dbo].[Posts]
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
    REFERENCES [dbo].[Users]
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
    REFERENCES [dbo].[Users]
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
    REFERENCES [dbo].[Users]
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
    REFERENCES [dbo].[Organizations]
        ([ID])
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
    REFERENCES [dbo].[Posts]
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
    REFERENCES [dbo].[Users]
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
    REFERENCES [dbo].[Users]
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
    REFERENCES [dbo].[Posts]
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

-- Creating foreign key on [UserID] in table 'CustomerGoups'
ALTER TABLE [dbo].[CustomerGoups]
ADD CONSTRAINT [FK_UserCustomerGoup1]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserCustomerGoup1'
CREATE INDEX [IX_FK_UserCustomerGoup1]
ON [dbo].[CustomerGoups]
    ([UserID]);
GO

-- Creating foreign key on [EmployeeId] in table 'JobChanges'
ALTER TABLE [dbo].[JobChanges]
ADD CONSTRAINT [FK_EmployeeJobChange]
    FOREIGN KEY ([EmployeeId])
    REFERENCES [dbo].[Employees1]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeeJobChange'
CREATE INDEX [IX_FK_EmployeeJobChange]
ON [dbo].[JobChanges]
    ([EmployeeId]);
GO

-- Creating foreign key on [PostID] in table 'JobChanges'
ALTER TABLE [dbo].[JobChanges]
ADD CONSTRAINT [FK_PostJobChange]
    FOREIGN KEY ([PostID])
    REFERENCES [dbo].[Posts]
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

-- Creating foreign key on [WorkSpaceBaseTypeId] in table 'DocLocations'
ALTER TABLE [dbo].[DocLocations]
ADD CONSTRAINT [FK_WorkSpaceBaseTypeDocLocation]
    FOREIGN KEY ([WorkSpaceBaseTypeId])
    REFERENCES [dbo].[WorkSpaceBaseTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WorkSpaceBaseTypeDocLocation'
CREATE INDEX [IX_FK_WorkSpaceBaseTypeDocLocation]
ON [dbo].[DocLocations]
    ([WorkSpaceBaseTypeId]);
GO

-- Creating foreign key on [LoginLogID] in table 'EventTimes'
ALTER TABLE [dbo].[EventTimes]
ADD CONSTRAINT [FK_LoginLogEventTime]
    FOREIGN KEY ([LoginLogID])
    REFERENCES [dbo].[LoginLogs]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LoginLogEventTime'
CREATE INDEX [IX_FK_LoginLogEventTime]
ON [dbo].[EventTimes]
    ([LoginLogID]);
GO

-- Creating foreign key on [PositionID1] in table 'Posts'
ALTER TABLE [dbo].[Posts]
ADD CONSTRAINT [FK_PositionPost]
    FOREIGN KEY ([PositionID1])
    REFERENCES [dbo].[Positions]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PositionPost'
CREATE INDEX [IX_FK_PositionPost]
ON [dbo].[Posts]
    ([PositionID1]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------