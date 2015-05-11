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
        { }
    }
}
