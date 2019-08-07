using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityFrameworkCoreProject.Models {

    public class Course {

        public int Id { get; set; }
        [StringLength(50)]
        [Required]
        public string Name { get; set; }
        [StringLength(50)]
        public string Instructor { get; set; }
        public int Credits { get; set; } = 3;

        public int? MajorId { get; set; }
        public virtual Major Major { get; set; }

        public Course() {

        }
    }
}
