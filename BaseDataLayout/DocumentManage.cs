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
    
    public partial class DocumentManage
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DocumentManage()
        {
            this.Project_Document1 = new HashSet<DocumentManage>();
            this.DocumentContents = new HashSet<DocumentContent>();
            this.DocLocalScopes = new HashSet<DocLocation>();
            this.DiscussAttaches = new HashSet<DiscussAttach>();
            this.DocTypes = new HashSet<DocType>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public string Catalog { get; set; }
        public string Content { get; set; }
        public string URL { get; set; }
        public string Handler { get; set; }
        public int DocManageStateID { get; set; }
        public Nullable<int> DocumentTypeID { get; set; }
        public string HandeTime { get; set; }
        public Nullable<int> EventTimeEventTimeID { get; set; }
        public int DocCheckStateID { get; set; }
        public Nullable<int> SecurityinfoID { get; set; }
        public Nullable<int> ParentVer { get; set; }
    
        public virtual DocManageState DocProcessType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DocumentManage> Project_Document1 { get; set; }
        public virtual DocumentManage Project_Document2 { get; set; }
        public virtual DocCheckState DocHanderState { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DocumentContent> DocumentContents { get; set; }
        public virtual Securityinfo Securityinfo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DocLocation> DocLocalScopes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DiscussAttach> DiscussAttaches { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DocType> DocTypes { get; set; }
    }
}
