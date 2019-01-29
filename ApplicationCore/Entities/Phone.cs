using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities
{
    public partial class Phone
    {
        public int PhoneId { get; set; }
        public int PhoneTypeId { get; set; }
        public int SubjectId { get; set; }
        [Required (ErrorMessage = "Phone number is reuired.")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Please enter a valid phone number.")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        public string Extention { get; set; }

        public virtual PhoneType PhoneType { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
