using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;


namespace Code_First
{
    public class Class : IClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClassID { get; set; }
        public string ClassName { get; set; }

        public void CreateClass(DBConnector context)
        {

            Console.Write("Enter class name: ");
            string? classname = Console.ReadLine();

            var subject = new Class
            {
                ClassName = classname,
            };

            context.Subjects.Add(subject);
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

        public void UpdateClass(DBConnector context)
        {
            Console.Write("Enter class ID to update: ");
            string? input = Console.ReadLine();
            int id = int.Parse(input);

            var Subject = context.Subjects.Find(id);

            if (Subject != null)
            {
                Console.Write("Enter class name: ");
                Subject.ClassName = Console.ReadLine();

                context.SaveChanges();
                Console.WriteLine("Class updated.");
            }
            else
            {
                Console.WriteLine("Class not found.");
            }
        }

        public void DeleteClass(DBConnector context)
        {
            Console.Write("Enter class ID to delete: ");
            string? input = Console.ReadLine();
            int id = int.Parse(input);

            var Subject = context.Subjects.Find(id);

            if (Subject != null)
            {
                context.Subjects.Remove(Subject);
                context.SaveChanges();
                Console.WriteLine("Class deleted.");
            }
            else
            {
                Console.WriteLine("Class not found.");
            }
        }
    }

}
