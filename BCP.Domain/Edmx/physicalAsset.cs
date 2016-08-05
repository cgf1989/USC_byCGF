//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace BCP.Domain.Edmx
{
    using System;
    using System.Collections.Generic;
    
    public partial class physicalAsset
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public physicalAsset()
        {
            this.AssetUses = new HashSet<AssetUse>();
            this.AssetMaintenances = new HashSet<AssetMaintenance>();
            this.OrganizationAssetTypes = new HashSet<OrganizationAssetType>();
        }
    
        public int Id { get; set; }
        public int OrganizationID { get; set; }
        public int ProductId { get; set; }
        public string PlaceOfBuy { get; set; }
        public string BuyTime { get; set; }
        public Nullable<int> Supplier { get; set; }
        public string Validity { get; set; }
        public string State { get; set; }
        public decimal Value { get; set; }
        public Nullable<System.DateTimeOffset> MaintenancePeriod { get; set; }
        public long EventTime { get; set; }
    
        public virtual Organization Organization { get; set; }
        public virtual Product Product { get; set; }
        public virtual Organization Organization1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AssetUse> AssetUses { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AssetMaintenance> AssetMaintenances { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrganizationAssetType> OrganizationAssetTypes { get; set; }
    }
}
