namespace VolunteerSystem.Migrations
{
    using VolunteerSystem.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<VolunteerSystem.DAL.CompanyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(VolunteerSystem.DAL.CompanyContext context)
        {
            var volunteers = new List<Volunteer>
            {
                new Volunteer { FirstMidName = "Carson",   LastName = "Alexander",BirthDate =DateTime.Parse("1986-08-01").Date,
                    PhoneNumber = "206-754-3311", Email = "Alexander@gmail.com"},
                new Volunteer { FirstMidName = "Meredith", LastName = "Alonso", BirthDate =DateTime.Parse("1985-07-01").Date,
                    PhoneNumber = "206-754-3311",Email = "Alexander@gmail.com" },
                new Volunteer { FirstMidName = "Arturo",   LastName = "Anand", BirthDate =DateTime.Parse("1965-06-12").Date,
                 PhoneNumber = "206-754-3311",Email = "Alonso@gmail.com"},
                new Volunteer { FirstMidName = "Gytis",    LastName = "Barzdukas", BirthDate =DateTime.Parse("1955-11-15").Date,
                    PhoneNumber = "206-754-3311",Email = "Barzdukas@gmail.com"},
                new Volunteer { FirstMidName = "Yan",      LastName = "Li", BirthDate =DateTime.Parse("1991-08-01").Date,
                   PhoneNumber = "206-754-3311",Email = "Li@gmail.com"},
                new Volunteer { FirstMidName = "Peggy",    LastName = "Justice", BirthDate =DateTime.Parse("1990-06-01").Date,
                    PhoneNumber = "206-754-3311",Email = "Justice@gmail.com"},
                new Volunteer { FirstMidName = "Laura",    LastName = "Norman", BirthDate =DateTime.Parse("1955-08-05").Date,
                  PhoneNumber = "206-754-3311",Email = "Norman@gmail.com"},
                new Volunteer { FirstMidName = "Nino",     LastName = "Olivetto", BirthDate =DateTime.Parse("1993-08-01").Date,
                   PhoneNumber = "206-754-3311",Email = "Olivetto@gmail.com"}
            };
            volunteers.ForEach(s => context.Volunteers.AddOrUpdate(p => p.LastName, s));
            context.SaveChanges();

            var jobs = new List<Job>
            {
                new Job {JobID = 1050, Title = "Administration", Description = "Manage the system" },
                new Job {JobID = 4022, Title = "Food deliveries", Description = "Delivery food to the clients who are not able to come to the food bank"},
                new Job {JobID = 4041, Title = "Phone bank", Description = "Contact manager for more information"},
                new Job {JobID = 1045, Title = "Food pickup", Description = "Pick up food from donation stores" },
                new Job {JobID = 3141, Title = "Fundraising/grant writing", Description = "Help on bringing money to into the organization" },
                new Job {JobID = 2021, Title = "Newsletter production", Description="Update newsletter on social media such as Facebook, Twitter and our website"},
                new Job {JobID = 2042, Title = "Volunteer coordination" , Description="Help to manage our volunteer system"}
            };
            jobs.ForEach(s => context.Jobs.AddOrUpdate(p => p.Title, s));
            context.SaveChanges();

            var enrollments = new List<Enrollment>
            {
                new Enrollment {
                    VolunteerID = volunteers.Single(s => s.LastName == "Alexander").VolunteerID,
                    JobID = jobs.Single(c => c.Title == "Administration" ).JobID,
                   EnrollmentDate = DateTime.Parse("2010-09-01").Date,
                },
                 new Enrollment {
                    VolunteerID = volunteers.Single(s => s.LastName == "Alexander").VolunteerID,
                    JobID = jobs.Single(c => c.Title == "Food deliveries" ).JobID,
                EnrollmentDate = DateTime.Parse("2012-09-01").Date,
                 },
                 new Enrollment {
                    VolunteerID = volunteers.Single(s => s.LastName == "Alexander").VolunteerID,
                    JobID = jobs.Single(c => c.Title == "Phone bank" ).JobID,
                       EnrollmentDate = DateTime.Parse("2013-09-01").Date,
                 },
                 new Enrollment {
                     VolunteerID = volunteers.Single(s => s.LastName == "Alonso").VolunteerID,
                    JobID = jobs.Single(c => c.Title == "Food pickup" ).JobID,
                     EnrollmentDate = DateTime.Parse("2012-09-01").Date,
                 },
                 new Enrollment {
                     VolunteerID = volunteers.Single(s => s.LastName == "Alonso").VolunteerID,
                    JobID = jobs.Single(c => c.Title == "Fundraising/grant writing" ).JobID,
                    EnrollmentDate = DateTime.Parse("2012-09-01").Date,
                 },
                 new Enrollment {
                    VolunteerID = volunteers.Single(s => s.LastName == "Alonso").VolunteerID,
                    JobID = jobs.Single(c => c.Title == "Volunteer coordination" ).JobID,
                   EnrollmentDate = DateTime.Parse("2011-09-01").Date,
                 },
                 new Enrollment {
                    VolunteerID = volunteers.Single(s => s.LastName == "Anand").VolunteerID,
                    JobID = jobs.Single(c => c.Title == "Newsletter production" ).JobID
                 },
                 new Enrollment {
                    VolunteerID = volunteers.Single(s => s.LastName == "Anand").VolunteerID,
                    JobID = jobs.Single(c => c.Title == "Volunteer coordination").JobID,
                 },
                new Enrollment {
                    VolunteerID = volunteers.Single(s => s.LastName == "Barzdukas").VolunteerID,
                    JobID = jobs.Single(c => c.Title == "Volunteer coordination").JobID,
                       EnrollmentDate = DateTime.Parse("2013-09-01").Date,
                 },
                 new Enrollment {
                    VolunteerID = volunteers.Single(s => s.LastName == "Li").VolunteerID,
                    JobID = jobs.Single(c => c.Title == "Food pickup").JobID,
                  
                 },
                 new Enrollment {
                    VolunteerID = volunteers.Single(s => s.LastName == "Justice").VolunteerID,
                    JobID = jobs.Single(c => c.Title == "Food pickup").JobID,
                     EnrollmentDate = DateTime.Parse("2005-08-11").Date,
                 }
            };

            foreach (Enrollment e in enrollments)
            {
                var enrollmentInDataBase = context.Enrollments.Where(
                    s =>
                         s.Volunteer.VolunteerID == e.VolunteerID &&
                         s.Job.JobID == e.JobID).SingleOrDefault();
                if (enrollmentInDataBase == null)
                {
                    context.Enrollments.Add(e);
                }
            }
            context.SaveChanges();

            var events = new List<Event>
            {
                new Event {EventID = 100,    
                    EventName = "Eloise's Cooking Pot",
                    Date = DateTime.Parse("2018-02-01").Date,
                },
                 new Event {EventID = 101,   
                    EventName = "Eloise's Cooking Pot",
                    Date = DateTime.Parse("2018-02-28").Date,
                },
                      new Event {EventID = 102,
                    EventName = "Food Prepare",
                    Date = DateTime.Parse("2018-03-05").Date,
                },
                 new Event {EventID = 103,
                    EventName = "Food Delivery",
                    Date = DateTime.Parse("2018-02-26").Date,
                },
                      new Event {EventID = 104,
                    EventName = "Eloise's Cooking Pot",
                    Date = DateTime.Parse("2018-02-01").Date,
                },
                 new Event {EventID = 105,
                    EventName = "Food Delivery",
                    Date = DateTime.Parse("2018-02-28").Date,
                },
                      new Event {EventID = 106,
                    EventName = "Eloise's Cooking Pot",
                    Date = DateTime.Parse("2018-06-03").Date,
                },
                 new Event {EventID = 107,
                    EventName = "Food Delivery",
                    Date = DateTime.Parse("2018-06-03").Date,
                },

            };
            events.ForEach(s => context.Events.AddOrUpdate(p => p.EventID, s));

            context.SaveChanges();

        }

    }
}
