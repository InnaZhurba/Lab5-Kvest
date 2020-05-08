namespace DAL_Kvest.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using DAL_Kvest.Entities;
    using DAL_Kvest.EF;

    internal sealed class Configuration : DbMigrationsConfiguration<BDContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BDContext context)
        {
            var age = new List<AgeCategory>
            {
                new AgeCategory{min = 5, max = 9,},
                new AgeCategory{min = 10, max = 15,},
                new AgeCategory{min = 16, max = 17,},
                new AgeCategory{min = 18, max = 25,},
                new AgeCategory{min = 26, max = 35,},
                new AgeCategory{min = 36, max = 45,},
                new AgeCategory{min = 46, max = 55,}
            };
            age.ForEach(s => context.AgeCategories.AddOrUpdate(s));
            context.SaveChanges();

            var val = new List<UsersValue>
            {
                new UsersValue{min = 2, max = 7,},
                new UsersValue{min = 4, max = 17,},
                new UsersValue{min = 3, max = 10,},
                new UsersValue{min = 10, max = 18,},
                new UsersValue{min = 16, max = 26,}
            };
            val.ForEach(s => context.UsersValues.AddOrUpdate(s));
            context.SaveChanges();

            var time = new List<TimeCategory>
            {
                new TimeCategory{data = DateTime.Parse("2020-06-03 12:00:00.000"),},
                new TimeCategory{data = DateTime.Parse("2020-06-03 13:00:00.000"),},
                new TimeCategory{data = DateTime.Parse("2020-06-03 14:00:00.000"),},
                new TimeCategory{data = DateTime.Parse("2020-06-03 15:00:00.000"),},
                new TimeCategory{data = DateTime.Parse("2020-06-03 16:00:00.000"),},
                new TimeCategory{data = DateTime.Parse("2020-06-03 17:00:00.000"),},
                new TimeCategory{data = DateTime.Parse("2020-06-04 12:00:00.000"),},
                new TimeCategory{data = DateTime.Parse("2020-06-04 13:00:00.000"),},
                new TimeCategory{data = DateTime.Parse("2020-06-04 14:00:00.000"),},
                new TimeCategory{data = DateTime.Parse("2020-06-04 15:00:00.000"),},
                new TimeCategory{data = DateTime.Parse("2020-06-04 16:00:00.000"),},
                new TimeCategory{data = DateTime.Parse("2020-06-04 17:00:00.000"),}
            };
            time.ForEach(s => context.TimeCategories.AddOrUpdate(s));
            context.SaveChanges();


        }
    }
}
