using System;
using System.ComponentModel.DataAnnotations;

namespace DemoEfCoreKhanhPhong.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Age { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public Boolean Sex { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}