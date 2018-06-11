namespace assignment1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class company
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public company()
        {
            cameras = new HashSet<camera>();
        }

        public int companyID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(150)]
        public string Address { get; set; }

        [StringLength(400)]
        public string Logo { get; set; }

        public int? Phone { get; set; }

        [Required]
        [StringLength(100)]
        public string CEO { get; set; }

        [Display(Name = "Number of Employees")]
        public int numEmployees { get; set; }

        [Required]
        [StringLength(4)]
        [Display(Name = "Stock Name")]
        public string stockName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<camera> cameras { get; set; }
    }
}
