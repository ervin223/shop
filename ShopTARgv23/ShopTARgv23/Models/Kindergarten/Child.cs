using System;
using System.ComponentModel.DataAnnotations;

namespace KindergartenManager.Models.Kindergarten
{
    public class Child
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Nimi")]
        public string ChildName { get; set; }

        [Required(ErrorMessage = "Sünnipäev")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Rühm")]
        public string GroupName { get; set; }

        [Required(ErrorMessage = "Õpetaja nimi")]
        public string TeacherName { get; set; }

        public string ParentContactInfo { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime ModifiedAt { get; set; } = DateTime.Now;
    }
}
