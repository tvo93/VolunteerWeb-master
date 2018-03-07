using System;
using System.ComponentModel.DataAnnotations;

namespace VolunteerSystem.ViewModels
{
    public class EnrollmentDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime? EnrollmentDate { get; set; }

        public int VolunteerCount { get; set; }
    }
}