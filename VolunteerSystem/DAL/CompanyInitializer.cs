using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using VolunteerSystem.Models;

namespace VolunteerSystem.DAL
{
    public class CompanyInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<CompanyContext>
    {
        protected override void Seed(CompanyContext context)
        {
            var volunteers = new List<Volunteer>
            {
            new Volunteer{FirstMidName="Carson",LastName="Alexander"},
            new Volunteer{FirstMidName="Meredith",LastName="Alonso"},
            new Volunteer{FirstMidName="Arturo",LastName="Anand"},
            new Volunteer{FirstMidName="Gytis",LastName="Barzdukas"},
            new Volunteer{FirstMidName="Yan",LastName="Li"},
            new Volunteer{FirstMidName="Peggy",LastName="Justice"},
            new Volunteer{FirstMidName="Laura",LastName="Norman"},
            new Volunteer{FirstMidName="Nino",LastName="Olivetto"}
            };

            volunteers.ForEach(s => context.Volunteers.Add(s));
            context.SaveChanges();
            var jobs = new List<Job>
            {
            new Job{JobID=1050,Title="Administration"},
            new Job{JobID=4022,Title="Food deliveries"},
            new Job{JobID=4041,Title="Food pickup"},
            new Job{JobID=1045,Title="Phone bank"},
            new Job{JobID=3141,Title="Fundraising/grant writing"},
            new Job{JobID=2021,Title="Newsletter production"},
            new Job{JobID=2042,Title="Volunteer coordination"}
            };
            jobs.ForEach(s => context.Jobs.Add(s));
            context.SaveChanges();

            var enrollments = new List<Enrollment>
            {
            new Enrollment{VolunteerID=1,JobID=1050},
            new Enrollment{VolunteerID=1,JobID=4022},
            new Enrollment{VolunteerID=1,JobID=4041},
            new Enrollment{VolunteerID=2,JobID=1045},
            new Enrollment{VolunteerID=2,JobID=3141},
            new Enrollment{VolunteerID=2,JobID=2021},
            new Enrollment{VolunteerID=3,JobID=1050},
            new Enrollment{VolunteerID=4,JobID=1050,},
            new Enrollment{VolunteerID=4,JobID=4022},
            new Enrollment{VolunteerID=5,JobID=4041},
            new Enrollment{VolunteerID=6,JobID=1045},
            new Enrollment{VolunteerID=7,JobID=3141},
            };
            enrollments.ForEach(s => context.Enrollments.Add(s));
            context.SaveChanges();
        }
    }
}