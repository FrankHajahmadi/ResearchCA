using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities
{
    public partial class LabResult
    {
        public int LabResultId { get; set; }
        public int SubjectId { get; set; }
        [Display(Name = "White Blood Cell Count")]
        public double? WhiteBloodCellCount { get; set; }
        [Display(Name = "Red Blood Cell Count")]
        public double? RedBloodCellCount { get; set; }
        public double? Hemoglobin { get; set; }
        public double? Hematocrit { get; set; }
        [Display(Name = "Platelet Count")]
        public double? PlateletCount { get; set; }
        [Display(Name = "Blood Urea Nitrogen")]
        public double? BloodUreaNitrogen { get; set; }
        public double? Creatinine { get; set; }
        [Display(Name = "Thyroid Simulationg Hormone")]
        public double? ThyroidSimulatingHormone { get; set; }
        [Display(Name = "Exame Date")]
        [DataType(DataType.Date)]
        public DateTime ExamDate { get; set; }

        public virtual Subject Subject { get; set; }
    }
}
