using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_First
{
    public class Student : Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentID { get; set; }
        public int AverageMark { get; set; }

        public void CreateStudent(DBConnector context)
        {
            bool integer = false;
            int averagemark = 0;

            Console.Write("Enter Average Mark: ");
            averagemark = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Name");
            string? name = Console.ReadLine();
            Console.WriteLine("Enter phone number");
            string? phoneNumber = Console.ReadLine();
            Console.WriteLine("Enter email");
            string? emailAddress = Console.ReadLine();


            var student = new Student
            {
                AverageMark = averagemark,
                Name = name,
                PhoneNumber = phoneNumber,
                EmailAddress = emailAddress
            };

            context.Students.Add(student);
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.WriteLine("Student created.");
        }

        public void UpdateStuden(DBConnector context)
        {
            Console.Write("Enter student ID to update: ");
            string? input = Console.ReadLine();
            int id = int.Parse(input);

            var student = context.Students.Find(id);

            if (student != null)
            {
                Console.Write("Enter new name: ");
                student.Name = Console.ReadLine();
                Console.Write("Enter new phone number: ");
                student.PhoneNumber = Console.ReadLine();
                Console.Write("Enter new email: ");
                student.EmailAddress = Console.ReadLine();
                Console.Write("Enter new Average Mark: ");
                string? num = Console.ReadLine();
                student.AverageMark = int.Parse(num);


                context.SaveChanges();
                Console.WriteLine("Student updated.");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        public void DeleteStudent(DBConnector context)
        {
            Console.Write("Enter student ID to delete: ");
            string? input = Console.ReadLine();
            int id = int.Parse(input);

            var student = context.Students.Find(id);

            if (student != null)
            {
                context.Students.Remove(student);
                context.SaveChanges();
                Console.WriteLine("Student deleted.");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }
    }
}
