using System;
using WebApiEf.DbOperations;
using WebApiEf.Entities;

namespace WebApiEf.UnitTests.TestSetup
{
    public static class Authors
    {
        public static void AddAuthors(this BookStoreDbContext context)
        {
            context.Author.AddRange(
                    new Author
                    {
                        Name = "Doğan Ali",
                        SurName = "Yeniacun",
                        Birthday = new DateTime(1997,01,07)
                    },
                    new Author
                    {
                        Name = "Veli",
                        SurName = "Baş",
                        Birthday = new DateTime(2001,03,05)
                    },
                    new Author
                    {
                        Name = "Melih",
                        SurName = "Şen",
                        Birthday = new DateTime(1976,06,01)
                    }

                );
        }
    }
}