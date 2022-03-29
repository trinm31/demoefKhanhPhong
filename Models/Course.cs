using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoEfCoreKhanhPhong.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        [Required] 
        public string Name { get; set; }
        [Required] 
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}