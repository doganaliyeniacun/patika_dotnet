using LinqPractices.DbOperations;
using LinqPractices.Entities;

DataGenerator.Initialize();
LinqDbContext _context = new LinqDbContext();

//Find
//db de pk ya göre id aratması yapar
Console.WriteLine("**** Find ****");
var student = _context.Students.Find(1);

//FirstOrDefault
//ilk bulduğunu getirir veri yoksa default veri döner. örn : null
Console.WriteLine("**** FirstOrDefault ****");
student = _context.Students.FirstOrDefault(x=> x.Name == "Ali");
Console.WriteLine(student.Name);

//SingleOrDefault
//birden fazla aynı veri varsa bulduğunu getirir veri yoksa default veri döner. örn : null
Console.WriteLine("**** SingleOrDefault ****");
student = _context.Students.SingleOrDefault(x=> x.Name == "Ali");
Console.WriteLine(student.Name);

//ToList
//veriyi listeye dönüştürmeye yarar
Console.WriteLine("**** ToList ****");
var studentList = _context.Students.Where(x => x.ClassId == 2).ToList();
Console.WriteLine(studentList.Count);

//OrderBy
//gelen veriyi a-z olarak sıralar
Console.WriteLine("**** OrderBy ****");
studentList = _context.Students.OrderBy(x=> x.StudentId).ToList();
foreach (var item in studentList)
{
    Console.WriteLine(item.StudentId + " - " + item.Name + " " + item.SurName);
}

//OrderByDescending
//gelen veriyi z-a olarak sıralar
Console.WriteLine("**** OrderByDescending ****");
studentList = _context.Students.OrderByDescending(x=> x.StudentId).ToList();
foreach (var item in studentList)
{
    Console.WriteLine(item.StudentId + " - " + item.Name + " " + item.SurName);
}

//Anonymous Object Result
Console.WriteLine("**** Anonymous Object Result ****");
var anonymousObject = _context.Students
                    .Where(x => x.ClassId == 2)
                    .Select(x => new 
                    {
                        Id = x.StudentId,
                        FullName = x.Name + " " + x.SurName
                    });

foreach (var item in anonymousObject)
{
    Console.WriteLine(item.Id + " - " + item.FullName);
}

