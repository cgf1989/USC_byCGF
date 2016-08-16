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
        public static IEnumerable<CustomerGoupDTO> ConvertToCustomerGroupDTO(this IEnumerable<CustomerGoup> customergoups)
        {
            List<CustomerGoupDTO> list=new List<CustomerGoupDTO>();
            if (customergoups == null || customergoups.Count() <= 0) return list;
            foreach (var node in customergoups)
            {
                list.Add(node.ConvertToCustomerGroupDTO());
            }
            return list;
        }

        /// <summary>
        /// return null or CustomerGoupDTO
        /// </summary>
        /// <param name="customergoup"></param>
        /// <returns></returns>
        public static CustomerGoupDTO ConvertToCustomerGroupDTO(this CustomerGoup customergoup)
        {
            if (customergoup == null) return null;
            CustomerGoupDTO dto = customergoup.MapperTo<CustomerGoup, CustomerGoupDTO>();
            if (customergoup.Members != null && customergoup.Members.Count > 0)
            {
                dto.Members = customergoup.Members.MapperTo<User, UserDTO>().ToList();
            }
            return dto;
        }
    }
}
