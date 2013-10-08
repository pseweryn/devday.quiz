using DevDay.Quiz.Models;

namespace DevDay.Quiz.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<QuizContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(QuizContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Sessions.AddOrUpdate(
                s => s.Speaker,
                new Session
                {
                    Speaker = "Jon Skeet",
                    Title = "Back to basics: the mess we've made of our fundamental data types",
                    Track = 0,
                    Date = new DateTime(2013, 9, 20, 9, 20, 0)
                },
                new Session
                {
                    Speaker = "Patrick Kua",
                    Title = "Implementing Continuous Delivery",
                    Track = 1,
                    Date = new DateTime(2013, 9, 20, 10, 40, 0)
                },
                new Session
                {
                    Speaker = "Dariusz Dziuk",
                    Title = "Scaling agile",
                    Track = 2,
                    Date = new DateTime(2013, 9, 20, 10, 40, 0)
                },
                new Session
                {
                    Speaker = "Andreas Håkansson",
                    Title = "Guerilla Framework Design",
                    Track = 1,
                    Date = new DateTime(2013, 9, 20, 11, 50, 0)
                },
                new Session
                {
                    Speaker = "Tiberiu Covaci",
                    Title = "SPA Made Breezy",
                    Track = 2,
                    Date = new DateTime(2013, 9, 20, 11, 50, 0)
                },
                new Session
                {
                    Speaker = "Hadi Hariri",
                    Title = "Moving the Web to the client",
                    Track = 1,
                    Date = new DateTime(2013, 9, 20, 13, 50, 0)
                },
                new Session
                {
                    Speaker = "Ben Hall",
                    Title = "Building Startups and Minimum Viable Products",
                    Track = 2,
                    Date = new DateTime(2013, 9, 20, 13, 50, 0)
                },
                new Session
                {
                    Speaker = "Itamar Syn-Hershko",
                    Title = "Full-text search with Lucene and neat things you can do with it",
                    Track = 1,
                    Date = new DateTime(2013, 9, 20, 15, 50, 0)
                },
                new Session
                {
                    Speaker = "Paul Stack",
                    Title = "Windows - Having its ass kicked by Puppet and PowerShell since 2012",
                    Track = 2,
                    Date = new DateTime(2013, 9, 20, 15, 50, 0)
                },
                new Session
                {
                    Speaker = "Marco Cecconi",
                    Title = "The Architecture of StackOverflow",
                    Track = 1,
                    Date = new DateTime(2013, 9, 20, 16, 10, 0)
                },
                new Session
                {
                    Speaker = "Dino Esposito",
                    Title = "Mobile is over: Start Planning Multi-Device Web sites Today",
                    Track = 2,
                    Date = new DateTime(2013, 9, 20, 16, 10, 0)
                },
                new Session
                {
                    Speaker = "Rob Ashton",
                    Title = "The software journeyman's guide to being homeless and jobless.",
                    Track = 0,
                    Date = new DateTime(2013, 9, 20, 17, 30, 0)
                }
                );
        }
    }
}
