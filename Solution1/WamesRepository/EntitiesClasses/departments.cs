namespace WamesRepository
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class departments
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public departments()
        {
            employees = new HashSet<employees>();
        }

        [Key]
        public int department_id { get; set; }

        [StringLength(20)]
        public string department_name { get; set; }

        public int max_employees { get; set; }

        public int headquarters_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<employees> employees { get; set; }

        public virtual headquarters headquarters { get; set; }
    }
}
