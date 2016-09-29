using BCP.Domain;
using BCP.ViewModel;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using System.Text;
using BCP.WebAPI.Helpers;
using BCP.WebAPI.Controllers.Filters;
using BCP.WebAPI.SignalR;
using System.Threading.Tasks;
using System.Web;
using System.Diagnostics;
using System.IO;
using BCP.Common.Helper;
using System.Web.Hosting;
using System.Net.Http.Headers;

namespace BCP.WebAPI.Controllers
{
    [WebApiFilter]
    public class OrgController:ApiController
    {
        [Dependency]
        public IOrgService OrgService { get; set; }

        #region OrgCURD

        /// <summary>
        /// 注册组织
        /// </summary>
        /// <param name="certificates">证书</param>
        /// <param name="userId">注册用户主键</param>
        /// <param name="isRoot">是否是组织根节点</param>
        /// <param name="markerString">不知道</param>
        /// <param name="notes">备注</param>
        /// <param name="orgaName">组织名称</param>
        /// <param name="parentId">父节点主键，如果没有父节点设置为零</param>
        /// <param name="type">类型时组织、部门、团体</param>
        /// <param name="orgCode">组织代码101</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage RegisterOrg(String certificates, int userId, bool isRoot, String markerString, String notes,
            String orgaName, int parentId, String type, String orgCode)
        {
            OrganizationDTO org = OrgService.Register(certificates, userId, isRoot, markerString, notes, orgaName, parentId > 0 ? (int?)parentId : null, type, orgCode);
            if (org != null)
            {
                return JsonHelper.GetResponseMessage(true, "注册成功", typeof(OrganizationDTO), false, org);
            }
            else
                throw new Exception("主测失败！");
        }

        /// <summary>
        /// 根据组织Id获取组织数据（不包括子结构）
        /// </summary>
        /// <param name="orgId">组织主键</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetOrgById(int orgId)
        {
            return JsonHelper.GetResponseMessage(true, "获取成功", typeof(OrganizationDTO), false, OrgService.GetOrgById(orgId));
        }

        /// <summary>
        /// 根据组织Id获取子集
        /// </summary>
        /// <param name="orgId">组织组织主键</param>
        /// <param name="top">top为真时获取顶级组织</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetOrgChildren(int orgId)
        {
            return JsonHelper.GetResponseMessage(true, "获取成功", typeof(OrganizationDTO), true, OrgService.GetOrgChildrenById(orgId));
        }

        /// <summary>
        /// 获取部门根记录（即组织节点）
        /// </summary>
        /// <param name="orgId">组织主键</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetOrgRoot(int orgId)
        {
            return JsonHelper.GetResponseMessage(true, "获取成功", typeof(OrganizationDTO), false, OrgService.GetOrgRootById(orgId));
        }

        /// <summary>
        /// 获取所有组织节点
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetAllOrgRoots()
        {
            return JsonHelper.GetResponseMessage(true, "获取成功", typeof(OrganizationDTO), true, OrgService.GetAllOrgRoot());
        }

        /// <summary>
        /// 设置/取消 组织的管理员
        /// </summary>
        /// <param name="orgId">组织主键</param>
        /// <param name="userId">待调整角色的用户主键</param>
        /// <param name="loginId">登录用户主键</param>
        /// <param name="isMananger">是否设置成组织管理员</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage ShiftOrgManager(int orgId,int userId,int loginId,bool isMananger)
        {
            if (OrgService.ShiftOrgManager(orgId, userId,loginId, isMananger))
            {
                return JsonHelper.GetResponseMessage(true, "设置成功", typeof(bool), false, true);
            }
            else
                throw new Exception("设置失败");
        }

        /// <summary>
        /// 根据组织Id获取组织所有管理员
        /// </summary>
        /// <param name="orgId">组织主键</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetOrgManager(int orgId)
        {
            return JsonHelper.GetResponseMessage(true, "", typeof(OrgManagerDTO), true, OrgService.GetOrgManagerById(orgId));
        }

        /// <summary>
        /// 移除组织（组织根节点或者组织子节点为空时）
        /// </summary>
        /// <param name="orgId">组织主键</param>
        /// <param name="loginId">登录用户主键</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage RemoveOrg(int orgId,int loginId)
        {
            if (OrgService.RemoveOrg(orgId,loginId))
            {
                return JsonHelper.GetResponseMessage(true, "删除成功", typeof(bool), false, true);
            }
            else
                throw new Exception("删除失败");
        }

        #endregion
    }
}