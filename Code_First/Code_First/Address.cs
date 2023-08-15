using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Code_First
{
    public class Address : ICity, ICountry
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddressID { get; set; }

        public int CountryID { get; set; }
        public string CountryName { get; set; }

        public int CityID { get; set; }
        public string CityName { get; set; }
        public int PostalCode { get; set; }

        public string Street { get; set; }

        public void CreateAddress(DBConnector context)
        {
            bool integer = false;
            int postalcode = 0;

            Console.Write("Enter Country name: ");
            string? countryname = Console.ReadLine();

            Console.Write("Enter City name: ");
            string? cityname = Console.ReadLine();

            Console.Write("Enter street: ");
            string? street = Console.ReadLine();

            Console.Write("Enter postal code: ");
            postalcode = Convert.ToInt32(Console.ReadLine());





            var address = new Address
            {
                CountryName = countryname,
                CityName = cityname,
                Street = street,
                PostalCode = postalcode
            };

            context.Addresses.Add(address);
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.WriteLine("Address created.");
        }

        public void UpdateAddress(DBConnector context)
        {
            Console.Write("Enter address ID to update: ");
            string? input = Console.ReadLine();
            int id = int.Parse(input);

            var address = context.Addresses.Find(id);

            if (address != null)
            {
                Console.Write("Enter new name: ");
                address.CountryName = Console.ReadLine();
                Console.Write("Enter new phone number: ");
                address.CityName = Console.ReadLine();
                Console.Write("Enter new email: ");
                address.Street = Console.ReadLine();
                Console.Write("Enter new Average Mark: ");
                string? num = Console.ReadLine();
                address.PostalCode = int.Parse(num);


                context.SaveChanges();
                Console.WriteLine("Address updated.");
            }
            else
            {
                Console.WriteLine("Address not found.");
            }
        }

        public void DeleteAddress(DBConnector context)
        {
            Console.Write("Enter address ID to delete: ");
            string? input = Console.ReadLine();
            int id = int.Parse(input);

            var address = context.Addresses.Find(id);

            if (address != null)
            {
                context.Addresses.Remove(address);
                context.SaveChanges();
                Console.WriteLine("Address deleted.");
            }
            else
            {
                Console.WriteLine("Address not found.");
            }
        }
    }
}

