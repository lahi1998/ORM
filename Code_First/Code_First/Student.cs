using System;
using System.Collections.Generic;
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
        private int StudentID { get; set; }
        private int AverageMark { get; set; }

        public void CreateClass(DBConnector context)
        {
            bool integer = false;
            int averagemark = 0;

            {

                Console.Write("Enter Average Mark: ");
                string? input = Console.ReadLine();
                // verify that the input is a int
                try
                {
                    averagemark = int.Parse(input);
                    integer = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                    Thread.Sleep(1500);
                    Console.Clear();
                }

            } while (integer == false) ;

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
            Console.WriteLine("Class created.");
        }

        public void UpdateWorker(DBConnector context)
        {
            Console.Write("Enter Professor ID to update: ");
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
                Console.WriteLine("professors updated.");
            }
            else
            {
                Console.WriteLine("professors not found.");
            }
        }

        public void DeleteWorker(DBConnector context)
        {
            Console.Write("Enter Professor ID to delete: ");
            string? input = Console.ReadLine();
            int id = int.Parse(input);

            var student = context.Students.Find(id);

            if (student != null)
            {
                context.Students.Remove(student);
                context.SaveChanges();
                Console.WriteLine("Worker deleted.");
            }
            else
            {
                Console.WriteLine("Worker not found.");
            }
        }
    }
}
