using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCP.Common;
using BCP.Domain;
using BCP.Domain.Edmx;
using BCP.ViewModel;

namespace BCP.Domain
{
    public class OrgService:IOrgService
    {

        private IOrganizationRepository _organizationRepository = null;
        private IOrgManagerRepository _orgManagerRepository = null;
        private IUserRepository _userRepository = null;
        private IUnitOfWork _unitOfWork = null;

        public OrgService(IUnitOfWork unitOfWork,
            IOrganizationRepository organizationRepository,IOrgManagerRepository orgManagerRepository,IUserRepository userRepository)
        {
            this._organizationRepository = organizationRepository;
            this._orgManagerRepository = orgManagerRepository;
            this._userRepository = userRepository;
            this._unitOfWork = unitOfWork;

            this._organizationRepository.UnitOfWork = unitOfWork;
            this._orgManagerRepository.UnitOfWork = unitOfWork;
            this._userRepository.UnitOfWork = unitOfWork;
        }

        #region IOrgServicve 成员

        public OrganizationDTO Register(String certificates,int userId,bool isRoot,String markerString,String notes,
            String orgaName,int? parentId,String type,String orgCode)
        {
            Organization org = new Organization();
            org.Certificates = certificates;
            org.CreateTime = DateTime.Now;
            org.CreateUserId = userId;
            org.IsDeleted = false;
            org.IsRoot = isRoot;
            org.MarkerString = markerString;
            org.Notes = notes;
            org.OrgaName = orgaName;
            org.OrganizationCode = orgCode;
            org.ParentId = parentId;
            org.Type = type;
            if (parentId == null && isRoot == false) throw new Exception("非组织节点父级不能为空！");
            if (parentId == null) org.RootId = null;
            else
            {
                Organization parent = _organizationRepository.GetAll().Where(it => it.IsDeleted == false && it.Id == (int)parentId).FirstOrDefault();
                if (parent == null) throw new Exception("出错了");
                org.RootId = parent.IsRoot ? parent.Id : parent.RootId;
            }
            org.State = "True";
            if (org.OrgManagers == null) org.OrgManagers = new List<OrgManager>();
            org.OrgManagers.Add(new OrgManager() { CrateUserId = userId, CreateTime = DateTime.Now, IsDeleted = false, Notes = "", State = "True", UserId = userId });
            _organizationRepository.Add(org);
            _unitOfWork.Commit();
            return org.MapperTo<Organization, OrganizationDTO>();
        }

        public OrganizationDTO GetOrgById(int orgId)
        {
            return _organizationRepository.GetAll()
                .Where(it => it.IsDeleted == false && it.Id == orgId)
                .FirstOrDefault()
                .MapperTo<Organization, OrganizationDTO>();
        }

        public List<OrganizationDTO> GetOrgChildrenById(int orgId)
        {
            return _organizationRepository.GetAll()
                .Where(it => it.IsDeleted == false && it.ParentId == orgId)
                .MapperTo<Organization, OrganizationDTO>()
                .ToList();
        }

        public OrganizationDTO GetOrgRootById(int orgId)
        {
            //return _organizationRepository.GetAll()
            //    .Where(it=>it.IsDeleted==false&&it.Id==orgId)
            //    .FirstOrDefault()
            //    .MapperTo<Organization, OrganizationDTO>();
            Organization org = _organizationRepository.GetAll()
                .Where(it => it.IsDeleted == false && it.Id == orgId)
                .FirstOrDefault();
            if (org == null) throw new Exception("不存在的组织");
            if (org.IsRoot) return org.MapperTo<Organization, OrganizationDTO>();
            else
            {
                return _organizationRepository.GetAll()
                    .Where(it=>it.IsDeleted==false&&it.Id==org.RootId)
                    .FirstOrDefault()
                    .MapperTo<Organization, OrganizationDTO>();
            }
        }

        public List<OrganizationDTO> GetAllOrgRoot()
        {
            return _organizationRepository.GetAll()
                .Where(it => it.IsDeleted == false && it.IsRoot == true)
                .MapperTo<Organization, OrganizationDTO>()
                .ToList();
        }

        public List<OrgManagerDTO> GetOrgManagerById(int orgId)
        {
            return _orgManagerRepository.GetAll()
                .Where(it => it.IsDeleted == false && it.OrganizationId == orgId)
                .MapperTo<OrgManager, OrgManagerDTO>()
                .ToList();
        }

        public bool ShiftOrgManager(int orgId, int userId, int loginId, bool isMananger)
        {
            Organization org = _organizationRepository.GetAll()
                .Where(it => it.IsDeleted == true && it.Id == orgId).FirstOrDefault();

            OrgManager loginUser = _orgManagerRepository.GetAll()
                .Where(it => it.IsDeleted == false && it.UserId == loginId)
                .FirstOrDefault();

            if (org == null || loginUser == null) throw new Exception("没有权限或者不存在的组织");

            if (isMananger)
            {
                OrgManager orgManager = new OrgManager() { CrateUserId = loginId, CreateTime = DateTime.Now, IsDeleted = false, UserId = userId };
                _orgManagerRepository.Add(orgManager);
                _unitOfWork.Commit();
            }
            else
            {
                OrgManager orgManager = _orgManagerRepository.GetAll()
                    .Where(it => it.IsDeleted == false && it.UserId == userId)
                    .FirstOrDefault();
                if (orgManager == null) throw new Exception("不存在的组织管理员");

                orgManager.IsDeleted = true;
                _orgManagerRepository.Save(orgManager);
                _unitOfWork.Commit();
            }
            return true;
        }

        public bool RemoveOrg(int orgId, int loginId)
        {
            Organization org = _organizationRepository.GetAll()
                .Where(it => it.IsDeleted == false && it.Id == orgId).FirstOrDefault();

            OrgManager loginUser = _orgManagerRepository.GetAll()
                .Where(it => it.IsDeleted == false && it.UserId == loginId)
                .FirstOrDefault();

            if (org == null || loginUser == null) throw new Exception("没有权限或者不存在的组织");

            if (org.IsRoot)
            {
                //清除所有节点以及子节点
                var list = _organizationRepository.GetAll()
                    .Where(it => it.Id == org.Id || it.RootId == org.Id).ToList();
                foreach (var item in list)
                {
                    item.IsDeleted = true;
                    _organizationRepository.Save(item);
                }

                //清理管理表

                var list2 = _orgManagerRepository.GetAll()
                    .Where(it => it.IsDeleted == false && it.OrganizationId == org.Id)
                    .ToList();
                foreach (var item in list2)
                {
                    item.IsDeleted = true;
                    _orgManagerRepository.Save(item);
                }

                //清理其他数据

                _unitOfWork.Commit();
            }
            else
            {
                var list = _organizationRepository.GetAll()
                    .Where(it => it.ParentId == org.Id).ToList();
                if (list != null) throw new Exception("非叶子节点、根节点");

                //清除节点
                org.IsDeleted = true;
                _organizationRepository.Save(org);

                //清除管理表 非根节点不需清理管理表

                //清除相关数据

                _unitOfWork.Commit();
            }
            return true;
        }

        #endregion
    }
}
