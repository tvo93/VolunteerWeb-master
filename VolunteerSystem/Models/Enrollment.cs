using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VolunteerSystem.Models
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }

        // foreign key
        public int JobID { get; set; }
        public int VolunteerID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EnrollmentDate { get; set; }
        public virtual Job Job { get; set; }

        // add job status for volunteer
       
        // public String Status { get; set; }
        public virtual Volunteer Volunteer { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }

    }
}