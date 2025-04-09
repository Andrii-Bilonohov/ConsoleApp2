using ConsoleApp1.DAL;
using ConsoleApp1.Entities;
using ConsoleApp1.Services;
using System;
using System.ComponentModel.Design;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var context = new AppDbContext();
            //var service = new StudentService();

            //var student = new Student
            //{
            //    Name = "Andrii",
            //    Description = "Test",
            //};

            //context.Students.Add(student);
            //context.SaveChanges();

            //var students = new List<Student>()
            //{
            //    new Student
            //    {
            //        Name = "Vlad",
            //        Description = "Test",
            //    },
            //    new Student
            //    {
            //        Name = "Max",
            //        Description = "Test",
            //    },
            //    new Student
            //    {
            //        Name = "Ivan",
            //        Description = "Test",
            //    }

            //};

            //context.Students.AddRange(students);
            //context.SaveChanges();


            //var students = rep.GetAll.ToList();
            //foreach (var student in students)
            //{
            //    Console.WriteLine(student.Name);
            //}
            //context.Remove(students[0]);

            //students = context.Students.ToList();
            //foreach (var student in students)
            //{
            //    Console.WriteLine(student.Name);
            //}
            var start = new MenuService();
            
            while (true)
            {
                start.Menu();
            }

        }
    }
}

