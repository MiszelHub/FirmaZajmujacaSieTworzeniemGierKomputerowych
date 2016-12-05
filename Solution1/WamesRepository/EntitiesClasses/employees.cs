namespace WamesRepository
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class employees
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int employee_id { get; set; }

        [StringLength(20)]
        public string first_name { get; set; }

        [Required]
        [StringLength(25)]
        public string last_name { get; set; }

        [StringLength(25)]
        public string email { get; set; }

        [Column(TypeName = "money")]
        public decimal? salary { get; set; }

        public int department_id { get; set; }

        public int position_id { get; set; }

        public int team_id { get; set; }

        public virtual departments departments { get; set; }

        public virtual positions positions { get; set; }

        public virtual Team Team { get; set; }
    }
}
