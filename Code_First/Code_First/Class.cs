using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


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

            Console.Write("Enter Class name: ");
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
    }

}
