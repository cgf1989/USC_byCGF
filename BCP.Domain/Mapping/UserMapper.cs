using BCP.Domain.Edmx;
using BCP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.Domain
{
    public static class UserMapper
    {
        public static IEnumerable<UserDTO> ConvertToUserDTO(this IEnumerable<User> users)
        {
            List<UserDTO> list = new List<UserDTO>();
            if (users != null && users.Count() > 0)
            {
                foreach (var node in users)
                {
                    list.Add(node.ConvertToUserDTO());
                }
            }
            return list;
        }

        public static UserDTO ConvertToUserDTO(this User user)
        {
            if (user == null) return null;
            var dto = user.MapperTo<User, UserDTO>();
            if (user.GroupNames != null) dto.Groups = user.GroupNames.ConvertToGroupDTO().ToList();
            return dto;
        }
    }
}
