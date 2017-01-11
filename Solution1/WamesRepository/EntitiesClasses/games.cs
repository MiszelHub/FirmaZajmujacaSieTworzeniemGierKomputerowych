namespace WamesRepository
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class games
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public games()
        {
            availablePlatforms = new HashSet<availablePlatforms>();
        }

        public int id { get; set; }

        [StringLength(20)]
        public string title { get; set; }

        [Column(TypeName = "money")]
        public decimal price { get; set; }

        public int genre_id { get; set; }

        public int team_id { get; set; }

        public virtual genre genre { get; set; }

        public virtual Team Team { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<availablePlatforms> availablePlatforms { get; set; }
    }
}
