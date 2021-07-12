using System;
using System.ComponentModel.DataAnnotations;

namespace Commander.Models
{
    public class Person
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Firstname { get; set; }

        [Required]
        [MaxLength(50)]
        public string Lastname { get; set; }
        public void Copy(Person from){
            
            this.Firstname=from.Firstname;
            this.Lastname=from.Lastname;
        }
    }
}