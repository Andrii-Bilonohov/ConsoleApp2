﻿using ConsoleApp1.Entities;
using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new AppDbContext();

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

            var students = context.Students.ToList();
            foreach (var student in students)
            {
                Console.WriteLine(student.Name);
            }
            context.Remove(students[0]);

            students = context.Students.ToList();
            foreach (var student in students)
            {
                Console.WriteLine(student.Name);
            }
        }
    }
}

