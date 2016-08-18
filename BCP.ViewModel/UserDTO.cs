using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    public partial class UserDTO
    {
        public String  ContextId { get; set; }
        public List<GroupDTO> Groups { get; set; }
    }
}
