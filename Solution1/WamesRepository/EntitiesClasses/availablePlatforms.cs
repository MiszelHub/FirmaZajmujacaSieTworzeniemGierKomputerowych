namespace WamesRepository
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class availablePlatforms
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public availablePlatforms()
        {
            games = new HashSet<games>();
        }

        [Key]
        [StringLength(3)]
        public string platformId { get; set; }

        [StringLength(20)]
        public string platformName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<games> games { get; set; }
    }

    public partial class availablePlatforms
    {
        public override string ToString()
        {
            return platformId+"  "+ platformName;
        }
    }
}
