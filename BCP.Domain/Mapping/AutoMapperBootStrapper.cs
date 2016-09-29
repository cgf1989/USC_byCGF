using AutoMapper;
using BCP.Domain.Edmx;
using System.Collections.Generic;
using BCP.ViewModel;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BCP.Domain.Mapping
{
    /// <summary>
    /// AutoMapper配置类
    /// </summary>
    public class AutoMapperBootStrapper
    {
        public static void Start()
        {
//
            Mapper.CreateMap<Administrativecode, AdministrativecodeDTO>();
            Mapper.CreateMap<AdministrativecodeDTO, Administrativecode>();

//
            Mapper.CreateMap<AssetBaseType, AssetBaseTypeDTO>();
            Mapper.CreateMap<AssetBaseTypeDTO, AssetBaseType>();

//
            Mapper.CreateMap<AssetMaintenance, AssetMaintenanceDTO>();
            Mapper.CreateMap<AssetMaintenanceDTO, AssetMaintenance>();

//
            Mapper.CreateMap<AssetUse, AssetUseDTO>();
            Mapper.CreateMap<AssetUseDTO, AssetUse>();

//
            Mapper.CreateMap<Authorization, AuthorizationDTO>();
            Mapper.CreateMap<AuthorizationDTO, Authorization>();

//
            Mapper.CreateMap<BussnessVer, BussnessVerDTO>();
            Mapper.CreateMap<BussnessVerDTO, BussnessVer>();

//
            Mapper.CreateMap<CustomCategory, CustomCategoryDTO>();
            Mapper.CreateMap<CustomCategoryDTO, CustomCategory>();

//
            Mapper.CreateMap<CustomGroup, CustomGroupDTO>();
            Mapper.CreateMap<CustomGroupDTO, CustomGroup>();

//
            Mapper.CreateMap<CustomGroupUser, CustomGroupUserDTO>();
            Mapper.CreateMap<CustomGroupUserDTO, CustomGroupUser>();

//
            Mapper.CreateMap<CustomTabData, CustomTabDataDTO>();
            Mapper.CreateMap<CustomTabDataDTO, CustomTabData>();

//
            Mapper.CreateMap<CustomTable, CustomTableDTO>();
            Mapper.CreateMap<CustomTableDTO, CustomTable>();

//
            Mapper.CreateMap<DllFileStream, DllFileStreamDTO>();
            Mapper.CreateMap<DllFileStreamDTO, DllFileStream>();

//
            Mapper.CreateMap<DocCheckState, DocCheckStateDTO>();
            Mapper.CreateMap<DocCheckStateDTO, DocCheckState>();

//
            Mapper.CreateMap<DocComent, DocComentDTO>();
            Mapper.CreateMap<DocComentDTO, DocComent>();

//
            Mapper.CreateMap<DocLocation, DocLocationDTO>();
            Mapper.CreateMap<DocLocationDTO, DocLocation>();

//
            Mapper.CreateMap<DocManageState, DocManageStateDTO>();
            Mapper.CreateMap<DocManageStateDTO, DocManageState>();

//
            Mapper.CreateMap<DocReader, DocReaderDTO>();
            Mapper.CreateMap<DocReaderDTO, DocReader>();

//
            Mapper.CreateMap<DocSender, DocSenderDTO>();
            Mapper.CreateMap<DocSenderDTO, DocSender>();

//
            Mapper.CreateMap<DocType, DocTypeDTO>();
            Mapper.CreateMap<DocTypeDTO, DocType>();

//
            Mapper.CreateMap<DocumentContent, DocumentContentDTO>();
            Mapper.CreateMap<DocumentContentDTO, DocumentContent>();

//
            Mapper.CreateMap<DocumentManage, DocumentManageDTO>();
            Mapper.CreateMap<DocumentManageDTO, DocumentManage>();

//
            Mapper.CreateMap<DocumentType, DocumentTypeDTO>();
            Mapper.CreateMap<DocumentTypeDTO, DocumentType>();

//
            Mapper.CreateMap<Employee, EmployeeDTO>();
            Mapper.CreateMap<EmployeeDTO, Employee>();

//
            Mapper.CreateMap<Group, GroupDTO>();
            Mapper.CreateMap<GroupDTO, Group>();

//
            Mapper.CreateMap<GroupMember, GroupMemberDTO>();
            Mapper.CreateMap<GroupMemberDTO, GroupMember>();

//
            Mapper.CreateMap<GroupMessager, GroupMessagerDTO>();
            Mapper.CreateMap<GroupMessagerDTO, GroupMessager>();

//
            Mapper.CreateMap<IndustryCode, IndustryCodeDTO>();
            Mapper.CreateMap<IndustryCodeDTO, IndustryCode>();

//
            Mapper.CreateMap<IndustrySolution, IndustrySolutionDTO>();
            Mapper.CreateMap<IndustrySolutionDTO, IndustrySolution>();

//
            Mapper.CreateMap<IPCode, IPCodeDTO>();
            Mapper.CreateMap<IPCodeDTO, IPCode>();

//
            Mapper.CreateMap<JobChange, JobChangeDTO>();
            Mapper.CreateMap<JobChangeDTO, JobChange>();

//
            Mapper.CreateMap<LandState, LandStateDTO>();
            Mapper.CreateMap<LandStateDTO, LandState>();

//
            Mapper.CreateMap<LoginLog, LoginLogDTO>();
            Mapper.CreateMap<LoginLogDTO, LoginLog>();

//
            Mapper.CreateMap<ModulProperty, ModulPropertyDTO>();
            Mapper.CreateMap<ModulPropertyDTO, ModulProperty>();

//
            Mapper.CreateMap<OperationDetail, OperationDetailDTO>();
            Mapper.CreateMap<OperationDetailDTO, OperationDetail>();

//
            Mapper.CreateMap<OperationEvent, OperationEventDTO>();
            Mapper.CreateMap<OperationEventDTO, OperationEvent>();

//
            Mapper.CreateMap<OrganicInvestor, OrganicInvestorDTO>();
            Mapper.CreateMap<OrganicInvestorDTO, OrganicInvestor>();

//
            Mapper.CreateMap<Organization, OrganizationDTO>();
            Mapper.CreateMap<OrganizationDTO, Organization>();

//
            Mapper.CreateMap<OrganizationAssetType, OrganizationAssetTypeDTO>();
            Mapper.CreateMap<OrganizationAssetTypeDTO, OrganizationAssetType>();

//
            Mapper.CreateMap<OrganizationCustomType, OrganizationCustomTypeDTO>();
            Mapper.CreateMap<OrganizationCustomTypeDTO, OrganizationCustomType>();

//
            Mapper.CreateMap<OrganizationEvent, OrganizationEventDTO>();
            Mapper.CreateMap<OrganizationEventDTO, OrganizationEvent>();

//
            Mapper.CreateMap<OrganizationOtherName, OrganizationOtherNameDTO>();
            Mapper.CreateMap<OrganizationOtherNameDTO, OrganizationOtherName>();

//
            Mapper.CreateMap<OrganizationTransition, OrganizationTransitionDTO>();
            Mapper.CreateMap<OrganizationTransitionDTO, OrganizationTransition>();

//
            Mapper.CreateMap<Organization_ContacTable, Organization_ContacTableDTO>();
            Mapper.CreateMap<Organization_ContacTableDTO, Organization_ContacTable>();

//
            Mapper.CreateMap<Organization_Type, Organization_TypeDTO>();
            Mapper.CreateMap<Organization_TypeDTO, Organization_Type>();

//
            Mapper.CreateMap<OrganizBasic, OrganizBasicDTO>();
            Mapper.CreateMap<OrganizBasicDTO, OrganizBasic>();

//
            Mapper.CreateMap<OrgaRegisterDocment, OrgaRegisterDocmentDTO>();
            Mapper.CreateMap<OrgaRegisterDocmentDTO, OrgaRegisterDocment>();

//
            Mapper.CreateMap<OrgManager, OrgManagerDTO>();
            Mapper.CreateMap<OrgManagerDTO, OrgManager>();

//
            Mapper.CreateMap<physicalAsset, physicalAssetDTO>();
            Mapper.CreateMap<physicalAssetDTO, physicalAsset>();

//
            Mapper.CreateMap<Position, PositionDTO>();
            Mapper.CreateMap<PositionDTO, Position>();

//
            Mapper.CreateMap<Post, PostDTO>();
            Mapper.CreateMap<PostDTO, Post>();

//
            Mapper.CreateMap<PostRequire, PostRequireDTO>();
            Mapper.CreateMap<PostRequireDTO, PostRequire>();

//
            Mapper.CreateMap<Product, ProductDTO>();
            Mapper.CreateMap<ProductDTO, Product>();

//
            Mapper.CreateMap<ProductComposition, ProductCompositionDTO>();
            Mapper.CreateMap<ProductCompositionDTO, ProductComposition>();

//
            Mapper.CreateMap<ProductCustomCategory, ProductCustomCategoryDTO>();
            Mapper.CreateMap<ProductCustomCategoryDTO, ProductCustomCategory>();

//
            Mapper.CreateMap<ProductCustomType, ProductCustomTypeDTO>();
            Mapper.CreateMap<ProductCustomTypeDTO, ProductCustomType>();

//
            Mapper.CreateMap<ProductEvent, ProductEventDTO>();
            Mapper.CreateMap<ProductEventDTO, ProductEvent>();

//
            Mapper.CreateMap<ProductStandard, ProductStandardDTO>();
            Mapper.CreateMap<ProductStandardDTO, ProductStandard>();

//
            Mapper.CreateMap<RegisterDocumentType, RegisterDocumentTypeDTO>();
            Mapper.CreateMap<RegisterDocumentTypeDTO, RegisterDocumentType>();

//
            Mapper.CreateMap<Securityinfo, SecurityinfoDTO>();
            Mapper.CreateMap<SecurityinfoDTO, Securityinfo>();

//
            Mapper.CreateMap<Specialized, SpecializedDTO>();
            Mapper.CreateMap<SpecializedDTO, Specialized>();

//
            Mapper.CreateMap<Subordinate, SubordinateDTO>();
            Mapper.CreateMap<SubordinateDTO, Subordinate>();

//
            Mapper.CreateMap<User, UserDTO>();
            Mapper.CreateMap<UserDTO, User>();

//
            Mapper.CreateMap<UserMessage, UserMessageDTO>();
            Mapper.CreateMap<UserMessageDTO, UserMessage>();

//
            Mapper.CreateMap<UserRelateTable, UserRelateTableDTO>();
            Mapper.CreateMap<UserRelateTableDTO, UserRelateTable>();

//
            Mapper.CreateMap<UserRelateType, UserRelateTypeDTO>();
            Mapper.CreateMap<UserRelateTypeDTO, UserRelateType>();

//
            Mapper.CreateMap<User_ContacTable, User_ContacTableDTO>();
            Mapper.CreateMap<User_ContacTableDTO, User_ContacTable>();

//
            Mapper.CreateMap<WorkMessage, WorkMessageDTO>();
            Mapper.CreateMap<WorkMessageDTO, WorkMessage>();

//
            Mapper.CreateMap<WorkModul, WorkModulDTO>();
            Mapper.CreateMap<WorkModulDTO, WorkModul>();

//
            Mapper.CreateMap<WorkSpace, WorkSpaceDTO>();
            Mapper.CreateMap<WorkSpaceDTO, WorkSpace>();

//
            Mapper.CreateMap<WorkSpaceBaseType, WorkSpaceBaseTypeDTO>();
            Mapper.CreateMap<WorkSpaceBaseTypeDTO, WorkSpaceBaseType>();

//
            Mapper.CreateMap<WorkSpaceRole, WorkSpaceRoleDTO>();
            Mapper.CreateMap<WorkSpaceRoleDTO, WorkSpaceRole>();

//
            Mapper.CreateMap<WorkSpaceType, WorkSpaceTypeDTO>();
            Mapper.CreateMap<WorkSpaceTypeDTO, WorkSpaceType>();

//
            Mapper.CreateMap<workTask, workTaskDTO>();
            Mapper.CreateMap<workTaskDTO, workTask>();

//
            Mapper.CreateMap<ZipCode, ZipCodeDTO>();
            Mapper.CreateMap<ZipCodeDTO, ZipCode>();

//
            Mapper.CreateMap<CustomerGoup, CustomerGoupDTO>();
            Mapper.CreateMap<CustomerGoupDTO, CustomerGoup>();

//
            Mapper.CreateMap<CustomGeographicType, CustomGeographicTypeDTO>();
            Mapper.CreateMap<CustomGeographicTypeDTO, CustomGeographicType>();

//
            Mapper.CreateMap<DesktopGeoManage, DesktopGeoManageDTO>();
            Mapper.CreateMap<DesktopGeoManageDTO, DesktopGeoManage>();

//
            Mapper.CreateMap<EventTime, EventTimeDTO>();
            Mapper.CreateMap<EventTimeDTO, EventTime>();

//
            Mapper.CreateMap<GroupName, GroupNameDTO>();
            Mapper.CreateMap<GroupNameDTO, GroupName>();

//
            Mapper.CreateMap<MessageGroupMessager, MessageGroupMessagerDTO>();
            Mapper.CreateMap<MessageGroupMessagerDTO, MessageGroupMessager>();

//
            Mapper.CreateMap<UserGroup, UserGroupDTO>();
            Mapper.CreateMap<UserGroupDTO, UserGroup>();

        }
    }
}
