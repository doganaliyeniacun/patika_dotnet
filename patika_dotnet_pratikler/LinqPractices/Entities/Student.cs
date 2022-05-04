using System.ComponentModel.DataAnnotations;

namespace LinqPractices.Entities
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string? Name { get; set; }

        public string? SurName { get; set; }

        public int ClassId { get; set; }
    }
}