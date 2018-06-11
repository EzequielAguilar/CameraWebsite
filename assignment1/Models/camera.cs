namespace assignment1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class camera
    {
        public int companyID { get; set; }

        public int cameraID { get; set; }

        [Required]
        [StringLength(50)]
        public string Model { get; set; }

        public int Megapixels { get; set; }

        [Column(TypeName = "money")]
        [Display(Name = "Price")]
        public decimal? cameraPrice { get; set; }

        [StringLength(400)]
        public string image { get; set; }

        public virtual company company { get; set; }
    }
}
