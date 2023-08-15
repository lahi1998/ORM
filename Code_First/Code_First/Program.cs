//using Microsoft.EntityFrameworkCore;
//using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
//using System.Collections.Generic;

//namespace Code_First
//{
//    public class Worker
//    {
//        public int Id { get; set; }
//        public string Name { get; set; }
//        public string Address { get; set; }
//        public int Age { get; set; }
//        public string Gender { get; set; }
//    }

//    public class Manager : Worker
//    {
//        public string Title { get; set; }
//    }

//    class Program
//    {
//        static void Main(string[] args)
//        {
//            using (var context = new DBConnector())
//            {
//                int choice;
//                do
//                {
//                    Console.WriteLine("1. Show Tables");
//                    Console.WriteLine("2. Create Worker");
//                    Console.WriteLine("3. Create Manager");
//                    Console.WriteLine("4. Update Worker");
//                    Console.WriteLine("5. Delete Worker");
//                    Console.WriteLine("6. Exit");
//                    Console.Write("Enter your choice: ");
//                    int.TryParse(Console.ReadLine(), out choice);

//                    switch (choice)
//                    {
//                        case 1:
//                            ShowTables(context);
//                            break;
//                        case 2:
//                            CreateWorker(context);
//                            break;
//                        case 3:
//                            CreateManager(context);
//                            break;
//                        case 4:
//                            UpdateWorker(context);
//                            break;
//                        case 5:
//                            DeleteWorker(context);
//                            break;
//                    }
//                } while (choice != 6);
//            }
//        }

//        static void ShowTables(DBConnector context)
//        {
//            Console.WriteLine("Workers:");
//            foreach (var worker in context.Workers)
//            {
//                Console.WriteLine($"{worker.Id}, {worker.Name}, {worker.Address}, {worker.Age}, {worker.Gender}");
//            }

//            Console.WriteLine("Managers:");
//            foreach (var manager in context.Managers)
//            {
//                Console.WriteLine($"{manager.Id}, {manager.Name}, {manager.Address}, {manager.Age}, {manager.Gender}, {manager.Title}");
//            }
//        }

//        static void CreateWorker(DBConnector context)
//        {
//            Console.Write("Enter name: ");
//            string name = Console.ReadLine();
//            Console.Write("Enter address: ");
//            string address = Console.ReadLine();
//            Console.Write("Enter age: ");
//            int.TryParse(Console.ReadLine(), out int age);
//            Console.Write("Enter gender: ");
//            string gender = Console.ReadLine();

//            var worker = new Worker
//            {
//                Name = name,
//                Address = address,
//                Age = age,
//                Gender = gender
//            };

//            context.Workers.Add(worker);
//            try
//            {
//                context.SaveChanges();
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.ToString());
//            }
//            Console.WriteLine("Worker created.");
//        }

//        static void CreateManager(DBConnector context)
//        {
//            Console.Write("Enter name: ");
//            string name = Console.ReadLine();
//            Console.Write("Enter address: ");
//            string address = Console.ReadLine();
//            Console.Write("Enter age: ");
//            int.TryParse(Console.ReadLine(), out int age);
//            Console.Write("Enter gender: ");
//            string gender = Console.ReadLine();
//            Console.Write("Enter title: ");
//            string title = Console.ReadLine();

//            var manager = new Manager
//            {
//                Name = name,
//                Address = address,
//                Age = age,
//                Gender = gender,
//                Title = title
//            };

//            context.Managers.Add(manager);
//            context.SaveChanges();
//            Console.WriteLine("Manager created.");
//        }

//        static void UpdateWorker(DBConnector context)
//        {
//            Console.Write("Enter worker ID to update: ");
//            int.TryParse(Console.ReadLine(), out int id);
//            var worker = context.Workers.Find(id);

//            if (worker != null)
//            {
//                Console.Write("Enter new name: ");
//                worker.Name = Console.ReadLine();
//                Console.Write("Enter new address: ");
//                worker.Address = Console.ReadLine();
//                Console.Write("Enter new age: ");
//                int.TryParse(Console.ReadLine(), out int age);
//                worker.Age = age;
//                Console.Write("Enter new gender: ");
//                worker.Gender = Console.ReadLine();

//                context.SaveChanges();
//                Console.WriteLine("Worker updated.");
//            }
//            else
//            {
//                Console.WriteLine("Worker not found.");
//            }
//        }

//        static void DeleteWorker(DBConnector context)
//        {
//            Console.Write("Enter worker ID to delete: ");
//            int.TryParse(Console.ReadLine(), out int id);
//            var worker = context.Workers.Find(id);

//            if (worker != null)
//            {
//                context.Workers.Remove(worker);
//                context.SaveChanges();
//                Console.WriteLine("Worker deleted.");
//            }
//            else
//            {
//                Console.WriteLine("Worker not found.");
//            }
//        }
//    }
//}