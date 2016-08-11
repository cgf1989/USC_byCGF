using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    /// <summary>
    /// Position DTO
    /// </summary>
    public partial class PositionDTO
    {
        public System.Int32 ID { get; set; }
        public System.String Title { get; set; }
        public System.Boolean IsValid { get; set; }
        public System.String PositionType { get; set; }
        public System.String PositionTile { get; set; }
        public System.String TaskNature { get; set; }
        public System.String WorkLocation { get; set; }
        public System.String SolaryStandard { get; set; }
        public Int32? PositionID { get; set; }
        public System.Int32 OrganizationID { get; set; }
        public System.Boolean IsAdministrator { get; set; }
        public Int32? PostRequireID { get; set; }
        public System.String PositionLevel { get; set; }
        public System.Int64 EventTime { get; set; }
    }
}
