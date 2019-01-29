// using Microsoft.AspNetCore.Mvc; modified
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities
{
    public partial class Subject
    {
        public Subject()
        {
            Address = new HashSet<Address>();
            Ethnicity = new HashSet<Ethnicity>();
            LabResult = new HashSet<LabResult>();
            Phone = new HashSet<Phone>();
        }

        public int SubjectId { get; set; }
        
        [Required(ErrorMessage = "Social Security Number is required.")]
        // [RegularExpression(@"^\d{3}-\d{2}-\d{4}$", ErrorMessage = "Please enter a valid Social Security Number.")]
        [RegularExpression(@"^\d{9}$", ErrorMessage = "Please enter a valid Social Security Number.")]
        public string Ssn { get; set; }
        [Required(ErrorMessage = "Last Name is required."), StringLength(50, ErrorMessage = "Last Name cannot exceed 50 characters.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "First Name is required."), StringLength(50, ErrorMessage = "First Name cannot exceed 50 characters.")]
        public string FirstName { get; set; }
        [StringLength(1, ErrorMessage = "Middle Initial cannot exceed 1 character.")]
        public string MiddleInitial { get; set; }
        public DateTime? DateOfBirth { get; set; }
        [Required]
        public string Gender { get; set; }
        [StringLength(50, ErrorMessage = "Occupation cannot exceed 50 characters.")]
        public string Occupation { get; set; }

        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<Ethnicity> Ethnicity { get; set; }
        public virtual ICollection<LabResult> LabResult { get; set; }
        public virtual ICollection<Phone> Phone { get; set; }
    }
}
