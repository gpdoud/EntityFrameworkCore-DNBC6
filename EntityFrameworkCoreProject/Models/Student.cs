using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityFrameworkCoreProject.Models {

    public class Student {

        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Firstname { get; set; }
        [StringLength(30)]
        [Required]
        public string Lastname { get; set; }
        public int SAT { get; set; }
        public double GPA { get; set; }
        public bool IsFulltime { get; set; } = true;

        public int? MajorId { get; set; }
        public virtual Major Major { get; set; }

        public override string ToString() {
            var major = this.Major == null ? "Undeclared" : this.Major.Description;
            return $"Id[{this.Id}], Name[{this.Firstname} {this.Lastname}], Major[{major}]";
        }
        public Student() {

        }
    }
}
