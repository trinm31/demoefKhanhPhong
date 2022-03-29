using System.Collections.Generic;
using DemoEfCoreKhanhPhong.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DemoEfCoreKhanhPhong.ViewModels
{
    public class CourseVM
    {
        public Course Course { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }
    }
}