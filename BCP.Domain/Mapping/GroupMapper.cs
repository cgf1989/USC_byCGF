using BCP.Domain.Edmx;
using BCP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.Domain
{
    public static class GroupMapper
    {
        public static IEnumerable<GroupDTO> ConvertToGroupDTO(this IEnumerable<Group> groups)
        {
            List<GroupDTO> list = new List<GroupDTO>();
            if (groups != null && groups.Count() > 0)
            {
                foreach (var node in groups)
                {
                    list.Add(node.ConvertToGroupDTO());
                }
            }
            return list;
        }

        public static GroupDTO ConvertToGroupDTO(this Group group)
        {
            if (group == null) return null;
            GroupDTO dto = group.MapperTo<Group, GroupDTO>();
            if (group.GroupMembers != null && group.GroupMembers.Count > 0)
            {
                dto.Members = group.GroupMembers.ConvertToGroupMemberDTO().ToList();
            }
            return dto;
        }

        public static IEnumerable<GroupMemberDTO> ConvertToGroupMemberDTO(this IEnumerable<GroupMember> groupMembers)
        {
            List<GroupMemberDTO> list = new List<GroupMemberDTO>();
            if (groupMembers != null && groupMembers.Count() > 0)
            {
                foreach (var node in groupMembers)
                {
                    list.Add(node.ConvertToGroupMemberDTO());
                }
            }
            return list;
        }

        public static GroupMemberDTO ConvertToGroupMemberDTO(this GroupMember groupMember)
        {
            if (groupMember == null) return null;
            var dto = groupMember.MapperTo<GroupMember, GroupMemberDTO>();
            if (groupMember.Group != null)
            {
                dto.GroupName = groupMember.Group.Name;
            }
            return dto;
        }
    }
}
