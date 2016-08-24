using BCP.Domain;
using BCP.Common;
using BCP.Domain.Service;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BCP.WebAPI.Controllers
{
    /// <summary>
    /// Unit配置类
    /// </summary>
    public class UnityBootStrapper
    {
        public IUnityContainer UnityContainer = new UnityContainer();

        public void Bindings()
        {
            UnityContainer.AddNewExtension<Interception>();
            UnityContainer.RegisterType<IUnitOfWork, EFUnitOfWork>();
            UnityContainer.RegisterType<IAdministrativecodeRepository, AdministrativecodeRepository>();
            UnityContainer.RegisterType<IAssetBaseTypeRepository, AssetBaseTypeRepository>();
            UnityContainer.RegisterType<IAssetMaintenanceRepository, AssetMaintenanceRepository>();
            UnityContainer.RegisterType<IAssetUseRepository, AssetUseRepository>();
            UnityContainer.RegisterType<IAuthorizationRepository, AuthorizationRepository>();
            UnityContainer.RegisterType<IBussnessVerRepository, BussnessVerRepository>();
            UnityContainer.RegisterType<ICustomCategoryRepository, CustomCategoryRepository>();
            UnityContainer.RegisterType<ICustomGroupRepository, CustomGroupRepository>();
            UnityContainer.RegisterType<ICustomGroupUserRepository, CustomGroupUserRepository>();
            UnityContainer.RegisterType<ICustomTabDataRepository, CustomTabDataRepository>();
            UnityContainer.RegisterType<ICustomTableRepository, CustomTableRepository>();
            UnityContainer.RegisterType<IDllFileStreamRepository, DllFileStreamRepository>();
            UnityContainer.RegisterType<IDocCheckStateRepository, DocCheckStateRepository>();
            UnityContainer.RegisterType<IDocComentRepository, DocComentRepository>();
            UnityContainer.RegisterType<IDocLocationRepository, DocLocationRepository>();
            UnityContainer.RegisterType<IDocManageStateRepository, DocManageStateRepository>();
            UnityContainer.RegisterType<IDocReaderRepository, DocReaderRepository>();
            UnityContainer.RegisterType<IDocSenderRepository, DocSenderRepository>();
            UnityContainer.RegisterType<IDocTypeRepository, DocTypeRepository>();
            UnityContainer.RegisterType<IDocumentContentRepository, DocumentContentRepository>();
            UnityContainer.RegisterType<IDocumentManageRepository, DocumentManageRepository>();
            UnityContainer.RegisterType<IDocumentTypeRepository, DocumentTypeRepository>();
            UnityContainer.RegisterType<IEmployeeRepository, EmployeeRepository>();
            UnityContainer.RegisterType<IGroupRepository, GroupRepository>();
            UnityContainer.RegisterType<IGroupMemberRepository, GroupMemberRepository>();
            UnityContainer.RegisterType<IGroupMessagerRepository, GroupMessagerRepository>();
            UnityContainer.RegisterType<IIndustryCodeRepository, IndustryCodeRepository>();
            UnityContainer.RegisterType<IIndustrySolutionRepository, IndustrySolutionRepository>();
            UnityContainer.RegisterType<IIPCodeRepository, IPCodeRepository>();
            UnityContainer.RegisterType<IJobChangeRepository, JobChangeRepository>();
            UnityContainer.RegisterType<ILoginLogRepository, LoginLogRepository>();
            UnityContainer.RegisterType<IModulPropertyRepository, ModulPropertyRepository>();
            UnityContainer.RegisterType<IOperationDetailRepository, OperationDetailRepository>();
            UnityContainer.RegisterType<IOperationEventRepository, OperationEventRepository>();
            UnityContainer.RegisterType<IOrganicInvestorRepository, OrganicInvestorRepository>();
            UnityContainer.RegisterType<IOrganizationRepository, OrganizationRepository>();
            UnityContainer.RegisterType<IOrganizationAssetTypeRepository, OrganizationAssetTypeRepository>();
            UnityContainer.RegisterType<IOrganizationCustomTypeRepository, OrganizationCustomTypeRepository>();
            UnityContainer.RegisterType<IOrganizationEventRepository, OrganizationEventRepository>();
            UnityContainer.RegisterType<IOrganizationOtherNameRepository, OrganizationOtherNameRepository>();
            UnityContainer.RegisterType<IOrganizationTransitionRepository, OrganizationTransitionRepository>();
            UnityContainer.RegisterType<IOrganization_ContacTableRepository, Organization_ContacTableRepository>();
            UnityContainer.RegisterType<IOrganization_TypeRepository, Organization_TypeRepository>();
            UnityContainer.RegisterType<IOrganizBasicRepository, OrganizBasicRepository>();
            UnityContainer.RegisterType<IOrgaRegisterDocmentRepository, OrgaRegisterDocmentRepository>();
            UnityContainer.RegisterType<IphysicalAssetRepository, physicalAssetRepository>();
            UnityContainer.RegisterType<IPositionRepository, PositionRepository>();
            UnityContainer.RegisterType<IPostRepository, PostRepository>();
            UnityContainer.RegisterType<IPostRequireRepository, PostRequireRepository>();
            UnityContainer.RegisterType<IProductRepository, ProductRepository>();
            UnityContainer.RegisterType<IProductCompositionRepository, ProductCompositionRepository>();
            UnityContainer.RegisterType<IProductCustomCategoryRepository, ProductCustomCategoryRepository>();
            UnityContainer.RegisterType<IProductCustomTypeRepository, ProductCustomTypeRepository>();
            UnityContainer.RegisterType<IProductEventRepository, ProductEventRepository>();
            UnityContainer.RegisterType<IProductStandardRepository, ProductStandardRepository>();
            UnityContainer.RegisterType<IRegisterDocumentTypeRepository, RegisterDocumentTypeRepository>();
            UnityContainer.RegisterType<ISecurityinfoRepository, SecurityinfoRepository>();
            UnityContainer.RegisterType<ISpecializedRepository, SpecializedRepository>();
            UnityContainer.RegisterType<ISubordinateRepository, SubordinateRepository>();
            UnityContainer.RegisterType<IUserRepository, UserRepository>();
            UnityContainer.RegisterType<IUserMessageRepository, UserMessageRepository>();
            UnityContainer.RegisterType<IUserRelateTableRepository, UserRelateTableRepository>();
            UnityContainer.RegisterType<IUserRelateTypeRepository, UserRelateTypeRepository>();
            UnityContainer.RegisterType<IUser_ContacTableRepository, User_ContacTableRepository>();
            UnityContainer.RegisterType<IWorkMessageRepository, WorkMessageRepository>();
            UnityContainer.RegisterType<IWorkModulRepository, WorkModulRepository>();
            UnityContainer.RegisterType<IWorkSpaceRepository, WorkSpaceRepository>();
            UnityContainer.RegisterType<IWorkSpaceBaseTypeRepository, WorkSpaceBaseTypeRepository>();
            UnityContainer.RegisterType<IWorkSpaceRoleRepository, WorkSpaceRoleRepository>();
            UnityContainer.RegisterType<IWorkSpaceTypeRepository, WorkSpaceTypeRepository>();
            UnityContainer.RegisterType<IworkTaskRepository, workTaskRepository>();
            UnityContainer.RegisterType<IZipCodeRepository, ZipCodeRepository>();
            UnityContainer.RegisterType<IUserService, UserService>();
        }
    }
}
