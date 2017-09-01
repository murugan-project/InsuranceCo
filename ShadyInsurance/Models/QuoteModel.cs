using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ShadyInsurance.Models
{
    [MetadataType(typeof(Quote.Metadata))]

    public partial class Quote
    {
        sealed class Metadata
        {
            [Key]
            public System.Guid Id { get; set; }

            [Required(ErrorMessage ="Required Field")]
            [Range(16, 100, ErrorMessage = "Age must be beween 16 and 100")]
            public Nullable<int> Age { get; set; }

            [Required(ErrorMessage = "Required Field")]
            [RegularExpression(@"\d{5}$", ErrorMessage ="Invalid zip code")]
            public Nullable<int> ZipCode { get; set; }

            [Required(ErrorMessage = "Required Field")]
            [Range(0, 100000, ErrorMessage = "Out of range: 0 to 100,000")]
            public Nullable<int> AnnualMilage { get; set; }

            [Required(ErrorMessage = "Required Field")]
            public string Make { get; set; }

            [Required(ErrorMessage = "Required Field")]
            public string Model { get; set; }

            [Required(ErrorMessage = "Required Field")]
            public string Year { get; set; }
        }
    }
}