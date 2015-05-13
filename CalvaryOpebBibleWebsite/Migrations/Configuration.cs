namespace CalvaryOpebBibleWebsite.Migrations
{
    using CalvaryOpebBibleWebsite.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CalvaryOpebBibleWebsite.DAL.CalvaryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CalvaryOpebBibleWebsite.DAL.CalvaryContext context)
        {
            var events = new List<Event>
            {
                new Event{EventID=1, EventType="Hooplah", EventCoordinator="Bob Sasslefras", EventLocation="Calvary Open Bible", EventMinistry="High School", EventName="Sunday Funday",EventDescription="A Lovely Church Event", StartDate=DateTime.Parse("2015-05-01"),EndDate=DateTime.Parse("2015-05-01")},
                new Event{EventID=2, EventType="rawr", EventCoordinator="Bob Sasslefras", EventLocation="Calvary Open Bible", EventMinistry="High School", EventName="Sunday Funday",EventDescription="A Lovely Church Event", StartDate=DateTime.Parse("2015-05-05"),EndDate=DateTime.Parse("2015-05-05")},
                new Event{EventID=3, EventType="Hooplah", EventCoordinator="Frank Sinatra", EventLocation="Lane Fair Grounds", EventMinistry="High School", EventName="Sunday Funday",EventDescription="A Lovely Church Event", StartDate=DateTime.Parse("2015-05-07"),EndDate=DateTime.Parse("2015-05-07")},
                new Event{EventID=4, EventType="umm", EventCoordinator="Bob Sasslefras", EventLocation="Calvary Open Bible", EventMinistry="High School", EventName="Sunday Funday",EventDescription="A Lovely Church Event", StartDate=DateTime.Parse("2015-05-11"),EndDate=DateTime.Parse("2015-05-11")},
                new Event{EventID=5, EventType="heh", EventCoordinator="Frank Sinatra", EventLocation="Calvary Open Bible", EventMinistry="College", EventName="Sunday Funday",EventDescription="A Lovely Church Event", StartDate=DateTime.Parse("2015-05-15"),EndDate=DateTime.Parse("2015-05-15")},
                new Event{EventID=6, EventType="Hooplah", EventCoordinator="Frank Sinatra", EventLocation="Calvary Open Bible", EventMinistry="College", EventName="Sunday Funday",EventDescription="A Lovely Church Event", StartDate=DateTime.Parse("2015-05-17"),EndDate=DateTime.Parse("2015-05-17")},
                new Event{EventID=7, EventType="yup", EventCoordinator="Bob Sasslefras", EventLocation="Calvary Open Bible", EventMinistry="College", EventName="Sunday Funday",EventDescription="A Lovely Church Event", StartDate=DateTime.Parse("2015-05-21"),EndDate=DateTime.Parse("2015-05-21")},
                new Event{EventID=8, EventType="Hooplah", EventCoordinator="Frank Sinatra", EventLocation="Calvary Open Bible", EventMinistry="College", EventName="Sunday Funday",EventDescription="A Lovely Church Event", StartDate=DateTime.Parse("2015-05-24"),EndDate=DateTime.Parse("2015-05-24")},
                new Event{EventID=9, EventType="pewpew", EventCoordinator="Bob Sasslefras", EventLocation="Calvary Open Bible", EventMinistry="College", EventName="Sunday Funday", EventDescription="A Lovely Church Event",StartDate=DateTime.Parse("2015-06-01"),EndDate=DateTime.Parse("2015-06-01")},
                new Event{EventID=10, EventType="Sunday Funday", EventCoordinator="Bob Sasslefras", EventLocation="Calvary Open Bible", EventMinistry="Community Groups", EventName="Pew Pew",EventDescription="A Lovely Church Event", StartDate=DateTime.Parse("2015-06-17"),EndDate=DateTime.Parse("2015-06-17")},
                new Event{EventID=11, EventType="pewpew", EventCoordinator="Bob Sasslefras", EventLocation="Calvary Open Bible", EventMinistry="Adults", EventName="Sunday Funday", EventDescription="A Lovely Church Event",StartDate=DateTime.Parse("2015-06-18"),EndDate=DateTime.Parse("2015-06-18")},
                new Event{EventID=12, EventType="pewpew", EventCoordinator="Bob Sasslefras", EventLocation="Calvary Open Bible", EventMinistry="Seniors", EventName="Sunday Funday", EventDescription="A Lovely Church Event",StartDate=DateTime.Parse("2015-06-26"),EndDate=DateTime.Parse("2015-06-26")},
                new Event{EventID=13, EventType="pewpew", EventCoordinator="Bob Sasslefras", EventLocation="Calvary Open Bible", EventMinistry="Sunday Church", EventName="Sunday Funday",EventDescription="A Lovely Church Event", StartDate=DateTime.Parse("2015-07-16"),EndDate=DateTime.Parse("2015-07-16")},
                new Event{EventID=14, EventType="pewpew", EventCoordinator="Bob Sasslefras", EventLocation="Calvary Open Bible", EventMinistry="Children", EventName="Sunday Funday",EventDescription="A Lovely Church Event", StartDate=DateTime.Parse("2015-07-29"),EndDate=DateTime.Parse("2015-07-29")},
                new Event{EventID=15, EventType="Hooplah", EventCoordinator="Frank Sinatra", EventLocation="Calvary Open Bible", EventMinistry="Children", EventName="Sunday Funday",EventDescription="A Lovely Church Event", StartDate=DateTime.Parse("2015-08-01"),EndDate=DateTime.Parse("2015-08-01")}
            };
            events.ForEach(s => context.Event.Add(s));
            context.SaveChanges();
        }
    }
}
