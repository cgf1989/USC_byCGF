using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// PostRequire DTO
    /// </summary>
    public partial class PostRequireDTO
    {
        public System.Int32 ID { get; set; }
        public System.String Name { get; set; }
        public System.Int32 SpecializedID { get; set; }
        public System.String Description { get; set; }
        public System.String Ranks { get; set; }
        public System.String EducationRequirement { get; set; }
        public System.String SkillRequirement { get; set; }
        public System.String State { get; set; }
        public System.Int64 EventTime { get; set; }
    }
}

