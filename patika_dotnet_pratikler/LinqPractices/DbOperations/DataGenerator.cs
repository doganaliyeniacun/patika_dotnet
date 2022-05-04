using LinqPractices.Entities;

namespace LinqPractices.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize()
        {
            using(var context = new LinqDbContext())
            {
                if (context.Students.Any())
                    return;

                context.Students.AddRange(
                    new Student()
                    {
                        Name = "Ali",
                        SurName = "Yeniacun",
                        ClassId = 1                        
                    },
                    new Student()
                    {
                        Name = "Selenay",
                        SurName = "Yeniacun",
                        ClassId = 1                        
                    },
                    new Student()
                    {
                        Name = "Merve",
                        SurName = "Çalışkan",
                        ClassId = 2                        
                    },
                    new Student()
                    {
                        Name = "Umut",
                        SurName = "Arda",
                        ClassId = 2                        
                    }

                    
                );
                
                context.SaveChanges();
            }
        }
    }
}