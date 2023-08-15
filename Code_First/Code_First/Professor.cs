using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Xml.Linq;


namespace Code_First
{


    public class Professor : Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProfessorID { get; set; }
        public int Salery { get; set; }

        public void CreateClass(DBConnector context)
        {
            bool integer = false;
            int salery = 0;

            {

                Console.Write("Enter Salery: ");
                string input = Console.ReadLine();
                // verify that the input is a int
                try
                {
                    salery = int.Parse(input);
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
            Console.WriteLine("Enter Name");
            string? phoneNumber = Console.ReadLine();
            Console.WriteLine("Enter Name");
            string? emailAddress = Console.ReadLine();


            var professor = new Professor
            {
                Salery = salery,
                Name = name,
                PhoneNumber = phoneNumber,
                EmailAddress = emailAddress
            };

            context.Professors.Add(professor);
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.WriteLine("Professor created.");
        }

        public void UpdateWorker(DBConnector context)
        {
            Console.Write("Enter Professor ID to update: ");
            string input = Console.ReadLine();
            int id = int.Parse(input);

            var professor = context.Professors.Find(id);

            if (professor != null)
            {
                Console.Write("Enter new name: ");
                professor.Name = Console.ReadLine();
                Console.Write("Enter new phone number: ");
                professor.PhoneNumber = Console.ReadLine();
                Console.Write("Enter new email: ");
                professor.EmailAddress = Console.ReadLine();
                Console.Write("Enter new salery: ");
                string? num = Console.ReadLine();
                professor.Salery = int.Parse(num);


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
            string input = Console.ReadLine();
            int id = int.Parse(input);

            var Professor = context.Professors.Find(id);

            if (Professor != null)
            {
                context.Professors.Remove(Professor);
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

