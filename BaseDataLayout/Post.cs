//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace BaseDataLayout
{
    using System;
    using System.Collections.Generic;
    
    public partial class Post
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Post()
        {
            this.Posts = new HashSet<Post>();
            this.Authorizations = new HashSet<Authorization>();
            this.Authorizations1 = new HashSet<Authorization>();
            this.DocReaders = new HashSet<DocReader>();
            this.DocSenders = new HashSet<DocSender>();
            this.JobChanges = new HashSet<JobChange>();
        }
    
        public int ID { get; set; }
        public string PostName { get; set; }
        public int DepartmentID { get; set; }
        public string Descript { get; set; }
        public string MarkerString { get; set; }
        public bool IsValid { get; set; }
        public string Jobname { get; set; }
        public int PositionID { get; set; }
        public Nullable<int> PostID { get; set; }
        public int OrganizationID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Post> Posts { get; set; }
        public virtual Post Post1 { get; set; }
        public virtual Organization Organization { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Authorization> Authorizations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Authorization> Authorizations1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DocReader> DocReaders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DocSender> DocSenders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JobChange> JobChanges { get; set; }
    }
}
