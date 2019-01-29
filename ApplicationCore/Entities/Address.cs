using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities
{
    public partial class Address
    {
        public int AddressId { get; set; }
        public int SubjectId { get; set; }
        [Required(ErrorMessage = "Street is required.")]
        public string Street { get; set; }
        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }
        [Required(ErrorMessage = "State is required.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please enter a valid state.")]
        public string State { get; set; }
        [Required(ErrorMessage = "ZIP code is required")]
        [RegularExpression(@"^\d{5}(?:[-\s]\d{4})?$", ErrorMessage = "Please enter a valid ZIP Code.")]
        public string Zip { get; set; }

        public virtual Subject Subject { get; set; }
    }
}
