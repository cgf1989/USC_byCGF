using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCP.ViewModel;

namespace BCP.Domain
{
    public interface IOrgService
    {
        #region Org
        /// <summary>
        /// 创建组织
        /// </summary>
        /// <param name="certificates">证书</param>
        /// <param name="loginId">登录用户主键</param>
        /// <param name="isRoot"></param>
        /// <param name="markerString"></param>
        /// <param name="notes"></param>
        /// <param name="orgaName"></param>
        /// <param name="parentId"></param>
        /// <param name="type"></param>
        /// <param name="orgCode"></param>
        /// <returns></returns>
        OrganizationDTO Register(string certificates, int loginId, bool isRoot, string markerString, string notes, string orgaName, int? parentId, string type, string orgCode);

        /// <summary>
        /// 根据组织主键获取组织
        /// </summary>
        /// <param name="orgId"></param>
        /// <returns></returns>
        OrganizationDTO GetOrgById(int orgId);

        /// <summary>
        /// 根据组织主键获取子集组织
        /// </summary>
        /// <param name="orgId"></param>
        /// <returns></returns>
        List<OrganizationDTO> GetOrgChildrenById(int orgId);

        /// <summary>
        /// 根据组织主键获取组织根节点
        /// </summary>
        /// <param name="orgId"></param>
        /// <returns></returns>
        OrganizationDTO GetOrgRootById(int orgId);

        /// <summary>
        /// 获取所有组织根节点
        /// </summary>
        /// <returns></returns>
        List<OrganizationDTO> GetAllOrgRoot();

        /// <summary>
        /// 根据组织组件获取组织管理员
        /// </summary>
        /// <param name="orgId"></param>
        /// <returns></returns>
        List<OrgManagerDTO> GetOrgManagerById(int orgId);
    
        /// <summary>
        /// 设置组织管理员
        /// </summary>
        /// <param name="orgId"></param>
        /// <param name="userId">待设置用户主键</param>
        /// <param name="loginId">登录用户主键</param>
        /// <param name="IsMananger"></param>
        /// <returns></returns>
        bool ShiftOrgManager(int orgId, int userId, int loginId, bool isMananger);

        /// <summary>
        /// 移除组织
        /// </summary>
        /// <param name="OrgId"></param>
        /// <param name="loginId">登录用户主键</param>
        /// <returns></returns>
        bool RemoveOrg(int orgId, int loginId);

        #endregion
    }
}
