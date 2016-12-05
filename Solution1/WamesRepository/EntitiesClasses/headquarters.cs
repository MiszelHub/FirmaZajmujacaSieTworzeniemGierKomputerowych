namespace WamesRepository
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class headquarters
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public headquarters()
        {
            departments = new HashSet<departments>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int headquarters_id { get; set; }

        [StringLength(20)]
        public string headquarters_name { get; set; }

        [StringLength(20)]
        public string city { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<departments> departments { get; set; }
    }
}
