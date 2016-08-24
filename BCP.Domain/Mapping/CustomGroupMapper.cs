using BCP.Domain.Edmx;
using BCP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.Domain
{
    public static  class CustomerGroupMapper
    {
        public static IEnumerable<CustomGroupDTO> ConvertToCustomGroupDTO(this IEnumerable<CustomGroup> customgroups,ICustomGroupUserRepository customGroupUserRepository)
        {
            List<CustomGroupDTO> list=new List<CustomGroupDTO>();
            if (customgroups == null || customgroups.Count() <= 0) return list;
            foreach (var node in customgroups)
            {
                list.Add(node.ConvertToCustomGroupDTO(customGroupUserRepository));
            }
            return list;
        }

        /// <summary>
        /// return null or CustomerGoupDTO
        /// </summary>
        /// <param name="customgroup"></param>
        /// <returns></returns>
        public static CustomGroupDTO ConvertToCustomGroupDTO(this CustomGroup customgroup, ICustomGroupUserRepository customGroupUserRepository)
        {
            if (customgroup == null) return null;
            CustomGroupDTO dto = customgroup.MapperTo<CustomGroup, CustomGroupDTO>();
            if (customgroup.CustomGroupUsers != null && customGroupUserRepository != null)
            {
                var users = customGroupUserRepository.GetAllWithNavigationalProperty("User").Where(it => it.GroupId == customgroup.Id).Select(it => it.User)
                    .MapperTo<User, UserDTO>();
                dto.Members = users.ToList();
            }
            return dto;
        }
    }
}
