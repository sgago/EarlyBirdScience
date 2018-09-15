using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EarlyBirdScience.Models
{
    public class DateModel
    {
        [Key]
        [ScaffoldColumn(false)]
        public int DateId { get; set; }

        [DisplayName("Creation Date")]
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }

        [DisplayName("Modified Date")]
        [DataType(DataType.Date)]
        public DateTime ModifiedDate { get; set; }
    }
}
