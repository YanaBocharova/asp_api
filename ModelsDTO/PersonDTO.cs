using System.ComponentModel.DataAnnotations;
using System;

namespace Commander.ModelsDTO
{
    public class PersonDTO
    {
        public int Id { get; set; }

          [Required]
        [MaxLength(50)]
        public string Firstname { get; set; }

          [Required]
        [MaxLength(50)]
        public string Lastname { get; set; }
    }
}