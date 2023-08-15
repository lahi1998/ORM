using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System.Collections.Generic;


namespace Code_First
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new DBConnector())
            {
                int exit = 0;
                do
                {
                    Console.Clear();
                    Console.WriteLine("1. Show Tables");
                    Console.WriteLine("2. Class");
                    Console.WriteLine("3. Address");
                    Console.WriteLine("4. Student");
                    Console.WriteLine("5. Professor");
                    Console.WriteLine("6. Exit");
                    Console.WriteLine("Press your choice: ");
                    var input = Console.ReadKey();

                    switch (input.Key)
                    {
                        case ConsoleKey.D1:
                        case ConsoleKey.NumPad1:
                            Console.Clear();
                            ShowTables(context);
                            Console.ReadKey();
                            break;
                        case ConsoleKey.D2:
                        case ConsoleKey.NumPad2:
                            Console.Clear();
                            ClassUi(context);
                            Console.ReadKey();
                            break;
                        case ConsoleKey.D3:
                        case ConsoleKey.NumPad3:
                            Console.Clear();
                            AddressUi(context);
                            Console.ReadKey();
                            break;
                        case ConsoleKey.D4:
                        case ConsoleKey.NumPad4:
                            Console.Clear();
                            StudentUi(context);
                            Console.ReadKey();
                            break;
                        case ConsoleKey.D5:
                        case ConsoleKey.NumPad5:
                            ProfessorUi(context);
                            break;
                        case ConsoleKey.D6:
                        case ConsoleKey.NumPad6:
                            exit = 6;
                            break;
                    }
                } while (exit != 6);
            }
        }

        static void ClassUi(DBConnector context)
        {
            Console.WriteLine("1. Create");
            Console.WriteLine("2. Update");
            Console.WriteLine("3. Delete");
            Console.Write("Press your choice: ");
            var input = Console.ReadKey();
            Class @class = new Class();

            Console.Clear();
            switch (input.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    @class.CreateClass(context);
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    @class.UpdateClass(context);
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    @class.DeleteClass(context);
                    break;
            }
        }

        static void AddressUi(DBConnector context)
        {
            Console.WriteLine("1. Create");
            Console.WriteLine("2. Update");
            Console.WriteLine("3. Delete");
            Console.Write("Press your choice: ");
            var input = Console.ReadKey();
            Address @address = new Address();

            Console.Clear();
            switch (input.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    @address.CreateAddress(context);
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    @address.UpdateAddress(context);
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    @address.DeleteAddress(context);
                    break;
            }
        }

        static void StudentUi(DBConnector context)
        {
            Console.WriteLine("1. Create");
            Console.WriteLine("2. Update");
            Console.WriteLine("3. Delete");
            Console.Write("Press your choice: ");
            var input = Console.ReadKey();
            Student @student = new Student();

            Console.Clear();
            switch (input.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    @student.CreateStudent(context);
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    @student.UpdateStuden(context);
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    @student.DeleteStudent(context);
                    break;
            }
        }

        static void ProfessorUi(DBConnector context)
        {
            Console.WriteLine("1. Create");
            Console.WriteLine("2. Update");
            Console.WriteLine("3. Delete");
            Console.Write("Press your choice: ");
            var input = Console.ReadKey();
            Professor @professor = new Professor();

            Console.Clear();
            switch (input.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    @professor.CreateProfessor(context);
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    @professor.UpdateProfessor(context);
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    @professor.DeleteProfessor(context);
                    break;
            }
        }

        static void ShowTables(DBConnector context)
        {
            Console.WriteLine("Class's");
            foreach (var Subject in context.Subjects)
            {
                Console.WriteLine($"{Subject.ClassID}, {Subject.ClassName}");
            }
            Console.WriteLine();
            Console.WriteLine("Addresses");
            foreach (var Address in context.Addresses)
            {
                Console.WriteLine($"{Address.AddressID}, {Address.CountryID}, {Address.CountryName}, {Address.CityID}, {Address.CityName}, {Address.PostalCode}, {Address.Street}");
            }
            Console.WriteLine();
            Console.WriteLine("Students");
            foreach (var student in context.Students)
            {
                Console.WriteLine($"{student.StudentID}, {student.AverageMark}");
            }
            Console.WriteLine();
            Console.WriteLine("Addresses");
            foreach (var Professor in context.Professors)
            {
                Console.WriteLine($"{Professor.ProfessorID}, {Professor.Salery}");
            }
        }

    }
}
